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
        private readonly int OFFSET_X_ONCE_LAPNUMBER = 13;
        private readonly int OFFSET_Y_ONCE_LAPNUMBER = 176;
        private readonly int OFFSET_X_ONCE_SECTORS = 23;
        private readonly int OFFSET_Y_ONCE_S0 = 195;
        private readonly int OFFSET_Y_ONCE_S1 = 214;
        private readonly int OFFSET_Y_ONCE_S2 = 233;
        private readonly int OFFSET_Y_LAP = 75;
        private readonly int OFFSET_X_FIRST_BOX = 119;
        private readonly int OFFSET_X_EACH_BOX = 299;
        private readonly int OFFSET_Y_FIRST_BOX = 84;
        private readonly int OFFSET_X_FIRST_SECTORTIME = 47;
        private readonly int OFFSET_Y_FIRST_SECTORTIME = 110;
        private readonly int OFFSET_Y_EACH_SECTOR = 19;
        private readonly int OFFSET_X_FIRST_LAPTIME = 4;
        private readonly int OFFSET_Y_FIRST_LAPTIME = 91;
        private readonly int OFFSET_X_FIRST_CUMLAPTIME = 197;


        // Section for all sizes 
        private readonly int SIZE_Y_SINGLELINE = 19;
        private readonly int SIZE_Y_TWOLINES = 38;
        private readonly int SIZE_X_ONCE_GENERAL = 270;
        private readonly int SIZE_X_LAPNUMBER = 79;
        private readonly int SIZE_X_SECTORS = 39;
        private readonly int SIZE_X_BOX = 300;
        private readonly int SIZE_Y_BOX_DEFAULT = 100;
        private readonly int SIZE_Y_BOX_LAP = 76;
        private readonly int SIZE_X_SECTORTIME = 79;
        private readonly int SIZE_X_LAPTIME = 89;
        private readonly int SIZE_X_CUMLAPTIME = 99;


        // Creating a list for comparisons 
        readonly int amountOfLapsFastestRun;
        private int[] CumulativeLapTimesFastestRun;

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

            //amount of sectors of the fastest run devided by 3 to get the lap count
            amountOfLapsFastestRun = providedRuns[0].SectorList.Count / 3;

            FillLapTimeOfFastestRun(providedRuns[0]);

            CreateLabelsForLapAndSectorNumbers(amountOfLapsFastestRun);

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
                Size = new Size(SIZE_X_ONCE_GENERAL, SIZE_Y_TWOLINES)
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
            Panel box = CreateBox(position);

            bool isFastestRun = (position == 0); //True for fastest run, false for all other runs
            CreateLabelsForLapAndSectorTimes(box, providedRun, isFastestRun);


        }


        /// <summary>
        /// Create all the labels for the lap and sector numbers. 4 labels for each lap will be generated, 1 for the lap and 3 for the sectors.
        /// </summary>
        /// <param name="amountOfLapsFastestRun"></param>
        private void CreateLabelsForLapAndSectorNumbers(int amountOfLapsFastestRun)
        {

            for (int i = 0; i < amountOfLapsFastestRun; i++)
            {
                //label for lap number
                Label lapNumberLabel = new()
                {
                    Text = "Lap " + (i + 1).ToString(), //switch from logic to display
                    Location = new Point(OFFSET_X_ONCE_LAPNUMBER, OFFSET_Y_ONCE_LAPNUMBER + OFFSET_Y_LAP * i),
                    Size = new Size(SIZE_X_LAPNUMBER, SIZE_Y_SINGLELINE)
                };
                Controls.Add(lapNumberLabel);

                Label sector0Label = new()
                {
                    Text = "S 1",
                    Location = new Point(OFFSET_X_ONCE_SECTORS, OFFSET_Y_ONCE_S0 + OFFSET_Y_LAP * i),
                    Size = new Size(SIZE_X_SECTORS, SIZE_Y_SINGLELINE),
                    ForeColor = Color.Silver
                };
                Controls.Add(sector0Label);
                //label for sector0 (displayed as S 1)

                Label sector1Label = new()
                {
                    Text = "S 2",
                    Location = new Point(OFFSET_X_ONCE_SECTORS, OFFSET_Y_ONCE_S1 + OFFSET_Y_LAP * i),
                    Size = new Size(SIZE_X_SECTORS, SIZE_Y_SINGLELINE),
                    ForeColor = Color.Silver
                };
                Controls.Add(sector1Label);
                //label for sector1 (displayed as S 2)

                Label sector2Label = new()
                {
                    Text = "S 3",
                    Location = new Point(OFFSET_X_ONCE_SECTORS, OFFSET_Y_ONCE_S2 + OFFSET_Y_LAP * i),
                    Size = new Size(SIZE_X_SECTORS, SIZE_Y_SINGLELINE),
                    ForeColor = Color.Silver
                };
                Controls.Add(sector2Label);
                //label for sector2 (displayed as S 3)
            }
        }

        /// <summary>
        /// Creates the box to keep all the information about a single run
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        private Panel CreateBox(int position)
        {
            Color color = (position % 2 == 0) ? Color.LightGray : Color.Silver;
            Panel box = new()
            {
                BackColor = color,
                Location = new Point(OFFSET_X_FIRST_BOX + OFFSET_X_EACH_BOX * position, OFFSET_Y_FIRST_BOX),
                Size = new Size(SIZE_X_BOX, SIZE_Y_BOX_DEFAULT + SIZE_Y_BOX_LAP * amountOfLapsFastestRun), //TODO
                Visible = true,
                BorderStyle = BorderStyle.FixedSingle,
            };
            Controls.Add(box);

            return box;
        }

        /// <summary>
        /// Creates all single labels for the sector times and the lap times. 
        /// </summary>
        /// <param name="box">The box in which the lap and sector times shall be displayed</param>
        /// <param name="providedRun">The run with the information about the sector times and lap times</param>
        private void CreateLabelsForLapAndSectorTimes(Panel box, RunInformation providedRun, bool isFastestRun)
        {
            int[] lapTimes = new int[providedRun.SectorList.Count / 3];
            int[] cumulativeLapTimes = new int[providedRun.SectorList.Count / 3];

            //First go through each sector, afterwards create laps
            foreach (SectorInformation sector in providedRun.SectorList)
            {
                lapTimes[sector.LapNumber] += sector.DrivenSectorTime; //No need for an ordered sector list of sectors

                Label sectorLabel = new()
                {
                    Text = TimeFormatter.ConvertMilisecondsToThreeFixedDigitsSecondsString(sector.DrivenSectorTime),
                    Size = new Size(SIZE_X_SECTORTIME, SIZE_Y_SINGLELINE),
                    Visible = true,
                    Location = new Point(OFFSET_X_FIRST_SECTORTIME, OFFSET_Y_FIRST_SECTORTIME + OFFSET_Y_LAP * sector.LapNumber + OFFSET_Y_EACH_SECTOR * sector.SectorIndex),
                };

                box.Controls.Add(sectorLabel);
            }

            //Add labels for laptimes
            for (int i = 0; i < lapTimes.Length; i++)
            {
                Label lapLabel = new()
                {
                    Text = TimeFormatter.ConvertMilisecondsToMinutesString(lapTimes[i]),
                    Size = new Size(SIZE_X_LAPTIME, SIZE_Y_SINGLELINE),
                    Visible = true,
                    Location = new Point(OFFSET_X_FIRST_LAPTIME, OFFSET_Y_FIRST_LAPTIME + OFFSET_Y_LAP * i),
                };
                box.Controls.Add(lapLabel);
            }

            //Calculate cumulative lap times
            cumulativeLapTimes[0] = lapTimes[0];
            for (int i = 1; i < lapTimes.Length; i++) 
            {
                cumulativeLapTimes[i] = cumulativeLapTimes[i - 1] + lapTimes[i];
            }


            //Add labels for cumulative times if it's the fastest run
            if (isFastestRun)
            {
                for (int i = 0; i < cumulativeLapTimes.Length; i++)
                {
                    string timeString = TimeFormatter.ConvertMilisecondsToMinutesString(cumulativeLapTimes[i]);
                    string formattedTimeString = (cumulativeLapTimes[i] < 600000)? " " + timeString : timeString;
                    Label cumulativeLapTimeLabel = new()
                    {
                        Text = formattedTimeString,
                        Visible = true,
                        Location = new Point(OFFSET_X_FIRST_CUMLAPTIME, OFFSET_Y_FIRST_LAPTIME + OFFSET_Y_LAP * i),
                        Size = new Size(SIZE_X_CUMLAPTIME, SIZE_Y_SINGLELINE),

                    };
                    box.Controls.Add(cumulativeLapTimeLabel);
                }
            } 
            else //Add labels for comparing to cumulative times of the fastest run
            {

            }
        }

        /// <summary>
        /// This function takes the RunInformation of the fastest run, adds up sector times and makes the lap times cumulative. 
        /// </summary>
        /// <param name="fastestRun">The fastest run of the provided runs.</param>
        private void FillLapTimeOfFastestRun(RunInformation fastestRun)
        {
            //Create two arrays with amount of laps of the fastest run
            int[] tempArrayLapTimes = new int[amountOfLapsFastestRun];
            CumulativeLapTimesFastestRun = new int[amountOfLapsFastestRun];

            //Create lap times out of sector information set
            foreach (SectorInformation sector in fastestRun.SectorList)
            {
                tempArrayLapTimes[sector.LapNumber] += sector.DrivenSectorTime;
            }

            //Prepare first entry to avoid out of bounds reads
            CumulativeLapTimesFastestRun[0] = tempArrayLapTimes[0];

            //Make a cumulative array
            for (int i = 1; i < tempArrayLapTimes.Length; i++) 
            {
                CumulativeLapTimesFastestRun[i] = tempArrayLapTimes[i] + CumulativeLapTimesFastestRun[i - 1];
            }
        }


    }
}
