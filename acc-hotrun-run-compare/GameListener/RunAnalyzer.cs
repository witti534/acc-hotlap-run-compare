using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using acc_hotrun_run_compare.DBClasses;

namespace acc_hotrun_run_compare.GameListener
{
    /// <summary>
    /// In this class information from ACC is being analyzed. It has different flags to be read for different stages/events of a run. 
    /// 
    /// </summary>
    internal class RunAnalyzer
    {
        public enum CollectInformationEnum
        {
            NOT_READY = 0,
            READY_FOR_STATICCOLLECTION = 1,
            COLLECTED = 2,
            READY_FOR_SESSIONLENGTHCOLLECTION = 3,
        }

        List<SectorInformation> sectors;

        private int analyzedSectorIndex = -1;
        private int analyzedLapNumber = -1;
        private bool sessionLengthGuessed = false;

        private int previousSector0Time = -1;
        private int previousSector1Time = -1;
        private int previousSector2Time = -1;

        private bool penaltyOccured = false; //internal flag
        private bool lastLap = false; //internal flag
        private int skipsRemainingSector = 3;
        private int skipsRemainingRun = 3;

        private string trackName = "DEBUG_STRING_TRACK";
        private string carName = "DEBUG_STRING_CARNAME";

        //Some constants for guessing the session length
        private static readonly float THREE_MIN_IN_MS = 1000 * 60 * 3;
        private static readonly float FIVE_MIN_IN_MS = 1000 * 60 * 5;
        private static readonly float EIGHT_MIN_IN_MS = 1000 * 60 * 8;
        private static readonly float TEN_MIN_IN_MS = 1000 * 60 * 10;
        private static readonly float THIRTEEN_MIN_IN_MS = 1000 * 60 * 13;
        private static readonly float FIFTEEN_MIN_IN_MS = 1000 * 60 * 15;
        private static readonly float TWENTYEIGHT_MIN_IN_MS = 1000 * 60 * 28;
        private static readonly float THIRTY_MIN_IN_MS = 1000 * 60 * 30;
        private static readonly float FIFTYEIGHT_MIN_IN_MS = 1000 * 60 * 58;
        private static readonly float SIXTY_MIN_IN_MS = 1000 * 60 * 60;


        public bool RunComplete { get; private set; } = false; //Global variable to check if a run is finished. Reset when run is being sent to main form
        public bool LapChanged {  get; private set; } = false;
        public bool SectorChanged { get; set; } = false;
        public CollectInformationEnum StartedNewRun { get; set; } = CollectInformationEnum.NOT_READY;
        public int AnalyzedLastSectorTime { get; private set; }
        public int AnalyzedLastSectorIndex { get; private set; }
        public ACCEnums.ACC_HOTSTINT_SESSION_LENGTH SessionLengthGuess { get; private set; } = ACCEnums.ACC_HOTSTINT_SESSION_LENGTH.INVALID;


        public RunAnalyzer() 
        { 
            sectors = [];
        }

