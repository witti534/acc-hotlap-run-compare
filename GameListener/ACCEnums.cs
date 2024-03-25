using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCEnums
{
    ///All enums of the possible ACC enums have been implemented

    /// <summary>
    /// Enum for the different ACC game modes
    /// </summary>
    public enum AC_SESSION_TYPE
    { 
        AC_UNKNOWN = -1,
        AC_PRACTICE = 0,
        AC_QUALIFY = 1,
        AC_RACE = 2,
        AC_HOTLAP = 3,
        AC_TIME_ATTACK = 4,
        AC_DRIFT = 5,
        AC_DRAG = 6,
        AC_HOTSTINT = 7,
        AC_HOTLAPSUPERPOLE = 8,
    }

    /// <summary>
    /// Enum for possible penalty shortcuts (only PostRaceTime used in here)
    /// </summary>
    public enum PenaltyShortcut : int
    {
        None,
        DriveThrough_Cutting,
        StopAndGo_10_Cutting,
        StopAndGo_20_Cutting,
        StopAndGo_30_Cutting,
        Disqualified_Cutting,
        RemoveBestLaptime_Cutting,

        DriveThrough_PitSpeeding,
        StopAndGo_10_PitSpeeding,
        StopAndGo_20_PitSpeeding,
        StopAndGo_30_PitSpeeding,
        Disqualified_PitSpeeding,
        RemoveBestLaptime_PitSpeeding,

        Disqualified_IgnoredMandatoryPit,

        PostRaceTime,
        Disqualified_Trolling,
        Disqualified_PitEntry,
        Disqualified_PitExit,
        Disqualified_WrongWay,

        DriveThrough_IgnoredDriverStint,
        Disqualified_IgnoredDriverStint,

        Disqualified_ExceededDriverStintLimit,
    }

    /// <summary>
    /// Enum for possible ACC (ingame racing) flags
    /// </summary>
    public enum AC_FLAG_TYPE
    {
        AC_NO_FLAG = 0,
        AC_BLUE_FLAG = 1,
        AC_YELLOW_FLAG = 2,
        AC_BLACK_FLAG = 3,
        AC_WHITE_FLAG = 4,
        AC_CHECKERED_FLAG = 5,
        AC_PENALTY_FLAG = 6,
    }

    /// <summary>
    /// Enum for possible ACC game states
    /// </summary>
    public enum AC_STATUS
    {
        AC_OFF = 0,
        AC_REPLAY = 1,
        AC_LIVE = 2,
        AC_PAUSE = 3,
    }

    /// <summary>
    /// Enum for all different possible hotstint lenghts in ACC
    /// </summary>
    public enum ACC_HOTSTINT_SESSION_LENGTH
    {
        FIVEMINUTES = 5 * 60 * 1000,
        TENMINUTES = 10 * 60 * 1000,
        FIFTEENMINUTES = 15 * 60 * 1000,
        THIRTYMINUTES = 30 * 60 * 1000,
        SIXTYMINUTES = 60 * 60 * 1000,
        INVALID = 0
    }
}
