using acc_hotlab_private_run_compare.DBClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace acc_hotlab_private_run_compare
{
    /// <summary>
    /// This is a class for the form to compare multiple runs. 
    /// The runs will be sorted from left to right from fastest to slowest. 
    /// </summary>
    public partial class FormMultipleRuns : Form
    {
        List<RunInformation> providedRuns;
        StoredRunContext storedRunContext;

        // Section for all locations and offsets for all labels
        private readonly int OFFSET_X_ONCE_GENERAL = 13;
        private readonly int OFFSET_Y_ONCE_GENERAL = 9;


        // Section for all sizes 
        private readonly int SIZE_X_ONCE_GENERAL = 270;
        private readonly int SIZE_Y_ONCE_GENERAL = 38;

        // Creating a list for comparisons 
        private int[] CumulativeLapTimesFastestRun = [];

        /// <summary>
        /// Constructer for the Form.
        /// </summary>
        /// <param name="providedRuns">A list of the runs to be compared. They must have the same track and session length</param>
        /// <param name="storedRunContext">The context to load sector times.</param>
        public FormMultipleRuns(List<RunInformation> providedRuns, StoredRunContext storedRunContext)
        {
            this.providedRuns = providedRuns;
            this.storedRunContext = storedRunContext;
            InitializeComponent();
            DeleteDesignerElements();
            CreateElementsForGeneralInformation();

            //Sort runs so the fastest run with most laps will always be first and the slowest run with least amount of laps will always be last.
            providedRuns.Sort(new RunInformationComparerFastestRunFirst());

            //Create all the labels for each single run
            for (int i = 0; i < providedRuns.Count; i++)
            {
                CreateElementsForASingleRun(i, providedRuns[i]);
            }
        }

        /// <summary>
        /// Delete all elements which were created in the designer
        /// </summary>
        private void DeleteDesignerElements()
        {
            Controls.Clear();
        }

        /// <summary>
        /// Create all the elements which contain the general information about runs
        /// </summary>
        private void CreateElementsForGeneralInformation()
        {
            Label labelRunInfoGeneral = new()
            {
                Text = "Track: " + providedRuns[0].TrackName
                + "\r\nSession length: " + (providedRuns[0].SessionTime / 60000).ToString() + " minutes",
                Location = new Point(OFFSET_X_ONCE_GENERAL, OFFSET_Y_ONCE_GENERAL),
                Size = new Size(SIZE_X_ONCE_GENERAL, SIZE_Y_ONCE_GENERAL)
            };
            Controls.Add(labelRunInfoGeneral);
        }

        /// <summary>
        /// Create all the elements which contain the information about a single run
        /// </summary>
        /// <param name="position">Position of the single run compared to provided runs. Dependant on amount of driven laps and total driven time. Starts at 0.</param>
        /// <param name="providedRun">The run with all sector times</param>
        private void CreateElementsForASingleRun(int position, RunInformation providedRun)
        {

        }
    }
}
