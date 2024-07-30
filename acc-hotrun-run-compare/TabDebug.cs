using acc_hotrun_run_compare.DBClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace acc_hotrun_run_compare
{
    /// <summary>
    /// This class contains functions for the debug tab.
    /// </summary>
    internal class TabDebug(StoredRunContext storedRunContext)
    {
        readonly StoredRunContext StoredRunContext = storedRunContext;
        readonly Random RandomNumberGenerator = new();

        /// <summary>
        /// In this class a new RunInformation is created with debug info
        /// </summary>
        /// <param name="debugBox"></param>
        /// <returns></returns>
        public RunInformation CreateDebugRun(GroupBox debugBox)
        {
            //Search the debugBox for the textBox for the lap amount
            var controlsLaps = debugBox.Controls.Find("debugTextBoxLapAmount", true);
            if (controlsLaps == null)
            {
                return null;
            }

            //Search the debugBox for the textBox for the car name
            var controlsCarNames = debugBox.Controls.Find("debugTextBoxCarName", true);
            if (controlsCarNames == null)
            {
                return null;
            }

            //Search the debugBox for the textBox for the track name
            var controlsTrackNames = debugBox.Controls.Find("debugTextBoxTrackname", true);
            if (controlsTrackNames == null)
            {
                return null;
            }

            var controlsDebugTextBoxes = debugBox.Controls.Find("debugTextbox1", true); 
            if (controlsDebugTextBoxes == null)
            {
                return null;
            }
            TextBox debugTextBox = (TextBox) controlsDebugTextBoxes[0];

            //begin get user input
            string tmpLapAmountRaw = controlsLaps[0].Text;
            string tmpCarNameRaw = controlsCarNames[0].Text;
            string tmpTrackNameRaw = controlsTrackNames[0].Text;

            bool isAnInteger;
            isAnInteger = int.TryParse(tmpLapAmountRaw, out int tmpLapAmount);
            //end get user input

            int totalDrivenTime = 0;
            int fastestLap = int.MaxValue;
            List<SectorInformation> sectorList = [];

            //Ensure only valid numbers get accepted
            if (isAnInteger)
            {
                if (tmpLapAmount > 0)
                {

                    debugTextBox.Text = "\r\nLap amount: " + tmpLapAmount.ToString() + debugTextBox.Text;

                    //Create Sector information

                    //Create specified amount of laps
                    for (int lapIndex = 0; lapIndex < tmpLapAmount; lapIndex++)
                    {
                        int sector0Time = int.MaxValue;
                        int sector1Time = int.MaxValue;
                        int sector2Time = int.MaxValue;

                        //Create 3 sectors for each lap
                        for (int sectorIndex = 0; sectorIndex <= 2; sectorIndex++)
                        {
                            int sectorTime = RandomNumberGenerator.Next(20000) + 40000; //give a sector time which is between 40 and 60 seconds
                            SectorInformation secInf = new(lapIndex, sectorIndex, sectorTime);
                            sectorList.Add(secInf);
                            totalDrivenTime += sectorTime;

                            //Set sectorTimes for fastest lap calculation
                            if (sectorIndex == 0)
                            {
                                sector0Time = sectorTime;
                            }
                            if (sectorIndex == 1)
                            {
                                sector1Time = sectorTime;
                            }
                            if (sectorIndex == 2)
                            {
                                sector2Time = sectorTime;
                            }
                        }

                        int lapTime = sector0Time + sector1Time + sector2Time;

                        //Check for new fastest lap
                        if (lapTime < fastestLap)
                        {
                            fastestLap = lapTime;
                        }
                    }



                }

                //Debug information
                foreach (SectorInformation secInf in sectorList)
                {
                    debugTextBox.Text = "\r\nNew Record added:\r\n--Lap: " + secInf.LapNumber + "\r\n--Sector: "
                        + secInf.SectorIndex + "\r\n--Time: " + secInf.DrivenSectorTime + debugTextBox.Text;
                }

                RunInformation randomRunInformation = new (tmpTrackNameRaw, tmpCarNameRaw, totalDrivenTime, fastestLap, (15 * 60 * 1000), true, sectorList);

                return randomRunInformation;
            }

            return null; //return if something went wrong

        }

    }
}
