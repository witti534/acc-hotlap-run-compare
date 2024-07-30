using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acc_hotrun_run_compare.GameListener
{
    /// <summary>
    /// Used https://github.com/mdjarv/assettocorsasharedmemory as reference (including variable names)
    /// This class is to interpret the bytes of the ACC shared graphics memory page
    /// </summary>
    internal class SharedMemoryGraphics
    {
        public int packetId { private set; get; }
        public ACCEnums.AC_STATUS status { private set; get; }
        public ACCEnums.AC_SESSION_TYPE session { private set; get; }
        public short[] currentTime { private set; get; }
        public short[] lastTime { private set; get; }
        public short[] bestTime { private set; get; }
        public short[] split { private set; get; }
        public  int completedLaps { private set; get; }
        public int position { private set; get; }
        public int iCurrentTime { private set; get; }
        public int iLastTime { private set; get; }
        public int iBestTime { private set; get; }
        public float sessionTimeLeft { private set; get; }
        public float distanceTraveled { private set; get; }
        public int isInPit { private set; get; }
        public int currentSectorIndex { private set; get; }
        public int lastSectorTime { private set; get; }
        public int numberOfLaps { private set; get; }
        public char[] tyreCompound { private set; get; }
        public float replayTimeMultiplier { private set; get; }
        public float normalizedCarPosition { private set; get; }

        public int activeCars { private set; get; }
        public float[,] carCoordinates { private set; get; }
        public int[] carID { private set; get; }
        public int playerCarID { private set; get; }
        public float penaltyTime { private set; get; }
        public ACCEnums.AC_FLAG_TYPE flag { private set; get; }
        public ACCEnums.PenaltyShortcut penalty { private set; get; }
        public int idealLineOn { private set; get; }
        public int isInPitLane { private set; get; }

        public float surfaceGrip { private set; get; }
        public int mandatoryPitDone { private set; get; }

        public float windSpeed { private set; get; }
        public float windDirection { private set; get; }


        public int isSetupMenuVisible { private set; get; }

        public int mainDisplayIndex { private set; get; }
        public int secondaryDisplayIndex { private set; get; }
        public int TC { private set; get; }
        public int TCCut { private set; get; }
        public int EngineMap { private set; get; }
        public int ABS { private set; get; }
        public int fuelXLap { private set; get; }
        public int rainLights { private set; get; }
        public int flashingLights { private set; get; }
        public int lightsStage { private set; get; }
        public float exhaustTemperature { private set; get; }
        public int wiperLV { private set; get; }
        public int DriverStintTotalTimeLeft { private set; get; }
        public int DriverStintTimeLeft { private set; get; }
        public int rainTyres { private set; get; }

        public SharedMemoryGraphics ()
        {
            currentTime = new short[15];
            lastTime = new short[15];
            bestTime = new short[15];
            split = new short[15];
            tyreCompound = new char[33];
            carCoordinates = new float[60,3];
            carID = new int[60];
        }

        /// <summary>
        /// In this function all bytes get analyzed and put into the correct fields.
        /// </summary>
        /// <param name="input">All bytes of the ACC graphics memory page as a byte array.</param>
        public void updateSMG(byte[] input)
        {
            //packetId
            const int indexPacketId = 0;
            packetId = BitConverter.ToInt32(input, indexPacketId);

            //status
            const int indexStatus = indexPacketId + 4;
            status = (ACCEnums.AC_STATUS)BitConverter.ToInt32(input, indexStatus);

            //session
            const int indexSession = indexStatus + 4;
            session = (ACCEnums.AC_SESSION_TYPE)BitConverter.ToInt32(input, indexSession);

            //currentTime
            const int indexCurrentTime = indexSession + 4;
            for (int i = 0; i < 15; i++)
            {
                currentTime[i] = BitConverter.ToInt16(input, indexCurrentTime + i * 2);
            }

            //lastTime
            const int indexLastTime = indexCurrentTime + 2 * 15;
            for (int i = 0; i < 15; i++)
            {
                lastTime[i] = BitConverter.ToInt16(input, indexLastTime + i * 2);
            }

            //bestTime
            const int indexBestTime = indexLastTime + 2 * 15;
            for (int i = 0;i < 15; i++)
            {
                bestTime[i] = BitConverter.ToInt16(input, indexBestTime + i * 2);
            }

            //split
            const int indexSplit = indexBestTime + 2 * 15;
            for (int i=0; i < 15; i++)
            {
                split[i] = BitConverter.ToInt16(input, indexSplit + i * 2);
            }

            //completedLaps
            const int indexCompletedLap = indexSplit + 2 * 15;
            completedLaps = BitConverter.ToInt32(input, indexCompletedLap);

            //position
            const int indexPosition = indexCompletedLap + 4;
            position = BitConverter.ToInt32(input, indexPosition);

            //iCurrentTime
            const int indexICurrentTime = indexPosition + 4;
            iCurrentTime = BitConverter.ToInt32(input, indexICurrentTime);

            //iLastTime
            const int indexILastTime = indexICurrentTime + 4;
            iLastTime = BitConverter.ToInt32(input, indexILastTime);

            //iBestTime
            const int indexIBestTime = indexILastTime + 4;
            iBestTime = BitConverter.ToInt32(input, indexIBestTime);

            //sessionTimeLeft
            const int indexSessionTimeLeft = indexIBestTime + 4;
            sessionTimeLeft = BitConverter.ToSingle(input, indexSessionTimeLeft);

            //distanceTraveled
            const int indexDistanceTraveled = indexSessionTimeLeft + 4;
            distanceTraveled = BitConverter.ToSingle(input, indexDistanceTraveled);

            //isInPit
            const int indexIsInPit = indexDistanceTraveled + 4;
            isInPit = BitConverter.ToInt32(input, indexIsInPit);

            //currentSectorIndex
            const int indexCurrentSectorIndex = indexIsInPit + 4;
            currentSectorIndex = BitConverter.ToInt32(input, indexCurrentSectorIndex);

            //lastSectorTime
            const int indexLastSectorTime = indexCurrentSectorIndex + 4;
            lastSectorTime = BitConverter.ToInt32(input, indexLastSectorTime);

            //numberOfLaps
            const int indexNumberOfLaps = indexLastSectorTime + 4;
            numberOfLaps = BitConverter.ToInt32(input, indexNumberOfLaps);

            //tyreCompound
            const int indexTyreCompound = indexNumberOfLaps + 4;
            for (int i = 0; i < 33; i++)
            {
                tyreCompound[i] = BitConverter.ToChar(input, indexTyreCompound + i * 2);
            }

            //replayTimeMultiplier
            const int indexReplayTimeMultiplier = indexTyreCompound + 2 * 34;
            replayTimeMultiplier = BitConverter.ToSingle(input, indexReplayTimeMultiplier);

            //normalizedCarPosition
            const int indexNormalizedCarPosition = indexReplayTimeMultiplier + 4;
            normalizedCarPosition = BitConverter.ToSingle(input, indexNormalizedCarPosition);

            //activeCars
            const int indexActiveCars = indexNormalizedCarPosition + 4;
            activeCars = BitConverter.ToInt32(input, indexActiveCars);

            //carCoordinates
            const int indexCarCoordinates = indexActiveCars + 4;
            //not implementing

            //carID
            const int indexCarID = indexCarCoordinates + 60 * 3 * 4;
            for (int i = 0; i < 60; i++)
            {
                carID[i] = BitConverter.ToInt32(input, indexCarID + i * 4);
            }

            //playerCarID
            const int indexPlayerCarID = indexCarID + 60 * 4;
            playerCarID = BitConverter.ToInt32(input, indexPlayerCarID);

            //penaltyTime
            const int indexPenaltyTime = indexPlayerCarID + 4;
            penaltyTime = BitConverter.ToSingle(input, indexPenaltyTime);

            //flag
            const int indexFlag = indexPenaltyTime + 4;
            flag = (ACCEnums.AC_FLAG_TYPE)BitConverter.ToInt32(input, indexFlag);

            //penalty
            const int indexPenalty = indexFlag + 4;
            penalty = (ACCEnums.PenaltyShortcut)BitConverter.ToInt32(input, indexPenalty);

            //idealLineOn
            const int indexIdealLineOn = indexPenalty + 4;
            idealLineOn = BitConverter.ToInt32(input, indexIdealLineOn);

            //isInPitLane
            const int indexIsInPitLane = indexIdealLineOn + 4;
            isInPitLane = BitConverter.ToInt32(input, indexIsInPitLane);

            //surfaceGrip
            const int indexSurfaceGrip = indexIsInPitLane + 4;
            surfaceGrip = BitConverter.ToSingle(input, indexSurfaceGrip);

            //mandatoryPitDone
            const int indexMandatoryPitDone = indexSurfaceGrip + 4;
            mandatoryPitDone = BitConverter.ToInt32(input, indexMandatoryPitDone);

            //windSpeed
            const int indexWindSpeed = indexMandatoryPitDone + 4;
            windSpeed = BitConverter.ToSingle(input, indexWindSpeed);

            //windDirection
            const int indexWindDirection = indexWindSpeed + 4;
            windDirection = BitConverter.ToSingle(input, indexWindDirection);

            //isSetupMenuVisible
            const int indexIsSetupMenuVisible = indexWindDirection + 4;
            isSetupMenuVisible = BitConverter.ToInt32(input, indexIsSetupMenuVisible);

            //mainDisplayIndex
            const int indexMainDisplayIndex = indexIsSetupMenuVisible + 4;
            mainDisplayIndex = BitConverter.ToInt32(input, indexMainDisplayIndex);

            //secondaryDisplayIndex
            const int indexSecondaryDisplayIndex = indexMainDisplayIndex + 4;
            secondaryDisplayIndex = BitConverter.ToInt32(input, indexSecondaryDisplayIndex);

            //TC
            const int indexTC = indexSecondaryDisplayIndex + 4;
            TC = BitConverter.ToInt32(input, indexTC);

            //TCCut
            const int indexTCCut = indexTC + 4;
            TCCut = BitConverter.ToInt32(input, indexTCCut);

            //EngineMap
            const int indexEngineMap = indexTCCut + 4;
            EngineMap = BitConverter.ToInt32(input, indexEngineMap);
            
            //ABS
            const int indexABS = indexEngineMap + 4;
            ABS = BitConverter.ToInt32(input, indexABS);
            
            //fuelXLap
            const int indexFuelXLap = indexABS + 4;
            fuelXLap = BitConverter.ToInt32(input, indexFuelXLap);

            //rainLights
            const int indexRainLights = indexFuelXLap + 4;
            rainLights = BitConverter.ToInt32(input, indexRainLights);

            //flashingLights
            const int indexFlashingLights = indexRainLights + 4;
            flashingLights = BitConverter.ToInt32(input, indexFlashingLights);

            //exhaustTemperature
            const int indexExhaustTemperature = indexFlashingLights + 4;
            exhaustTemperature = BitConverter.ToSingle(input, indexExhaustTemperature);

            //wiperLV
            const int indexWiperLV = indexExhaustTemperature + 4;
            wiperLV = BitConverter.ToInt32(input, indexWiperLV);

            //DriverStintTotalTimeLeft
            const int indexDriverStintTotalTimeLeft = indexWiperLV + 4;
            DriverStintTotalTimeLeft = BitConverter.ToInt32(input, indexDriverStintTotalTimeLeft);

            //DriverStintTimeLeft
            const int indexDriverStintTimeLeft = indexDriverStintTotalTimeLeft + 4;
            DriverStintTimeLeft = BitConverter.ToInt32(input, indexDriverStintTimeLeft);

            //rainTyres
            const int indexRainTyres = indexDriverStintTimeLeft + 4;
            rainTyres = BitConverter.ToInt32(input, indexRainTyres);
        }

        /// <summary>
        /// Turns the array currentTime into a string
        /// </summary>
        /// <returns>string of the array currentTime</returns>
        public string currentTimeToString ()
        {
            StringBuilder sb = new StringBuilder();

            foreach (short element in currentTime){
                if (element != 0) 
                {
                    sb.Append((char)element);
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Turns the array lastTime into a string
        /// </summary>
        /// <returns>string of the array lastTime</returns>
        public string lastTimeToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (short element in lastTime) 
            { 
                if (element != 0)
                {
                    sb.Append((char)element);
                }
            }

            return sb.ToString ();
        }

        /// <summary>
        /// Returns the array bestTime into a string
        /// </summary>
        /// <returns>string of the array bestTime</returns>
        public string bestTimeToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (short element in bestTime)
            {
                if (element != 0)
                {
                    sb.Append((char)element);

                }
            }

            return sb.ToString ();
        }

        /// <summary>
        /// Turns the array tyreCompound into a string
        /// </summary>
        /// <returns>string of the array tyreCompound</returns>
        public string tyreCompoundToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (char element in tyreCompound)
            {
                if (element != 0)
                {
                    sb.Append(element);
                }
            }

            return sb.ToString ();
        }

    }
}
