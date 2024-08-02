using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acc_hotrun_run_compare.DBClasses
{
    /// <summary>
    /// A class to hold information about a sector (lap number, sector index, driven time and runID)
    /// </summary>
    public class SectorInformation
    {
        public int LapNumber { get; set; }
        public int SectorIndex { get; set; }
        public int DrivenSectorTime { get; set; }
        public long RunID { get; set; }

        public SectorInformation() { }

        public SectorInformation(long runInformation, int lapNumber, int sectorIndex, int drivenSectorTime)
        {
            this.RunID = runInformation;
            LapNumber = lapNumber;
            SectorIndex = sectorIndex;
            DrivenSectorTime = drivenSectorTime;
        }

        public SectorInformation(int lap, int sector, int drivenTime)
        {
            LapNumber = lap;
            SectorIndex = sector;
            DrivenSectorTime = drivenTime;
        }

        public static List<SectorInformation> SortListSectorInformation(List<SectorInformation> list)
        {
            if (list == null)
            {
                throw new ArgumentException("IllegalArgumentException: Provided list of SectorInformation is null.");
            }

            SectorInformation[] sectorArrayToBeSorted = new SectorInformation[list.Count];

            foreach (SectorInformation sector in list)
            {
                int lapSectorIndex = sector.LapNumber * 3 + sector.SectorIndex;

                if (sectorArrayToBeSorted[lapSectorIndex] != null)
                {
                    throw new Exception("Error in List<SectorInformation>: Multiple occurances of same lap/sector combination. There should only be one.");
                }
                if (lapSectorIndex >= sectorArrayToBeSorted.Length)
                {
                    throw new ArgumentOutOfRangeException(nameof(list), "Sector list is not continuous from lap 0 sector 0 towards last lap sector 2.");
                }

                sectorArrayToBeSorted[lapSectorIndex] = sector;
            }

            List<SectorInformation> returnList = new(sectorArrayToBeSorted);

            return returnList;
        }
    }
}
