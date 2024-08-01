namespace calendarApp
{
    partial class appointmentsReport
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
            this.backToCalendar = new System.Windows.Forms.Button();
            this.appointmentReportTextbox = new System.Windows.Forms.TextBox();
            this.appointmentReportTextboxLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // backToCalendar
            // 
            this.backToCalendar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.backToCalendar.Location = new System.Drawing.Point(29, 601);
            this.backToCalendar.Name = "backToCalendar";
            this.backToCalendar.Size = new System.Drawing.Size(215, 54);
            this.backToCalendar.TabIndex = 1;
            this.backToCalendar.Text = "Back To Calendar";
            this.backToCalendar.UseVisualStyleBackColor = true;
            this.backToCalendar.Click += new System.EventHandler(this.backToCalendar_Click);
            // 
            // appointmentReportTextbox
            // 
            this.appointmentReportTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.appointmentReportTextbox.Location = new System.Drawing.Point(29, 55);
            this.appointmentReportTextbox.Multiline = true;
            this.appointmentReportTextbox.Name = "appointmentReportTextbox";
            this.appointmentReportTextbox.Size = new System.Drawing.Size(1646, 540);
            this.appointmentReportTextbox.TabIndex = 2;
            // 
            // appointmentReportTextboxLabel
            // 
            this.appointmentReportTextboxLabel.AutoSize = true;
            this.appointmentReportTextboxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.appointmentReportTextboxLabel.Location = new System.Drawing.Point(24, 18);
            this.appointmentReportTextboxLabel.Name = "appointmentReportTextboxLabel";
            this.appointmentReportTextboxLabel.Size = new System.Drawing.Size(69, 25);
            this.appointmentReportTextboxLabel.TabIndex = 3;
            this.appointmentReportTextboxLabel.Text = "Report";
            // 
            // appointmentsReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1687, 916);
            this.Controls.Add(this.appointmentReportTextboxLabel);
            this.Controls.Add(this.appointmentReportTextbox);
            this.Controls.Add(this.backToCalendar);
            this.Name = "appointmentsReport";
            this.Text = "appointmentsReport";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button backToCalendar;
        private System.Windows.Forms.TextBox appointmentReportTextbox;
        private System.Windows.Forms.Label appointmentReportTextboxLabel;
    }
}