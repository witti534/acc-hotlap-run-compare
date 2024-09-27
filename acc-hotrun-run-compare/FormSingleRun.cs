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
        RunInformation providedRun;
        StoredRunContext storedRunContext = StoredRunContext.GetInstance();

        const int XOFFSETLAPNUMBER = 17;
        const int XOFFSETLAPTIME = 124;
        const int XOFFSETSSECTOR0 = 271;
        const int XOFFSETLIMITER0 = 358;
        const int XOFFSETSSECTOR1 = 385;
        const int XOFFSETLIMITER1 = 472;
        const int XOFFSETSSECTOR2 = 499;

        const int YOFFSETSTATIC = 200;
        const int YOFFSETEACHLAP = 30;

        const int SIZEXLABELTIME = 79;
        const int SIZEXLABELLIMITER = 19;
        const int SIZEXLABELLAPNUMBER = 99;
        const int SIZEXLABELLAPTIME = 89;
        const int SIZEYLABEL = 19;

        public FormSingleRun(RunInformation providedRun)
        {
            InitializeComponent();
            this.providedRun = providedRun;
            DeleteDesignLabels();
            FillUpRunInformation();
            FillUpSectorAndLapInformation();
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
        /// This function is used to fill up the panel with all lap times and sector times
        /// </summary>
        private void FillUpSectorAndLapInformation()
        {

            //Retrieve all sectors for the given runID
            var sectorList = from sector in storedRunContext.SectorInformationSet
                             where sector.RunID == providedRun.RunID
                             select sector;

            int[] laptimes = new int[(sectorList.Count() / 3)]; //Each lap has exactly 3 sectors
            //Make an array for each lap

            //First do sectors, then laptimes
            foreach (SectorInformation sector in sectorList)
            {
                //Add curent sector time to lap time
                laptimes[sector.LapNumber] = laptimes[sector.LapNumber] + sector.DrivenSectorTime;

                Label sectorTimeLabel = new();

                if (sector.SectorIndex == 0)
                {
                    //Create label sectorIndex 0                    
                    sectorTimeLabel.Location = new Point(XOFFSETSSECTOR0, YOFFSETSTATIC + sector.LapNumber * YOFFSETEACHLAP);

                    //Create a label with the text "|" to seperate the sector times
                    Label limiterLabelSector0 = new()
                    {
                        Text = "|",
                        Size = new Size(SIZEXLABELLIMITER, SIZEYLABEL),
                        Location = new Point(XOFFSETLIMITER0, YOFFSETSTATIC + sector.LapNumber * YOFFSETEACHLAP),
                        Visible = true
                    };
                    Controls.Add(limiterLabelSector0);

                }
                else if (sector.SectorIndex == 1)
                {

                    sectorTimeLabel.Location = new Point(XOFFSETSSECTOR1, YOFFSETSTATIC + sector.LapNumber * YOFFSETEACHLAP);
                    //Do stuff for sectorIndex 1

                    //Create a label with the text "|" to seperate the sector times
                    Label limiterLabelSector1 = new()
                    {
                        Text = "|",
                        Size = new Size(SIZEXLABELLIMITER, SIZEYLABEL),
                        Location = new Point(XOFFSETLIMITER1, YOFFSETSTATIC + sector.LapNumber * YOFFSETEACHLAP),
                        Visible = true
                    };
                    Controls.Add(limiterLabelSector1);
                }
                else
                {

                    sectorTimeLabel.Location = new Point(XOFFSETSSECTOR2, YOFFSETSTATIC + sector.LapNumber * YOFFSETEACHLAP);
                    //Do stuff for sectorIndex 2
                }

                sectorTimeLabel.Name = "sectortimelabel|" + sector.LapNumber + "|" + sector.SectorIndex;
                sectorTimeLabel.Text = TimeFormatter.CreateThreeFixedDigitsSecondsString(sector.DrivenSectorTime);
                sectorTimeLabel.Size = new Size(SIZEXLABELTIME, SIZEYLABEL);
                sectorTimeLabel.Visible = true;
                Controls.Add(sectorTimeLabel);

            }

            //Add laps labels to form
            for (int lap = 0; lap < laptimes.Length; lap++)
            {
                Label lapNumberLabel = new()
                {
                    Size = new Size(SIZEXLABELLAPNUMBER, SIZEYLABEL),
                    Text = (lap < 9) ? "Lap   " + (lap + 1) + " | " : "Lap  " + (lap + 1) + " | ",
                    Location = new Point(XOFFSETLAPNUMBER, YOFFSETSTATIC + lap * YOFFSETEACHLAP),
                    Visible = true
                };

                Controls.Add(lapNumberLabel);

                Label lapTimeLabel = new()
                {
                    Size = new Size(SIZEXLABELLAPTIME, SIZEYLABEL),
                    Text = TimeFormatter.CreateMinutesString(laptimes[lap]),
                    Location = new Point(XOFFSETLAPTIME, YOFFSETSTATIC + lap * YOFFSETEACHLAP),
                    Visible = true
                };

                Controls.Add(lapTimeLabel);
            }
        }

        /// <summary>
        /// This function is called to remove all the labels in the form which are used in the designer
        /// </summary>
        private void DeleteDesignLabels()
        {
            Controls.Remove(labelLapDelete);
            Controls.Remove(labelLapTimeDelete);
            Controls.Remove(labelSector1Delete);
            Controls.Remove(labelSector2Delete);
            Controls.Remove(labelSector3Delete);
            Controls.Remove(labelSeperator1Delete);
            Controls.Remove(labelSeperator2Delete);
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
    }
}
