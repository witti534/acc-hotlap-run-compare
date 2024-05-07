using System.Collections.Concurrent;
using System.IO.MemoryMappedFiles;
using System.Xml.Serialization;
using acc_hotlab_private_run_compare.DBClasses;

namespace acc_hotlab_private_run_compare.GameListener
{

    /// <summary>
    /// A class which is the entry point to analyze the data from the Assetto Corsa Competizione 
    /// </summary>
    public class ACCGameStateReader
    {
        private readonly ConcurrentQueue<string> gameStateReaderControlQueue;
        private readonly ConcurrentQueue<string> debugMessageQueue;
        private readonly ConcurrentQueue<string> currentRunInformationQueue;
        private readonly MainForm formContext;

        private readonly SharedMemoryGraphics sharedMemoryGraphicsInstance;
        private readonly SharedMemoryStatic sharedMemoryStaticInstance;

        private readonly RunAnalyzer runAnalyzerInstance = new();

        

        /// <summary>
        /// Initializer for the ACCGameStateReader. Invoked by the main form. 
        /// </summary>
        /// <param name="form"></param>
        public ACCGameStateReader(MainForm form) {

            formContext = form;
            debugMessageQueue = formContext.AccDebugMsgListenerQueue;
            gameStateReaderControlQueue = formContext.AccGameStateControlQueue;
            currentRunInformationQueue = formContext.AccCurrentRunInformationQueue;
            RefreshDebugTextbox();
            sharedMemoryGraphicsInstance = new SharedMemoryGraphics();
            sharedMemoryStaticInstance = new SharedMemoryStatic();
        }

