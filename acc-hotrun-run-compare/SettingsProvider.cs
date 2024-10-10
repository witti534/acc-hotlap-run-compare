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
        public StoreRunsWithPenaltiesEnum StoreRunsWithPenalties { get; private set; }
        public CompareRunsAgainstCarsEnum CompareRunsAgainstCars { get; private set; }
        public CompareRunsAgainstDriversEnum CompareRunsAgainstDrivers { get; private set; }


        private readonly string settingsFilePath = "settings.xml";
        private readonly XElement rootXElement;
        private readonly XDocument settingsDocument;
        private readonly StoredRunContext storedRunContext = StoredRunContext.GetInstance();

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
                rootXElement = settingsDocument.Element("settings");
                if (rootXElement == null)
                {
                    // Create a new settings element
                    rootXElement = new XElement("settings", 
                        new XElement("StoreRunsWithPenalties", 1),
                        new XElement("CompareRunsAgainstCars", 1),
                        new XElement("CompareRunsAgainstDrivers", 1),
                        new XElement("username", "You")
                    );
                }
                else
                {
                    // Read existing settings

                    //StoreRunsWithPenalties
                    XElement storeRunsWithPenaltiesXElement = rootXElement.Element("StoreRunsWithPenalties");
                    if (storeRunsWithPenaltiesXElement == null)
                    {
                        //Couldn't find child XElement for StoreRunsWithPenalties, create a new one
                        storeRunsWithPenaltiesXElement = new XElement("StoreRunsWithPenalties", 1);
                        rootXElement.Add(storeRunsWithPenaltiesXElement);
                    } 
                    else
                    {
                        string XElementValue = storeRunsWithPenaltiesXElement.Value;
                        bool readSuccessful = Int32.TryParse(XElementValue, out int storeRunsWithPenaltiesValue);
                        if (readSuccessful)
                        {
                            StoreRunsWithPenalties = (StoreRunsWithPenaltiesEnum)storeRunsWithPenaltiesValue; //read value
                        }
                        else
                        {
                            StoreRunsWithPenalties = StoreRunsWithPenaltiesEnum.STORE_RUNS_WITH_PENALTIES_ENABLED; //default value
                        }
                    }

                    //CompareRunsAgainstCars
                    XElement compareRunsAgainstCarsXElement = rootXElement.Element("CompareRunsAgainstCars");
                    if (compareRunsAgainstCarsXElement == null)
                    {
                        //Couldn't find child XElement for CompareRunsAgainstCars, create a new one
                        compareRunsAgainstCarsXElement = new XElement("CompareRunsAgainstCars", 1);
                        CompareRunsAgainstCars = CompareRunsAgainstCarsEnum.COMPARE_RUNS_AGAINST_CURRENT_CAR;
                        rootXElement.Add(compareRunsAgainstCarsXElement);
                    }
                    else
                    {
                        string XElementValue = compareRunsAgainstCarsXElement.Value;
                        bool readSuccessful = Int32.TryParse(XElementValue, out int compareRunsAgainstCarsValue);
                        if (readSuccessful)
                        {
                            CompareRunsAgainstCars = (CompareRunsAgainstCarsEnum)compareRunsAgainstCarsValue; //read value
                        }
                        else
                        {
                            CompareRunsAgainstCars = CompareRunsAgainstCarsEnum.COMPARE_RUNS_AGAINST_CURRENT_CAR; //default value
                        }
                    }

                    //CompareRunsAgainstDrivers
                    XElement compareRunsAgainstDriversXElement = rootXElement.Element("CompareRunsAgainstDrivers");
                    if (compareRunsAgainstDriversXElement == null)
                    {
                        //Couldn't find child XElement for CompareRunsAgainstDrivers, create a new one
                        compareRunsAgainstDriversXElement = new XElement("CompareRunsAgainstDrivers", 1);
                        CompareRunsAgainstDrivers = CompareRunsAgainstDriversEnum.COMPARE_RUNS_AGAINST_ALL_DRIVERS;
                        rootXElement.Add(compareRunsAgainstDriversXElement);
                    }
                    else
                    {
                        string XElementValue = compareRunsAgainstDriversXElement.Value;
                        bool readSuccessful = Int32.TryParse(XElementValue, out int compareRunsAgainstDriversValue);
                        if (readSuccessful)
                        {
                            CompareRunsAgainstDrivers = (CompareRunsAgainstDriversEnum)compareRunsAgainstDriversValue; //read value
                        }
                        else
                        {
                            CompareRunsAgainstDrivers = CompareRunsAgainstDriversEnum.COMPARE_RUNS_AGAINST_ALL_DRIVERS; //default value
                        }
                    }

                    //Username
                    XElement usernameXElement = rootXElement.Element("username");
                    if (usernameXElement == null)
                    {
                        usernameXElement = new XElement("username", "You");
                        Username = "You";
                        rootXElement.Add(usernameXElement);
                    }
                    else
                    {
                        Username = usernameXElement.Value;
                    }

                } //end read existing settings
                SaveSettingsFile();
            }//end file exists
            else
            {
                rootXElement = new XElement("settings",
                    new XElement("StoreRunsWithPenalties", 1),
                    new XElement("CompareRunsAgainstCars", 1),
                    new XElement("CompareRunsAgainstDrivers", 1),
                    new XElement("username", "You")
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

        private void SaveSettingsFile()
        {
            settingsDocument.Save(settingsFilePath);
        }

        public void SettingsSetStoreRunsWithPenaltiesEnabled()
        {
            XElement storeRunsWithPenaltiesXElement = rootXElement.Element("StoreRunsWithPenalties");
            storeRunsWithPenaltiesXElement.Value = "1";
            StoreRunsWithPenalties = StoreRunsWithPenaltiesEnum.STORE_RUNS_WITH_PENALTIES_ENABLED;
            SaveSettingsFile();
        }

        public void SettingsSetStoreRunsWithPenaltiesDisabled()
        {
            XElement storeRunsWithPenaltiesXElement = rootXElement.Element("StoreRunsWithPenalties");
            storeRunsWithPenaltiesXElement.Value = "2";
            StoreRunsWithPenalties = StoreRunsWithPenaltiesEnum.STORE_RUNS_WITH_PENALTIES_DISABLED;
            SaveSettingsFile();
        }

        public void SettingsSetCompareAgainstCarsCurrent()
        {
            XElement compareCarsXElement = rootXElement.Element("CompareRunsAgainstCars");
            compareCarsXElement.Value = "1";
            CompareRunsAgainstCars = CompareRunsAgainstCarsEnum.COMPARE_RUNS_AGAINST_CURRENT_CAR;
            SaveSettingsFile();
        }

        public void SettingsSetCompareAgainstCarsAll()
        {
            XElement compareCarsXElement = rootXElement.Element("CompareRunsAgainstCars");
            compareCarsXElement.Value = "2";
            CompareRunsAgainstCars = CompareRunsAgainstCarsEnum.COMPARE_RUNS_AGAINST_ALL_CARS;
            SaveSettingsFile();
        }

        public void SettingsSetCompareAgainstDriverUser()
        {
            XElement compareDriversXElement = rootXElement.Element("CompareRunsAgainstDrivers");
            compareDriversXElement.Value = "2";
            CompareRunsAgainstDrivers = CompareRunsAgainstDriversEnum.COMPARE_RUNS_AGAINST_OWN_RUNS_ONLY;
            SaveSettingsFile();
        }

        public void SettingsSetCompareAgainstDriverAll()
        {
            XElement compareDriversXElement = rootXElement.Element("CompareRunsAgainstDrivers");
            compareDriversXElement.Value = "1";
            CompareRunsAgainstDrivers = CompareRunsAgainstDriversEnum.COMPARE_RUNS_AGAINST_ALL_DRIVERS;
            SaveSettingsFile();
        }

        public void SettingsUpdateUsername(string newUsername, bool additionallyUpdateRunInformation)
        {
            if (string.IsNullOrEmpty(newUsername))
            {
                MessageBox.Show("Please enter a valid username.");
                return;
            }

            string oldUsername = Username;

            Username = newUsername;
            XElement usernameXElement = rootXElement.Element("username");
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
    }
}
