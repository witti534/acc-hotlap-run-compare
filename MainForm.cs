using acc_hotlab_private_run_compare.DBClasses;
using acc_hotlab_private_run_compare.GameListener;
using System.Collections.Concurrent;
using System.Text;

namespace acc_hotlab_private_run_compare
{
    /// <summary>
    /// Main Form of the program. Contains autogenerated functions. 
    /// </summary>
    public partial class MainForm : Form
    {
        public const string VERSION = "0.1.3";


        public StoredRunContext dbStoredRunsContext = new();
        private readonly Random DebugRNGProvider = new();
        public Thread AccListenerThread { get; private set; }
        private ACCGameStateReader AccListener { get; set; }
        private readonly TabCompareRuns tabCompareRuns;
        private readonly TabCurrentRun tabCurrentRun;
        private readonly TabDebug tabDebug;

        public ConcurrentQueue<string> AccDebugMsgListenerQueue { get; private set; } = new();
        public ConcurrentQueue<string> AccGameStateControlQueue { get; private set; } = new();
        public ConcurrentQueue<string> AccCurrentRunInformationQueue { get; private set; } = new();

        int tickCounter = 0;


        public MainForm()
        {
            InitializeComponent();
            InitializeDebugBox();
            InitialzeOrderByCheckBox();
            InitializeLabelsOnCurrentRunTab();
            timer1.Enabled = true;
            tabCompareRuns = new TabCompareRuns(dbStoredRunsContext);
            tabDebug = new TabDebug(dbStoredRunsContext);
            tabCurrentRun = new TabCurrentRun(dbStoredRunsContext);
            labelVersion.Text = "Version: " + VERSION;
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
        /// 
        /// </summary>
        /// <param name="finishedRun">A RunInformation object. No RunID is needed</param>
        public void addFinishedRunToFormContext(RunInformation finishedRun)
        {
            if (finishedRun != null)
            {
                AccDebugMsgListenerQueue.Enqueue("RunInformation added.");
            }
            else
            {
                AccDebugMsgListenerQueue.Enqueue("Error: RunInformation is null.");
                MoveTextFromQueueToDebugbox();
                return;
            }
            MoveTextFromQueueToDebugbox();
            labelRunData.Text = TabCurrentRun.CreateDisplayStringFromCompleteRunInformation(finishedRun);

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
            string trackName = comboBoxTrackSelector.Text;
            comboBoxCarSelector.Enabled = true;
            tabCompareRuns.PopulateCarSelector(comboBoxCarSelector, trackName);

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
            string trackName = comboBoxTrackSelector.Text;
            string carName = comboBoxCarSelector.Text;
            tabCompareRuns.PopulateSessionSelector(comboBoxTimeSelector, trackName, carName);
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
            if (tabControl1.SelectedIndex == 1) //tab for comparing runs
            {
                //Clear fields and populate TrackSelector
                tabCompareRuns.PopulateTrackSelector(comboBoxTrackSelector);

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
            string trackName = comboBoxTrackSelector.Text;
            string carName = comboBoxCarSelector.Text;
            string sessionTime = comboBoxTimeSelector.Text;
            bool displayRunsWithPenalties = checkBoxDisplayRunsWIthPenalties.Checked;
            string comparerName = sortRunsByComboBox.Text;

            if (comboBoxTimeSelector.Items.Count > 0 || comboBoxTimeSelector.SelectedItem != null)
            {
                int sessionTimeString = Int32.Parse(sessionTime);

                panelDisplayRuns.Controls.Clear();

                tabCompareRuns.FillUpPanelWithRuns(panelDisplayRuns, trackName, carName, displayRunsWithPenalties, sessionTimeString, comparerName);
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
    }
}