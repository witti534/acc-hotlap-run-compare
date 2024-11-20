namespace acc_hotrun_run_compare
{
    partial class FormMultipleRuns
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMultipleRuns));
            labelRunInfoStatic = new Label();
            ButtonShowLaptimes = new Button();
            ButtonShowTimeDifference = new Button();
            SuspendLayout();
            // 
            // labelRunInfoStatic
            // 
            labelRunInfoStatic.AutoSize = true;
            labelRunInfoStatic.Font = new Font("Segoe UI", 11.25F);
            labelRunInfoStatic.Location = new Point(13, 9);
            labelRunInfoStatic.Margin = new Padding(4, 0, 4, 0);
            labelRunInfoStatic.Name = "labelRunInfoStatic";
            labelRunInfoStatic.Size = new Size(186, 40);
            labelRunInfoStatic.TabIndex = 12;
            labelRunInfoStatic.Text = "Track: ABC\r\nSession Length: 99 minutes";
            // 
            // ButtonShowLaptimes
            // 
            ButtonShowLaptimes.Font = new Font("Segoe UI", 11.25F);
            ButtonShowLaptimes.Location = new Point(485, 12);
            ButtonShowLaptimes.Name = "ButtonShowLaptimes";
            ButtonShowLaptimes.Size = new Size(175, 29);
            ButtonShowLaptimes.TabIndex = 90;
            ButtonShowLaptimes.Text = "Lap times graph";
            ButtonShowLaptimes.UseVisualStyleBackColor = true;
            ButtonShowLaptimes.Click += ButtonShowLaptimes_Click;
            // 
            // ButtonShowTimeDifference
            // 
            ButtonShowTimeDifference.Font = new Font("Segoe UI", 11.25F);
            ButtonShowTimeDifference.Location = new Point(485, 47);
            ButtonShowTimeDifference.Name = "ButtonShowTimeDifference";
            ButtonShowTimeDifference.Size = new Size(175, 29);
            ButtonShowTimeDifference.TabIndex = 91;
            ButtonShowTimeDifference.Text = "Time difference graph";
            ButtonShowTimeDifference.UseVisualStyleBackColor = true;
            ButtonShowTimeDifference.Click += ButtonShowTimeDifference_Click;
            // 
            // FormMultipleRuns
            // 
            AutoScaleDimensions = new SizeF(10F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1290, 569);
            Controls.Add(ButtonShowTimeDifference);
            Controls.Add(ButtonShowLaptimes);
            Controls.Add(labelRunInfoStatic);
            Font = new Font("Noto Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "FormMultipleRuns";
            Text = "Compare Multiple Runs";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelRunInfoStatic;
        private Button ButtonShowLaptimes;
        private Button ButtonShowTimeDifference;
    }
}