        /// <summary>
        /// The main function to read the ACC game state. Runs as its own thread. Has an infinite loop to read the game state.
        /// </summary>
        public void Start() {

            //string accPhysicsPageName = "Local\\acpmf_physics"; not needed
            string accGraphicsPageName = "Local\\acpmf_graphics";
            string accStaticPageName = "Local\\acpmf_static";

            bool memoryMappedFileWasOpenBefore = false;
            bool debugBreakPointStaticActive = false;
            bool debugBreakPointGraphicsActive = false;
            bool debugGetGraphicsData = false;
            bool debugGetStaticData = false;


            //Main loop
            while (true)
            {

                //At the beginning of each loop reads one command from the Control Queue. 
                if (gameStateReaderControlQueue.TryDequeue(out string lastControlQueueElement))
                {
                    if (lastControlQueueElement.Equals("close"))
                    { break; }
                    //Leaves the main loop; should only be used when closing the program

                    if (lastControlQueueElement.Equals("break_static"))
                    { debugBreakPointStaticActive = true; }
                    //Go to debug break point to see if GameStateReader has the proper values/Static page

                    if (lastControlQueueElement.Equals("break_graphics"))
                    { debugBreakPointGraphicsActive = true; }
                    //Go to debug break point to see if GameStateReader has the proper values/Graphics page

                    if (lastControlQueueElement.Equals("data_graphics"))
                    { debugGetGraphicsData = true; }
                    //Puts data from the graphics page into the debug textbox

                    if (lastControlQueueElement.Equals("data_static"))
                    { debugGetStaticData = true; }
                    //Puts data from the static page into the debug textbox

                }

                //
                // Here the access to the graphics shared memory file
                //

                try
                {
                    using var mmf = MemoryMappedFile.OpenExisting(accGraphicsPageName); //Get access to memory mapped file

                    if (!memoryMappedFileWasOpenBefore)
                    {
                        //Debug output
                        memoryMappedFileWasOpenBefore = true;
                        debugMessageQueue.Enqueue("Found Memory Mapped File.\r\n");
                        RefreshDebugTextbox();
                    }

                    using (var accessor = mmf.CreateViewAccessor())
                    {
                        if (!accessor.CanRead)
                        {
                            //We shouldn't end up here but well, you never know
                            debugMessageQueue.Enqueue("For some reason the accessor can't read.\r\n");
                            RefreshDebugTextbox();
                        }

                        //Raw byte array for data from memory mapped file
                        byte[] RawSMGByteData = new byte[512 * 4];

                        //Fill up byte array with data
                        accessor.ReadArray<byte>(0, RawSMGByteData, 0, RawSMGByteData.Length);

                        //Turn raw bytes into usable information/fields
                        sharedMemoryGraphicsInstance.updateSMG(RawSMGByteData);

                        //Debugging
                        if (debugBreakPointGraphicsActive)
                        {
                            debugBreakPointGraphicsActive = false;
                        }

                        //Move data to debug textbox
                        if (debugGetGraphicsData)
                        {
                            debugGetGraphicsData = false;
                            debugMessageQueue.Enqueue("Current Time: " + sharedMemoryGraphicsInstance.currentTimeToString() + "\r\n");
                            debugMessageQueue.Enqueue("Last Time: " + sharedMemoryGraphicsInstance.lastTimeToString() + "\r\n");
                            debugMessageQueue.Enqueue("Completed Laps: " + sharedMemoryGraphicsInstance.completedLaps + "\r\n");
                            debugMessageQueue.Enqueue("Tyre Compound: " + sharedMemoryGraphicsInstance.tyreCompoundToString() + "\r\n");
                            debugMessageQueue.Enqueue("Time left: " + sharedMemoryGraphicsInstance.sessionTimeLeft.ToString() + "\r\n");
                            RefreshDebugTextbox();
                        }

                        //Work with data in here
                        RunAnalyzerGraphics(sharedMemoryGraphicsInstance);

                    }

                    mmf.Dispose();
                }
                catch (Exception)
                {
                    //If ACC page can't be found, this exception will be catched
                    memoryMappedFileWasOpenBefore = false;
                    debugMessageQueue.Enqueue("There is no ACC process to be found.\r\n");
                    RefreshDebugTextbox();
                    Thread.Sleep(5000);
                    //Reduce CPU impact, read only every 5 seconds until game is found. 

                }

                //
                // Here the access to the shared statics memory file
                //

                try
                {
                    using var mmf = MemoryMappedFile.OpenExisting(accStaticPageName); //Get access to memory mapped file

                    if (!memoryMappedFileWasOpenBefore)
                    {
                        //Debug output
                        memoryMappedFileWasOpenBefore = true;
                        debugMessageQueue.Enqueue("Found Memory Mapped File.\r\n");
                        RefreshDebugTextbox();
                    }

                    using (var accessor = mmf.CreateViewAccessor())
                    {
                        if (!accessor.CanRead)
                        {
                            //We shouldn't end up here but well, you never know
                            debugMessageQueue.Enqueue("For some reason the accessor can't read.\r\n");
                            RefreshDebugTextbox();
                        }

                        //Reserve byte array for raw bytes from shared memory page
                        byte[] RawSSGByteData = new byte[256 * 4];

                        //Move bytes from shared memory page into the byte array
                        accessor.ReadArray<byte>(0, RawSSGByteData, 0, RawSSGByteData.Length);

                        //Analyze data to make it usable for us
                        sharedMemoryStaticInstance.updateSMS(RawSSGByteData);


                        //Debugging
                        if (debugBreakPointStaticActive)
                        {
                            debugBreakPointStaticActive = false;
                        }

                        //Move data to debug textbox
                        if (debugGetStaticData)
                        {
                            debugGetStaticData = false;
                            debugMessageQueue.Enqueue("Current Track: " + sharedMemoryStaticInstance.getTrack() + "\r\n");
                            debugMessageQueue.Enqueue("Sector Count: " + sharedMemoryStaticInstance.sectorCount + "\r\n");
                            RefreshDebugTextbox();
                        }

                        RunAnalyzerStatic(sharedMemoryStaticInstance); //Analyze and prepare data here for static data
                    }

                    mmf.Dispose();
                }
                catch (Exception)
                {
                    //If ACC page can't be found, this exception will be catched
                    memoryMappedFileWasOpenBefore = false;
                    debugMessageQueue.Enqueue("There is no ACC process to be found.\r\n");
                    Thread.Sleep(5000);
                    //Reduce CPU impact, read only every 5 seconds until game is found. 

                }


                Thread.Sleep(50);
                //Reduce CPU impact
            } //end of while(true) loop
        }

        /// <summary>
        /// Handy function to refresh the text in the debug textbox for the form.
        /// 
        /// </summary>
        private void RefreshDebugTextbox()
        {
            formContext.Invoke(formContext.MoveTextFromQueueToDebugbox);
        }

        private void AddRunToFormContext(RunInformation finishedRun)
        {
            RunInformation[] paramList = [finishedRun];
            formContext.Invoke(formContext.addFinishedRunToFormContext, paramList);
        }

