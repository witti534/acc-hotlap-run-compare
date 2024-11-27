using acc_hotrun_run_compare.DBClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace acc_hotrun_run_compare
{
    /// <summary>
    /// Class which provides settings values. Also saves settings in the current configuration folder. 
    /// Singleton pattern applied. 
    /// </summary>
    class SettingsProvider
    {
        private static SettingsProvider instance = null;
        public string Username { get; private set; }
        public StoreRunsWithPenaltiesEnum CurrentRunStoreRunsWithPenalties { get; private set; }
        public CompareRunsAgainstCarsEnum CurrentRunCompareRunsAgainstCars { get; private set; }
        public CompareRunsAgainstDriversEnum CurrentRunCompareRunsAgainstDrivers { get; private set; }
        public bool CurrentRunCompareAgainstRunsWithPenalties { get; private set; }
        public string CompareRunsLastTrackName { get; private set; }
        public string CompareRunsLastCarName { get; private set; }
        public string CompareRunsLastSessionTime { get; private set; }
        public bool CompareRunsDisplayRunsWithPenalties { get; private set; }
        public bool CompareRunsDisplayRunsFromOtherDrivers { get; private set; }
        public string CompareRunsSelectedComparerName { get; private set; }


        private readonly string settingsFilePath = "settings.xml";
        private readonly XElement rootXElement;
        private readonly XDocument settingsDocument;
        private readonly StoredRunContext storedRunContext = StoredRunContext.GetInstance();

        private readonly static string XMLKeySettings = "settings";
        private readonly static string XMLKeyStoreRunsWithPenalties = "StoreRunsWithPenalties";
        private readonly static string XMLKeyCompareRunsAgainstCars = "CompareRunsAgainstCars";
        private readonly static string XMLKeyCompareRunsAgainstDrivers = "CompareRunsAgainstDrivers";
        private readonly static string XMLKeyUsername = "username";
        private readonly static string XMLKeyLastTrackName = "LastTrackName";
        private readonly static string XMLKeyLastCarName = "LastCarName";
        private readonly static string XMLKeyLastSessionTime = "LastSessionTime";
        private readonly static string XMLKeyDisplayRunsWithPenalties = "DisplayRunsWithPenalties";
        private readonly static string XMLKeyDisplayRunsFromOtherDrivers = "DisplayRunsFromOtherDrivers";
        private readonly static string XMLKeyComparerName = "ComparerName";
        private readonly static string XMLKeyCompareRunsAgainstPenalties = "CompareRunsAgainstPenalties";


        public enum StoreRunsWithPenaltiesEnum
        {
            STORE_RUNS_WITH_PENALTIES_ENABLED = 1,
            STORE_RUNS_WITH_PENALTIES_DISABLED = 2
        }

        public enum CompareRunsAgainstCarsEnum
        {
            COMPARE_RUNS_AGAINST_CURRENT_CAR = 1,
            COMPARE_RUNS_AGAINST_ALL_CARS = 2
        }

        public enum CompareRunsAgainstDriversEnum
        {
            COMPARE_RUNS_AGAINST_OWN_RUNS_ONLY = 2,
            COMPARE_RUNS_AGAINST_ALL_DRIVERS = 1
        }

        /// <summary>
        /// Constructor for SettingsProvider
        /// </summary>
        private SettingsProvider() 
        {
            if (File.Exists(settingsFilePath))
            {
                settingsDocument = XDocument.Load(settingsFilePath);
                rootXElement = settingsDocument.Element(XMLKeySettings);
                if (rootXElement == null)
                {
                    // Create a new settings element
                    rootXElement = new XElement(XMLKeySettings, 
                        new XElement(XMLKeyStoreRunsWithPenalties, 1),
                        new XElement(XMLKeyCompareRunsAgainstCars, 1),
                        new XElement(XMLKeyCompareRunsAgainstDrivers, 1),
                        new XElement(XMLKeyCompareRunsAgainstPenalties, false),
                        new XElement(XMLKeyUsername, "You"),
                        new XElement(XMLKeyLastTrackName, "-"),
                        new XElement(XMLKeyLastCarName, "-"),
                        new XElement(XMLKeyLastSessionTime, "0"),
                        new XElement(XMLKeyDisplayRunsWithPenalties, false),
                        new XElement(XMLKeyDisplayRunsFromOtherDrivers, true),
                        new XElement(XMLKeyComparerName, FormStrings.SortByTotalTimeShortestFirst)
                    );
                }
                else
                {
                    // Read existing settings

                    //StoreRunsWithPenalties
                    XElement storeRunsWithPenaltiesXElement = rootXElement.Element(XMLKeyStoreRunsWithPenalties);
                    if (storeRunsWithPenaltiesXElement == null)
                    {
                        //Couldn't find child XElement for StoreRunsWithPenalties, create a new one
                        storeRunsWithPenaltiesXElement = new XElement(XMLKeyStoreRunsWithPenalties, 1);
                        rootXElement.Add(storeRunsWithPenaltiesXElement);
                    } 
                    else
                    {
                        string XElementValue = storeRunsWithPenaltiesXElement.Value;
                        bool readSuccessful = Int32.TryParse(XElementValue, out int storeRunsWithPenaltiesValue);
                        if (readSuccessful)
                        {
                            CurrentRunStoreRunsWithPenalties = (StoreRunsWithPenaltiesEnum)storeRunsWithPenaltiesValue; //read value
                        }
                        else
                        {
                            CurrentRunStoreRunsWithPenalties = StoreRunsWithPenaltiesEnum.STORE_RUNS_WITH_PENALTIES_ENABLED; //default value
                        }
                    }

                    //CompareRunsAgainstCars
                    XElement compareRunsAgainstCarsXElement = rootXElement.Element(XMLKeyCompareRunsAgainstCars);
                    if (compareRunsAgainstCarsXElement == null)
                    {
                        //Couldn't find child XElement for CompareRunsAgainstCars, create a new one
                        compareRunsAgainstCarsXElement = new XElement(XMLKeyCompareRunsAgainstCars, 1);
                        CurrentRunCompareRunsAgainstCars = CompareRunsAgainstCarsEnum.COMPARE_RUNS_AGAINST_CURRENT_CAR;
                        rootXElement.Add(compareRunsAgainstCarsXElement);
                    }
                    else
                    {
                        string XElementValue = compareRunsAgainstCarsXElement.Value;
                        bool readSuccessful = Int32.TryParse(XElementValue, out int compareRunsAgainstCarsValue);
                        if (readSuccessful)
                        {
                            CurrentRunCompareRunsAgainstCars = (CompareRunsAgainstCarsEnum)compareRunsAgainstCarsValue; //read value
                        }
                        else
                        {
                            CurrentRunCompareRunsAgainstCars = CompareRunsAgainstCarsEnum.COMPARE_RUNS_AGAINST_CURRENT_CAR; //default value
                        }
                    }

                    //CompareRunsAgainstPenalites
                    XElement compareRunsAgainstPenaltiesXElement = rootXElement.Element(XMLKeyCompareRunsAgainstPenalties);
                    if (compareRunsAgainstPenaltiesXElement == null)
                    {
                        compareRunsAgainstPenaltiesXElement = new XElement(XMLKeyCompareRunsAgainstPenalties, false);
                        CurrentRunCompareAgainstRunsWithPenalties = false;
                        rootXElement.Add(compareRunsAgainstPenaltiesXElement);
                    } 
                    else
                    {
                        string XElementValue = compareRunsAgainstPenaltiesXElement.Value;
                        bool readSuccessful = Boolean.TryParse(XElementValue, out bool compareRunsAgainstPenalties);
                        if (readSuccessful)
                        {
                            CurrentRunCompareAgainstRunsWithPenalties = compareRunsAgainstPenalties;
                        }
                        else
                        {
                            CurrentRunCompareAgainstRunsWithPenalties = false;
                        }
                    }

                    //CompareRunsAgainstDrivers
                    XElement compareRunsAgainstDriversXElement = rootXElement.Element(XMLKeyCompareRunsAgainstDrivers);
                    if (compareRunsAgainstDriversXElement == null)
                    {
                        //Couldn't find child XElement for CompareRunsAgainstDrivers, create a new one
                        compareRunsAgainstDriversXElement = new XElement(XMLKeyCompareRunsAgainstDrivers, 1);
                        CurrentRunCompareRunsAgainstDrivers = CompareRunsAgainstDriversEnum.COMPARE_RUNS_AGAINST_ALL_DRIVERS;
                        rootXElement.Add(compareRunsAgainstDriversXElement);
                    }
                    else
                    {
                        string XElementValue = compareRunsAgainstDriversXElement.Value;
                        bool readSuccessful = Int32.TryParse(XElementValue, out int compareRunsAgainstDriversValue);
                        if (readSuccessful)
                        {
                            CurrentRunCompareRunsAgainstDrivers = (CompareRunsAgainstDriversEnum)compareRunsAgainstDriversValue; //read value
                        }
                        else
                        {
                            CurrentRunCompareRunsAgainstDrivers = CompareRunsAgainstDriversEnum.COMPARE_RUNS_AGAINST_ALL_DRIVERS; //default value
                        }
                    }

                    //Username
                    XElement usernameXElement = rootXElement.Element(XMLKeyUsername);
                    if (usernameXElement == null)
                    {
                        usernameXElement = new XElement(XMLKeyUsername, "You");
                        Username = "You";
                        rootXElement.Add(usernameXElement);
                    }
                    else
                    {
                        Username = usernameXElement.Value;
                    }

                    //LastTrackName
                    XElement lastTrackNameXElement = rootXElement.Element(XMLKeyLastTrackName);
                    if (lastTrackNameXElement == null)
                    {
                        lastTrackNameXElement = new XElement(XMLKeyLastTrackName, "-");
                        CompareRunsLastTrackName = "-";
                        rootXElement.Add(lastTrackNameXElement);
                    }
                    else
                    {
                        CompareRunsLastTrackName = lastTrackNameXElement.Value;
                    }

                    //lastCarName
                    XElement lastCarNameXElement = rootXElement.Element(XMLKeyLastCarName);
                    if (lastCarNameXElement == null)
                    {
                        lastCarNameXElement = new XElement(XMLKeyLastCarName, "-");
                        CompareRunsLastCarName = "-";
                        rootXElement.Add(lastCarNameXElement);
                    }
                    else
                    {
                        CompareRunsLastCarName = lastCarNameXElement.Value;
                    }

                    //lastSessionTime
                    XElement lastSessionTimeXElement = rootXElement.Element(XMLKeyLastSessionTime);
                    if (lastSessionTimeXElement == null)
                    {
                        lastSessionTimeXElement = new XElement(XMLKeyLastSessionTime, "0");
                        CompareRunsLastSessionTime = "0";
                        rootXElement.Add(lastSessionTimeXElement);
                    }
                    else
                    {
                        string XElementValue = lastSessionTimeXElement.Value;
                        if (XElementValue != null)
                        {
                            CompareRunsLastSessionTime = XElementValue; //read value
                        }
                        else
                        {
                            CompareRunsLastSessionTime = "0"; //default value
                        }
                    }

                    //DisplayRunsWithPenalties
                    XElement displayRunsWithPenaltiesXElement = rootXElement.Element(XMLKeyDisplayRunsWithPenalties);
                    if (displayRunsWithPenaltiesXElement == null)
                    {
                        displayRunsWithPenaltiesXElement = new XElement(XMLKeyDisplayRunsWithPenalties, false);
                        CompareRunsDisplayRunsWithPenalties = false;
                        rootXElement.Add(displayRunsWithPenaltiesXElement);
                    }
                    else
                    {
                        string XElementValue = displayRunsWithPenaltiesXElement.Value;
                        bool readSuccessful = Boolean.TryParse(XElementValue, out bool displayRunsWithPenaltiesValue);
                        if (readSuccessful)
                        {
                            CompareRunsDisplayRunsWithPenalties = displayRunsWithPenaltiesValue;
                        }
                        else
                        {
                            CompareRunsDisplayRunsWithPenalties = false;
                        }
                    }

                    //DisplayRunsFromOtherDrivers
                    XElement displayRunsFromOtherDriversXElement = rootXElement.Element(XMLKeyDisplayRunsFromOtherDrivers);
                    if (displayRunsFromOtherDriversXElement == null)
                    {
                        displayRunsFromOtherDriversXElement = new XElement(XMLKeyDisplayRunsFromOtherDrivers, true);
                        CompareRunsDisplayRunsFromOtherDrivers = true;
                        rootXElement.Add(displayRunsFromOtherDriversXElement);
                    }
                    else
                    {
                        string XElementValue = displayRunsWithPenaltiesXElement.Value;
                        bool readSuccessful = Boolean.TryParse(XElementValue, out bool displayRunsFromOtherDriversValue);
                        if (readSuccessful)
                        {
                            CompareRunsDisplayRunsFromOtherDrivers = displayRunsFromOtherDriversValue;
                        }
                        else
                        {
                            CompareRunsDisplayRunsFromOtherDrivers = true;
                        }
                    }

                    //comparerName
                    XElement comparerNameXElement = rootXElement.Element(XMLKeyComparerName);
                    if (comparerNameXElement == null)
                    {
                        comparerNameXElement = new XElement(XMLKeyComparerName, FormStrings.SortByTotalTimeShortestFirst);
                        CompareRunsSelectedComparerName = FormStrings.SortByTotalTimeShortestFirst;
                        rootXElement.Add(comparerNameXElement);
                    }
                    else
                    {
                        CompareRunsSelectedComparerName = comparerNameXElement.Value;
                    }


                } //end read existing settings
                SaveSettingsFile();
            }//end file exists
            else
            //Create new file from scratch
            {
                rootXElement = new XElement(XMLKeySettings,
                    new XElement(XMLKeyStoreRunsWithPenalties, 1),
                    new XElement(XMLKeyCompareRunsAgainstCars, 1),
                    new XElement(XMLKeyCompareRunsAgainstDrivers, 1),
                    new XElement(XMLKeyCompareRunsAgainstPenalties, false),
                    new XElement(XMLKeyUsername, "You"),
                    new XElement(XMLKeyLastTrackName, "-"),
                    new XElement(XMLKeyLastCarName, "-"),
                    new XElement(XMLKeyLastSessionTime, "0"),
                    new XElement(XMLKeyDisplayRunsWithPenalties, false),
                    new XElement(XMLKeyDisplayRunsFromOtherDrivers, true),
                    new XElement(XMLKeyComparerName, FormStrings.SortByTotalTimeShortestFirst)
                );
                settingsDocument = new XDocument(rootXElement);
                SaveSettingsFile();
            }
        }

        /// <summary>
        /// Returns instance of SettingsProvider. Creates a new instance if no SettingsProvider exists yet
        /// </summary>
        /// <returns></returns>
        public static SettingsProvider GetInstance()
        {
            instance ??= new SettingsProvider();
            return instance;
        }

        /// <summary>
        /// Save the settings file to disk. Any existing file will be updated.
        /// </summary>
        private void SaveSettingsFile()
        {
            settingsDocument.Save(settingsFilePath);
        }

        /// <summary>
        /// Setter: Store runs with penalties has been enabled. Update all necessary values.
        /// </summary>
        public void SettingsSetStoreRunsWithPenaltiesEnabled()
        {
            XElement storeRunsWithPenaltiesXElement = rootXElement.Element(XMLKeyStoreRunsWithPenalties);
            storeRunsWithPenaltiesXElement.Value = "1";
            CurrentRunStoreRunsWithPenalties = StoreRunsWithPenaltiesEnum.STORE_RUNS_WITH_PENALTIES_ENABLED;
            SaveSettingsFile();
        }

        /// <summary>
        /// Setter: Store runs with penalties has been disabled. Update all necessary values.
        /// </summary>
        public void SettingsSetStoreRunsWithPenaltiesDisabled()
        {
            XElement storeRunsWithPenaltiesXElement = rootXElement.Element(XMLKeyStoreRunsWithPenalties);
            storeRunsWithPenaltiesXElement.Value = "2";
            CurrentRunStoreRunsWithPenalties = StoreRunsWithPenaltiesEnum.STORE_RUNS_WITH_PENALTIES_DISABLED;
            SaveSettingsFile();
        }

        /// <summary>
        /// Setter: Compare live runs against current car has been set. Update all necessary values.
        /// </summary>
        public void SettingsSetCompareAgainstCarsCurrent()
        {
            XElement compareCarsXElement = rootXElement.Element(XMLKeyCompareRunsAgainstCars);
            compareCarsXElement.Value = "1";
            CurrentRunCompareRunsAgainstCars = CompareRunsAgainstCarsEnum.COMPARE_RUNS_AGAINST_CURRENT_CAR;
            SaveSettingsFile();
        }

        /// <summary>
        /// Setter: Compare live runs against all cars has been set. Update all necessary values.
        /// </summary>
        public void SettingsSetCompareAgainstCarsAll()
        {
            XElement compareCarsXElement = rootXElement.Element(XMLKeyCompareRunsAgainstCars);
            compareCarsXElement.Value = "2";
            CurrentRunCompareRunsAgainstCars = CompareRunsAgainstCarsEnum.COMPARE_RUNS_AGAINST_ALL_CARS;
            SaveSettingsFile();
        }

        /// <summary>
        /// Setter: Compare live runs against current user has been set. Update all necessary values.
        /// </summary>
        public void SettingsSetCompareAgainstDriverUser()
        {
            XElement compareDriversXElement = rootXElement.Element(XMLKeyCompareRunsAgainstDrivers);
            compareDriversXElement.Value = "2";
            CurrentRunCompareRunsAgainstDrivers = CompareRunsAgainstDriversEnum.COMPARE_RUNS_AGAINST_OWN_RUNS_ONLY;
            SaveSettingsFile();
        }

        /// <summary>
        /// Setter: Compare live runs against all users has been set. Update all necessary values.
        /// </summary>
        public void SettingsSetCompareAgainstDriverAll()
        {
            XElement compareDriversXElement = rootXElement.Element(XMLKeyCompareRunsAgainstDrivers);
            compareDriversXElement.Value = "1";
            CurrentRunCompareRunsAgainstDrivers = CompareRunsAgainstDriversEnum.COMPARE_RUNS_AGAINST_ALL_DRIVERS;
            SaveSettingsFile();
        }

        public void SettingsSetDisplayRunsWithPenalties(bool displayRunsWithPenaltiesChecked)
        {
            XElement displayRunsWithPenaltiesXElement = rootXElement.Element(XMLKeyDisplayRunsWithPenalties);
            if (displayRunsWithPenaltiesChecked)
            {
                displayRunsWithPenaltiesXElement.Value = true.ToString();
                CompareRunsDisplayRunsWithPenalties = true;
            }
            else
            {
                displayRunsWithPenaltiesXElement.Value = false.ToString();
                CompareRunsDisplayRunsWithPenalties = false;
            }
            SaveSettingsFile();
        }

        public void SettingsSetDisplayRunsFromCurrentDriver(bool displayRunsFromCurrentDriverOnlyChecked)
        {
            XElement displayRunsFromOtherDriversXElement = rootXElement.Element(XMLKeyDisplayRunsFromOtherDrivers);
            if (displayRunsFromCurrentDriverOnlyChecked)
            {
                displayRunsFromOtherDriversXElement.Value = false.ToString();
                CompareRunsDisplayRunsFromOtherDrivers = false;
            }
            else
            {
                displayRunsFromOtherDriversXElement.Value = true.ToString();
                CompareRunsDisplayRunsFromOtherDrivers = true;
            }
            SaveSettingsFile();
        }

        /// <summary>
        /// Function to set a new username for the application. If checkbox is ticked, then runs with old username will be updated to the new username.
        /// </summary>
        /// <param name="newUsername">string consisting of the new username</param>
        /// <param name="additionallyUpdateRunInformation">If checked, runs in the database with the old username will be updated to new username. Otherwise no effect.</param>
        public void SettingsUpdateUsername(string newUsername, bool additionallyUpdateRunInformation)
        {
            if (string.IsNullOrEmpty(newUsername))
            {
                MessageBox.Show("Please enter a valid username.");
                return;
            }

            string oldUsername = Username;

            Username = newUsername;
            XElement usernameXElement = rootXElement.Element(XMLKeyUsername);
            usernameXElement.Value = newUsername;
            SaveSettingsFile();

            if (additionallyUpdateRunInformation)
            {
                List<RunInformation> runsWithOldUsername = storedRunContext.RunInformationSet
                    .Where(run => run.DriverName == oldUsername)
                    .ToList();

                MessageBox.Show("Updated " + runsWithOldUsername.Count + " runs.");

                foreach (RunInformation run in runsWithOldUsername)
                {
                    run.DriverName = newUsername;
                }

                storedRunContext.SaveChanges();
            }
        }

        public void SettingsSetLastTrackName(string trackName)
        {
            XElement lastTrackNameXElement = rootXElement.Element(XMLKeyLastTrackName);
            lastTrackNameXElement.Value = trackName;
            CompareRunsLastTrackName = trackName;
            SaveSettingsFile();
        }

        public void SettingsSetLastCarName(string carName)
        {
            XElement lastCarNameXElement = rootXElement.Element(XMLKeyLastCarName);
            lastCarNameXElement.Value = carName;
            CompareRunsLastTrackName = carName;
            SaveSettingsFile();
        }

        public void SettingsSetLastSessionTime(string sessionTime)
        {
            XElement lastSessionTimeXElement = rootXElement.Element(XMLKeyLastSessionTime);
            lastSessionTimeXElement.Value = sessionTime;
            CompareRunsLastSessionTime = sessionTime;
            SaveSettingsFile();
        }

        public void SettingsSetLastSelector(string selectorName)
        {
            XElement lastSelectorNameXElement = rootXElement.Element(XMLKeyComparerName);
            lastSelectorNameXElement.Value = selectorName;
            CompareRunsSelectedComparerName = selectorName;
            SaveSettingsFile();
        }

        public void SettingsSetLiveRunsCompareAgainstPenalties()
        {
            XElement compareRunsAgainstPenaltiesXElement = rootXElement.Element(XMLKeyCompareRunsAgainstPenalties);
            compareRunsAgainstPenaltiesXElement.Value = true.ToString();
            CurrentRunCompareAgainstRunsWithPenalties = true;
            SaveSettingsFile();
        }

        public void SettingsSetLiveRunsCompareNotAgainstPenalties()
        {
            XElement compareRunsAgainstPenaltiesXElement = rootXElement.Element(XMLKeyCompareRunsAgainstPenalties);
            compareRunsAgainstPenaltiesXElement.Value = false.ToString();
            CurrentRunCompareAgainstRunsWithPenalties = false;
            SaveSettingsFile();
        }
    }
}
