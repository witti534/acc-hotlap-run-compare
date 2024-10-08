using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace acc_hotrun_run_compare.DBClasses
{
    internal class RunImportAndExport
    {
        //List of the xml field names 
        static readonly string XML_XMLSCHEME_KEY = "xmlScheme";
        static readonly string XML_RUN_KEY = "run";
        static readonly string XML_SECTORLIST_KEY = "SectorList";
        static readonly string XML_FASTESTLAP_KEY = "FastestLap";
        static readonly string XML_TRACKNAME_KEY = "TrackName";
        static readonly string XML_CARNAME_KEY = "CarName";
        static readonly string XML_DRIVENTIME_KEY = "DrivenTime";
        static readonly string XML_SESSIONTIME_KEY = "SessionTime";
        static readonly string XML_PENALTYOCCURED_KEY = "PenaltyOccured";
        static readonly string XML_RUNCREATEDTIME_KEY = "RunCreatedDateTime";
        static readonly string XML_RUNDESCRIPTION_KEY = "RunDescription";
        static readonly string XML_SECTOR_KEY = "sector";
        static readonly string XML_LAPNUMBER_KEY = "lapNumber";
        static readonly string XML_SECTORINDEX_KEY = "sectorIndex";
        static readonly string XML_DRIVERNAME_KEY = "driverName";

        //Retrieve and store run information in the StoredRunContext
        private static StoredRunContext? StoredRunContext = null;

        /// <summary>
        /// This is the function to export a single file. The output scheme might change over time, version number implies changes in this scheme. 
        /// </summary>
        /// <param name="runID">The runID as an int</param>
        /// <param name="saveLocation">The saveLocation (folder) on the disk where the run will be exported to</param>
        public static void ExportSingleRun(int runID, string saveLocation)
        {
            StoredRunContext ??= StoredRunContext.GetInstance(); // Get StoredRunContext singleton if not assigned yet

            RunInformation runInstance = StoredRunContext.RunInformationSet.Where(r => r.RunID == runID)
                .First(); //Get a single run from the data base where the supplied runID matches one from the data base
            
            runInstance.SectorList = StoredRunContext.SectorInformationSet.Where(r => r.RunID == runID).ToList();


            //Create the XElements which contain all the sector times
            XElement xSectors = new XElement(XML_SECTORLIST_KEY);
            foreach (SectorInformation sector in runInstance.SectorList)
            {
                xSectors.Add(new XElement(XML_SECTOR_KEY,
                    new XAttribute(XML_LAPNUMBER_KEY, sector.LapNumber),
                    new XAttribute(XML_SECTORINDEX_KEY, sector.SectorIndex),
                    sector.DrivenSectorTime
                    )
                );
            }

            //Create the unix timestap with UTC+0
            TimeZoneInfo localTimeZone = TimeZoneInfo.Local;
            DateTimeOffset dateTimeOffset = new DateTimeOffset(runInstance.RunCreatedDateTime, TimeZoneInfo.Local.GetUtcOffset(runInstance.RunCreatedDateTime));
            string unixTimeStampRunCreated = dateTimeOffset.ToUnixTimeSeconds().ToString();

            //Prepare the drivername string
            string driverNameString;
            if (runInstance.DriverName != null)
            {
                driverNameString = runInstance.DriverName;
            }
            else
            {
                driverNameString = "";
            }

            //Create the XDocument with all the data (except runID) from a RunInformation.
            //runID is not supposed to be in the export file because IDs are to be determined
            //by the local database itself when importing the run later.
            var xDocument = new XDocument(
                new XElement(XML_RUN_KEY,
                    new XElement(XML_XMLSCHEME_KEY, "version2"),
                    //xmlStructure might change over time
                    new XElement(XML_TRACKNAME_KEY, runInstance.TrackName),
                    new XElement(XML_CARNAME_KEY, runInstance.CarName),
                    new XElement(XML_DRIVENTIME_KEY, runInstance.DrivenTime),
                    new XElement(XML_FASTESTLAP_KEY, runInstance.FastestLap),
                    new XElement(XML_SESSIONTIME_KEY, runInstance.SessionTime),
                    xSectors, //XElement containing sectors
                    new XElement(XML_PENALTYOCCURED_KEY, runInstance.PenaltyOccured),
                    new XElement(XML_RUNCREATEDTIME_KEY, unixTimeStampRunCreated),
                    new XElement(XML_RUNDESCRIPTION_KEY, runInstance.RunDescription),
                    new XElement(XML_DRIVERNAME_KEY, driverNameString)
                )
            );

            DateTime dateTime = DateTime.Now;

            //
            String xmlSaveLocation = saveLocation + "\\" + DateTimeOffset.Now.ToUnixTimeSeconds() + "-" + runID + ".xml";

            xDocument.Save(xmlSaveLocation);
        }

        /// <summary>
        /// The entry function to import a single run. This function reads the xml file which contains a run and also the version of the xml scheme. 
        /// It then calls a function depending on the version of the xml scheme to generate a RunInformation + multiple SecterInformation to store that information.
        /// </summary>
        /// <param name="fileLocation">The location on the disk of the file to be loaded</param>
        public static void ImportSingleRun(String fileLocation)
        {
            XDocument xDocument = XDocument.Load(fileLocation);
            if (xDocument != null)
            {
                try
                {
                    XElement rootElement = xDocument.Element(XML_RUN_KEY);
                    XElement xmlScheme = rootElement.Element(XML_XMLSCHEME_KEY);
                    if (xmlScheme.Value == "version1")
                    {
                        InterpretXMLFileSchemev1(rootElement);
                    }
                    if (xmlScheme.Value == "version2")
                    {
                        InterpretXMLFileSchemev2(rootElement);
                    }
                    throw new Exception("Unknown document version. Please download the latest update.");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        /// <summary>
        /// This function tries to read the content of an root XML element and parse it into a RunInformation object. 
        /// Result will be saved into the EF database. 
        /// Version1 does not contain a driver name.
        /// </summary>
        /// <param name="rootXElement">The root element of the XML file to be parsed</param>
        private static void InterpretXMLFileSchemev1(XElement rootXElement)
        {
            StoredRunContext ??= StoredRunContext.GetInstance(); // Get StoredRunContext singleton if not assigned yet

            try
            {
                string trackName = rootXElement.Element(XML_TRACKNAME_KEY).Value;
                string carName = rootXElement.Element(XML_CARNAME_KEY).Value;
                int drivenTime = Int32.Parse(rootXElement.Element(XML_DRIVENTIME_KEY).Value);
                int fastestLap = Int32.Parse(rootXElement.Element(XML_FASTESTLAP_KEY).Value);
                int sessionTime = Int32.Parse(rootXElement.Element(XML_SESSIONTIME_KEY).Value);
                DateTimeOffset runCreatedAtOffset = DateTimeOffset.FromUnixTimeSeconds(Int64.Parse(rootXElement.Element(XML_RUNCREATEDTIME_KEY).Value));
                DateTime runCreatedAt = runCreatedAtOffset.LocalDateTime; //Save the time as local time
                
                bool penaltyOccured = Boolean.Parse(rootXElement.Element(XML_PENALTYOCCURED_KEY).Value);

                List<SectorInformation> sectorList = [];
                XElement xSectors = rootXElement.Element(XML_SECTORLIST_KEY);
                foreach (XElement xSector in xSectors.Nodes())
                {
                    int lapNumber = Int32.Parse(xSector.Attribute(XML_LAPNUMBER_KEY).Value);
                    int sectorIndex = Int32.Parse(xSector.Attribute(XML_SECTORINDEX_KEY).Value);
                    int sectorTime = Int32.Parse(xSector.Value);
                    SectorInformation sectorInformation = new(lapNumber, sectorIndex, sectorTime);
                    sectorList.Add(sectorInformation);
                    StoredRunContext.SectorInformationSet.Add(sectorInformation);
                }

                RunInformation newRun = new RunInformation(trackName, carName, drivenTime, fastestLap, sessionTime, penaltyOccured, runCreatedAt, sectorList);
                newRun.DriverName = "";
                
                StoredRunContext.RunInformationSet.Add(newRun);
                StoredRunContext.SaveChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
                MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// This function tries to read the content of an root XML element and parse it into a RunInformation object. 
        /// Result will be saved into the EF database. 
        /// Version2 contains a driver name.
        /// </summary>
        /// <param name="rootXElement">The root element of the XML file to be parsed</param>
        private static void InterpretXMLFileSchemev2(XElement rootXElement)
        {
            StoredRunContext ??= StoredRunContext.GetInstance(); // Get StoredRunContext singleton if not assigned yet

            try
            {
                string trackName = rootXElement.Element(XML_TRACKNAME_KEY).Value;
                string carName = rootXElement.Element(XML_CARNAME_KEY).Value;
                int drivenTime = Int32.Parse(rootXElement.Element(XML_DRIVENTIME_KEY).Value);
                int fastestLap = Int32.Parse(rootXElement.Element(XML_FASTESTLAP_KEY).Value);
                int sessionTime = Int32.Parse(rootXElement.Element(XML_SESSIONTIME_KEY).Value);
                DateTimeOffset runCreatedAtOffset = DateTimeOffset.FromUnixTimeSeconds(Int64.Parse(rootXElement.Element(XML_RUNCREATEDTIME_KEY).Value));
                DateTime runCreatedAt = runCreatedAtOffset.LocalDateTime; //Save the time as local time

                bool penaltyOccured = Boolean.Parse(rootXElement.Element(XML_PENALTYOCCURED_KEY).Value);
                string driverName = rootXElement.Element(XML_DRIVERNAME_KEY).Value.ToString();

                List<SectorInformation> sectorList = [];
                XElement xSectors = rootXElement.Element(XML_SECTORLIST_KEY);
                foreach (XElement xSector in xSectors.Nodes())
                {
                    int lapNumber = Int32.Parse(xSector.Attribute(XML_LAPNUMBER_KEY).Value);
                    int sectorIndex = Int32.Parse(xSector.Attribute(XML_SECTORINDEX_KEY).Value);
                    int sectorTime = Int32.Parse(xSector.Value);
                    SectorInformation sectorInformation = new(lapNumber, sectorIndex, sectorTime);
                    sectorList.Add(sectorInformation);
                    StoredRunContext.SectorInformationSet.Add(sectorInformation);
                }

                RunInformation newRun = new(trackName, carName, drivenTime, fastestLap, sessionTime, penaltyOccured, runCreatedAt, sectorList)
                {
                    DriverName = driverName
                };

                StoredRunContext.RunInformationSet.Add(newRun);
                StoredRunContext.SaveChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
                MessageBox.Show(e.Message);
            }
        }
    }
}
