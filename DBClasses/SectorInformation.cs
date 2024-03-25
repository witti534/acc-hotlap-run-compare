using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acc_hotlab_private_run_compare.DBClasses
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
    }
}
