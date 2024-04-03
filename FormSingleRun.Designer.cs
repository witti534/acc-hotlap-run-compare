namespace acc_hotlab_private_run_compare
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
            labelRunInfo = new Label();
            TextBoxRunDescription = new TextBox();
            label1 = new Label();
            ButtonSaveRunInfoText = new Button();
            SuspendLayout();
            // 
            // labelRunInfo
            // 
            labelRunInfo.AutoSize = true;
            labelRunInfo.Font = new Font("Noto Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelRunInfo.Location = new Point(12, 9);
            labelRunInfo.Name = "labelRunInfo";
            labelRunInfo.Size = new Size(269, 57);
            labelRunInfo.TabIndex = 11;
            labelRunInfo.Text = "Track: ABC\r\nCar: ABC\r\nSession Length: 99 minutes";
            // 
            // TextBoxRunDescription
            // 
            TextBoxRunDescription.Location = new Point(77, 95);
            TextBoxRunDescription.Name = "TextBoxRunDescription";
            TextBoxRunDescription.Size = new Size(546, 23);
            TextBoxRunDescription.TabIndex = 12;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Noto Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 95);
            label1.Name = "label1";
            label1.Size = new Size(59, 19);
            label1.TabIndex = 13;
            label1.Text = "Info:";
            // 
            // ButtonSaveRunInfoText
            // 
            ButtonSaveRunInfoText.Image = (Image)resources.GetObject("ButtonSaveRunInfoText.Image");
            ButtonSaveRunInfoText.Location = new Point(629, 95);
            ButtonSaveRunInfoText.Name = "ButtonSaveRunInfoText";
            ButtonSaveRunInfoText.Size = new Size(28, 26);
            ButtonSaveRunInfoText.TabIndex = 14;
            ButtonSaveRunInfoText.UseVisualStyleBackColor = true;
            ButtonSaveRunInfoText.Click += ButtonSaveRunInfoText_Click;
            // 
            // FormSingleRun
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ButtonSaveRunInfoText);
            Controls.Add(label1);
            Controls.Add(TextBoxRunDescription);
            Controls.Add(labelRunInfo);
            Name = "FormSingleRun";
            Text = "FormSingleRun";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelRunInfo;
        private TextBox TextBoxRunDescription;
        private Label label1;
        private Button ButtonSaveRunInfoText;
    }
}