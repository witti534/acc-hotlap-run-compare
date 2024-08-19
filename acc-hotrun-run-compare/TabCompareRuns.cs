﻿using acc_hotrun_run_compare.DBClasses;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace acc_hotrun_run_compare
{
    /// <summary>
    /// This class contains (non-autogenerated) functions for the tab CompareRuns
    /// </summary>
    /// <param name="storedRunContext"></param>
    public class TabCompareRuns()
    {
        readonly StoredRunContext StoredRunContext = StoredRunContext.GetInstance();

        /// <summary>
        /// This function reads all distinct Tracknames in the stored database and fills in the found track names in the comboBoxTrackSelector
        /// 
        /// </summary>
        /// <param name="comboBoxTrackSelector">Accesses the comboBoxTrackSelector to fill in the names of the found tracks</param>
        public void PopulateTrackSelector(ComboBox comboBoxTrackSelector)
        {

            comboBoxTrackSelector.Items.Clear();

            //Retrieve all unique tracknames
            var trackNames = StoredRunContext.RunInformationSet
                .Select(r => r.TrackName)
                .Distinct()
                .ToList();

            //Add tracknames to comboBoxTrackSelector
            foreach (var trackName in trackNames)
            {
                comboBoxTrackSelector.Items.Add(trackName);
            }
        }

        /// <summary>
        /// This funtion populates the car selector. It reads the selected trackname and searches for cars which have a record for that track. 
        /// It then populates the carSelector combobox. 
        /// </summary>
        /// <param name="comboBoxCarSelector">The comboBox which shall be populated (carSelector)</param>
        /// <param name="trackName">The trackname as a string</param>
        public void PopulateCarSelector(ComboBox comboBoxCarSelector, string trackName)
        {
            comboBoxCarSelector.Items.Clear();

            comboBoxCarSelector.Items.Add("all cars");

            //Retrieve all unique car names for a chosen track
            var carNames = StoredRunContext.RunInformationSet
                .Where(s => s.TrackName == trackName)
                .Select(s => s.CarName)
                .Distinct()
                .ToList(); //turn it into a list

            //Add carnames to comboBoxCarSelector
            foreach (var carName in carNames)
            {
                comboBoxCarSelector.Items.Add(carName);
            }

        }

        /// <summary>
        /// This function populates the session time selector. It reads the selected trackname and carname, and searches for runs with distinct session lengths.
        /// </summary>
        /// <param name="comboBoxSessionSelector"></param>
        /// <param name="trackName"></param>
        /// <param name="carName"></param>
        public void PopulateSessionSelector(ComboBox comboBoxSessionSelector, string trackName, string carName)
        {
            comboBoxSessionSelector.Items.Clear();

            List<int> sessionLengths;

            //Select all disctint session times depending on the supplied trackname and carname
            if (carName == "all cars")
            {
                sessionLengths = StoredRunContext.RunInformationSet
                    .Where(r => r.TrackName == trackName)
                    .Select(r => r.SessionTime)
                    .Distinct()
                    .ToList();
            }
            else
            {
                sessionLengths = StoredRunContext.RunInformationSet
                    .Where(r => r.TrackName == trackName && r.CarName == carName)
                    .Select(r => r.SessionTime)
                    .Distinct()
                    .ToList();
            }
            //Add all session lenghts to the comboBox
            foreach (int sessionLenght in sessionLengths)
            {
                comboBoxSessionSelector.Items.Add(sessionLenght.ToString());
            }
        }

        /// <summary>
        /// This function takes the information from the comboboxes and fills up the panel with information about different runs.
        /// It sorts runs depending on the comparer.
        /// </summary>
        /// <param name="panel">Panel where the runs shall be displayed</param>
        /// <param name="trackName">tracNname as a string</param>
        /// <param name="carName">carName as a string</param>
        /// <param name="displayRunsWithPenalties"></param>
        /// <param name="sessionLength"></param>
        /// <param name="comparerName"></param>
        public void FillUpPanelWithRuns(Panel panel, string trackName, string carName, bool displayRunsWithPenalties, int sessionLength, string comparerName)
        {
            //Compare with strings from FormStrings to choose the comparer.
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
            List<RunInformation> selectedRunsWithoutSectors;
            //Select runs based on trackname, carname and session length
            if (carName == "all cars")
            {
                selectedRunsWithoutSectors = StoredRunContext.RunInformationSet
               .Where(r => r.TrackName == trackName && r.SessionTime == sessionLength)
               .Select(r => r)
               .ToList();
            }
            else
            {
                selectedRunsWithoutSectors = StoredRunContext.RunInformationSet
                .Where(r => r.TrackName == trackName && r.CarName == carName && r.SessionTime == sessionLength)
                .Select(r => r)
                .ToList();
            }



            //Add sector information lists to runs to be able to compare runs with different amounts of laps
            foreach (RunInformation runWithoutSectors in selectedRunsWithoutSectors)
            {
                var sectorList = StoredRunContext.SectorInformationSet
                    .Select(s => s)
                    .Where(s => s.RunID == runWithoutSectors.RunID)
                    .ToList<SectorInformation>();

                runWithoutSectors.SectorList = sectorList;
            }

            // Sort list
            selectedRunsWithoutSectors.Sort(comparer);

            int indexForDrawingYOffset = 0;
            int amountPixelYOffset = 79;
            int amountPixelXOffset = 30;


            // Add each run to the panel
            foreach (var run in selectedRunsWithoutSectors)
            {
                if (displayRunsWithPenalties || (!displayRunsWithPenalties && !run.PenaltyOccured))
                {
                    //Do not display runs if a penalty occured and the checkbox is set to not show runs with penalties

                    var amountOfSectors = StoredRunContext.SectorInformationSet
                        .Where(s => s.RunID == run.RunID)
                        .Count();

                    int amountOfLaps = amountOfSectors / 3;

                    // Create the label with the run information
                    Label runInformationLabel = new()
                    {
                        Text = ("Total time: " + TimeFormatter.CreateHoursString(run.DrivenTime) + " | Fastest lap: " + TimeFormatter.CreateMinutesString(run.FastestLap) + " | No. of laps: " + amountOfLaps.ToString() + "\r\n"
                        + "Description: " + run.RunDescription + "\r\n"
                        + "Car: " + run.CarName + "\r\n"
                        + "Created at: " + run.RunCreatedDateTime.ToString()),
                        Location = new Point(amountPixelXOffset, 0 + indexForDrawingYOffset * amountPixelYOffset),
                        Size = new Size(1030, amountPixelYOffset),
                        BorderStyle = BorderStyle.FixedSingle,
                        Name = run.RunID.ToString()
                    };

                    CheckBox runSelectorCheckBox = new()
                    {
                        Name = "checkboxrun|" + run.RunID.ToString(),
                        Location = new Point(0, 0 + indexForDrawingYOffset * amountPixelYOffset)
                    };

                    panel.Controls.Add(runInformationLabel);
                    panel.Controls.Add(runSelectorCheckBox);

                    indexForDrawingYOffset++;
                }
            }

            return;
        }

        /// <summary>
        /// This function is used to get all selected runs and delete each of the 
        /// </summary>
        /// <param name="panelWithRuns"></param>
        public void DeleteSelectedRuns(Panel panelWithRuns)
        {
            List<int> selectedRunIDs = GetSelectedRunIDs(panelWithRuns);

            foreach (int runID in selectedRunIDs)
            {
                //Remove the run with the RunID from the RunInformationSet
                var runToBeDeleted = StoredRunContext.RunInformationSet.Where(run => run.RunID == runID)
                    .First();

                StoredRunContext.RunInformationSet.Remove(runToBeDeleted);

                //Remove the sectors with the RunID from the SectorInformationSet

                var sectorsToBeDeleted = StoredRunContext.SectorInformationSet.Where(sector => sector.RunID == runID)
                    .ToList();

                foreach (var sector in sectorsToBeDeleted)
                {
                    StoredRunContext.SectorInformationSet.Remove(sector);
                }

                StoredRunContext.SaveChanges();

            }
        }

        /// <summary>
        /// A helper function to get all currently selected checkboxes and runs
        /// </summary>
        /// <param name="panelWithRuns">The panel for </param>
        /// <returns></returns>
        private List<int> GetSelectedRunIDs(Panel panelWithRuns)
        {
            List<int> resultList = [];

            //Get all controls in the panel)
            foreach (Control control in panelWithRuns.Controls)
            {
                //all checkboxes we need starts with "checkboxrun|"
                if (control.Name.StartsWith("checkboxrun|"))
                {
                    CheckBox tempCheckBox = (CheckBox)control;

                    //Get only checked checkboxes
                    if (tempCheckBox.Checked)
                    {
                        //Extract the runID
                        string[] controlNameElements = control.Name.Split('|');
                        resultList.Add(Int32.Parse(controlNameElements[1]));
                    }
                }
            }

            return resultList;
        }

        /// <summary>
        /// This function is being called from the main form.
        /// It reads the selected checkboxes from the 
        /// </summary>
        /// <param name="panelWithRuns">The Panel which has the runs with IDs to be selected</param>
        public void ShowRuns(Panel panelWithRuns)
        {
            List<int> selectedRuns = GetSelectedRunIDs(panelWithRuns);


            if (selectedRuns.Count == 0)
            {
                //Zero runs selected
                return;
            }
            if (selectedRuns.Count == 1)
            {
                //One run selected, show details of one run

                RunInformation run = StoredRunContext.RunInformationSet.First(r => r.RunID == selectedRuns[0]);
                //Get a single run where the runID of the selected checkbox is being used to find the run in the StoredRunContext

                Form singleRunForm = new FormSingleRun(run);
                singleRunForm.Show();
            }
            else
            {
                //Mutiple runs selected, compare different runs with eachother
                List<RunInformation> runs = [];

                //Get the run for each provided runID and add it to the list to be used in the FormMultipleRuns
                foreach (int runID in selectedRuns)
                {
                    RunInformation singleRun = StoredRunContext.RunInformationSet.First(r => r.RunID == runID);
                    runs.Add(singleRun);
                }

                Form multipleRunsForm = new FormMultipleRuns(runs);
                multipleRunsForm.Show();
            }
        }

        /// <summary>
        /// This function serves as the entry point to export runs. It reads all selected runs from the Panel panelWithRuns. 
        /// </summary>
        /// <param name="panelWithRuns">The Panel which has the runs with IDs to be selected</param>
        public void ExportRunsEntryFunction(Panel panelWithRuns)
        {
            List<int> selectedRunIDs = GetSelectedRunIDs(panelWithRuns);

            if (selectedRunIDs.Count == 0)
            {
                MessageBox.Show("No runs were selected.");
            }
            else //Count >= 1
            {
                //Open a FileDialog so the user can select a folder where to export runs to
                CommonOpenFileDialog folderDialog = new CommonOpenFileDialog();
                folderDialog.IsFolderPicker = true;

                if (folderDialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    string saveLocation = folderDialog.FileName;

                    foreach (int runID in selectedRunIDs)
                    {
                        CreateAndSaveSingleRunSaveFile(runID, saveLocation);
                    }
                }
            }
        }

        /// <summary>
        /// This function creates and saves a single run save file
        /// </summary>
        /// <param name="runID"></param>
        /// <param name="saveLocation"></param>
        private void CreateAndSaveSingleRunSaveFile(int runID, string saveLocation)
        {
            //TODO
        }
    }
}
