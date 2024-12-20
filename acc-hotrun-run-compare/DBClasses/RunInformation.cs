﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace acc_hotrun_run_compare.DBClasses
{
    /// <summary>
    /// This class is to create objects for completed runs. 
    /// It contains comperators to compare runs by the date/time of creation, the fastest lap and the total time, all ascending and descending.
    /// </summary>
    public class RunInformation
    {
        public IList<SectorInformation> SectorList { get; set; }
        public string TrackName { get; set; }
        public string CarName { get; set; }
        public int DrivenTime { get; set; }
        public int FastestLap { get; set; }
        public int SessionTime { get; set; }
        public bool PenaltyOccured { get; set; }
        public long RunID { get; set; }
        public DateTime RunCreatedDateTime { get; set; }
        public string RunDescription { get; set; }
        public string ?DriverName { get; set; }




        public RunInformation(string trackName, string carName, int fastestLap, int sessionTime, bool penaltyOccured, IList<SectorInformation> sectorList)
        {
            TrackName = trackName;
            CarName = carName;
            FastestLap = fastestLap;
            SessionTime = sessionTime;
            PenaltyOccured = penaltyOccured;
            SectorList = sectorList;
            int tempDrivenTime = 0;
            foreach (SectorInformation item in sectorList)
            {
                tempDrivenTime += item.DrivenSectorTime;
            }
            DrivenTime = tempDrivenTime;
            RunDescription = "";
        }

        public RunInformation(string trackName, string carName, int drivenTime, int fastestLap, int sessionTime, bool penaltyOccured, IList<SectorInformation> sectorList)
        {
            TrackName = trackName;
            CarName = carName;
            DrivenTime = drivenTime;
            FastestLap = fastestLap;
            SessionTime = sessionTime;
            PenaltyOccured = penaltyOccured;
            SectorList = sectorList;
            RunCreatedDateTime = DateTime.Now;
            RunCreatedDateTime = DateTime.SpecifyKind(RunCreatedDateTime, DateTimeKind.Local);
            RunDescription = "";
        }

        public RunInformation(string trackName, string carName, int drivenTime, int fastestLap, int sessionTime, bool penaltyOccured)
        {
            TrackName = trackName;
            CarName = carName;
            DrivenTime = drivenTime;
            FastestLap = fastestLap;
            SessionTime = sessionTime;
            PenaltyOccured = penaltyOccured;
            SectorList = [];
            RunDescription = "";
        }

        public RunInformation(string trackName, string carName, int drivenTime, int fastestLap, int sessionTime, bool penaltyOccured, DateTime runCreatedAt, IList<SectorInformation> sectorList)
        {
            TrackName = trackName;
            CarName = carName;
            DrivenTime = drivenTime;
            FastestLap = fastestLap;
            SessionTime = sessionTime;
            PenaltyOccured = penaltyOccured;
            RunCreatedDateTime = runCreatedAt;
            SectorList = sectorList;
            RunDescription = "";
        }

        public static string GetComparerNameFromComparer(Comparer<RunInformation> comparer)
        {
            ArgumentNullException.ThrowIfNull(comparer);

            if (comparer.GetType() == typeof(RunInformationComparerFastestLapFirst))
            {
                return FormStrings.SortByFastestLapShortestFirst;
            }
            if (comparer.GetType() == typeof(RunInformationComparerFastestLapLast))
            {
                return FormStrings.SortByFastestLapShortestLast;
            }
            if (comparer.GetType() == typeof(RunInformationComparerFastestRunFirst))
            {
                return FormStrings.SortByTotalTimeShortestFirst;
            }
            if (comparer.GetType() == typeof(RunInformationComparerFastestRunLast))
            {
                return FormStrings.SortByTotalTimeShortestLast;
            }
            if (comparer.GetType() == typeof(RunInformationComparerOldestDateFirst))
            {
                return FormStrings.SortByDateOldestFirst;
            }
            if (comparer.GetType() == typeof(RunInformationComparerOldestDateLast))
            {
                return FormStrings.SortByDateOldestLast;
            }
            return "unknown_comparer";
        }

        public static Comparer<RunInformation> GetComparerFromComparerName(string comparerName)
        {
            Comparer<RunInformation> comparer = comparerName switch
            {
                FormStrings.SortByTotalTimeShortestFirst => new RunInformationComparerFastestRunFirst(),
                FormStrings.SortByTotalTimeShortestLast => new RunInformationComparerFastestRunLast(),
                FormStrings.SortByFastestLapShortestLast => new RunInformationComparerFastestLapFirst(),
                FormStrings.SortByFastestLapShortestFirst => new RunInformationComparerFastestLapLast(),
                FormStrings.SortByDateOldestFirst => new RunInformationComparerOldestDateFirst(),
                FormStrings.SortByDateOldestLast => new RunInformationComparerOldestDateLast(),
                _ => new RunInformationComparerFastestRunFirst(),
            };
            return comparer;
        }

        /// <summary>
        /// Returns an array of all laptimes sorted by lapnumber.
        /// </summary>
        /// <returns>An array of all laptimes sorted by lapnumber.</returns>
        public int[] GetLaptimes()
        {
            int[] laptimes = new int[SectorList.Count / 3];
            //Each lap has exactly three sectors

            foreach (SectorInformation sector in SectorList)
            {
                laptimes[sector.LapNumber] += sector.DrivenSectorTime;
            }
            return laptimes;
        }
    }

    public class RunInformationComparerFastestRunFirst : Comparer<RunInformation>
    {
        public override int Compare(RunInformation? x, RunInformation? y)
        {
            ArgumentNullException.ThrowIfNull(x);
            ArgumentNullException.ThrowIfNull(y);

            if (x.SectorList.Count < y.SectorList.Count)
            { return 1; }

            if (y.SectorList.Count < x.SectorList.Count)
            { return -1; }


            return x.DrivenTime - y.DrivenTime;
        }
    }

    public class RunInformationComparerFastestRunLast : Comparer<RunInformation>
    {
        public override int Compare(RunInformation? x, RunInformation? y)
        {
            ArgumentNullException.ThrowIfNull(x);
            ArgumentNullException.ThrowIfNull(y);

            if (x.SectorList.Count < y.SectorList.Count)
            { return -1; }

            if (y.SectorList.Count < x.SectorList.Count)
            { return 1; }

            return y.DrivenTime - x.DrivenTime;
        }
    }

    public class RunInformationComparerFastestLapFirst : Comparer<RunInformation>
    {
        public override int Compare(RunInformation? x, RunInformation? y)
        {
            ArgumentNullException.ThrowIfNull(x);
            ArgumentNullException.ThrowIfNull(y);

            return y.FastestLap - x.FastestLap;
        }
    }

    public class RunInformationComparerFastestLapLast : Comparer<RunInformation>
    {
        public override int Compare(RunInformation? x, RunInformation? y)
        {
            ArgumentNullException.ThrowIfNull(x);
            ArgumentNullException.ThrowIfNull(y);

            return x.FastestLap - y.FastestLap;
        }
    }


    public class RunInformationComparerOldestDateFirst : Comparer<RunInformation>
    {
        public override int Compare(RunInformation? x, RunInformation? y)
        {
            ArgumentNullException.ThrowIfNull(x);
            ArgumentNullException.ThrowIfNull(y);

            return x.RunCreatedDateTime.CompareTo(y.RunCreatedDateTime);
        }
    }

    public class RunInformationComparerOldestDateLast : Comparer<RunInformation>
    {
        public override int Compare(RunInformation? x, RunInformation? y)
        {
            ArgumentNullException.ThrowIfNull(x);
            ArgumentNullException.ThrowIfNull(y);

            return y.RunCreatedDateTime.CompareTo(x.RunCreatedDateTime);
        }
    }

}