        /// <summary>
        /// The central function for this class. Each time the graphics data gets refreshed, it gets analyzed in here.
        /// </summary>
        /// <param name="currentSectorIndex">The index of the current sector (0, 1 or 2)</param>
        /// <param name="lastSectorTime">The laptime when the last sector got changed</param>
        /// <param name="completedLapNumber">Amount of completed laps (is 0 in the first lap)</param>
        /// <param name="lastFlagStatus"></param>
        /// <param name="lastPenaltyStatus">Will be analyzed if a penalty occured</param>
        /// <param name="remainingTime">Remaining session time</param>
        /// <param name="lastLapTime">The last lap time in ms.</param>
        public void AnalyzeGraphics(int currentSectorIndex, 
            int lastSectorTime, 
            int completedLapNumber, 
            ACCEnums.AC_FLAG_TYPE lastFlagStatus,
            ACCEnums.PenaltyShortcut lastPenaltyStatus,
            float remainingTime,
            int lastLapTime)
        {
            
            // Don't collect data in first sector on the first lap
            if (completedLapNumber == 0 && currentSectorIndex == 0)
            {

                // Avoid resetting the run when there is a bad data read for less than 3 cycles
                if (skipsRemainingRun != 0)
                {
                    skipsRemainingRun--;
                    return;
                }
                else
                {
                    skipsRemainingRun = 3;
                }

                ResetRun();
                return;
            }

            skipsRemainingRun = 3;

            ///
            /// from here on it is after the first sector of the first lap
            ///

            // Allow static data to be collected and sent to the main form to reduce text draw functions on main form
            if (StartedNewRun == CollectInformationEnum.NOT_READY)
            {
                StartedNewRun = CollectInformationEnum.READY_FOR_STATICCOLLECTION;
            }

            // Guess the total hotstint session length by reading the remaining time after the first sector
            // For actual training sessions the second sector will always be reached within two minutes
            if (!sessionLengthGuessed)
            {
                sessionLengthGuessed = true;
                if (remainingTime > THREE_MIN_IN_MS && remainingTime < FIVE_MIN_IN_MS)
                {
                    SessionLengthGuess = ACCEnums.ACC_HOTSTINT_SESSION_LENGTH.FIVEMINUTES;
                } else if (remainingTime > EIGHT_MIN_IN_MS && remainingTime < TEN_MIN_IN_MS)
                {
                    SessionLengthGuess = ACCEnums.ACC_HOTSTINT_SESSION_LENGTH.TENMINUTES;
                } else if (remainingTime > THIRTEEN_MIN_IN_MS && remainingTime < FIFTEEN_MIN_IN_MS)
                {
                    SessionLengthGuess = ACCEnums.ACC_HOTSTINT_SESSION_LENGTH.FIFTEENMINUTES;
                } else if (remainingTime > TWENTYEIGHT_MIN_IN_MS && remainingTime < THIRTY_MIN_IN_MS)
                {
                    SessionLengthGuess = ACCEnums.ACC_HOTSTINT_SESSION_LENGTH.THIRTYMINUTES;
                } else if (remainingTime > FIFTYEIGHT_MIN_IN_MS && remainingTime < SIXTY_MIN_IN_MS)
                {
                    SessionLengthGuess = ACCEnums.ACC_HOTSTINT_SESSION_LENGTH.SIXTYMINUTES;
                } else
                {
                    SessionLengthGuess = ACCEnums.ACC_HOTSTINT_SESSION_LENGTH.INVALID;
                }
            }

            //Mark runs where the driver gathered a penalty 
            if (lastPenaltyStatus != ACCEnums.PenaltyShortcut.None)
            {
                penaltyOccured = true;
            }

            //Lap will be driven to the end, no further laps afterwards
            if (remainingTime == 0.0f)
            {
                lastLap = true;
            }

            if (currentSectorIndex != analyzedSectorIndex)
            {
                //Skip a few cycles to make sure the graphics page is completely updated
                if (skipsRemainingSector != 0)
                {
                    skipsRemainingSector--;
                    return;
                } 
                else //skipsRemaining == 0
                {
                    skipsRemainingSector = 3;
                }

                //Next sector started
                SectorChanged = true;

                if (currentSectorIndex == 1)
                {
                    //When driving into sector index 1/the second sector
                    previousSector0Time = lastSectorTime;
                    if (AnalyzedLastSectorTime == previousSector0Time)
                    {
                        //debugBreakpoint
                    }
                    AnalyzedLastSectorTime = previousSector0Time;
                    AnalyzedLastSectorIndex = 0;
                }
                else if (currentSectorIndex == 2)
                {
                    //When driving into sector index 2/the third sector
                    previousSector1Time = lastSectorTime - previousSector0Time;
                    if (AnalyzedLastSectorTime == previousSector1Time)
                    {
                        //debugBreakpoint
                    }
                    AnalyzedLastSectorTime = previousSector1Time;
                    AnalyzedLastSectorIndex = 1;
                }
                else
                { 
                    previousSector2Time = lastLapTime - previousSector0Time - previousSector1Time;
                    if (AnalyzedLastSectorTime == previousSector2Time)
                    {
                        //debugBreakpoint
                    }
                    AnalyzedLastSectorIndex = 2;
                    AnalyzedLastSectorTime = previousSector2Time;
                }

                if (completedLapNumber == analyzedLapNumber + 1 && completedLapNumber >= 1)
                {
                    LapChanged = true;

                    //Next lap started/driving into sector index 0/first sector
                    //Don't do it during the first lap to only record full valid laps because you start at lap -1 ingame.
                    previousSector2Time = lastLapTime - previousSector0Time - previousSector1Time;
                    AnalyzedLastSectorTime = previousSector2Time;
                    AnalyzedLastSectorIndex = 2;

                    //Create SectorInformation for each sector now

                    SectorInformation completeSector0 = new(analyzedLapNumber, 0, previousSector0Time);
                    SectorInformation completeSector1 = new(analyzedLapNumber, 1, previousSector1Time);
                    SectorInformation completeSector2 = new(analyzedLapNumber, 2, previousSector2Time);
                    sectors.Add(completeSector0);
                    sectors.Add(completeSector1);
                    sectors.Add(completeSector2);
                }

                // This combination can only happen when the driver crossed the finish line on the last lap
                if (lastLap && currentSectorIndex == 0 && analyzedSectorIndex == 2)
                {
                    RunComplete = true;
                }

                analyzedSectorIndex = currentSectorIndex;
                analyzedLapNumber = completedLapNumber;


            }

        }