        /// <summary>
        /// This function is the entry point for analyzing the static data for a run. 
        /// </summary>
        /// <param name="sharedMemoryStatic">A SharedMemoryStatic object where the fields are already filled</param>
        private void RunAnalyzerStatic(SharedMemoryStatic sharedMemoryStatic)
        {

            //Run when new run has been started
            if (runAnalyzerInstance.StartedNewRun == RunAnalyzer.CollectInformationEnum.READY_FOR_STATICCOLLECTION)
            {
                string trackName = sharedMemoryStatic.getTrack();
                string carName = sharedMemoryStatic.getCarModel();


                runAnalyzerInstance.AnalyzeStatic(trackName, carName);
                runAnalyzerInstance.StartedNewRun = RunAnalyzer.CollectInformationEnum.READY_FOR_SESSIONLENGTHCOLLECTION;
                ResetRunAndSendNewStaticInformationToMainForm(trackName, carName);
            }
        }

        /// <summary>
        /// This function is the entry point for analyzing the graphics data (i.e. current sector index,
        /// remaining session time, completed laps number). 
        /// </summary>
        /// <param name="sharedMemoryGraphic"></param>
        private void RunAnalyzerGraphics (SharedMemoryGraphics sharedMemoryGraphic) 
        {
            //Move needed data into the RunAnalyzer
            int currentSectorIndex = sharedMemoryGraphic.currentSectorIndex;
            int lastSectorTime = sharedMemoryGraphic.lastSectorTime;
            int lastLapNumber = sharedMemoryGraphic.completedLaps;
            ACCEnums.AC_FLAG_TYPE currentFlagType = sharedMemoryGraphic.flag;
            ACCEnums.PenaltyShortcut currentPenaltyType = sharedMemoryGraphic.penalty;
            float remainingTime = sharedMemoryGraphic.sessionTimeLeft;
            int lastLapTime = sharedMemoryGraphic.iLastTime;

            runAnalyzerInstance.AnalyzeGraphics(currentSectorIndex, lastSectorTime, lastLapNumber, currentFlagType, currentPenaltyType, remainingTime, lastLapTime);

            //Do it once to guess session length and send to main form
            if (runAnalyzerInstance.StartedNewRun == RunAnalyzer.CollectInformationEnum.READY_FOR_SESSIONLENGTHCOLLECTION)
            {
                GetSessionLengthAndSendToMainForm(runAnalyzerInstance.SessionLengthGuess);
                runAnalyzerInstance.StartedNewRun = RunAnalyzer.CollectInformationEnum.COLLECTED;
            }

            //Only do it after session time has been collected, will be triggered after each sector change
            if (runAnalyzerInstance.SectorChanged && runAnalyzerInstance.StartedNewRun == RunAnalyzer.CollectInformationEnum.COLLECTED)
            {
                int sectorTime = runAnalyzerInstance.AnalyzedLastSectorTime;
                int sectorIndex = runAnalyzerInstance.AnalyzedLastSectorIndex;
                GetSectorDataAndSendToMainForm(sectorTime, sectorIndex);
                runAnalyzerInstance.SectorChanged = false;
                
            }

            //Run after each lap change
            if (runAnalyzerInstance.LapChanged)
            {
                //debug - some graphics data to the main form debug
                debugMessageQueue.Enqueue(runAnalyzerInstance.GetGraphicsDebugDataAndChangeLapChangeStatus());
                RefreshDebugTextbox();

                bool wasLastLap = false;
                if (runAnalyzerInstance.RunComplete)
                {
                    //Run is complete
                    wasLastLap = true;
                    AddRunToFormContext(runAnalyzerInstance.ReturnCompletedRun());
                    debugMessageQueue.Enqueue("Run complete.");
                    RefreshDebugTextbox();
                }

                GetLapDataAndSendToMainForm(lastLapTime, wasLastLap, lastLapNumber + 1);
            }
        }

        /// <summary>
        /// This function is supposed to be invoked when starting a new run. 
        /// It adds strings to the currentRunInformationQueue to display static run information in the main form.
        /// 
        /// </summary>
        /// <param name="trackName">Track name string of the newly started run</param>
        /// <param name="carName">Car name string of the newly started run</param>
        private void ResetRunAndSendNewStaticInformationToMainForm(string trackName, string carName)
        {
            currentRunInformationQueue.Enqueue("reset");
            debugMessageQueue.Enqueue("reset" + "\r\n");
            currentRunInformationQueue.Enqueue("carname|" + carName);
            debugMessageQueue.Enqueue("carname|" + carName + "\r\n");
            currentRunInformationQueue.Enqueue("trackname|" + trackName);
            debugMessageQueue.Enqueue("trackname|" + trackName + "\r\n");
            formContext.Invoke(formContext.UpdateCurrentRunData);
            formContext.Invoke(formContext.MoveTextFromQueueToDebugbox);
        }

