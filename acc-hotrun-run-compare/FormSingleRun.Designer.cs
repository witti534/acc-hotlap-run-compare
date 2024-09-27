namespace acc_hotrun_run_compare
{
    partial class FormSingleRun
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSingleRun));
            labelRunInfoStatic = new Label();
            TextBoxRunDescription = new TextBox();
            LabelRunInfo = new Label();
            ButtonSaveRunInfoText = new Button();
            labelRunTotalTime = new Label();
            labelLapDelete = new Label();
            labelLapTimeDelete = new Label();
            labelSector1Delete = new Label();
            labelSector2Delete = new Label();
            labelSector3Delete = new Label();
            labelSeperator1Delete = new Label();
            labelSeperator2Delete = new Label();
            LabelDriverName = new Label();
            TextBoxDriverName = new TextBox();
            ButtonSaveDriverName = new Button();
            SuspendLayout();
            // 
            // labelRunInfoStatic
            // 
            labelRunInfoStatic.AutoSize = true;
            labelRunInfoStatic.Font = new Font("Noto Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelRunInfoStatic.Location = new Point(17, 11);
            labelRunInfoStatic.Margin = new Padding(4, 0, 4, 0);
            labelRunInfoStatic.Name = "labelRunInfoStatic";
            labelRunInfoStatic.Size = new Size(269, 57);
            labelRunInfoStatic.TabIndex = 11;
            labelRunInfoStatic.Text = "Track: ABC\r\nCar: ABC\r\nSession Length: 99 minutes";
            // 
            // TextBoxRunDescription
            // 
            TextBoxRunDescription.Location = new Point(84, 125);
            TextBoxRunDescription.Margin = new Padding(4);
            TextBoxRunDescription.Name = "TextBoxRunDescription";
            TextBoxRunDescription.Size = new Size(647, 26);
            TextBoxRunDescription.TabIndex = 12;
            // 
            // LabelRunInfo
            // 
            LabelRunInfo.AutoSize = true;
            LabelRunInfo.Font = new Font("Noto Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LabelRunInfo.Location = new Point(17, 128);
            LabelRunInfo.Margin = new Padding(4, 0, 4, 0);
            LabelRunInfo.Name = "LabelRunInfo";
            LabelRunInfo.Size = new Size(59, 19);
            LabelRunInfo.TabIndex = 13;
            LabelRunInfo.Text = "Info:";
            // 
            // ButtonSaveRunInfoText
            // 
            ButtonSaveRunInfoText.Image = (Image)resources.GetObject("ButtonSaveRunInfoText.Image");
            ButtonSaveRunInfoText.Location = new Point(739, 121);
            ButtonSaveRunInfoText.Margin = new Padding(4);
            ButtonSaveRunInfoText.Name = "ButtonSaveRunInfoText";
            ButtonSaveRunInfoText.Size = new Size(40, 33);
            ButtonSaveRunInfoText.TabIndex = 14;
            ButtonSaveRunInfoText.UseVisualStyleBackColor = true;
            ButtonSaveRunInfoText.Click += ButtonSaveRunInfoText_Click;
            // 
            // labelRunTotalTime
            // 
            labelRunTotalTime.AutoSize = true;
            labelRunTotalTime.Font = new Font("Noto Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelRunTotalTime.Location = new Point(17, 167);
            labelRunTotalTime.Margin = new Padding(4, 0, 4, 0);
            labelRunTotalTime.Name = "labelRunTotalTime";
            labelRunTotalTime.Size = new Size(279, 19);
            labelRunTotalTime.TabIndex = 15;
            labelRunTotalTime.Text = "Total Run Time: -:13:37.123";
            // 
            // labelLapDelete
            // 
            labelLapDelete.AutoSize = true;
            labelLapDelete.Font = new Font("Noto Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelLapDelete.Location = new Point(17, 200);
            labelLapDelete.Margin = new Padding(4, 0, 4, 0);
            labelLapDelete.Name = "labelLapDelete";
            labelLapDelete.Size = new Size(99, 19);
            labelLapDelete.TabIndex = 16;
            labelLapDelete.Text = "Lap   1 |";
            // 
            // labelLapTimeDelete
            // 
            labelLapTimeDelete.AutoSize = true;
            labelLapTimeDelete.Font = new Font("Noto Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelLapTimeDelete.Location = new Point(124, 200);
            labelLapTimeDelete.Margin = new Padding(4, 0, 4, 0);
            labelLapTimeDelete.Name = "labelLapTimeDelete";
            labelLapTimeDelete.Size = new Size(89, 19);
            labelLapTimeDelete.TabIndex = 17;
            labelLapTimeDelete.Text = "1:32:798";
            // 
            // labelSector1Delete
            // 
            labelSector1Delete.AutoSize = true;
            labelSector1Delete.Font = new Font("Noto Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelSector1Delete.Location = new Point(271, 200);
            labelSector1Delete.Margin = new Padding(4, 0, 4, 0);
            labelSector1Delete.Name = "labelSector1Delete";
            labelSector1Delete.Size = new Size(79, 19);
            labelSector1Delete.TabIndex = 18;
            labelSector1Delete.Text = " 82:314";
            // 
            // labelSector2Delete
            // 
            labelSector2Delete.AutoSize = true;
            labelSector2Delete.Font = new Font("Noto Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelSector2Delete.Location = new Point(385, 200);
            labelSector2Delete.Margin = new Padding(4, 0, 4, 0);
            labelSector2Delete.Name = "labelSector2Delete";
            labelSector2Delete.Size = new Size(79, 19);
            labelSector2Delete.TabIndex = 19;
            labelSector2Delete.Text = " 42:221";
            // 
            // labelSector3Delete
            // 
            labelSector3Delete.AutoSize = true;
            labelSector3Delete.Font = new Font("Noto Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelSector3Delete.Location = new Point(499, 200);
            labelSector3Delete.Margin = new Padding(4, 0, 4, 0);
            labelSector3Delete.Name = "labelSector3Delete";
            labelSector3Delete.Size = new Size(79, 19);
            labelSector3Delete.TabIndex = 20;
            labelSector3Delete.Text = " 22:515";
            // 
            // labelSeperator1Delete
            // 
            labelSeperator1Delete.AutoSize = true;
            labelSeperator1Delete.Font = new Font("Noto Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelSeperator1Delete.Location = new Point(358, 200);
            labelSeperator1Delete.Margin = new Padding(4, 0, 4, 0);
            labelSeperator1Delete.Name = "labelSeperator1Delete";
            labelSeperator1Delete.Size = new Size(19, 19);
            labelSeperator1Delete.TabIndex = 21;
            labelSeperator1Delete.Text = "|";
            // 
            // labelSeperator2Delete
            // 
            labelSeperator2Delete.AutoSize = true;
            labelSeperator2Delete.Font = new Font("Noto Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelSeperator2Delete.Location = new Point(472, 200);
            labelSeperator2Delete.Margin = new Padding(4, 0, 4, 0);
            labelSeperator2Delete.Name = "labelSeperator2Delete";
            labelSeperator2Delete.Size = new Size(19, 19);
            labelSeperator2Delete.TabIndex = 22;
            labelSeperator2Delete.Text = "|";
            // 
            // LabelDriverName
            // 
            LabelDriverName.AutoSize = true;
            LabelDriverName.Location = new Point(17, 94);
            LabelDriverName.Name = "LabelDriverName";
            LabelDriverName.Size = new Size(129, 19);
            LabelDriverName.TabIndex = 23;
            LabelDriverName.Text = "Driver name:";
            // 
            // TextBoxDriverName
            // 
            TextBoxDriverName.Location = new Point(153, 91);
            TextBoxDriverName.Margin = new Padding(4);
            TextBoxDriverName.Name = "TextBoxDriverName";
            TextBoxDriverName.Size = new Size(578, 26);
            TextBoxDriverName.TabIndex = 24;
            // 
            // ButtonSaveDriverName
            // 
            ButtonSaveDriverName.Image = (Image)resources.GetObject("ButtonSaveDriverName.Image");
            ButtonSaveDriverName.Location = new Point(739, 87);
            ButtonSaveDriverName.Margin = new Padding(4);
            ButtonSaveDriverName.Name = "ButtonSaveDriverName";
            ButtonSaveDriverName.Size = new Size(40, 33);
            ButtonSaveDriverName.TabIndex = 25;
            ButtonSaveDriverName.UseVisualStyleBackColor = true;
            ButtonSaveDriverName.Click += ButtonSaveDriverName_Click;
            // 
            // FormSingleRun
            // 
            AutoScaleDimensions = new SizeF(10F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(872, 508);
            Controls.Add(ButtonSaveDriverName);
            Controls.Add(TextBoxDriverName);
            Controls.Add(LabelDriverName);
            Controls.Add(labelSeperator2Delete);
            Controls.Add(labelSeperator1Delete);
            Controls.Add(labelSector3Delete);
            Controls.Add(labelSector2Delete);
            Controls.Add(labelSector1Delete);
            Controls.Add(labelLapTimeDelete);
            Controls.Add(labelLapDelete);
            Controls.Add(labelRunTotalTime);
            Controls.Add(ButtonSaveRunInfoText);
            Controls.Add(LabelRunInfo);
            Controls.Add(TextBoxRunDescription);
            Controls.Add(labelRunInfoStatic);
            Font = new Font("Noto Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "FormSingleRun";
            Text = "Details Single Run";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelRunInfoStatic;
        private TextBox TextBoxRunDescription;
        private Label LabelRunInfo;
        private Button ButtonSaveRunInfoText;
        private Label labelRunTotalTime;
        private Label labelLapDelete;
        private Label labelLapTimeDelete;
        private Label labelSector1Delete;
        private Label labelSector2Delete;
        private Label labelSector3Delete;
        private Label labelSeperator1Delete;
        private Label labelSeperator2Delete;
        private Label LabelDriverName;
        private TextBox TextBoxDriverName;
        private Button ButtonSaveDriverName;
    }
}