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
    public class TabCompareRuns(Panel runPanel,
        ComboBox comboBoxTrackSelector,
        ComboBox comboBoxCarSelector,
        ComboBox comboBoxSessionTimeSelector,
        CheckBox checkBoxDisplayInvalidRuns,
        ComboBox comboBoxComparer,
        CheckBox checkBoxDisplayOwnRunsOnly)

    {
        readonly StoredRunContext StoredRunContext = StoredRunContext.GetInstance();
        readonly Panel RunPanel = runPanel;
        readonly ComboBox ComboBoxTrackSelector = comboBoxTrackSelector;
        readonly ComboBox ComboBoxCarSelector = comboBoxCarSelector;
        readonly ComboBox ComboBoxSessionTimeSelector = comboBoxSessionTimeSelector;
        readonly CheckBox CheckBoxDisplayInvalidRuns = checkBoxDisplayInvalidRuns;
        readonly ComboBox ComboBoxComparer = comboBoxComparer;

        readonly SettingsProvider settingsProvider = SettingsProvider.GetInstance();
        

        /// <summary>
        /// This function reads all distinct Tracknames in the stored database and fills in the found track names in the ComboBoxTrackSelector
        /// </summary>
        public void PopulateTrackSelector()
        {
            var lastSelectedTrackItem = ComboBoxTrackSelector.SelectedItem;

            ComboBoxTrackSelector.Items.Clear();

            //Retrieve all unique tracknames
            var trackNames = StoredRunContext.RunInformationSet
                .Select(r => r.TrackName)
                .Distinct()
                .ToList();

            //Add tracknames to comboBoxTrackSelector
            foreach (var trackName in trackNames)
            {
                ComboBoxTrackSelector.Items.Add(trackName);
            }

            if (ComboBoxTrackSelector.Items.Contains(lastSelectedTrackItem))
            {
                ComboBoxTrackSelector.SelectedItem = lastSelectedTrackItem;
            }
        }

        /// <summary>
        /// This funtion populates the car selector. It reads the selected trackname and searches for cars which have a record for that track. 
        /// It then populates the carSelector combobox. 
        /// </summary>
        public void PopulateCarSelector()
        {
            string trackName = ComboBoxTrackSelector.Text;
            ComboBoxCarSelector.Items.Clear();

            ComboBoxCarSelector.Items.Add("All cars");

            //Retrieve all unique car names for a chosen track
            var carNames = StoredRunContext.RunInformationSet
                .Where(s => s.TrackName == trackName)
                .Select(s => s.CarName)
                .Distinct()
                .ToList(); //turn it into a list

            //Add carnames to comboBoxCarSelector
            foreach (var carName in carNames)
            {
                ComboBoxCarSelector.Items.Add(carName);
            }

            PopulateSessionSelector();

        }

        /// <summary>
        /// This function populates the session time selector. It reads the selected trackname and carname, and searches for runs with distinct session lengths.
        /// </summary>
        public void PopulateSessionSelector()
        {
            ComboBoxSessionTimeSelector.Items.Clear();
            ComboBoxSessionTimeSelector.Items.Add("Any");

            string carName = ComboBoxCarSelector.Text;
            string trackName = ComboBoxTrackSelector.Text;

            List<int> sessionLengths;

            //Select all disctint session times depending on the supplied trackname and carname
            if (carName == "All cars")
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
                ComboBoxSessionTimeSelector.Items.Add(sessionLenght.ToString());
            }
        }

        /// <summary>
        /// This function takes the information from the comboboxes and fills up the panel with information about different runs.
        /// It sorts runs depending on the comparer.
        /// </summary>
        public void RedrawPanelWithRunsToBeCompared()
        {
            string trackName = ComboBoxTrackSelector.Text;
            string carName = ComboBoxCarSelector.Text;
            bool displayRunsWithPenalties = CheckBoxDisplayInvalidRuns.Checked;
            bool sessionLengthSet = Int32.TryParse(ComboBoxSessionTimeSelector.Text, out int sessionLength);
            string comparerName = ComboBoxComparer.Text;

            RunPanel.Controls.Clear();

            //Compare with strings from FormStrings to choose the comparer.
            Comparer<RunInformation> comparer = RunInformation.GetComparerFromComparerName(comparerName);
            List<RunInformation> selectedRunsWithoutSectors;

            //Get a list of all tracks of the chosen track
            selectedRunsWithoutSectors = StoredRunContext.RunInformationSet
                .Where(r => r.TrackName == trackName)
                .Select(r => r)
                .ToList();

            //Filter if a certain car has been chosen
            if (carName != "All cars")
            {
                selectedRunsWithoutSectors = selectedRunsWithoutSectors.Where(r => r.CarName == carName)
                    .ToList();
            }

            //Filter if a certain session length has been chosen
            if (sessionLengthSet)
            {
                selectedRunsWithoutSectors = selectedRunsWithoutSectors.Where(r => r.SessionTime == sessionLength)
                    .ToList();
            }


            //Filter if only runs for the current driver name shall be displayed
            if (checkBoxDisplayOwnRunsOnly.Checked)
            {
                selectedRunsWithoutSectors = selectedRunsWithoutSectors.Where(r => r.DriverName == settingsProvider.Username)
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
            for (int i = 0; i < selectedRunsWithoutSectors.Count; i++)
            {
                RunInformation run = selectedRunsWithoutSectors[i];
                if (displayRunsWithPenalties || (!displayRunsWithPenalties && !run.PenaltyOccured))
                {
                    //Do not display runs if a penalty occured and the checkbox is set to not show runs with penalties

                    var amountOfSectors = StoredRunContext.SectorInformationSet
                        .Where(s => s.RunID == run.RunID)
                        .Count();

                    int amountOfLaps = amountOfSectors / 3;

                    Color backgroundColor = (i % 2 == 0) ? Color.Silver : Color.LightGray;

                    Panel runInformationPanel = new()
                    {
                        Size = new Size(900, 84), //Numbers taken from editor
                        Name = "panelrun|" + run.RunID.ToString(),
                        BackColor = backgroundColor,
                        Location = new Point(0, i * 84)
                    };

                    //Label for total run time and amount of laps
                    Color totalTimeColor = (run.PenaltyOccured) ? Color.DarkRed : Color.Black; //Red in case of penalty occured, black otherwise
                    Label totalTimeLabel = new()
                    {
                        Text = TimeFormatter.CreateHoursString(run.DrivenTime) + " (" + amountOfLaps + " laps)",
                        Font = new Font("Segoe UI", 14),
                        Name = "labelTotalTime|" + run.RunID.ToString(),
                        Location = new Point(20, 0), //Numbers from editor
                        Size = new Size(185, 25), //Numbers from editor
                        ForeColor = totalTimeColor,
                    };
                    runInformationPanel.Controls.Add(totalTimeLabel);

                    //Label for fastest lap
                    Label fastestLapLabel = new()
                    {
                        Text = "FL: " + TimeFormatter.CreateMinutesString(run.FastestLap),
                        Location = new Point(20, 25), //Numbers from editor
                        Size = new Size(115,21), //Numbers from editor
                        Name = "labelFastestLap|" + run.RunID.ToString()
                    };
                    runInformationPanel.Controls.Add(fastestLapLabel);

                    //Button to open the details page of a run
                    Button detailsButton = new()
                    {
                        Text = "Details ->",
                        Location = new Point(104, 49), //Numbers from editor
                        Size = new Size(85, 30), //Numbers from editor
                        Name = "runDetailsButton|" + run.RunID.ToString(),                        
                    };
                    detailsButton.Click += (sender, EventArgs) => { OpenRunDetailsWindow(sender, EventArgs, run.RunID); };
                    //Custom function for dynamic buttons

                    runInformationPanel.Controls.Add(detailsButton);

                    //CheckBox for selecting multiple runs
                    CheckBox checkBox = new()
                    {
                        Text = "",
                        Location = new Point(3, 25), //Numbers from editor
                        Name = "checkboxrun|" + run.RunID.ToString()
                    };
                    runInformationPanel.Controls.Add(checkBox);

                    Label runInfoLabel = new()
                    {
                        Text = "Car: " + run.CarName + "\r\n"
                        + "Driver: " + run.DriverName + "\r\n"
                        + "Info: " + run.RunDescription + "\r\n"
                        + "Driven at: " + run.RunCreatedDateTime.ToString(),
                        AutoSize = true,
                        Location = new Point(205, 0),
                        Name = "runInfoLabel|" + run.RunID.ToString()
                    };
                    runInformationPanel.Controls.Add(runInfoLabel);

                    RunPanel.Controls.Add(runInformationPanel);
                }
            }

            return;
        }

        /// <summary>
        /// This function is used to get all selected runs and delete each of the 
        /// </summary>
        public void DeleteSelectedRuns()
        {
            List<int> selectedRunIDs = GetSelectedRunIDs();

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

            PopulateTrackSelector();
        }

        /// <summary>
        /// A helper function to get all currently selected checkboxes and runs
        /// </summary>
        /// <returns></returns>
        private List<int> GetSelectedRunIDs()
        {
            List<int> resultList = [];

            //Get all controls in the panel)
            foreach (Control controlPanel in RunPanel.Controls)
            {
                foreach (Control controlSpecific in controlPanel.Controls) {

                    //all checkboxes we need starts with "checkboxrun|"
                    if (controlSpecific.Name.StartsWith("checkboxrun|"))
                    {
                        CheckBox tempCheckBox = (CheckBox)controlSpecific;

                        //Get only checked checkboxes
                        if (tempCheckBox.Checked)
                        {
                            //Extract the runID
                            string[] controlNameElements = controlSpecific.Name.Split('|');
                            resultList.Add(Int32.Parse(controlNameElements[1]));
                        }
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
            List<int> selectedRunIDs = GetSelectedRunIDs();


            if (selectedRunIDs.Count == 0)
            {
                //Zero runs selected
                return;
            }
            if (selectedRunIDs.Count == 1)
            {
                //One run selected, show details of one run

                RunInformation run = StoredRunContext.RunInformationSet.First(r => r.RunID == selectedRunIDs[0]);
                //Get a single run where the runID of the selected checkbox is being used to find the run in the StoredRunContext

                Form singleRunForm = new FormSingleRun(run);
                singleRunForm.Show();
            }
            else
            {
                //Mutiple runs selected, compare different runs with eachother
                List<RunInformation> runs = [];

                //Get the run for each provided runID and add it to the list to be used in the FormMultipleRuns
                foreach (int runID in selectedRunIDs)
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
        public void ExportRunsEntryFunction()
        {
            List<int> selectedRunIDs = GetSelectedRunIDs();
            //Get a list of each runID of all selected runs

            if (selectedRunIDs.Count == 0)
            {
                MessageBox.Show("No runs were selected.");
            }
            else //Count >= 1
            {
                //Open a FileDialog so the user can select a folder where to export runs to
                CommonOpenFileDialog folderDialog = new CommonOpenFileDialog
                {
                    IsFolderPicker = true
                };

                if (folderDialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    string saveLocation = folderDialog.FileName;

                    foreach (int runID in selectedRunIDs)
                    {
                        RunImportAndExport.ExportSingleRun(runID, saveLocation);
                    }
                }
            }
        } //function ExportRunsEntryFunction


        /// <summary>
        /// This function is being called when the button is pressed to import runs. This opens a file dialog and allows importing multiple runs.
        /// </summary>
        public void ImportRunsEntryFunction()
        {
            CommonOpenFileDialog fileDialog = new CommonOpenFileDialog
            {
                Multiselect = true
            };

            if (fileDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                List<string> fileLocations = fileDialog.FileNames.ToList();
                foreach (string fileLocation in fileLocations)
                {
                    RunImportAndExport.ImportSingleRun(fileLocation);
                }
            }

        } //function ImportRunsEntryFunction

        /// <summary>
        /// This function opens a new form with the referenced run
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="runID">RunID of the run</param>
        private void OpenRunDetailsWindow(object sender, EventArgs e, long runID)
        {
            RunInformation singleRun = StoredRunContext.RunInformationSet.First(run => run.RunID == runID);

            Form singleRunForm = new FormSingleRun(singleRun);
            singleRunForm.Show();
        }
    } //class
} //namespace
