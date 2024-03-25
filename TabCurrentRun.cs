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
                        labelCurrentRunLaps.Text = "Lap  1 | ";
                        labelCurrentRunSectors.Text = "";
                        labelCurrentRunInfo.Text = "";
                    }

                    if (stringTokens[0].Equals("carname"))
                    {
                        labelCurrentRunInfo.Text += "Car: ";
                        labelCurrentRunInfo.Text += stringTokens[1];
                        labelCurrentRunInfo.Text += "\r\n";
                    }

                    if (stringTokens[0].Equals("trackname"))
                    {
                        labelCurrentRunInfo.Text += "Track: ";
                        labelCurrentRunInfo.Text += stringTokens[1];
                        labelCurrentRunInfo.Text += "\r\n";
                    }

                    if (stringTokens[0].Equals("sessionlength"))
                    {
                        labelCurrentRunInfo.Text += "Session Length";
                        labelCurrentRunInfo.Text += stringTokens[1];
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
                    }

                    if (stringTokens[0].Equals("lapend"))
                    {
                        labelCurrentRunLaps.Text += stringTokens[1];
                        labelCurrentRunLaps.Text += "\r\n";
                    }

                    if (stringTokens[0].Equals("sector"))
                    {
                        if (stringTokens[1].Equals("s0"))
                        {
                            labelCurrentRunSectors.Text += stringTokens[2];
                            labelCurrentRunSectors.Text += " ";
                        }
                        if (stringTokens[1].Equals("s1"))
                        {
                            labelCurrentRunSectors.Text += stringTokens[2];
                            labelCurrentRunSectors.Text += " ";
                        }
                        if (stringTokens[1].Equals("s2"))
                        {
                            labelCurrentRunSectors.Text += stringTokens[2];
                            labelCurrentRunSectors.Text += "\r\n";
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

    }
}
