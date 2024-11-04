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
            labelLastSavedRunData = new Label();
            labelCurrentRunInfo = new Label();
            labelCurrentRunLaps = new Label();
            labelCurrentRunSectors = new Label();
            tabPageCompareRuns = new TabPage();
            CheckBoxDisplayOwnRunsOnly = new CheckBox();
            ButtonCompareRuns = new Button();
            buttonImportRuns = new Button();
            buttonExportSelectedRuns = new Button();
            buttonDeleteSelectedRuns = new Button();
            ComboBoxSortRunsBy = new ComboBox();
            labelSortBy = new Label();
            panelDisplayRuns = new Panel();
            panel2 = new Panel();
            panel1 = new Panel();
            button1 = new Button();
            EditorPreviewLabel7 = new Label();
            EditorPreviewLabel6 = new Label();
            EditorPreviewLabel5 = new Label();
            EditorPreviewLabel4 = new Label();
            EditorPreviewLabel3 = new Label();
            EditorPreviewLabel1 = new Label();
            checkBox1 = new CheckBox();
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
            panelDisplayRuns.SuspendLayout();
            panel1.SuspendLayout();
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
            debugBox.Size = new Size(929, 527);
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
            debugTextbox1.Location = new Point(275, 17);
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
            labelRadioSessionLength.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelRadioSessionLength.Location = new Point(3, 9);
            labelRadioSessionLength.Name = "labelRadioSessionLength";
            labelRadioSessionLength.Size = new Size(185, 25);
            labelRadioSessionLength.TabIndex = 7;
            labelRadioSessionLength.Text = "Current Session Info";
            // 
            // labelStaticLastSavedRun
            // 
            labelStaticLastSavedRun.AutoSize = true;
            labelStaticLastSavedRun.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            labelStaticLastSavedRun.Location = new Point(427, 119);
            labelStaticLastSavedRun.Name = "labelStaticLastSavedRun";
            labelStaticLastSavedRun.Size = new Size(141, 25);
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
            tabControl1.Size = new Size(949, 1000);
            tabControl1.SizeMode = TabSizeMode.FillToRight;
            tabControl1.TabIndex = 9;
            // 
            // tabPageMainAddRun
            // 
            tabPageMainAddRun.AutoScroll = true;
            tabPageMainAddRun.Controls.Add(panelCurrentRunInfo);
            tabPageMainAddRun.Location = new Point(4, 26);
            tabPageMainAddRun.Margin = new Padding(0);
            tabPageMainAddRun.Name = "tabPageMainAddRun";
            tabPageMainAddRun.Padding = new Padding(3);
            tabPageMainAddRun.Size = new Size(941, 970);
            tabPageMainAddRun.TabIndex = 0;
            tabPageMainAddRun.Text = "Add New Run";
            tabPageMainAddRun.UseVisualStyleBackColor = true;
            // 
            // panelCurrentRunInfo
            // 
            panelCurrentRunInfo.AutoScroll = true;
            panelCurrentRunInfo.Controls.Add(labelTimeDifferenceFastestValue);
            panelCurrentRunInfo.Controls.Add(labelTimeDifferenceFasterValue);
            panelCurrentRunInfo.Controls.Add(label2);
            panelCurrentRunInfo.Controls.Add(labelTimeDifferenceFastestText);
            panelCurrentRunInfo.Controls.Add(labelTimeDifferenceFasterText);
            panelCurrentRunInfo.Controls.Add(labelPositionValue);
            panelCurrentRunInfo.Controls.Add(labelLastSavedRunData);
            panelCurrentRunInfo.Controls.Add(labelCurrentRunInfo);
            panelCurrentRunInfo.Controls.Add(labelCurrentRunLaps);
            panelCurrentRunInfo.Controls.Add(labelRadioSessionLength);
            panelCurrentRunInfo.Controls.Add(labelCurrentRunSectors);
            panelCurrentRunInfo.Controls.Add(labelStaticLastSavedRun);
            panelCurrentRunInfo.Location = new Point(0, 0);
            panelCurrentRunInfo.Margin = new Padding(0);
            panelCurrentRunInfo.Name = "panelCurrentRunInfo";
            panelCurrentRunInfo.Size = new Size(941, 970);
            panelCurrentRunInfo.TabIndex = 13;
            // 
            // labelTimeDifferenceFastestValue
            // 
            labelTimeDifferenceFastestValue.AutoSize = true;
            labelTimeDifferenceFastestValue.Font = new Font("Noto Mono", 11.25F);
            labelTimeDifferenceFastestValue.Location = new Point(804, 79);
            labelTimeDifferenceFastestValue.Margin = new Padding(0);
            labelTimeDifferenceFastestValue.Name = "labelTimeDifferenceFastestValue";
            labelTimeDifferenceFastestValue.Size = new Size(71, 18);
            labelTimeDifferenceFastestValue.TabIndex = 18;
            labelTimeDifferenceFastestValue.Text = "23.456s";
            // 
            // labelTimeDifferenceFasterValue
            // 
            labelTimeDifferenceFasterValue.AutoSize = true;
            labelTimeDifferenceFasterValue.Font = new Font("Noto Mono", 11.25F);
            labelTimeDifferenceFasterValue.Location = new Point(804, 59);
            labelTimeDifferenceFasterValue.Margin = new Padding(0);
            labelTimeDifferenceFasterValue.Name = "labelTimeDifferenceFasterValue";
            labelTimeDifferenceFasterValue.Size = new Size(71, 18);
            labelTimeDifferenceFasterValue.TabIndex = 17;
            labelTimeDifferenceFasterValue.Text = "12.345s";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F);
            label2.Location = new Point(740, 37);
            label2.Margin = new Padding(3, 0, 0, 0);
            label2.Name = "label2";
            label2.Size = new Size(64, 20);
            label2.TabIndex = 16;
            label2.Text = "Position:";
            // 
            // labelTimeDifferenceFastestText
            // 
            labelTimeDifferenceFastestText.AutoSize = true;
            labelTimeDifferenceFastestText.Font = new Font("Segoe UI", 11.25F);
            labelTimeDifferenceFastestText.Location = new Point(589, 77);
            labelTimeDifferenceFastestText.Margin = new Padding(0);
            labelTimeDifferenceFastestText.Name = "labelTimeDifferenceFastestText";
            labelTimeDifferenceFastestText.Size = new Size(215, 20);
            labelTimeDifferenceFastestText.TabIndex = 15;
            labelTimeDifferenceFastestText.Text = "Time Difference To Fastest Run:";
            // 
            // labelTimeDifferenceFasterText
            // 
            labelTimeDifferenceFasterText.AutoSize = true;
            labelTimeDifferenceFasterText.Font = new Font("Segoe UI", 11.25F);
            labelTimeDifferenceFasterText.Location = new Point(595, 57);
            labelTimeDifferenceFasterText.Margin = new Padding(0);
            labelTimeDifferenceFasterText.Name = "labelTimeDifferenceFasterText";
            labelTimeDifferenceFasterText.Size = new Size(209, 20);
            labelTimeDifferenceFasterText.TabIndex = 14;
            labelTimeDifferenceFasterText.Text = "Time Difference To Faster Run:";
            // 
            // labelPositionValue
            // 
            labelPositionValue.AutoSize = true;
            labelPositionValue.Font = new Font("Noto Mono", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelPositionValue.Location = new Point(804, 34);
            labelPositionValue.Margin = new Padding(0, 0, 3, 0);
            labelPositionValue.Name = "labelPositionValue";
            labelPositionValue.Size = new Size(62, 24);
            labelPositionValue.TabIndex = 13;
            labelPositionValue.Text = "6/12";
            // 
            // labelLastSavedRunData
            // 
            labelLastSavedRunData.AutoSize = true;
            labelLastSavedRunData.Font = new Font("Noto Mono", 11.25F);
            labelLastSavedRunData.Location = new Point(427, 144);
            labelLastSavedRunData.Name = "labelLastSavedRunData";
            labelLastSavedRunData.Size = new Size(359, 54);
            labelLastSavedRunData.TabIndex = 9;
            labelLastSavedRunData.Text = "Lap 1 | 1:11.123 | 11.123 12.123 13.123\r\nLap 2 | 2:22.123 | 21.123 22.123 23.123\r\nLap 3 | 3:33.123 | 31.123 23.123 33.123\r\n";
            // 
            // labelCurrentRunInfo
            // 
            labelCurrentRunInfo.AutoSize = true;
            labelCurrentRunInfo.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelCurrentRunInfo.Location = new Point(3, 34);
            labelCurrentRunInfo.Name = "labelCurrentRunInfo";
            labelCurrentRunInfo.Size = new Size(186, 60);
            labelCurrentRunInfo.TabIndex = 10;
            labelCurrentRunInfo.Text = "Track: ABC\r\nCar: ABC\r\nSession Length: 99 minutes";
            // 
            // labelCurrentRunLaps
            // 
            labelCurrentRunLaps.AutoSize = true;
            labelCurrentRunLaps.Font = new Font("Noto Mono", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelCurrentRunLaps.Location = new Point(3, 144);
            labelCurrentRunLaps.Name = "labelCurrentRunLaps";
            labelCurrentRunLaps.Size = new Size(161, 180);
            labelCurrentRunLaps.TabIndex = 11;
            labelCurrentRunLaps.Text = "Lap  1 | 1:11.123\r\nLap  2 | 1:12.123\r\nLap  3 | 1:13.123\r\nLap  4 | 1:14.123\r\nLap  5 | 1:15.123\r\nLap  6 | 1:16.123\r\nLap  7 | 1:17.123\r\nLap  8 | 1:18.123\r\nLap  9 | 1:19.123\r\nLap 10 | 1:20.123";
            // 
            // labelCurrentRunSectors
            // 
            labelCurrentRunSectors.AutoSize = true;
            labelCurrentRunSectors.Font = new Font("Noto Mono", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelCurrentRunSectors.Location = new Point(170, 144);
            labelCurrentRunSectors.Name = "labelCurrentRunSectors";
            labelCurrentRunSectors.Size = new Size(251, 144);
            labelCurrentRunSectors.TabIndex = 12;
            labelCurrentRunSectors.Text = resources.GetString("labelCurrentRunSectors.Text");
            // 
            // tabPageCompareRuns
            // 
            tabPageCompareRuns.Controls.Add(CheckBoxDisplayOwnRunsOnly);
            tabPageCompareRuns.Controls.Add(ButtonCompareRuns);
            tabPageCompareRuns.Controls.Add(buttonImportRuns);
            tabPageCompareRuns.Controls.Add(buttonExportSelectedRuns);
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
            tabPageCompareRuns.Size = new Size(941, 970);
            tabPageCompareRuns.TabIndex = 2;
            tabPageCompareRuns.Text = "Compare Runs";
            tabPageCompareRuns.UseVisualStyleBackColor = true;
            // 
            // CheckBoxDisplayOwnRunsOnly
            // 
            CheckBoxDisplayOwnRunsOnly.AutoSize = true;
            CheckBoxDisplayOwnRunsOnly.Font = new Font("Segoe UI", 11.25F);
            CheckBoxDisplayOwnRunsOnly.Location = new Point(213, 73);
            CheckBoxDisplayOwnRunsOnly.Name = "CheckBoxDisplayOwnRunsOnly";
            CheckBoxDisplayOwnRunsOnly.Size = new Size(172, 24);
            CheckBoxDisplayOwnRunsOnly.TabIndex = 14;
            CheckBoxDisplayOwnRunsOnly.Text = "Display own runs only";
            CheckBoxDisplayOwnRunsOnly.UseVisualStyleBackColor = true;
            CheckBoxDisplayOwnRunsOnly.CheckedChanged += CheckBoxDisplayOwnRunsOnly_CheckedChanged;
            // 
            // ButtonCompareRuns
            // 
            ButtonCompareRuns.Font = new Font("Segoe UI", 11.25F);
            ButtonCompareRuns.Location = new Point(279, 124);
            ButtonCompareRuns.Name = "ButtonCompareRuns";
            ButtonCompareRuns.Size = new Size(159, 27);
            ButtonCompareRuns.TabIndex = 11;
            ButtonCompareRuns.Text = "Show Selected Run(s)";
            ButtonCompareRuns.UseVisualStyleBackColor = true;
            ButtonCompareRuns.Click += ButtonCompareRuns_Click;
            // 
            // buttonImportRuns
            // 
            buttonImportRuns.Font = new Font("Segoe UI", 11.25F);
            buttonImportRuns.Location = new Point(771, 124);
            buttonImportRuns.Name = "buttonImportRuns";
            buttonImportRuns.Size = new Size(99, 27);
            buttonImportRuns.TabIndex = 13;
            buttonImportRuns.Text = "Import Runs";
            buttonImportRuns.UseVisualStyleBackColor = true;
            buttonImportRuns.Click += buttonImportRuns_Click;
            // 
            // buttonExportSelectedRuns
            // 
            buttonExportSelectedRuns.Font = new Font("Segoe UI", 11.25F);
            buttonExportSelectedRuns.Location = new Point(608, 124);
            buttonExportSelectedRuns.Name = "buttonExportSelectedRuns";
            buttonExportSelectedRuns.Size = new Size(157, 27);
            buttonExportSelectedRuns.TabIndex = 12;
            buttonExportSelectedRuns.Text = "Export Selected Runs";
            buttonExportSelectedRuns.UseVisualStyleBackColor = true;
            buttonExportSelectedRuns.Click += ButtonExportSelectedRuns_Click;
            // 
            // buttonDeleteSelectedRuns
            // 
            buttonDeleteSelectedRuns.Font = new Font("Segoe UI", 11.25F);
            buttonDeleteSelectedRuns.Location = new Point(444, 124);
            buttonDeleteSelectedRuns.Name = "buttonDeleteSelectedRuns";
            buttonDeleteSelectedRuns.Size = new Size(158, 27);
            buttonDeleteSelectedRuns.TabIndex = 10;
            buttonDeleteSelectedRuns.Text = "Delete Selected Runs";
            buttonDeleteSelectedRuns.UseVisualStyleBackColor = true;
            buttonDeleteSelectedRuns.Click += buttonDeleteSelectedRuns_Click;
            // 
            // ComboBoxSortRunsBy
            // 
            ComboBoxSortRunsBy.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxSortRunsBy.Font = new Font("Segoe UI", 11.25F);
            ComboBoxSortRunsBy.FormattingEnabled = true;
            ComboBoxSortRunsBy.Location = new Point(3, 123);
            ComboBoxSortRunsBy.Name = "ComboBoxSortRunsBy";
            ComboBoxSortRunsBy.Size = new Size(270, 28);
            ComboBoxSortRunsBy.TabIndex = 9;
            ComboBoxSortRunsBy.SelectedIndexChanged += ComboBoxSortRunsBy_SelectedIndexChanged;
            // 
            // labelSortBy
            // 
            labelSortBy.AutoSize = true;
            labelSortBy.Font = new Font("Segoe UI", 11.25F);
            labelSortBy.Location = new Point(3, 100);
            labelSortBy.Name = "labelSortBy";
            labelSortBy.Size = new Size(56, 20);
            labelSortBy.TabIndex = 8;
            labelSortBy.Text = "Sort by";
            // 
            // panelDisplayRuns
            // 
            panelDisplayRuns.AutoScroll = true;
            panelDisplayRuns.Controls.Add(panel2);
            panelDisplayRuns.Controls.Add(panel1);
            panelDisplayRuns.Font = new Font("Segoe UI", 11.25F);
            panelDisplayRuns.Location = new Point(3, 157);
            panelDisplayRuns.Name = "panelDisplayRuns";
            panelDisplayRuns.Size = new Size(935, 810);
            panelDisplayRuns.TabIndex = 7;
            // 
            // panel2
            // 
            panel2.Location = new Point(5, 87);
            panel2.Margin = new Padding(0);
            panel2.Name = "panel2";
            panel2.Size = new Size(200, 100);
            panel2.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Controls.Add(button1);
            panel1.Controls.Add(EditorPreviewLabel7);
            panel1.Controls.Add(EditorPreviewLabel6);
            panel1.Controls.Add(EditorPreviewLabel5);
            panel1.Controls.Add(EditorPreviewLabel4);
            panel1.Controls.Add(EditorPreviewLabel3);
            panel1.Controls.Add(EditorPreviewLabel1);
            panel1.Controls.Add(checkBox1);
            panel1.Location = new Point(5, 3);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(927, 84);
            panel1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(104, 49);
            button1.Name = "button1";
            button1.Size = new Size(85, 30);
            button1.TabIndex = 7;
            button1.Text = "Details ->";
            button1.UseVisualStyleBackColor = true;
            // 
            // EditorPreviewLabel7
            // 
            EditorPreviewLabel7.AutoSize = true;
            EditorPreviewLabel7.Location = new Point(195, 59);
            EditorPreviewLabel7.Name = "EditorPreviewLabel7";
            EditorPreviewLabel7.Size = new Size(210, 20);
            EditorPreviewLabel7.TabIndex = 6;
            EditorPreviewLabel7.Text = "Driven at: 13/10/2024 15:32:12";
            // 
            // EditorPreviewLabel6
            // 
            EditorPreviewLabel6.AutoSize = true;
            EditorPreviewLabel6.Font = new Font("Segoe UI", 12F);
            EditorPreviewLabel6.Location = new Point(20, 25);
            EditorPreviewLabel6.Name = "EditorPreviewLabel6";
            EditorPreviewLabel6.Size = new Size(93, 21);
            EditorPreviewLabel6.TabIndex = 5;
            EditorPreviewLabel6.Text = "FL: 2:19.981";
            // 
            // EditorPreviewLabel5
            // 
            EditorPreviewLabel5.AutoSize = true;
            EditorPreviewLabel5.Location = new Point(195, 39);
            EditorPreviewLabel5.Name = "EditorPreviewLabel5";
            EditorPreviewLabel5.Size = new Size(143, 20);
            EditorPreviewLabel5.TabIndex = 4;
            EditorPreviewLabel5.Text = "Info: Setup Safe v2.1";
            // 
            // EditorPreviewLabel4
            // 
            EditorPreviewLabel4.AutoSize = true;
            EditorPreviewLabel4.Location = new Point(195, 0);
            EditorPreviewLabel4.Name = "EditorPreviewLabel4";
            EditorPreviewLabel4.Size = new Size(153, 20);
            EditorPreviewLabel4.TabIndex = 3;
            EditorPreviewLabel4.Text = "Car: Toyota Yaris 2007";
            // 
            // EditorPreviewLabel3
            // 
            EditorPreviewLabel3.AutoSize = true;
            EditorPreviewLabel3.Location = new Point(195, 19);
            EditorPreviewLabel3.Name = "EditorPreviewLabel3";
            EditorPreviewLabel3.Size = new Size(88, 20);
            EditorPreviewLabel3.TabIndex = 2;
            EditorPreviewLabel3.Text = "Driver: Witti";
            // 
            // EditorPreviewLabel1
            // 
            EditorPreviewLabel1.AutoSize = true;
            EditorPreviewLabel1.Font = new Font("Segoe UI", 14F);
            EditorPreviewLabel1.Location = new Point(20, 0);
            EditorPreviewLabel1.Name = "EditorPreviewLabel1";
            EditorPreviewLabel1.Size = new Size(178, 25);
            EditorPreviewLabel1.TabIndex = 1;
            EditorPreviewLabel1.Text = "-:15:41.818 (10 laps)";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(3, 25);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(15, 14);
            checkBox1.TabIndex = 0;
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBoxDisplayRunsWIthPenalties
            // 
            checkBoxDisplayRunsWIthPenalties.AutoSize = true;
            checkBoxDisplayRunsWIthPenalties.Font = new Font("Segoe UI", 11.25F);
            checkBoxDisplayRunsWIthPenalties.Location = new Point(3, 73);
            checkBoxDisplayRunsWIthPenalties.Name = "checkBoxDisplayRunsWIthPenalties";
            checkBoxDisplayRunsWIthPenalties.Size = new Size(204, 24);
            checkBoxDisplayRunsWIthPenalties.TabIndex = 6;
            checkBoxDisplayRunsWIthPenalties.Text = "Display runs with penalties";
            checkBoxDisplayRunsWIthPenalties.UseVisualStyleBackColor = true;
            checkBoxDisplayRunsWIthPenalties.CheckedChanged += checkBoxDisplayRunsWIthPenalties_CheckedChanged;
            // 
            // labelChooseSessionTime
            // 
            labelChooseSessionTime.AutoSize = true;
            labelChooseSessionTime.Font = new Font("Segoe UI", 11.25F);
            labelChooseSessionTime.Location = new Point(499, 18);
            labelChooseSessionTime.Name = "labelChooseSessionTime";
            labelChooseSessionTime.Size = new Size(95, 20);
            labelChooseSessionTime.TabIndex = 5;
            labelChooseSessionTime.Text = "Session Time";
            // 
            // labelChooseCar
            // 
            labelChooseCar.AutoSize = true;
            labelChooseCar.Font = new Font("Segoe UI", 11.25F);
            labelChooseCar.Location = new Point(238, 18);
            labelChooseCar.Name = "labelChooseCar";
            labelChooseCar.Size = new Size(31, 20);
            labelChooseCar.TabIndex = 4;
            labelChooseCar.Text = "Car";
            // 
            // labelChooseTrack
            // 
            labelChooseTrack.AutoSize = true;
            labelChooseTrack.Font = new Font("Segoe UI", 11.25F);
            labelChooseTrack.Location = new Point(3, 18);
            labelChooseTrack.Name = "labelChooseTrack";
            labelChooseTrack.Size = new Size(43, 20);
            labelChooseTrack.TabIndex = 3;
            labelChooseTrack.Text = "Track";
            // 
            // comboBoxTimeSelector
            // 
            comboBoxTimeSelector.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTimeSelector.Font = new Font("Segoe UI", 11.25F);
            comboBoxTimeSelector.FormattingEnabled = true;
            comboBoxTimeSelector.Items.AddRange(new object[] { "5 minutes", "10 minutes", "15 minutes", "30 minutes", "60 minutes" });
            comboBoxTimeSelector.Location = new Point(499, 41);
            comboBoxTimeSelector.Name = "comboBoxTimeSelector";
            comboBoxTimeSelector.Size = new Size(181, 28);
            comboBoxTimeSelector.TabIndex = 2;
            comboBoxTimeSelector.SelectedIndexChanged += comboBoxTimeSelector_SelectedIndexChanged;
            // 
            // comboBoxCarSelector
            // 
            comboBoxCarSelector.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCarSelector.Font = new Font("Segoe UI", 11.25F);
            comboBoxCarSelector.FormattingEnabled = true;
            comboBoxCarSelector.Items.AddRange(new object[] { "DEBUG_CAR", "ANOTHER_CAR", "FAKE_CAR" });
            comboBoxCarSelector.Location = new Point(238, 41);
            comboBoxCarSelector.Name = "comboBoxCarSelector";
            comboBoxCarSelector.Size = new Size(255, 28);
            comboBoxCarSelector.TabIndex = 1;
            comboBoxCarSelector.SelectedIndexChanged += comboBoxCarSelector_SelectedIndexChanged;
            // 
            // comboBoxTrackSelector
            // 
            comboBoxTrackSelector.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTrackSelector.Font = new Font("Segoe UI", 11.25F);
            comboBoxTrackSelector.FormattingEnabled = true;
            comboBoxTrackSelector.Items.AddRange(new object[] { "0", "4", "5", "6", "7", "8", "9", "ANOTHER_TRACK", "DEBUG_TRACK", "MADE_UP_TRACK" });
            comboBoxTrackSelector.Location = new Point(3, 41);
            comboBoxTrackSelector.Name = "comboBoxTrackSelector";
            comboBoxTrackSelector.Size = new Size(229, 28);
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
            tabPageSettings.Size = new Size(941, 970);
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
            tabPageDebug.Size = new Size(941, 970);
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
            ClientSize = new Size(958, 1000);
            Controls.Add(tabControl1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(974, 1030);
            Name = "MainForm";
            Text = "ACC Hotrun Compare";
            FormClosing += Form1_FormClosing;
            SizeChanged += MainForm_SizeChanged;
            debugBox.ResumeLayout(false);
            debugBox.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPageMainAddRun.ResumeLayout(false);
            panelCurrentRunInfo.ResumeLayout(false);
            panelCurrentRunInfo.PerformLayout();
            tabPageCompareRuns.ResumeLayout(false);
            tabPageCompareRuns.PerformLayout();
            panelDisplayRuns.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
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
            labelLastSavedRunData.Text = "";
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
        private Label labelLastSavedRunData;
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
        private CheckBox CheckBoxDisplayOwnRunsOnly;
        private Panel panel1;
        private Label EditorPreviewLabel1;
        private CheckBox checkBox1;
        private Label EditorPreviewLabel3;
        private Label EditorPreviewLabel4;
        private Label EditorPreviewLabel5;
        private Label EditorPreviewLabel6;
        private Label EditorPreviewLabel7;
        private Button button1;
        private Panel panel2;
    }
}