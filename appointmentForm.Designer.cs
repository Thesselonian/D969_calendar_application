namespace calendarApp
{
    partial class appointmentForm
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
            this.mySqlCommand1 = new MySql.Data.MySqlClient.MySqlCommand();
            this.customerComboBox = new System.Windows.Forms.ComboBox();
            this.customerComboBoxLabel = new System.Windows.Forms.Label();
            this.appointmentType = new System.Windows.Forms.TextBox();
            this.appointmentTypeLabel = new System.Windows.Forms.Label();
            this.appointmentStart = new System.Windows.Forms.DateTimePicker();
            this.appointmentEnd = new System.Windows.Forms.DateTimePicker();
            this.appointmentEndLabel = new System.Windows.Forms.Label();
            this.appointmentStartLabel = new System.Windows.Forms.Label();
            this.appointmentStartTime = new System.Windows.Forms.DateTimePicker();
            this.appointmentEndTime = new System.Windows.Forms.DateTimePicker();
            this.saveAppointmentButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mySqlCommand1
            // 
            this.mySqlCommand1.CacheAge = 0;
            this.mySqlCommand1.Connection = null;
            this.mySqlCommand1.EnableCaching = false;
            this.mySqlCommand1.Transaction = null;
            // 
            // customerComboBox
            // 
            this.customerComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.customerComboBox.FormattingEnabled = true;
            this.customerComboBox.Location = new System.Drawing.Point(63, 99);
            this.customerComboBox.Name = "customerComboBox";
            this.customerComboBox.Size = new System.Drawing.Size(283, 33);
            this.customerComboBox.TabIndex = 0;
            // 
            // customerComboBoxLabel
            // 
            this.customerComboBoxLabel.AutoSize = true;
            this.customerComboBoxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.customerComboBoxLabel.Location = new System.Drawing.Point(73, 61);
            this.customerComboBoxLabel.Name = "customerComboBoxLabel";
            this.customerComboBoxLabel.Size = new System.Drawing.Size(196, 31);
            this.customerComboBoxLabel.TabIndex = 1;
            this.customerComboBoxLabel.Text = "Select Customer";
            // 
            // appointmentType
            // 
            this.appointmentType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.appointmentType.Location = new System.Drawing.Point(454, 100);
            this.appointmentType.Name = "appointmentType";
            this.appointmentType.Size = new System.Drawing.Size(373, 38);
            this.appointmentType.TabIndex = 2;
            // 
            // appointmentTypeLabel
            // 
            this.appointmentTypeLabel.AutoSize = true;
            this.appointmentTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.appointmentTypeLabel.Location = new System.Drawing.Point(465, 68);
            this.appointmentTypeLabel.Name = "appointmentTypeLabel";
            this.appointmentTypeLabel.Size = new System.Drawing.Size(215, 31);
            this.appointmentTypeLabel.TabIndex = 3;
            this.appointmentTypeLabel.Text = "Appointment Type";
            // 
            // appointmentStart
            // 
            this.appointmentStart.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.appointmentStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.appointmentStart.Location = new System.Drawing.Point(64, 214);
            this.appointmentStart.Name = "appointmentStart";
            this.appointmentStart.Size = new System.Drawing.Size(393, 30);
            this.appointmentStart.TabIndex = 5;
            // 
            // appointmentEnd
            // 
            this.appointmentEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.appointmentEnd.Location = new System.Drawing.Point(463, 214);
            this.appointmentEnd.Name = "appointmentEnd";
            this.appointmentEnd.Size = new System.Drawing.Size(432, 30);
            this.appointmentEnd.TabIndex = 6;
            // 
            // appointmentEndLabel
            // 
            this.appointmentEndLabel.AutoSize = true;
            this.appointmentEndLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.appointmentEndLabel.Location = new System.Drawing.Point(479, 177);
            this.appointmentEndLabel.Name = "appointmentEndLabel";
            this.appointmentEndLabel.Size = new System.Drawing.Size(222, 25);
            this.appointmentEndLabel.TabIndex = 7;
            this.appointmentEndLabel.Text = "Select Appointment End";
            // 
            // appointmentStartLabel
            // 
            this.appointmentStartLabel.AutoSize = true;
            this.appointmentStartLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.appointmentStartLabel.Location = new System.Drawing.Point(79, 177);
            this.appointmentStartLabel.Name = "appointmentStartLabel";
            this.appointmentStartLabel.Size = new System.Drawing.Size(285, 31);
            this.appointmentStartLabel.TabIndex = 8;
            this.appointmentStartLabel.Text = "Select Appointment Start";
            // 
            // appointmentStartTime
            // 
            this.appointmentStartTime.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.appointmentStartTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.appointmentStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.appointmentStartTime.Location = new System.Drawing.Point(67, 265);
            this.appointmentStartTime.Name = "appointmentStartTime";
            this.appointmentStartTime.ShowUpDown = true;
            this.appointmentStartTime.Size = new System.Drawing.Size(202, 30);
            this.appointmentStartTime.TabIndex = 9;
            // 
            // appointmentEndTime
            // 
            this.appointmentEndTime.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.appointmentEndTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.appointmentEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.appointmentEndTime.Location = new System.Drawing.Point(463, 265);
            this.appointmentEndTime.Name = "appointmentEndTime";
            this.appointmentEndTime.ShowUpDown = true;
            this.appointmentEndTime.Size = new System.Drawing.Size(217, 30);
            this.appointmentEndTime.TabIndex = 10;
            // 
            // saveAppointmentButton
            // 
            this.saveAppointmentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.saveAppointmentButton.Location = new System.Drawing.Point(484, 350);
            this.saveAppointmentButton.Name = "saveAppointmentButton";
            this.saveAppointmentButton.Size = new System.Drawing.Size(294, 54);
            this.saveAppointmentButton.TabIndex = 12;
            this.saveAppointmentButton.Text = "Save";
            this.saveAppointmentButton.UseVisualStyleBackColor = true;
            this.saveAppointmentButton.Click += new System.EventHandler(this.saveAppointmentButton_Click);
            // 
            // appointmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1331, 716);
            this.Controls.Add(this.saveAppointmentButton);
            this.Controls.Add(this.appointmentEndTime);
            this.Controls.Add(this.appointmentStartTime);
            this.Controls.Add(this.appointmentStartLabel);
            this.Controls.Add(this.appointmentEndLabel);
            this.Controls.Add(this.appointmentEnd);
            this.Controls.Add(this.appointmentStart);
            this.Controls.Add(this.appointmentTypeLabel);
            this.Controls.Add(this.appointmentType);
            this.Controls.Add(this.customerComboBoxLabel);
            this.Controls.Add(this.customerComboBox);
            this.Name = "appointmentForm";
            this.Text = "appointmentForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MySql.Data.MySqlClient.MySqlCommand mySqlCommand1;
        private System.Windows.Forms.ComboBox customerComboBox;
        private System.Windows.Forms.Label customerComboBoxLabel;
        private System.Windows.Forms.TextBox appointmentType;
        private System.Windows.Forms.Label appointmentTypeLabel;
        private System.Windows.Forms.DateTimePicker appointmentStart;
        private System.Windows.Forms.DateTimePicker appointmentEnd;
        private System.Windows.Forms.Label appointmentEndLabel;
        private System.Windows.Forms.Label appointmentStartLabel;
        private System.Windows.Forms.DateTimePicker appointmentStartTime;
        private System.Windows.Forms.DateTimePicker appointmentEndTime;
        private System.Windows.Forms.Button saveAppointmentButton;
    }
}