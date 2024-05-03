using acc_hotlab_private_run_compare.DBClasses;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acc_hotlab_private_run_compare
{
    /// <summary>
    /// This class contains functions for the current run tab. 
    /// </summary>
    internal class TabCurrentRun (StoredRunContext storedRunContext)
    {
        readonly StoredRunContext StoredRunContext = storedRunContext;

        List<int[]> cumulativeSectorTimes = [];
        string trackName = "";
        string carName = "";
        int sessionLength = 0;
        bool allStaticRunDataProvided = false;
        bool cumulativeSectorTimesCalculated = false;
        int cumulativeRunTime = 0;
        int analyzedSectors = 0;
        int totalNumberOfComparableRuns = 0;

        /// <summary>
        /// It reads the strings from the AccCurrentRunInformationQueue and interpretes the information. 
        /// The strings are being split up by the token character |
        /// Three different labels get filled up with information.
        /// </summary>
        /// <param name="panel"></param>
        /// <param name="accRunInfoQueue"></param>
        public void UpdateCurrentRunInfo(Panel panel, ConcurrentQueue<string> accRunInfoQueue)
        {
            // Find Label in the panel and make them accessible 
            var controlsLabelRunInfo = panel.Controls.Find("labelCurrentRunInfo", true);
            Label labelCurrentRunInfo = (Label) controlsLabelRunInfo[0];

            var controlsLabelRunLaps = panel.Controls.Find("labelCurrentRunLaps", true);
            Label labelCurrentRunLaps = (Label) controlsLabelRunLaps[0];

            var controlsLabelRunSectors = panel.Controls.Find("labelCurrentRunSectors", true); 
            Label labelCurrentRunSectors = (Label)controlsLabelRunSectors[0];

            //work until queue is empty
            //interpret messages from the ACCGameStateReaderThread
            while (!accRunInfoQueue.IsEmpty)
            {
                bool operationWorked = accRunInfoQueue.TryDequeue(out string currentMsg);
                if (currentMsg == null)
                {
                    return;
                }
                if (operationWorked)
                {
                    string[] stringTokens = currentMsg.Split('|');

                    if (stringTokens[0].Equals("reset"))
                    {
                        ResetCurrentRunPosition();
                        labelCurrentRunLaps.Text = "Lap  1 | ";
                        labelCurrentRunSectors.Text = "";
                        labelCurrentRunInfo.Text = "";
                        continue;
                    }

                    if (stringTokens[0].Equals("carname"))
                    {
                        labelCurrentRunInfo.Text += "Car: ";
                        labelCurrentRunInfo.Text += stringTokens[1];
                        labelCurrentRunInfo.Text += "\r\n";
                        carName = stringTokens[1];
                        VerifyCompletenessOfRunData();
                        continue;
                    }

                    if (stringTokens[0].Equals("trackname"))
                    {
                        labelCurrentRunInfo.Text += "Track: ";
                        labelCurrentRunInfo.Text += stringTokens[1];
                        labelCurrentRunInfo.Text += "\r\n";
                        trackName = stringTokens[1];
                        VerifyCompletenessOfRunData();
                        continue;
                    }

                    if (stringTokens[0].Equals("sessionlength"))
                    {
                        labelCurrentRunInfo.Text += "Session Length: ";
                        labelCurrentRunInfo.Text += stringTokens[1];
                        sessionLength = ParseSessionLength(stringTokens[1]);
                        VerifyCompletenessOfRunData();
                        continue;
                    }

                    if (stringTokens[0].Equals("lapstart"))
                    {
                        string tempLapNumberString;
                        if (stringTokens[1].Length == 1)
                        {
                            tempLapNumberString = " " + stringTokens[1];
                        }
                        else
                        {
                            tempLapNumberString = stringTokens[1];
                        }

                        labelCurrentRunLaps.Text += "Lap ";
                        labelCurrentRunLaps.Text += tempLapNumberString;
                        labelCurrentRunLaps.Text += " | ";
                        continue;
                    }

                    if (stringTokens[0].Equals("lapend"))
                    {
                        labelCurrentRunLaps.Text += stringTokens[1];
                        labelCurrentRunLaps.Text += "\r\n";
                        continue;
                    }

                    // at the change of a sector
                    if (stringTokens[0].Equals("sector"))
                    {
                        if (!allStaticRunDataProvided)
                        {
                            accRunInfoQueue.Enqueue(currentMsg);
                        }
                        int sectorTimeValue = Int32.Parse(stringTokens[2]);
                        string sectorTimeString = TimeFormatter.ConvertMilisecondsToThreeFixedDigitsSecondsString(sectorTimeValue);
                        UpdateCurrentRunPosition(sectorTimeValue, panel);
                        if (stringTokens[1].Equals("s0"))
                        {
                            labelCurrentRunSectors.Text += sectorTimeString;
                            labelCurrentRunSectors.Text += " ";
                            continue;
                        }
                        if (stringTokens[1].Equals("s1"))
                        {
                            labelCurrentRunSectors.Text += sectorTimeString;
                            labelCurrentRunSectors.Text += " "; 
                            continue;
                        }
                        if (stringTokens[1].Equals("s2"))
                        {
                            labelCurrentRunSectors.Text += sectorTimeString;
                            labelCurrentRunSectors.Text += "\r\n";
                            continue;
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Takes a finished run RunInformation and displays several information of it as a string. 
        /// </summary>
        /// <param name="finishedRun"></param>
        /// <returns></returns>
        public static string CreateDisplayStringFromCompleteRunInformation(RunInformation finishedRun)
        {
            StringBuilder sb = new();

            if (finishedRun.SectorList.Count == 0)
            {
                return "No sectors have been driven.\r\n";
            }

            if (finishedRun.SectorList.Count % 3 != 0)
            {
                return "Not all laps have been completed.\r\n";
            }

            int numberOfLaps = finishedRun.SectorList.Count / 3;

            for (int i = 0; i < numberOfLaps; i++)
            {
                SectorInformation sector0 = (SectorInformation)finishedRun.SectorList[3 * i + 0];
                SectorInformation sector1 = (SectorInformation)finishedRun.SectorList[3 * i + 1];
                SectorInformation sector2 = (SectorInformation)finishedRun.SectorList[3 * i + 2];

                int lapTimeInt = sector0.DrivenSectorTime + sector1.DrivenSectorTime + sector2.DrivenSectorTime;
                string lapTimeFormated = TimeFormatter.ConvertMilisecondsToMinutesString(lapTimeInt);
                string sector0TimeFormated = TimeFormatter.ConvertMilisecondsToThreeFixedDigitsSecondsString(sector0.DrivenSectorTime);
                string sector1TimeFormated = TimeFormatter.ConvertMilisecondsToThreeFixedDigitsSecondsString(sector1.DrivenSectorTime);
                string sector2TimeFormated = TimeFormatter.ConvertMilisecondsToThreeFixedDigitsSecondsString(sector2.DrivenSectorTime);

                sb.Append("Lap ");
                sb.Append(i + 1);
                sb.Append(" | ");
                sb.Append(lapTimeFormated);
                sb.Append(" | ");
                sb.Append(sector0TimeFormated);
                sb.Append(' ');
                sb.Append(sector1TimeFormated);
                sb.Append(' ');
                sb.Append(sector2TimeFormated);
                sb.Append("\r\n");

            }
            return sb.ToString();
        }

        /// <summary>
        /// Call this function when a run has been reset to reset fields for trackname, carname and sessionlength.
        /// </summary>
        private void ResetCurrentRunPosition()
        {
            trackName = "";
            carName = "";
            sessionLength = 0;
            allStaticRunDataProvided = false;
            cumulativeSectorTimesCalculated = false;
            analyzedSectors = 0;
            cumulativeRunTime = 0;
            totalNumberOfComparableRuns = 0;
            cumulativeSectorTimes.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lastSectorTime">The sector time of exactly the last driven sector in ms</param>
        /// <param name="currentRunPanel">The panel which contains labels for the current run position</param>
        private void UpdateCurrentRunPosition(int lastSectorTime, Panel currentRunPanel)
        {
            cumulativeRunTime += lastSectorTime;
            int counterForFasterRuns = 0;
            foreach (int[] cumulativeSectorsArray in cumulativeSectorTimes)
            {
                if (analyzedSectors < cumulativeSectorsArray.Length)
                {
                    if (cumulativeRunTime < cumulativeSectorsArray[analyzedSectors])
                    {
                        counterForFasterRuns++;
                    }
                }
            }
            analyzedSectors++;
            var searchForPositionLabelResult = currentRunPanel.Controls.Find("labelPosition", true);
            Label currentPositionLabel = (Label)searchForPositionLabelResult[0];
            currentPositionLabel.Text = "Position " + (counterForFasterRuns + 1).ToString() + "/" + (totalNumberOfComparableRuns + 1).ToString();
        }

        /// <summary>
        /// This functions checks if proper values have been set for carname, trackname and sessionlength. 
        /// When all variables have good values, the flag runDataComplete will be set to true.
        /// </summary>
        private void VerifyCompletenessOfRunData()
        {
            if (carName.Length >= 0 && //a valid carname
                trackName.Length >= 0 && //a valid trackname
                sessionLength > 0) //a valid sessionlength
            {
                allStaticRunDataProvided = true; //change flag
            }

            if (!cumulativeSectorTimesCalculated && allStaticRunDataProvided)
            {
                CalculateCumulativeSectorTimes();
                cumulativeSectorTimesCalculated = true; //change flag
            }
        }

        /// <summary>
        /// Reads the trackname, sessionlength and carname and fetches runs from the database with the same values. 
        /// Then creaetes lists of cumulative sector times.
        /// </summary>
        private void CalculateCumulativeSectorTimes()
        {
            
            //get runs with matching carname, trackname and sessionlength
            List<RunInformation> listOfSelectedRuns = StoredRunContext.RunInformationSet
                .Where(run => run.TrackName == trackName 
                && run.SessionTime == sessionLength 
                && run.CarName == carName)
                .ToList();

            foreach (RunInformation run in listOfSelectedRuns)
            {
                var sectorInformationResults = StoredRunContext.SectorInformationSet
                    .Where(sector => sector.RunID == run.RunID)
                    .ToList();

                //Create two arrays, one for singular sector times and one for cumulative sector times
                int[] sectorTimesCurrentRun = new int[sectorInformationResults.Count];
                int[] cumulativeSectorTimesCurrentRun = new int[sectorInformationResults.Count];

                //put single sectors in right order in the array for sector times
                foreach (SectorInformation sector in sectorInformationResults)
                {
                    sectorTimesCurrentRun[3 * sector.LapNumber + sector.SectorIndex] = sector.DrivenSectorTime;
                }

                //special case first sector
                cumulativeSectorTimesCurrentRun[0] = sectorTimesCurrentRun[0];

                //add up sector times to be cumulative
                for (int i = 1; i < sectorTimesCurrentRun.Length; i++)
                {
                    cumulativeSectorTimesCurrentRun[i] = cumulativeSectorTimesCurrentRun[i - 1] + sectorTimesCurrentRun[i];
                }

                cumulativeSectorTimes.Add(cumulativeSectorTimesCurrentRun);
            }

            totalNumberOfComparableRuns = cumulativeSectorTimes.Count;
        }

        private int ParseSessionLength(string inputString)
        {
            switch (inputString){
                case "5 Minutes":
                    return 5 * 60 * 1000;
                case "10 Minutes":
                    return 10 * 60 * 1000;
                case "15 Minutes":
                    return 15 * 60 * 1000;
                case "30 Minutes":
                    return 30 * 60 * 1000;
                case "60 Minutes":
                    return 60 * 60 * 1000;
                default:
                    return 0;
            }
        }
    }
}
