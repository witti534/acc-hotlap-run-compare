using acc_hotrun_run_compare.DBClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace acc_hotrun_run_compare
{
    public partial class FormSingleRun : Form
    {
        readonly RunInformation providedRun;
        readonly StoredRunContext storedRunContext = StoredRunContext.GetInstance();

        private SectorInformation[] sortedSectorList;
        private int[] lapTimes;

        private int bestSector1Time = Int32.MaxValue;
        private Label bestSector1Label;
        private int bestSector2Time = Int32.MaxValue;
        private Label bestSector2Label;
        private int bestSector3Time = Int32.MaxValue;
        private Label bestSector3Label;
        private int bestLapTime = Int32.MaxValue;
        private Label bestLapTimeLabel;

        const int XOFFSETLAPNUMBER = 3;
        const int XOFFSETLAPTIME = 420;
        const int XOFFSETSSECTOR0 = 99;
        const int XOFFSETSSECTOR1 = 184;
        const int XOFFSETSSECTOR2 = 269;
        const int XOFFSETLAPPANEL = 13;

        const int YOFFSETSTATIC = 213;
        const int YOFFSETEACHLAP = 25;

        const int SIZEXLAPPANEL = 512;
        const int SIZEYLABEL = 19;

        public FormSingleRun(RunInformation providedRun)
        {
            if (providedRun == null)
            {
                MessageBox.Show("Something went wrong opening the single run information screen. Please contact the developer.");
                Close();
                return;
            }
            InitializeComponent();
            this.providedRun = providedRun;
            DeleteDesignLabels();
            FillUpRunInformation();
            PrepareTimeInformation();
            CreateLapPanelsAndLabels();
            ManipulateLabelsForFastestsTimes();
            SetupAdditionalInfoPanel();
        }

        /// <summary>
        /// This function reads the text from the only textbox and saves the content as the RunDescription for a run information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSaveRunInfoText_Click(object sender, EventArgs e)
        {
            providedRun.RunDescription = TextBoxRunDescription.Text;
            storedRunContext.SaveChanges();
            TabCompareRuns.instance.RedrawPanelWithRunsToBeCompared();
        }

        /// <summary>
        /// This function fills up the label for the static run information and the text boxes with information from the provided run.
        /// </summary>
        private void FillUpRunInformation()
        {
            labelRunInfoStatic.Text = "Track: " + providedRun.TrackName +
                "\r\nCar: " + providedRun.CarName +
                "\r\nSession length: " + (providedRun.SessionTime / 60000).ToString() + " min"; //miliseconds to minutes
            TextBoxRunDescription.Text = providedRun.RunDescription;
            labelRunTotalTime.Text = "Total Run Time: " + TimeFormatter.CreateHoursString(providedRun.DrivenTime);
            if (providedRun.DriverName != null)
            {
                TextBoxDriverName.Text = providedRun.DriverName;
            }
            else
            {
                TextBoxDriverName.Text = "";
            }
        }

        /// <summary>
        /// This function is used to prepare the sector times and lap times which will be used later on. Information will be stored in class arrays.
        /// </summary>
        private void PrepareTimeInformation()
        {

            //Retrieve all sectors for the given runID
            var maybeUnsortedSectorList = from sector in storedRunContext.SectorInformationSet
                                          where sector.RunID == providedRun.RunID
                                          select sector;

            lapTimes = new int[(maybeUnsortedSectorList.Count() / 3)]; //Each lap has exactly 3 sectors
            //Make an array for each lap

            sortedSectorList = new SectorInformation[maybeUnsortedSectorList.Count()];

            foreach (SectorInformation maybeUnsortedSector in maybeUnsortedSectorList)
            {
                //Make sure we have a sorted list of sector entries
                int arraySectorIndex = maybeUnsortedSector.SectorIndex + maybeUnsortedSector.LapNumber * 3;
                sortedSectorList[arraySectorIndex] = maybeUnsortedSector;

            }

            //Populate the list of laptimes with sector values
            foreach (SectorInformation sortedSector in sortedSectorList)
            {
                lapTimes[sortedSector.LapNumber] += sortedSector.DrivenSectorTime;
            }

        }

        /// <summary>
        /// This function is called to remove all the labels in the form which are used in the designer
        /// </summary>
        private void DeleteDesignLabels()
        {
            Controls.Remove(DesignerLabelL1S1);
            Controls.Remove(DesignerLabelL1S2);
            Controls.Remove(DesignerLabelL1S3);
            Controls.Remove(DesignerLabelLap1);
            Controls.Remove(DesignerLabelLap2);
            Controls.Remove(DesignerPanel1);
            Controls.Remove(DesignerPanel2);
            Controls.Remove(DesignerLabelTotalLaptime);
        }

        /// <summary>
        /// This function is used to update the driver name of the provided run.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSaveDriverName_Click(object sender, EventArgs e)
        {
            providedRun.DriverName = TextBoxDriverName.Text;
            storedRunContext.SaveChanges();
        }

        /// <summary>
        /// This function creates all the panels and labels for each single lap. Also the values and references for the fastest laps/sectors will be set here.
        /// </summary>
        private void CreateLapPanelsAndLabels()
        {
            //Create a panel for each lap
            for (int lapNumber = 0; lapNumber < lapTimes.Length; lapNumber++)
            {
                //prepare laptimes for each sector of a lap, read them from the sorted sector list array
                int timeSector1 = sortedSectorList[lapNumber * 3 + 0].DrivenSectorTime;
                int timeSector2 = sortedSectorList[lapNumber * 3 + 1].DrivenSectorTime;
                int timeSector3 = sortedSectorList[lapNumber * 3 + 2].DrivenSectorTime;
                int lapTime = lapTimes[lapNumber];
                string lapNumberString = (lapNumber < 9) ? "Lap  " + (lapNumber + 1) : "Lap " + (lapNumber + 1);
                //Add an additional space if displayed lap number has only 1 digit

                Color backgroundColor = (lapNumber % 2 == 0) ? Color.Silver : Color.LightGray;

                // The panel has all information (labels) for a single lap
                Panel lapInfoPanel = new()
                {
                    Size = new Size(SIZEXLAPPANEL, SIZEYLABEL),
                    BackColor = backgroundColor,
                    Location = new Point(XOFFSETLAPPANEL, YOFFSETSTATIC + lapNumber * SIZEYLABEL)
                };

                // Monospace font so it will look better above/below each other
                Font timeFont = new("Noto Mono", 12);

                // A few labels containing the sector values
                Label sector1Label = new()
                {
                    Name = "sectorLabel|" + lapNumber + "|1",
                    Text = TimeFormatter.CreateThreeFixedDigitsSecondsString(timeSector1),
                    Location = new Point(XOFFSETSSECTOR0, 0),
                    Font = timeFont,
                };

                Label sector2Label = new()
                {
                    Name = "sectorLabel|" + lapNumber + "|2",
                    Text = TimeFormatter.CreateThreeFixedDigitsSecondsString(timeSector2),
                    Location = new Point(XOFFSETSSECTOR1, 0),
                    Font = timeFont,
                };
                Label sector3Label = new()
                {
                    Name = "sectorLabel|" + lapNumber + "|3",
                    Text = TimeFormatter.CreateThreeFixedDigitsSecondsString(timeSector3),
                    Location = new Point(XOFFSETSSECTOR2, 0),
                    Font = timeFont,
                };
                Label lapTimeLabel = new()
                {
                    Name = "lapTimeLabel|" + lapNumber,
                    Text = TimeFormatter.CreateMinutesString(lapTime),
                    Location = new Point(XOFFSETLAPTIME, 0),
                    Font = timeFont,
                };
                Label lapNumberLabel = new()
                {
                    Name = "lapNumberLabel|" + lapNumber,
                    Text = lapNumberString,
                    Font = timeFont,
                };

                // Update values for fastest sector times in case there was a faster sector (both the value itself and a reference to the label
                // Label can be updated later with special font coloring 
                if (timeSector1 < bestSector1Time)
                {
                    bestSector1Time = timeSector1;
                    bestSector1Label = sector1Label;
                }
                if (timeSector2 < bestSector2Time)
                {
                    bestSector2Time = timeSector2;
                    bestSector2Label = sector2Label;
                }
                if (timeSector3 < bestSector3Time)
                {
                    bestSector3Time = timeSector3;
                    bestSector3Label = sector3Label;
                }
                if (lapTime < bestLapTime)
                {
                    bestLapTime = lapTime;
                    bestLapTimeLabel = lapTimeLabel;
                }

                //Add each lap time to the panel, afterwards add the panel to the form
                lapInfoPanel.Controls.Add(sector1Label);
                lapInfoPanel.Controls.Add(sector2Label);
                lapInfoPanel.Controls.Add(sector3Label);
                lapInfoPanel.Controls.Add(lapTimeLabel);
                lapInfoPanel.Controls.Add(lapNumberLabel);
                Controls.Add(lapInfoPanel);


            }
        }

        /// <summary>
        /// This function sets all the labels for the additional run info panel
        /// </summary>
        private void SetupAdditionalInfoPanel()
        {
            string averageLapTimeString = "Average lap time: " + TimeFormatter.CreateMinutesString(CalculateAverageLapTime(lapTimes));

            decimal standardDeviationSeconds = Math.Truncate(Convert.ToDecimal(CalculateMeanDeviation(lapTimes))) / 1000;
            string standardDeviationString = "Standard deviation: " + standardDeviationSeconds;

            string potentialFastestLapString = "Potential fastest lap: " + TimeFormatter.CreateMinutesString(bestSector1Time + bestSector2Time + bestSector3Time);

            string finalText = averageLapTimeString + "\r\n"
                + standardDeviationString + "\r\n"
                + potentialFastestLapString;
            LabelAdditionalRunInfo.Text = finalText;
        }

        /// <summary>
        /// This function calculates the average lap time over an array consisting lap times. 
        /// Output is an integer because a float output would not provide any beneficial accuracy. 
        /// </summary>
        /// <param name="lapTimes">An integer array consisting of all lap times of a run.</param>
        /// <returns></returns>
        private static int CalculateAverageLapTime(int[] lapTimes)
        {
            int sum = 0;
            foreach (int lapTime in lapTimes)
            {
                sum += lapTime;
            }

            return sum / lapTimes.Length;
        }

        /// <summary>
        /// This function calculates the standard deriviation for the data set of lap times.
        /// </summary>
        /// <param name="lapTimes">An integer array consisting of all lap times of a run.</param>
        /// <returns></returns>
        private static double CalculateMeanDeviation(int[] lapTimes)
        {
            int meanLapTime = CalculateAverageLapTime(lapTimes);
            double squaredDifferencesSum = 0;
            for (int i = 0; i < lapTimes.Length; i++)
            {
                squaredDifferencesSum += Math.Pow((lapTimes[i] - meanLapTime), 2);
            }
            double squaredDifferencesMean = squaredDifferencesSum / lapTimes.Length;
            return Math.Sqrt(squaredDifferencesMean);
        }

        /// <summary>
        /// Setting the colors for the labels for the fastest times to a purple color.
        /// Purple is the standard color for the fastest time in the domain of motorsport.
        /// </summary>
        private void ManipulateLabelsForFastestsTimes()
        {
            bestSector1Label.ForeColor = Color.Purple;
            bestSector2Label.ForeColor = Color.Purple;
            bestSector3Label.ForeColor = Color.Purple;
            bestLapTimeLabel.ForeColor = Color.Purple;
        }

        /// <summary>
        /// Opens a new Frame containing the graph of a 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonOpenLaptimesGraph_Click(object sender, EventArgs e)
        {
            List<RunInformation> providedRunsList = [providedRun];
            Graphs.GraphLaptimes _ = new(providedRunsList)
            {
                Visible = true
            };
        }
    }
}