        /// <summary>
        /// Read the static data (track name and car name)
        /// </summary>
        /// <param name="lastTrackName">Track name string</param>
        /// <param name="lastCarName">Car name string</param>
        public void AnalyzeStatic(string lastTrackName, string lastCarName)
        {
            trackName = lastTrackName;
            carName = lastCarName;
        }

        /// <summary>
        /// This function is being called when the remaining session time hit 0 and the lap has been completed.
        /// </summary>
        /// <returns>A completed RunInformation</returns>
        public RunInformation ReturnCompletedRun()
        {
            int totalDrivenTime = 0;

            // Add up all sector times to a total time
            foreach (SectorInformation sectorInfo in sectors)
            {
                totalDrivenTime += sectorInfo.DrivenSectorTime;
            }

            int fastestLap = GetFastestLap(sectors);

            int totalSessionLength = (int)SessionLengthGuess;


            RunInformation finishedRun = new(trackName,
                                             carName,
                                             totalDrivenTime,
                                             fastestLap,
                                             totalSessionLength,
                                             penaltyOccured,
                                             sectors);

            RunComplete = false; 
            return finishedRun;
        }

        /// <summary>
        /// A driver might restart a run at any point, therefore all flags and data must be reset again.
        /// </summary>
        private void ResetRun()
        {
            analyzedSectorIndex = -1;
            analyzedLapNumber = -1;
            penaltyOccured = false;
            lastLap = false;
            SessionLengthGuess = ACCEnums.ACC_HOTSTINT_SESSION_LENGTH.INVALID;
            sessionLengthGuessed = false;
            sectors.Clear();

            trackName = "DEBUG_STRING_TRACK";

            RunComplete = false;
            StartedNewRun = CollectInformationEnum.NOT_READY;
        }

        /// <summary>
        /// After a run finished get the fastest lap by going through all sectors.
        /// </summary>
        /// <param name="sectorArrayList">The list of all sectors. Must be a multiple of three</param>
        /// <returns></returns>
        private static int GetFastestLap (List<SectorInformation> sectorArrayList)
        {
            int lapNumber = sectorArrayList.Count / 3;
            if (sectorArrayList.Count % 3 != 0)
            {
                throw new Exception();
            }

            int fastestLap = Int32.MaxValue;

            object[] sectorList = sectorArrayList.ToArray();

            for (int i = 0; i < lapNumber; i++)
            {
                SectorInformation sector0Object = (SectorInformation)sectorList[i * 3 + 0];
                SectorInformation sector1Object = (SectorInformation)sectorList[i * 3 + 1];
                SectorInformation sector2Object = (SectorInformation)sectorList[i * 3 + 2];
                int sector0Time = sector0Object.DrivenSectorTime;
                int sector1Time = sector1Object.DrivenSectorTime;
                int sector2Time = sector2Object.DrivenSectorTime;

                if (sector0Time + sector1Time + sector2Time < fastestLap)
                {
                    fastestLap = sector0Time + sector1Time + sector2Time;
                }
            }

            return fastestLap;
        }

        /// <summary>
        /// This function gets called when the LapChanged flag is true.
        /// </summary>
        /// <returns></returns>
        public string GetGraphicsDebugDataAndChangeLapChangeStatus()
        {
            LapChanged = false;
            StringBuilder sb = new();
            sb.Append("Sector 1 Time: " + previousSector0Time + "\r\n");
            sb.Append("Sector 2 Time: " + previousSector1Time + "\r\n");
            sb.Append("Sector 3 Time: " + previousSector2Time + "\r\n");
            sb.Append("Lap number: " + (analyzedLapNumber - 1) + "\r\n");
            sb.Append("_______________\r\n");
            return sb.ToString();
        }


    }
}
