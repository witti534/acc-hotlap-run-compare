using acc_hotrun_run_compare.DBClasses;
using acc_hotrun_run_compare.GameListener;
using Microsoft.EntityFrameworkCore;
using System.Collections.Concurrent;
using System.Configuration;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace acc_hotrun_run_compare
{
    /// <summary>
    /// Main Form of the program. Contains autogenerated functions. 
    /// </summary>
    public partial class MainForm : Form
    {
        public string Version = "0.0.1-error"; //Default value for Version in case something goes wrong


        public StoredRunContext dbStoredRunsContext = StoredRunContext.GetInstance();
        private readonly Random DebugRNGProvider = new();
        public Thread AccListenerThread { get; private set; }
        private ACCGameStateReader AccListener { get; set; }
        private readonly TabCompareRuns tabCompareRuns;
        private readonly TabCurrentRun tabCurrentRun;
        private readonly TabDebug tabDebug;
        private readonly SettingsProvider settingsProvider;

        public ConcurrentQueue<string> AccDebugMsgListenerQueue { get; private set; } = new();
        public ConcurrentQueue<string> AccGameStateControlQueue { get; private set; } = new();
        public ConcurrentQueue<string> AccCurrentRunInformationQueue { get; private set; } = new();

        int tickCounter = 0;


        public MainForm()
        {
            settingsProvider = SettingsProvider.GetInstance();
            InitializeVersion();
            InitializeComponent();
            InitializeDebugBox();
            InitialzeOrderByCheckBox();
            InitializeLabelsOnCurrentRunTab();
            InitializeSettings();
            timer1.Enabled = true;
            tabCompareRuns = new TabCompareRuns(panelDisplayRuns, comboBoxTrackSelector, comboBoxCarSelector, comboBoxTimeSelector, checkBoxDisplayRunsWIthPenalties, ComboBoxSortRunsBy);
            tabDebug = new TabDebug();
            tabCurrentRun = new TabCurrentRun();
            labelVersion.Text = "Version: " + Version;
        }


        /// <summary>
        /// Close the database connection and send a message to the ACCGameStateReader that the program is being closed.
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            AccGameStateControlQueue.Enqueue("close");
        }

        /// <summary>
        /// To avoid needing to drive in the game for several minutes this function creates a fake run with the information provided in the debug page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonClickDebugCreatFakeRunInfo(object sender, EventArgs e)
        {
            RunInformation debugRun = tabDebug.CreateDebugRun(debugBox);

            if (debugRun != null)
            {
                addFinishedRunToFormContext(debugRun);
            }
            else
            {
                debugTextbox1.Text = "Could not create run. Most likely the lap number was not input correctly.\r\n" + debugTextbox1.Text;
            }

        }

        /// <summary>
        /// A function for other threads to invoke to full up the form textbox with messages from the message queue
        /// </summary>
        public void MoveTextFromQueueToDebugbox()
        {
            while (!AccDebugMsgListenerQueue.IsEmpty)
            {
                AccDebugMsgListenerQueue.TryDequeue(out string tmpString);
                debugTextbox1.Text = tmpString + debugTextbox1.Text;
            }
        }


        /// <summary>
        /// This method is intended to accept a finished RunInformation from the ACCGameStateReader thread or the debug context. 
        /// The RunInformation including all SectorInformation will be added to the database.
        /// </summary>
        /// <param name="finishedRun">A RunInformation object. No RunID is needed</param>
        public void addFinishedRunToFormContext(RunInformation finishedRun)
        {
            //debug text
            if (finishedRun != null)
            {
                AccDebugMsgListenerQueue.Enqueue("RunInformation recieved in main thread.");
            }
            else
            {
                AccDebugMsgListenerQueue.Enqueue("Error: RunInformation is null.");
                MoveTextFromQueueToDebugbox();
                return;
            }

            //Check if penalties occured during the run.
            //Do not save the run if settings forbid saving runs with penalties.
            //Display debug text.
            if (settingsProvider.StoreRunsWithPenalties == SettingsProvider.StoreRunsWithPenaltiesEnum.STORE_RUNS_WITH_PENALTIES_DISABLED && finishedRun.PenaltyOccured)
            {
                labelLastSavedRunData.Text = "There has been a penalty in the last run.\r\n" +
                    "Change settings if you want to store runs with penalties.";
                AccDebugMsgListenerQueue.Enqueue("RunInformation not saved: Settings forbid saving runs with penalties.");
                MoveTextFromQueueToDebugbox();
                return;
            }

            MoveTextFromQueueToDebugbox();

            labelLastSavedRunData.Text = TabCurrentRun.CreateDisplayStringFromCompleteRunInformation(finishedRun);

            finishedRun.DriverName = settingsProvider.Username; //Get username from SettingsProvider

            //Add all sectors to the database, afterwards add the RunInformation itself to the database
            foreach (SectorInformation sectorInformation in finishedRun.SectorList)
            {
                dbStoredRunsContext.Add(sectorInformation);
            }
            dbStoredRunsContext.Add(finishedRun);
            dbStoredRunsContext.SaveChanges();
            return;
        }


        /// <summary>
        /// This function gets run every tick in the background timer from the form. At the time of writing this information it's one time per second.
        /// Starts the ACCGameStateReader thread and makes sure it's running. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContinuousMainFormTick(object sender, EventArgs e)
        {

            tickCounter++;
            if (tickCounter % 10 == 2) //check every 10 seconds, starting with second 2
            {
                if (AccListenerThread == null)
                {
                    AccListener = new ACCGameStateReader(this);

                    debugTextbox1.Text = "Initializing ACC game state listener...\r\n" + debugTextbox1.Text;

                    AccListenerThread = new Thread(new ThreadStart(AccListener.Start));
                    AccListenerThread.Start();
                }
                else
                {
                    //debugTextbox1.Text = "ACC game state listener already running.\r\n" + debugTextbox1.Text;
                }

            }

        }


        /// <summary>
        /// This function is being called when the comboBoxTrackSelector index is being changed (so an item is selected).
        /// It reads the value of this ComboBox and then populates the comboBoxCarSelector, depending on the trackname. 
        /// The comboBoxCarSelector is being activated.
        /// Additionally the comboBoxTimeSelector is being cleared and deactivated.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxTrackSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxCarSelector.Enabled = true;
            tabCompareRuns.PopulateCarSelector();

            comboBoxTimeSelector.Items.Clear();
            comboBoxTimeSelector.Enabled = false;

            if (comboBoxCarSelector.Items.Count == 1)
            {
                comboBoxCarSelector.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// This function is being called when the comboBoxCarSelector index is being changed (so an item is selected).
        /// It reads the value of this ComboBox and then populates the comboBoxSessionSelector, depending on trackname and carname.
        /// The comboBoxSessionSelector is being activated.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxCarSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxTimeSelector.Enabled = true;
            tabCompareRuns.PopulateSessionSelector();
            checkBoxDisplayRunsWIthPenalties.Enabled = true;

            if (comboBoxTimeSelector.Items.Count == 1)
            {
                comboBoxTimeSelector.SelectedIndex = 0;
            }

            //After changing the car populate the session length selector
        }

        /// <summary>
        /// This function is being called when the tab is changed
        /// For now this only affects the data in the tab for comparing runs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Name == "tabPageCompareRuns") //tab for comparing runs
            {

                //Clear fields and populate TrackSelector
                tabCompareRuns.PopulateTrackSelector();

                //Disable other Selectors
                comboBoxCarSelector.Items.Clear();
                comboBoxCarSelector.Enabled = false;

                comboBoxTimeSelector.Items.Clear();
                comboBoxTimeSelector.Enabled = false;

                checkBoxDisplayRunsWIthPenalties.Enabled = false;

                if (comboBoxTrackSelector.Items.Count == 1)
                {
                    comboBoxTrackSelector.SelectedIndex = 0;
                }

            }
        }

        /// <summary>
        /// This function is being called when the Session Length Selector index is being changed (so an item has been selected).
        /// Afterwards it fills up panel with all runs which are available for the track, car and session length combination.
        /// Additionally runs with penalties can be excluded.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxTimeSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTimeSelector.Items.Count > 0 || comboBoxTimeSelector.SelectedItem != null)
            {
                panelDisplayRuns.Controls.Clear();

                tabCompareRuns.FillUpPanelWithRuns();
            }
        }

        /// <summary>
        /// Debug function to make sure the database context and files exist
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetDatabase_Click(object sender, EventArgs e)
        {
            dbStoredRunsContext.Database.EnsureDeleted();
            dbStoredRunsContext.ChangeTracker.Clear();
            dbStoredRunsContext.Database.EnsureCreated();
            dbStoredRunsContext.SaveChanges();
        }

        /// <summary>
        /// This function is being invoked from the ACCGameStateReader thread. 
        /// </summary>
        public void UpdateCurrentRunData()
        {
            tabCurrentRun.UpdateCurrentRunInfo(panelCurrentRunInfo, AccCurrentRunInformationQueue);
        }

        private void labelChooseSessionTime_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// This function calls the function to delete selected runs in the tab "compareRuns". Afterwards it reruns the function to display all new runs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDeleteSelectedRuns_Click(object sender, EventArgs e)
        {
            tabCompareRuns.DeleteSelectedRuns(panelDisplayRuns);
            comboBoxTimeSelector_SelectedIndexChanged(null, null);
        }

        /// <summary>
        /// This function calls the function to show selected runs in the tab "compareRuns".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCompareRuns_Click(object sender, EventArgs e)
        {
            tabCompareRuns.ShowRuns(panelDisplayRuns);
        }

        private void InitializeVersion()
        {
            XmlReader xmlReader = XmlReader.Create("version.xml");

            try
            {
                xmlReader.MoveToContent();
                Version = xmlReader.ReadElementContentAsString();
            }
            finally
            {
                xmlReader?.Close();
            }
        }

        private void ButtonExportSelectedRuns_Click(object sender, EventArgs e)
        {
            tabCompareRuns.ExportRunsEntryFunction(panelDisplayRuns);
        }

        private void buttonImportRuns_Click(object sender, EventArgs e)
        {
            tabCompareRuns.ImportRunsEntryFunction(panelDisplayRuns);
        }

        private void comboBoxTrackSelector_MouseClick(object sender, MouseEventArgs e)
        {
            //tabCompareRuns.PopulateTrackSelector();
        }

        /// <summary>
        /// Reads values from SettingsProvider and sets up the radio buttons with the correct values
        /// </summary>
        private void InitializeSettings()
        {
            textBoxUsername.Text = settingsProvider.Username;

            if (settingsProvider.StoreRunsWithPenalties == SettingsProvider.StoreRunsWithPenaltiesEnum.STORE_RUNS_WITH_PENALTIES_ENABLED)
            {
                radioButtonStoreRunsWithPenaltiesEnabled.Checked = true;
            }
            if (settingsProvider.StoreRunsWithPenalties == SettingsProvider.StoreRunsWithPenaltiesEnum.STORE_RUNS_WITH_PENALTIES_DISABLED)
            {
                radioButtonStoreRunsWithPenaltiesDisabled.Checked = true;
            }
            if (settingsProvider.CompareRunsAgainstCars == SettingsProvider.CompareRunsAgainstCarsEnum.COMPARE_RUNS_AGAINST_ALL_CARS)
            {
                radioButtonCarCompareAllCars.Checked = true;
            }
            if (settingsProvider.CompareRunsAgainstCars == SettingsProvider.CompareRunsAgainstCarsEnum.COMPARE_RUNS_AGAINST_CURRENT_CAR)
            {
                radioButtonCarCompareCurrentCar.Checked = true;
            }
            if (settingsProvider.CompareRunsAgainstDrivers == SettingsProvider.CompareRunsAgainstDriversEnum.COMPARE_RUNS_AGAINST_ALL_DRIVERS)
            {
                radioButtonDriverCompareAllDrivers.Checked = true;
            }
            if (settingsProvider.CompareRunsAgainstDrivers == SettingsProvider.CompareRunsAgainstDriversEnum.COMPARE_RUNS_AGAINST_OWN_RUNS_ONLY)
            {
                radioButtonDriverCompareUserOnly.Checked = true;
            }
        }

        private void radioButtonStoreRunsWithPenaltiesEnabled_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonStoreRunsWithPenaltiesEnabled.Checked)
            {
                settingsProvider.SettingsSetStoreRunsWithPenaltiesEnabled();
            }
        }

        private void radioButtonStoreRunsWithPenaltiesDisabled_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonStoreRunsWithPenaltiesDisabled.Checked)
            {
                settingsProvider.SettingsSetStoreRunsWithPenaltiesDisabled();
            }
        }

        private void radioButtonCarCompareCurrentCar_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonCarCompareCurrentCar.Checked)
            {
                settingsProvider.SettingsSetCompareAgainstCarsCurrent();
            }
        }

        private void radioButtonCarCompareAllCars_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonCarCompareAllCars.Checked)
            {
                settingsProvider.SettingsSetCompareAgainstCarsAll();
            }
        }

        private void radioButtonDriverCompareUserOnly_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonDriverCompareUserOnly.Checked)
            {
                settingsProvider.SettingsSetCompareAgainstDriverUser();
            }
        }

        private void radioButtonDriverCompareAllDrivers_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonDriverCompareAllDrivers.Checked)
            {
                settingsProvider.SettingsSetCompareAgainstDriverAll();
            }
        }

        private void buttonUpdateUsername_Click(object sender, EventArgs e)
        {
            settingsProvider.SettingsUpdateUsername(textBoxUsername.Text, checkBoxUpdateUsernameForAllRuns.Checked);
        }

    }
}