        /// <summary>
        /// This function is supposed to be invoked after the static information of the run has been sent to the main form. 
        /// It takes the guessed session length (context: can't read actual value, need to guess) after first sector.
        /// It sends a string to the currentRunInformationQueue.
        /// 
        /// </summary>
        /// <param name="sessionLength"></param>
        private void GetSessionLengthAndSendToMainForm(ACCEnums.ACC_HOTSTINT_SESSION_LENGTH sessionLength)
        {
            switch (sessionLength)
            {
                case ACCEnums.ACC_HOTSTINT_SESSION_LENGTH.FIVEMINUTES:
                    currentRunInformationQueue.Enqueue("sessionlength|5 Minutes");
                    break;
                case ACCEnums.ACC_HOTSTINT_SESSION_LENGTH.TENMINUTES:
                    currentRunInformationQueue.Enqueue("sessionlength|10 Minutes");
                    break;
                case ACCEnums.ACC_HOTSTINT_SESSION_LENGTH.FIFTEENMINUTES:
                    currentRunInformationQueue.Enqueue("sessionlength|15 Minutes");
                    break;
                case ACCEnums.ACC_HOTSTINT_SESSION_LENGTH.THIRTYMINUTES:
                    currentRunInformationQueue.Enqueue("sessionlength|30 Minutes");
                    break;
                case ACCEnums.ACC_HOTSTINT_SESSION_LENGTH.SIXTYMINUTES:
                    currentRunInformationQueue.Enqueue("sessionlength|60 Minutes");
                    break;
                case ACCEnums.ACC_HOTSTINT_SESSION_LENGTH.INVALID:
                    currentRunInformationQueue.Enqueue("sessionlength|Something went wrong.");
                    break;
            }
            formContext.Invoke(formContext.UpdateCurrentRunData);
        }

        /// <summary>
        /// Each time the sector changes this function is supposed to be called.
        /// A string with the sector index and the sector time is being sent to the currentRunInformationQueue.
        /// </summary>
        /// <param name="sectorTime">The sector time in ms</param>
        /// <param name="sectorIndex">The sector index (either 0, 1 or 2)</param>
        private void GetSectorDataAndSendToMainForm(int sectorTime, int sectorIndex)
        {
            string formattedSectorTime = sectorTime.ToString();
            string formattedSectorIndex;

            if (sectorIndex == 0)
                formattedSectorIndex = "s0";
            else if (sectorIndex == 1)
                formattedSectorIndex = "s1";
            else
                formattedSectorIndex = "s2";
            currentRunInformationQueue.Enqueue("sector|" + formattedSectorIndex + "|" + formattedSectorTime);
            debugMessageQueue.Enqueue("sector|" + formattedSectorIndex + "|" + formattedSectorTime + "\r\n");
            formContext.Invoke(formContext.MoveTextFromQueueToDebugbox);
            formContext.Invoke(formContext.UpdateCurrentRunData);
        }

        /// <summary>
        /// Each time the lap changes this function is supposed to be called.
        /// Always a string to end a lap with the laptime and in all but the last lap a string with the following lap number. 
        /// </summary>
        /// <param name="finishedLapTime">Lap time in ms</param>
        /// <param name="wasLastLap">Boolean if this was the last lap</param>
        /// <param name="newLapNumber">The lap number for the new lap which will follow. Not used when (wasLastLap == true)</param>
        private void GetLapDataAndSendToMainForm(int finishedLapTime, bool wasLastLap, int newLapNumber)
        {
            string endFinishedLapConstruct;
            string endFinishedLapTime = TimeFormatter.ConvertMilisecondsToMinutesString(finishedLapTime);
            endFinishedLapConstruct = "lapend|" + endFinishedLapTime;
            debugMessageQueue.Enqueue(endFinishedLapConstruct + "\r\n");
            currentRunInformationQueue.Enqueue(endFinishedLapConstruct);

            if (!wasLastLap) 
            { 
                string beginNewLapString;
                beginNewLapString = "lapstart|" + newLapNumber.ToString();
                debugMessageQueue.Enqueue(beginNewLapString + "\r\n");
                currentRunInformationQueue.Enqueue(beginNewLapString);
            }
            formContext.Invoke(formContext.MoveTextFromQueueToDebugbox);
            formContext.Invoke(formContext.UpdateCurrentRunData);
        }
    }
}
