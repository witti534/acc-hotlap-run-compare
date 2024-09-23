namespace acc_hotrun_run_compare
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }



        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            debugBox = new GroupBox();
            labelVersion = new Label();
            resetDatabase = new Button();
            debugTextBoxLapAmount = new TextBox();
            debugTextBoxCarName = new TextBox();
            debugTextBoxTrackname = new TextBox();
            buttonCreateFakeRunInformation = new Button();
            debugTextbox1 = new TextBox();
            labelRadioSessionLength = new Label();
            labelStaticLastSavedRun = new Label();
            tabControl1 = new TabControl();
            tabPageMainAddRun = new TabPage();
            panelCurrentRunInfo = new Panel();
            labelTimeDifferenceFastestValue = new Label();
            labelTimeDifferenceFasterValue = new Label();
            label2 = new Label();
            labelTimeDifferenceFastestText = new Label();
            labelTimeDifferenceFasterText = new Label();
            labelPositionValue = new Label();
            labelRunData = new Label();
            labelCurrentRunInfo = new Label();
            labelCurrentRunLaps = new Label();
            labelCurrentRunSectors = new Label();
            tabPageCompareRuns = new TabPage();
            buttonImportRuns = new Button();
            buttonExportSelectedRuns = new Button();
            ButtonCompareRuns = new Button();
            buttonDeleteSelectedRuns = new Button();
            ComboBoxSortRunsBy = new ComboBox();
            labelSortBy = new Label();
            panelDisplayRuns = new Panel();
            checkBoxDisplayRunsWIthPenalties = new CheckBox();
            labelChooseSessionTime = new Label();
            labelChooseCar = new Label();
            labelChooseTrack = new Label();
            comboBoxTimeSelector = new ComboBox();
            comboBoxCarSelector = new ComboBox();
            comboBoxTrackSelector = new ComboBox();
            tabPageSettings = new TabPage();
            groupBoxLiveRunDriverCompare = new GroupBox();
            radioButtonDriverCompareAllDrivers = new RadioButton();
            radioButtonDriverCompareUserOnly = new RadioButton();
            groupBoxUsername = new GroupBox();
            checkBoxUpdateUsernameForAllRuns = new CheckBox();
            buttonUpdateUsername = new Button();
            textBoxUsername = new TextBox();
            groupBoxLiveRunCarCategory = new GroupBox();
            radioButtonCarCompareCarCategory = new RadioButton();
            radioButtonCarCompareAllCars = new RadioButton();
            radioButtonCarCompareCurrentCar = new RadioButton();
            groupBoxStoreInvalidRuns = new GroupBox();
            radioButtonStoreRunsWithPenaltiesDisabled = new RadioButton();
            radioButtonStoreRunsWithPenaltiesEnabled = new RadioButton();
            tabPageDebug = new TabPage();
            timer1 = new System.Windows.Forms.Timer(components);
            debugBox.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPageMainAddRun.SuspendLayout();
            panelCurrentRunInfo.SuspendLayout();
            tabPageCompareRuns.SuspendLayout();
            tabPageSettings.SuspendLayout();
            groupBoxLiveRunDriverCompare.SuspendLayout();
            groupBoxUsername.SuspendLayout();
            groupBoxLiveRunCarCategory.SuspendLayout();
            groupBoxStoreInvalidRuns.SuspendLayout();
            tabPageDebug.SuspendLayout();
            SuspendLayout();
            // 
            // debugBox
            // 
            debugBox.Controls.Add(labelVersion);
            debugBox.Controls.Add(resetDatabase);
            debugBox.Controls.Add(debugTextBoxLapAmount);
            debugBox.Controls.Add(debugTextBoxCarName);
            debugBox.Controls.Add(debugTextBoxTrackname);
            debugBox.Controls.Add(buttonCreateFakeRunInformation);
            debugBox.Controls.Add(debugTextbox1);
            debugBox.Location = new Point(6, 6);
            debugBox.Name = "debugBox";
            debugBox.Size = new Size(1202, 527);
            debugBox.TabIndex = 0;
            debugBox.TabStop = false;
            debugBox.Text = "DebugBox";
            // 
            // labelVersion
            // 
            labelVersion.AutoSize = true;
            labelVersion.Location = new Point(6, 505);
            labelVersion.Name = "labelVersion";
            labelVersion.Size = new Size(61, 19);
            labelVersion.TabIndex = 15;
            labelVersion.Text = "Version: ";
            // 
            // resetDatabase
            // 
            resetDatabase.Location = new Point(6, 24);
            resetDatabase.Name = "resetDatabase";
            resetDatabase.Size = new Size(263, 23);
            resetDatabase.TabIndex = 14;
            resetDatabase.Text = "Reset Database";
            resetDatabase.UseVisualStyleBackColor = true;
            resetDatabase.Click += ResetDatabase_Click;
            // 
            // debugTextBoxLapAmount
            // 
            debugTextBoxLapAmount.Location = new Point(6, 144);
            debugTextBoxLapAmount.Name = "debugTextBoxLapAmount";
            debugTextBoxLapAmount.PlaceholderText = "7";
            debugTextBoxLapAmount.Size = new Size(100, 25);
            debugTextBoxLapAmount.TabIndex = 6;
            debugTextBoxLapAmount.Text = "7";
            // 
            // debugTextBoxCarName
            // 
            debugTextBoxCarName.Location = new Point(6, 113);
            debugTextBoxCarName.Name = "debugTextBoxCarName";
            debugTextBoxCarName.PlaceholderText = "Car name";
            debugTextBoxCarName.Size = new Size(100, 25);
            debugTextBoxCarName.TabIndex = 5;
            debugTextBoxCarName.Text = "DEBUG_CAR";
            // 
            // debugTextBoxTrackname
            // 
            debugTextBoxTrackname.Location = new Point(6, 82);
            debugTextBoxTrackname.Name = "debugTextBoxTrackname";
            debugTextBoxTrackname.PlaceholderText = "Track name";
            debugTextBoxTrackname.Size = new Size(100, 25);
            debugTextBoxTrackname.TabIndex = 4;
            debugTextBoxTrackname.Text = "DEBUG_TRACK";
            // 
            // buttonCreateFakeRunInformation
            // 
            buttonCreateFakeRunInformation.Location = new Point(6, 53);
            buttonCreateFakeRunInformation.Name = "buttonCreateFakeRunInformation";
            buttonCreateFakeRunInformation.Size = new Size(263, 23);
            buttonCreateFakeRunInformation.TabIndex = 3;
            buttonCreateFakeRunInformation.Text = "Create Fake Run Information";
            buttonCreateFakeRunInformation.UseVisualStyleBackColor = true;
            buttonCreateFakeRunInformation.Click += ButtonClickDebugCreatFakeRunInfo;
            // 
            // debugTextbox1
            // 
            debugTextbox1.Location = new Point(682, 11);
            debugTextbox1.Multiline = true;
            debugTextbox1.Name = "debugTextbox1";
            debugTextbox1.ReadOnly = true;
            debugTextbox1.ScrollBars = ScrollBars.Vertical;
            debugTextbox1.Size = new Size(514, 510);
            debugTextbox1.TabIndex = 1;
            // 
            // labelRadioSessionLength
            // 
            labelRadioSessionLength.AutoSize = true;
            labelRadioSessionLength.Font = new Font("Noto Mono", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelRadioSessionLength.Location = new Point(3, 9);
            labelRadioSessionLength.Name = "labelRadioSessionLength";
            labelRadioSessionLength.Size = new Size(230, 23);
            labelRadioSessionLength.TabIndex = 7;
            labelRadioSessionLength.Text = "Current Session Info";
            // 
            // labelStaticLastSavedRun
            // 
            labelStaticLastSavedRun.AutoSize = true;
            labelStaticLastSavedRun.Font = new Font("Noto Mono", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelStaticLastSavedRun.Location = new Point(561, 89);
            labelStaticLastSavedRun.Name = "labelStaticLastSavedRun";
            labelStaticLastSavedRun.Size = new Size(164, 23);
            labelStaticLastSavedRun.TabIndex = 8;
            labelStaticLastSavedRun.Text = "Last Saved Run";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageMainAddRun);
            tabControl1.Controls.Add(tabPageCompareRuns);
            tabControl1.Controls.Add(tabPageSettings);
            tabControl1.Controls.Add(tabPageDebug);
            tabControl1.Font = new Font("Segoe UI", 10F);
            tabControl1.Location = new Point(0, 0);
            tabControl1.Margin = new Padding(0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1231, 585);
            tabControl1.SizeMode = TabSizeMode.FillToRight;
            tabControl1.TabIndex = 9;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // tabPageMainAddRun
            // 
            tabPageMainAddRun.AutoScroll = true;
            tabPageMainAddRun.Controls.Add(panelCurrentRunInfo);
            tabPageMainAddRun.Location = new Point(4, 26);
            tabPageMainAddRun.Name = "tabPageMainAddRun";
            tabPageMainAddRun.Padding = new Padding(3);
            tabPageMainAddRun.Size = new Size(1223, 555);
            tabPageMainAddRun.TabIndex = 0;
            tabPageMainAddRun.Text = "Add New Run";
            tabPageMainAddRun.UseVisualStyleBackColor = true;
            // 
            // panelCurrentRunInfo
            // 
            panelCurrentRunInfo.Controls.Add(labelTimeDifferenceFastestValue);
            panelCurrentRunInfo.Controls.Add(labelTimeDifferenceFasterValue);
            panelCurrentRunInfo.Controls.Add(label2);
            panelCurrentRunInfo.Controls.Add(labelTimeDifferenceFastestText);
            panelCurrentRunInfo.Controls.Add(labelTimeDifferenceFasterText);
            panelCurrentRunInfo.Controls.Add(labelPositionValue);
            panelCurrentRunInfo.Controls.Add(labelRunData);
            panelCurrentRunInfo.Controls.Add(labelCurrentRunInfo);
            panelCurrentRunInfo.Controls.Add(labelCurrentRunLaps);
            panelCurrentRunInfo.Controls.Add(labelRadioSessionLength);
            panelCurrentRunInfo.Controls.Add(labelCurrentRunSectors);
            panelCurrentRunInfo.Controls.Add(labelStaticLastSavedRun);
            panelCurrentRunInfo.Location = new Point(6, 6);
            panelCurrentRunInfo.Name = "panelCurrentRunInfo";
            panelCurrentRunInfo.Size = new Size(1202, 537);
            panelCurrentRunInfo.TabIndex = 13;
            // 
            // labelTimeDifferenceFastestValue
            // 
            labelTimeDifferenceFastestValue.AutoSize = true;
            labelTimeDifferenceFastestValue.Font = new Font("Noto Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelTimeDifferenceFastestValue.Location = new Point(880, 32);
            labelTimeDifferenceFastestValue.Margin = new Padding(0);
            labelTimeDifferenceFastestValue.Name = "labelTimeDifferenceFastestValue";
            labelTimeDifferenceFastestValue.Size = new Size(79, 19);
            labelTimeDifferenceFastestValue.TabIndex = 18;
            labelTimeDifferenceFastestValue.Text = "23.456s";
            // 
            // labelTimeDifferenceFasterValue
            // 
            labelTimeDifferenceFasterValue.AutoSize = true;
            labelTimeDifferenceFasterValue.Font = new Font("Noto Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelTimeDifferenceFasterValue.Location = new Point(881, 9);
            labelTimeDifferenceFasterValue.Margin = new Padding(0);
            labelTimeDifferenceFasterValue.Name = "labelTimeDifferenceFasterValue";
            labelTimeDifferenceFasterValue.Size = new Size(79, 19);
            labelTimeDifferenceFasterValue.TabIndex = 17;
            labelTimeDifferenceFasterValue.Text = "12.345s";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Noto Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(1020, 13);
            label2.Margin = new Padding(3, 0, 0, 0);
            label2.Name = "label2";
            label2.Size = new Size(99, 19);
            label2.TabIndex = 16;
            label2.Text = "Position:";
            // 
            // labelTimeDifferenceFastestText
            // 
            labelTimeDifferenceFastestText.AutoSize = true;
            labelTimeDifferenceFastestText.Font = new Font("Noto Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelTimeDifferenceFastestText.Location = new Point(561, 32);
            labelTimeDifferenceFastestText.Margin = new Padding(0);
            labelTimeDifferenceFastestText.Name = "labelTimeDifferenceFastestText";
            labelTimeDifferenceFastestText.Size = new Size(319, 19);
            labelTimeDifferenceFastestText.TabIndex = 15;
            labelTimeDifferenceFastestText.Text = "Time Difference To Fastest Run:";
            // 
            // labelTimeDifferenceFasterText
            // 
            labelTimeDifferenceFasterText.AutoSize = true;
            labelTimeDifferenceFasterText.Font = new Font("Noto Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelTimeDifferenceFasterText.Location = new Point(561, 9);
            labelTimeDifferenceFasterText.Margin = new Padding(0);
            labelTimeDifferenceFasterText.Name = "labelTimeDifferenceFasterText";
            labelTimeDifferenceFasterText.Size = new Size(309, 19);
            labelTimeDifferenceFasterText.TabIndex = 14;
            labelTimeDifferenceFasterText.Text = "Time Difference To Faster Run:";
            // 
            // labelPositionValue
            // 
            labelPositionValue.AutoSize = true;
            labelPositionValue.Font = new Font("Noto Mono", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelPositionValue.Location = new Point(1042, 32);
            labelPositionValue.Margin = new Padding(0, 0, 3, 0);
            labelPositionValue.Name = "labelPositionValue";
            labelPositionValue.Size = new Size(62, 24);
            labelPositionValue.TabIndex = 13;
            labelPositionValue.Text = "6/12";
            // 
            // labelRunData
            // 
            labelRunData.AutoSize = true;
            labelRunData.Font = new Font("Noto Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelRunData.Location = new Point(561, 126);
            labelRunData.Name = "labelRunData";
            labelRunData.Size = new Size(399, 57);
            labelRunData.TabIndex = 9;
            labelRunData.Text = "Lap 1 | 1:11.123 | 11.123 12.123 13.123\r\nLap 2 | 2:22.123 | 21.123 22.123 23.123\r\nLap 3 | 3:33.123 | 31.123 23.123 33.123\r\n";
            // 
            // labelCurrentRunInfo
            // 
            labelCurrentRunInfo.AutoSize = true;
            labelCurrentRunInfo.Font = new Font("Noto Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelCurrentRunInfo.Location = new Point(3, 32);
            labelCurrentRunInfo.Name = "labelCurrentRunInfo";
            labelCurrentRunInfo.Size = new Size(269, 57);
            labelCurrentRunInfo.TabIndex = 10;
            labelCurrentRunInfo.Text = "Track: ABC\r\nCar: ABC\r\nSession Length: 99 minutes";
            // 
            // labelCurrentRunLaps
            // 
            labelCurrentRunLaps.AutoSize = true;
            labelCurrentRunLaps.Font = new Font("Noto Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelCurrentRunLaps.Location = new Point(3, 126);
            labelCurrentRunLaps.Name = "labelCurrentRunLaps";
            labelCurrentRunLaps.Size = new Size(179, 190);
            labelCurrentRunLaps.TabIndex = 11;
            labelCurrentRunLaps.Text = "Lap  1 | 1:11.123\r\nLap  2 | 1:12.123\r\nLap  3 | 1:13.123\r\nLap  4 | 1:14.123\r\nLap  5 | 1:15.123\r\nLap  6 | 1:16.123\r\nLap  7 | 1:17.123\r\nLap  8 | 1:18.123\r\nLap  9 | 1:19.123\r\nLap 10 | 1:20.123";
            // 
            // labelCurrentRunSectors
            // 
            labelCurrentRunSectors.AutoSize = true;
            labelCurrentRunSectors.Font = new Font("Noto Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelCurrentRunSectors.Location = new Point(188, 126);
            labelCurrentRunSectors.Name = "labelCurrentRunSectors";
            labelCurrentRunSectors.Size = new Size(279, 152);
            labelCurrentRunSectors.TabIndex = 12;
            labelCurrentRunSectors.Text = resources.GetString("labelCurrentRunSectors.Text");
            // 
            // tabPageCompareRuns
            // 
            tabPageCompareRuns.Controls.Add(buttonImportRuns);
            tabPageCompareRuns.Controls.Add(buttonExportSelectedRuns);
            tabPageCompareRuns.Controls.Add(ButtonCompareRuns);
            tabPageCompareRuns.Controls.Add(buttonDeleteSelectedRuns);
            tabPageCompareRuns.Controls.Add(ComboBoxSortRunsBy);
            tabPageCompareRuns.Controls.Add(labelSortBy);
            tabPageCompareRuns.Controls.Add(panelDisplayRuns);
            tabPageCompareRuns.Controls.Add(checkBoxDisplayRunsWIthPenalties);
            tabPageCompareRuns.Controls.Add(labelChooseSessionTime);
            tabPageCompareRuns.Controls.Add(labelChooseCar);
            tabPageCompareRuns.Controls.Add(labelChooseTrack);
            tabPageCompareRuns.Controls.Add(comboBoxTimeSelector);
            tabPageCompareRuns.Controls.Add(comboBoxCarSelector);
            tabPageCompareRuns.Controls.Add(comboBoxTrackSelector);
            tabPageCompareRuns.Location = new Point(4, 26);
            tabPageCompareRuns.Name = "tabPageCompareRuns";
            tabPageCompareRuns.Size = new Size(1223, 555);
            tabPageCompareRuns.TabIndex = 2;
            tabPageCompareRuns.Text = "Compare Runs";
            tabPageCompareRuns.UseVisualStyleBackColor = true;
            // 
            // buttonImportRuns
            // 
            buttonImportRuns.Font = new Font("Noto Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonImportRuns.Location = new Point(975, 114);
            buttonImportRuns.Name = "buttonImportRuns";
            buttonImportRuns.Size = new Size(226, 27);
            buttonImportRuns.TabIndex = 13;
            buttonImportRuns.Text = "Import Runs";
            buttonImportRuns.UseVisualStyleBackColor = true;
            buttonImportRuns.Click += buttonImportRuns_Click;
            // 
            // buttonExportSelectedRuns
            // 
            buttonExportSelectedRuns.Font = new Font("Noto Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonExportSelectedRuns.Location = new Point(743, 113);
            buttonExportSelectedRuns.Name = "buttonExportSelectedRuns";
            buttonExportSelectedRuns.Size = new Size(226, 27);
            buttonExportSelectedRuns.TabIndex = 12;
            buttonExportSelectedRuns.Text = "Export Selected Runs";
            buttonExportSelectedRuns.UseVisualStyleBackColor = true;
            buttonExportSelectedRuns.Click += ButtonExportSelectedRuns_Click;
            // 
            // ButtonCompareRuns
            // 
            ButtonCompareRuns.Font = new Font("Noto Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ButtonCompareRuns.Location = new Point(279, 113);
            ButtonCompareRuns.Name = "ButtonCompareRuns";
            ButtonCompareRuns.Size = new Size(226, 27);
            ButtonCompareRuns.TabIndex = 11;
            ButtonCompareRuns.Text = "Show Selected Run(s)";
            ButtonCompareRuns.UseVisualStyleBackColor = true;
            ButtonCompareRuns.Click += ButtonCompareRuns_Click;
            // 
            // buttonDeleteSelectedRuns
            // 
            buttonDeleteSelectedRuns.Font = new Font("Noto Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonDeleteSelectedRuns.Location = new Point(511, 113);
            buttonDeleteSelectedRuns.Name = "buttonDeleteSelectedRuns";
            buttonDeleteSelectedRuns.Size = new Size(226, 27);
            buttonDeleteSelectedRuns.TabIndex = 10;
            buttonDeleteSelectedRuns.Text = "Delete Selected Runs";
            buttonDeleteSelectedRuns.UseVisualStyleBackColor = true;
            buttonDeleteSelectedRuns.Click += buttonDeleteSelectedRuns_Click;
            // 
            // ComboBoxSortRunsBy
            // 
            ComboBoxSortRunsBy.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxSortRunsBy.Font = new Font("Noto Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ComboBoxSortRunsBy.FormattingEnabled = true;
            ComboBoxSortRunsBy.Location = new Point(3, 114);
            ComboBoxSortRunsBy.Name = "ComboBoxSortRunsBy";
            ComboBoxSortRunsBy.Size = new Size(270, 27);
            ComboBoxSortRunsBy.TabIndex = 9;
            ComboBoxSortRunsBy.SelectedIndexChanged += comboBoxTimeSelector_SelectedIndexChanged;
            // 
            // labelSortBy
            // 
            labelSortBy.AutoSize = true;
            labelSortBy.Font = new Font("Noto Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelSortBy.Location = new Point(3, 90);
            labelSortBy.Name = "labelSortBy";
            labelSortBy.Size = new Size(79, 19);
            labelSortBy.TabIndex = 8;
            labelSortBy.Text = "Sort by";
            // 
            // panelDisplayRuns
            // 
            panelDisplayRuns.AutoScroll = true;
            panelDisplayRuns.Font = new Font("Noto Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panelDisplayRuns.Location = new Point(3, 146);
            panelDisplayRuns.Name = "panelDisplayRuns";
            panelDisplayRuns.Size = new Size(1208, 397);
            panelDisplayRuns.TabIndex = 7;
            // 
            // checkBoxDisplayRunsWIthPenalties
            // 
            checkBoxDisplayRunsWIthPenalties.AutoSize = true;
            checkBoxDisplayRunsWIthPenalties.Font = new Font("Noto Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkBoxDisplayRunsWIthPenalties.Location = new Point(727, 44);
            checkBoxDisplayRunsWIthPenalties.Name = "checkBoxDisplayRunsWIthPenalties";
            checkBoxDisplayRunsWIthPenalties.Size = new Size(298, 23);
            checkBoxDisplayRunsWIthPenalties.TabIndex = 6;
            checkBoxDisplayRunsWIthPenalties.Text = "Display runs with penalties";
            checkBoxDisplayRunsWIthPenalties.UseVisualStyleBackColor = true;
            checkBoxDisplayRunsWIthPenalties.CheckedChanged += comboBoxTimeSelector_SelectedIndexChanged;
            // 
            // labelChooseSessionTime
            // 
            labelChooseSessionTime.AutoSize = true;
            labelChooseSessionTime.Font = new Font("Noto Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelChooseSessionTime.Location = new Point(540, 18);
            labelChooseSessionTime.Name = "labelChooseSessionTime";
            labelChooseSessionTime.Size = new Size(129, 19);
            labelChooseSessionTime.TabIndex = 5;
            labelChooseSessionTime.Text = "Session Time";
            labelChooseSessionTime.Click += labelChooseSessionTime_Click;
            // 
            // labelChooseCar
            // 
            labelChooseCar.AutoSize = true;
            labelChooseCar.Font = new Font("Noto Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelChooseCar.Location = new Point(279, 18);
            labelChooseCar.Name = "labelChooseCar";
            labelChooseCar.Size = new Size(39, 19);
            labelChooseCar.TabIndex = 4;
            labelChooseCar.Text = "Car";
            // 
            // labelChooseTrack
            // 
            labelChooseTrack.AutoSize = true;
            labelChooseTrack.Font = new Font("Noto Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelChooseTrack.Location = new Point(3, 18);
            labelChooseTrack.Name = "labelChooseTrack";
            labelChooseTrack.Size = new Size(59, 19);
            labelChooseTrack.TabIndex = 3;
            labelChooseTrack.Text = "Track";
            // 
            // comboBoxTimeSelector
            // 
            comboBoxTimeSelector.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTimeSelector.Font = new Font("Noto Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxTimeSelector.FormattingEnabled = true;
            comboBoxTimeSelector.Items.AddRange(new object[] { "5 minutes", "10 minutes", "15 minutes", "30 minutes", "60 minutes" });
            comboBoxTimeSelector.Location = new Point(540, 40);
            comboBoxTimeSelector.Name = "comboBoxTimeSelector";
            comboBoxTimeSelector.Size = new Size(181, 27);
            comboBoxTimeSelector.TabIndex = 2;
            comboBoxTimeSelector.SelectedIndexChanged += comboBoxTimeSelector_SelectedIndexChanged;
            // 
            // comboBoxCarSelector
            // 
            comboBoxCarSelector.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCarSelector.Font = new Font("Noto Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxCarSelector.FormattingEnabled = true;
            comboBoxCarSelector.Items.AddRange(new object[] { "DEBUG_CAR", "ANOTHER_CAR", "FAKE_CAR" });
            comboBoxCarSelector.Location = new Point(279, 40);
            comboBoxCarSelector.Name = "comboBoxCarSelector";
            comboBoxCarSelector.Size = new Size(255, 27);
            comboBoxCarSelector.TabIndex = 1;
            comboBoxCarSelector.SelectedIndexChanged += comboBoxCarSelector_SelectedIndexChanged;
            // 
            // comboBoxTrackSelector
            // 
            comboBoxTrackSelector.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTrackSelector.Font = new Font("Noto Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBoxTrackSelector.FormattingEnabled = true;
            comboBoxTrackSelector.Items.AddRange(new object[] { "0", "4", "5", "6", "7", "8", "9", "ANOTHER_TRACK", "DEBUG_TRACK", "MADE_UP_TRACK" });
            comboBoxTrackSelector.Location = new Point(3, 40);
            comboBoxTrackSelector.Name = "comboBoxTrackSelector";
            comboBoxTrackSelector.Size = new Size(270, 27);
            comboBoxTrackSelector.Sorted = true;
            comboBoxTrackSelector.TabIndex = 0;
            comboBoxTrackSelector.SelectedIndexChanged += comboBoxTrackSelector_SelectedIndexChanged;
            comboBoxTrackSelector.MouseClick += comboBoxTrackSelector_MouseClick;
            // 
            // tabPageSettings
            // 
            tabPageSettings.AutoScroll = true;
            tabPageSettings.Controls.Add(groupBoxLiveRunDriverCompare);
            tabPageSettings.Controls.Add(groupBoxUsername);
            tabPageSettings.Controls.Add(groupBoxLiveRunCarCategory);
            tabPageSettings.Controls.Add(groupBoxStoreInvalidRuns);
            tabPageSettings.Location = new Point(4, 26);
            tabPageSettings.Name = "tabPageSettings";
            tabPageSettings.Size = new Size(1223, 555);
            tabPageSettings.TabIndex = 3;
            tabPageSettings.Text = "Settings";
            tabPageSettings.UseVisualStyleBackColor = true;
            // 
            // groupBoxLiveRunDriverCompare
            // 
            groupBoxLiveRunDriverCompare.Controls.Add(radioButtonDriverCompareAllDrivers);
            groupBoxLiveRunDriverCompare.Controls.Add(radioButtonDriverCompareUserOnly);
            groupBoxLiveRunDriverCompare.Location = new Point(8, 319);
            groupBoxLiveRunDriverCompare.Name = "groupBoxLiveRunDriverCompare";
            groupBoxLiveRunDriverCompare.Size = new Size(380, 100);
            groupBoxLiveRunDriverCompare.TabIndex = 3;
            groupBoxLiveRunDriverCompare.TabStop = false;
            groupBoxLiveRunDriverCompare.Text = "Live Hotrun: Compare against drivers";
            // 
            // radioButtonDriverCompareAllDrivers
            // 
            radioButtonDriverCompareAllDrivers.AutoSize = true;
            radioButtonDriverCompareAllDrivers.Location = new Point(6, 53);
            radioButtonDriverCompareAllDrivers.Name = "radioButtonDriverCompareAllDrivers";
            radioButtonDriverCompareAllDrivers.Size = new Size(87, 23);
            radioButtonDriverCompareAllDrivers.TabIndex = 1;
            radioButtonDriverCompareAllDrivers.TabStop = true;
            radioButtonDriverCompareAllDrivers.Text = "All drivers";
            radioButtonDriverCompareAllDrivers.UseVisualStyleBackColor = true;
            radioButtonDriverCompareAllDrivers.CheckedChanged += radioButtonDriverCompareAllDrivers_CheckedChanged;
            // 
            // radioButtonDriverCompareUserOnly
            // 
            radioButtonDriverCompareUserOnly.AutoSize = true;
            radioButtonDriverCompareUserOnly.Location = new Point(6, 24);
            radioButtonDriverCompareUserOnly.Name = "radioButtonDriverCompareUserOnly";
            radioButtonDriverCompareUserOnly.Size = new Size(117, 23);
            radioButtonDriverCompareUserOnly.TabIndex = 0;
            radioButtonDriverCompareUserOnly.TabStop = true;
            radioButtonDriverCompareUserOnly.Text = "Own runs only";
            radioButtonDriverCompareUserOnly.UseVisualStyleBackColor = true;
            radioButtonDriverCompareUserOnly.CheckedChanged += radioButtonDriverCompareUserOnly_CheckedChanged;
            // 
            // groupBoxUsername
            // 
            groupBoxUsername.Controls.Add(checkBoxUpdateUsernameForAllRuns);
            groupBoxUsername.Controls.Add(buttonUpdateUsername);
            groupBoxUsername.Controls.Add(textBoxUsername);
            groupBoxUsername.Location = new Point(8, 3);
            groupBoxUsername.Name = "groupBoxUsername";
            groupBoxUsername.Size = new Size(380, 100);
            groupBoxUsername.TabIndex = 2;
            groupBoxUsername.TabStop = false;
            groupBoxUsername.Text = "Username";
            // 
            // checkBoxUpdateUsernameForAllRuns
            // 
            checkBoxUpdateUsernameForAllRuns.AutoSize = true;
            checkBoxUpdateUsernameForAllRuns.Checked = true;
            checkBoxUpdateUsernameForAllRuns.CheckState = CheckState.Checked;
            checkBoxUpdateUsernameForAllRuns.Location = new Point(6, 55);
            checkBoxUpdateUsernameForAllRuns.Name = "checkBoxUpdateUsernameForAllRuns";
            checkBoxUpdateUsernameForAllRuns.Size = new Size(345, 23);
            checkBoxUpdateUsernameForAllRuns.TabIndex = 2;
            checkBoxUpdateUsernameForAllRuns.Text = "Update username for all saved runs (recommended)";
            checkBoxUpdateUsernameForAllRuns.UseVisualStyleBackColor = true;
            // 
            // buttonUpdateUsername
            // 
            buttonUpdateUsername.Location = new Point(299, 23);
            buttonUpdateUsername.Name = "buttonUpdateUsername";
            buttonUpdateUsername.Size = new Size(75, 25);
            buttonUpdateUsername.TabIndex = 1;
            buttonUpdateUsername.Text = "Update";
            buttonUpdateUsername.UseVisualStyleBackColor = true;
            buttonUpdateUsername.Click += buttonUpdateUsername_Click;
            // 
            // textBoxUsername
            // 
            textBoxUsername.Location = new Point(6, 24);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(287, 25);
            textBoxUsername.TabIndex = 0;
            // 
            // groupBoxLiveRunCarCategory
            // 
            groupBoxLiveRunCarCategory.Controls.Add(radioButtonCarCompareCarCategory);
            groupBoxLiveRunCarCategory.Controls.Add(radioButtonCarCompareAllCars);
            groupBoxLiveRunCarCategory.Controls.Add(radioButtonCarCompareCurrentCar);
            groupBoxLiveRunCarCategory.Location = new Point(8, 203);
            groupBoxLiveRunCarCategory.Name = "groupBoxLiveRunCarCategory";
            groupBoxLiveRunCarCategory.Size = new Size(380, 110);
            groupBoxLiveRunCarCategory.TabIndex = 1;
            groupBoxLiveRunCarCategory.TabStop = false;
            groupBoxLiveRunCarCategory.Text = "Live Hotrun: Compare against cars";
            // 
            // radioButtonCarCompareCarCategory
            // 
            radioButtonCarCompareCarCategory.AutoSize = true;
            radioButtonCarCompareCarCategory.Enabled = false;
            radioButtonCarCompareCarCategory.Location = new Point(6, 82);
            radioButtonCarCompareCarCategory.Name = "radioButtonCarCompareCarCategory";
            radioButtonCarCompareCarCategory.Size = new Size(201, 23);
            radioButtonCarCompareCarCategory.TabIndex = 2;
            radioButtonCarCompareCarCategory.TabStop = true;
            radioButtonCarCompareCarCategory.Text = "Car category (future update)";
            radioButtonCarCompareCarCategory.UseVisualStyleBackColor = true;
            // 
            // radioButtonCarCompareAllCars
            // 
            radioButtonCarCompareAllCars.AutoSize = true;
            radioButtonCarCompareAllCars.Location = new Point(6, 53);
            radioButtonCarCompareAllCars.Name = "radioButtonCarCompareAllCars";
            radioButtonCarCompareAllCars.Size = new Size(70, 23);
            radioButtonCarCompareAllCars.TabIndex = 1;
            radioButtonCarCompareAllCars.TabStop = true;
            radioButtonCarCompareAllCars.Text = "All cars";
            radioButtonCarCompareAllCars.UseVisualStyleBackColor = true;
            radioButtonCarCompareAllCars.CheckedChanged += radioButtonCarCompareAllCars_CheckedChanged;
            // 
            // radioButtonCarCompareCurrentCar
            // 
            radioButtonCarCompareCurrentCar.AutoSize = true;
            radioButtonCarCompareCurrentCar.Location = new Point(6, 24);
            radioButtonCarCompareCurrentCar.Name = "radioButtonCarCompareCurrentCar";
            radioButtonCarCompareCurrentCar.Size = new Size(150, 23);
            radioButtonCarCompareCurrentCar.TabIndex = 0;
            radioButtonCarCompareCurrentCar.TabStop = true;
            radioButtonCarCompareCurrentCar.Text = "Only the current car";
            radioButtonCarCompareCurrentCar.UseVisualStyleBackColor = true;
            radioButtonCarCompareCurrentCar.CheckedChanged += radioButtonCarCompareCurrentCar_CheckedChanged;
            // 
            // groupBoxStoreInvalidRuns
            // 
            groupBoxStoreInvalidRuns.Controls.Add(radioButtonStoreRunsWithPenaltiesDisabled);
            groupBoxStoreInvalidRuns.Controls.Add(radioButtonStoreRunsWithPenaltiesEnabled);
            groupBoxStoreInvalidRuns.Location = new Point(8, 109);
            groupBoxStoreInvalidRuns.Name = "groupBoxStoreInvalidRuns";
            groupBoxStoreInvalidRuns.Size = new Size(380, 88);
            groupBoxStoreInvalidRuns.TabIndex = 0;
            groupBoxStoreInvalidRuns.TabStop = false;
            groupBoxStoreInvalidRuns.Text = "Store Runs With Penalties";
            // 
            // radioButtonStoreRunsWithPenaltiesDisabled
            // 
            radioButtonStoreRunsWithPenaltiesDisabled.AutoSize = true;
            radioButtonStoreRunsWithPenaltiesDisabled.Location = new Point(6, 53);
            radioButtonStoreRunsWithPenaltiesDisabled.Name = "radioButtonStoreRunsWithPenaltiesDisabled";
            radioButtonStoreRunsWithPenaltiesDisabled.Size = new Size(141, 23);
            radioButtonStoreRunsWithPenaltiesDisabled.TabIndex = 1;
            radioButtonStoreRunsWithPenaltiesDisabled.TabStop = true;
            radioButtonStoreRunsWithPenaltiesDisabled.Text = "Do not store them";
            radioButtonStoreRunsWithPenaltiesDisabled.UseVisualStyleBackColor = true;
            radioButtonStoreRunsWithPenaltiesDisabled.CheckedChanged += radioButtonStoreRunsWithPenaltiesDisabled_CheckedChanged;
            // 
            // radioButtonStoreRunsWithPenaltiesEnabled
            // 
            radioButtonStoreRunsWithPenaltiesEnabled.AutoSize = true;
            radioButtonStoreRunsWithPenaltiesEnabled.Location = new Point(6, 24);
            radioButtonStoreRunsWithPenaltiesEnabled.Name = "radioButtonStoreRunsWithPenaltiesEnabled";
            radioButtonStoreRunsWithPenaltiesEnabled.Size = new Size(95, 23);
            radioButtonStoreRunsWithPenaltiesEnabled.TabIndex = 0;
            radioButtonStoreRunsWithPenaltiesEnabled.TabStop = true;
            radioButtonStoreRunsWithPenaltiesEnabled.Text = "Store them";
            radioButtonStoreRunsWithPenaltiesEnabled.UseVisualStyleBackColor = true;
            radioButtonStoreRunsWithPenaltiesEnabled.CheckedChanged += radioButtonStoreRunsWithPenaltiesEnabled_CheckedChanged;
            // 
            // tabPageDebug
            // 
            tabPageDebug.Controls.Add(debugBox);
            tabPageDebug.Location = new Point(4, 26);
            tabPageDebug.Name = "tabPageDebug";
            tabPageDebug.Padding = new Padding(3);
            tabPageDebug.Size = new Size(1223, 555);
            tabPageDebug.TabIndex = 1;
            tabPageDebug.Text = "Debug Page";
            tabPageDebug.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += ContinuousMainFormTick;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1240, 594);
            Controls.Add(tabControl1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "ACC Hotrun Compare";
            FormClosing += Form1_FormClosing;
            debugBox.ResumeLayout(false);
            debugBox.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPageMainAddRun.ResumeLayout(false);
            panelCurrentRunInfo.ResumeLayout(false);
            panelCurrentRunInfo.PerformLayout();
            tabPageCompareRuns.ResumeLayout(false);
            tabPageCompareRuns.PerformLayout();
            tabPageSettings.ResumeLayout(false);
            groupBoxLiveRunDriverCompare.ResumeLayout(false);
            groupBoxLiveRunDriverCompare.PerformLayout();
            groupBoxUsername.ResumeLayout(false);
            groupBoxUsername.PerformLayout();
            groupBoxLiveRunCarCategory.ResumeLayout(false);
            groupBoxLiveRunCarCategory.PerformLayout();
            groupBoxStoreInvalidRuns.ResumeLayout(false);
            groupBoxStoreInvalidRuns.PerformLayout();
            tabPageDebug.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private void InitializeDebugBox()
        {
            debugBox.Visible = true;

        }

        private void InitialzeOrderByCheckBox()
        {
            ComboBoxSortRunsBy.Items.Add(FormStrings.SortByFastestLapShortestFirst);
            ComboBoxSortRunsBy.Items.Add(FormStrings.SortByFastestLapShortestLast);
            ComboBoxSortRunsBy.Items.Add(FormStrings.SortByDateOldestFirst);
            ComboBoxSortRunsBy.Items.Add(FormStrings.SortByDateOldestLast);
            ComboBoxSortRunsBy.Items.Add(FormStrings.SortByTotalTimeShortestFirst);
            ComboBoxSortRunsBy.Items.Add(FormStrings.SortByTotalTimeShortestLast);
        }

        private void InitializeLabelsOnCurrentRunTab()
        {
            labelCurrentRunInfo.Text = "Track: ...\r\nCar: ...\r\nSession Length: ...";
            labelCurrentRunLaps.Text = "";
            labelRunData.Text = "";
            labelCurrentRunSectors.Text = "Start a run in the ACC Hostint \r\ngamemode to begin data collection.";
            labelTimeDifferenceFasterValue.Text = "...";
            labelTimeDifferenceFastestValue.Text = "...";
            labelPositionValue.Text = "Waiting...";
        }

        private GroupBox debugBox;
        private TextBox debugTextbox1;
        private TextBox debugTextBoxLapAmount;
        private TextBox debugTextBoxCarName;
        private TextBox debugTextBoxTrackname;
        private Button buttonCreateFakeRunInformation;
        private Label labelRadioSessionLength;
        private Label labelStaticLastSavedRun;
        private TabControl tabControl1;
        private TabPage tabPageMainAddRun;
        private TabPage tabPageDebug;
        private TabPage tabPageCompareRuns;
        private System.Windows.Forms.Timer timer1;
        private Label labelRunData;
        private ComboBox comboBoxTrackSelector;
        private ComboBox comboBoxTimeSelector;
        private ComboBox comboBoxCarSelector;
        private Label labelChooseSessionTime;
        private Label labelChooseCar;
        private Label labelChooseTrack;
        private CheckBox checkBoxDisplayRunsWIthPenalties;
        private Panel panelDisplayRuns;
        private Label labelSortBy;
        private ComboBox ComboBoxSortRunsBy;
        private Button resetDatabase;
        private Label labelCurrentRunInfo;
        private Label labelCurrentRunLaps;
        private Label labelCurrentRunSectors;
        private Panel panelCurrentRunInfo;
        private Label labelVersion;
        private Button buttonDeleteSelectedRuns;
        private Button ButtonCompareRuns;
        private Label labelPositionValue;
        private Label labelTimeDifferenceFastestText;
        private Label labelTimeDifferenceFasterText;
        private Label labelTimeDifferenceFastestValue;
        private Label labelTimeDifferenceFasterValue;
        private Label label2;
        private Button buttonImportRuns;
        private Button buttonExportSelectedRuns;
        private TabPage tabPageSettings;
        private GroupBox groupBoxStoreInvalidRuns;
        private RadioButton radioButtonStoreRunsWithPenaltiesDisabled;
        private RadioButton radioButtonStoreRunsWithPenaltiesEnabled;
        private GroupBox groupBoxLiveRunCarCategory;
        private RadioButton radioButtonCarCompareCurrentCar;
        private RadioButton radioButtonCarCompareAllCars;
        private RadioButton radioButtonCarCompareCarCategory;
        private GroupBox groupBoxUsername;
        private CheckBox checkBoxUpdateUsernameForAllRuns;
        private Button buttonUpdateUsername;
        private TextBox textBoxUsername;
        private GroupBox groupBoxLiveRunDriverCompare;
        private RadioButton radioButtonDriverCompareAllDrivers;
        private RadioButton radioButtonDriverCompareUserOnly;
    }
}