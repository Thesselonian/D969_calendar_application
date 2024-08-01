﻿namespace calendarApp
{
    partial class calendar
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
            this.appointmentsTable = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.appointmentsTableLabel = new System.Windows.Forms.Label();
            this.createAppointmentButton = new System.Windows.Forms.Button();
            this.deleteAppointmentButton = new System.Windows.Forms.Button();
            this.editAppointmentButton = new System.Windows.Forms.Button();
            this.showAllAppointments = new System.Windows.Forms.RadioButton();
            this.showMonthAppointments = new System.Windows.Forms.RadioButton();
            this.showWeekAppointments = new System.Windows.Forms.RadioButton();
            this.appointmentsByDay = new System.Windows.Forms.RadioButton();
            this.selectAppointmentsDay = new System.Windows.Forms.DateTimePicker();
            this.numberAppointmentTypesByMonth = new System.Windows.Forms.Button();
            this.appointmentsByUser = new System.Windows.Forms.Button();
            this.totalUserAppointments = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentsTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // appointmentsTable
            // 
            this.appointmentsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.appointmentsTable.Location = new System.Drawing.Point(3, 46);
            this.appointmentsTable.Name = "appointmentsTable";
            this.appointmentsTable.RowHeadersWidth = 51;
            this.appointmentsTable.RowTemplate.Height = 24;
            this.appointmentsTable.Size = new System.Drawing.Size(1251, 558);
            this.appointmentsTable.TabIndex = 0;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(195, 97);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(8, 8);
            this.dataGridView2.TabIndex = 1;
            // 
            // appointmentsTableLabel
            // 
            this.appointmentsTableLabel.AutoSize = true;
            this.appointmentsTableLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.appointmentsTableLabel.Location = new System.Drawing.Point(38, 9);
            this.appointmentsTableLabel.Name = "appointmentsTableLabel";
            this.appointmentsTableLabel.Size = new System.Drawing.Size(132, 25);
            this.appointmentsTableLabel.TabIndex = 2;
            this.appointmentsTableLabel.Text = "Appointments";
            // 
            // createAppointmentButton
            // 
            this.createAppointmentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.createAppointmentButton.Location = new System.Drawing.Point(484, 634);
            this.createAppointmentButton.Name = "createAppointmentButton";
            this.createAppointmentButton.Size = new System.Drawing.Size(218, 53);
            this.createAppointmentButton.TabIndex = 3;
            this.createAppointmentButton.Text = "Create Appointment";
            this.createAppointmentButton.UseVisualStyleBackColor = true;
            this.createAppointmentButton.Click += new System.EventHandler(this.createAppointmentButton_Click);
            // 
            // deleteAppointmentButton
            // 
            this.deleteAppointmentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.deleteAppointmentButton.Location = new System.Drawing.Point(228, 637);
            this.deleteAppointmentButton.Name = "deleteAppointmentButton";
            this.deleteAppointmentButton.Size = new System.Drawing.Size(219, 50);
            this.deleteAppointmentButton.TabIndex = 4;
            this.deleteAppointmentButton.Text = "Delete Appointment";
            this.deleteAppointmentButton.UseVisualStyleBackColor = true;
            this.deleteAppointmentButton.Click += new System.EventHandler(this.deleteAppointmentButton_Click);
            // 
            // editAppointmentButton
            // 
            this.editAppointmentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.editAppointmentButton.Location = new System.Drawing.Point(17, 637);
            this.editAppointmentButton.Name = "editAppointmentButton";
            this.editAppointmentButton.Size = new System.Drawing.Size(186, 50);
            this.editAppointmentButton.TabIndex = 5;
            this.editAppointmentButton.Text = "Edit Appointment";
            this.editAppointmentButton.UseVisualStyleBackColor = true;
            this.editAppointmentButton.Click += new System.EventHandler(this.editAppointmentButton_Click);
            // 
            // showAllAppointments
            // 
            this.showAllAppointments.AutoSize = true;
            this.showAllAppointments.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.showAllAppointments.Location = new System.Drawing.Point(228, 12);
            this.showAllAppointments.Name = "showAllAppointments";
            this.showAllAppointments.Size = new System.Drawing.Size(180, 29);
            this.showAllAppointments.TabIndex = 7;
            this.showAllAppointments.TabStop = true;
            this.showAllAppointments.Text = "All Appointments";
            this.showAllAppointments.UseVisualStyleBackColor = true;
            this.showAllAppointments.CheckedChanged += new System.EventHandler(this.showAppointments);
            // 
            // showMonthAppointments
            // 
            this.showMonthAppointments.AutoSize = true;
            this.showMonthAppointments.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.showMonthAppointments.Location = new System.Drawing.Point(484, 12);
            this.showMonthAppointments.Name = "showMonthAppointments";
            this.showMonthAppointments.Size = new System.Drawing.Size(256, 29);
            this.showMonthAppointments.TabIndex = 8;
            this.showMonthAppointments.TabStop = true;
            this.showMonthAppointments.Text = "Appointments This Month";
            this.showMonthAppointments.UseVisualStyleBackColor = true;
            this.showMonthAppointments.CheckedChanged += new System.EventHandler(this.showAppointments);
            // 
            // showWeekAppointments
            // 
            this.showWeekAppointments.AutoSize = true;
            this.showWeekAppointments.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.showWeekAppointments.Location = new System.Drawing.Point(808, 9);
            this.showWeekAppointments.Name = "showWeekAppointments";
            this.showWeekAppointments.Size = new System.Drawing.Size(253, 29);
            this.showWeekAppointments.TabIndex = 9;
            this.showWeekAppointments.TabStop = true;
            this.showWeekAppointments.Text = "Appointments This Week";
            this.showWeekAppointments.UseVisualStyleBackColor = true;
            this.showWeekAppointments.CheckedChanged += new System.EventHandler(this.showAppointments);
            // 
            // appointmentsByDay
            // 
            this.appointmentsByDay.AutoSize = true;
            this.appointmentsByDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.appointmentsByDay.Location = new System.Drawing.Point(1115, 9);
            this.appointmentsByDay.Name = "appointmentsByDay";
            this.appointmentsByDay.Size = new System.Drawing.Size(221, 29);
            this.appointmentsByDay.TabIndex = 11;
            this.appointmentsByDay.TabStop = true;
            this.appointmentsByDay.Text = "Appointments By Day";
            this.appointmentsByDay.UseVisualStyleBackColor = true;
            this.appointmentsByDay.CheckedChanged += new System.EventHandler(this.showAppointments);
            // 
            // selectAppointmentsDay
            // 
            this.selectAppointmentsDay.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.selectAppointmentsDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.selectAppointmentsDay.Location = new System.Drawing.Point(1260, 57);
            this.selectAppointmentsDay.Name = "selectAppointmentsDay";
            this.selectAppointmentsDay.Size = new System.Drawing.Size(360, 30);
            this.selectAppointmentsDay.TabIndex = 13;
            this.selectAppointmentsDay.ValueChanged += new System.EventHandler(this.selectAppointmentsDay_ValueChanged);
            // 
            // numberAppointmentTypesByMonth
            // 
            this.numberAppointmentTypesByMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.numberAppointmentTypesByMonth.Location = new System.Drawing.Point(17, 796);
            this.numberAppointmentTypesByMonth.Name = "numberAppointmentTypesByMonth";
            this.numberAppointmentTypesByMonth.Size = new System.Drawing.Size(364, 59);
            this.numberAppointmentTypesByMonth.TabIndex = 14;
            this.numberAppointmentTypesByMonth.Text = "Number Appointment Types by Month";
            this.numberAppointmentTypesByMonth.UseVisualStyleBackColor = true;
            this.numberAppointmentTypesByMonth.Click += new System.EventHandler(this.numberAppointmentTypesByMonth_Click);
            // 
            // appointmentsByUser
            // 
            this.appointmentsByUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.appointmentsByUser.Location = new System.Drawing.Point(442, 795);
            this.appointmentsByUser.Name = "appointmentsByUser";
            this.appointmentsByUser.Size = new System.Drawing.Size(352, 59);
            this.appointmentsByUser.TabIndex = 15;
            this.appointmentsByUser.Text = "Appointments By User";
            this.appointmentsByUser.UseVisualStyleBackColor = true;
            this.appointmentsByUser.Click += new System.EventHandler(this.appointmentsByUser_Click);
            // 
            // totalUserAppointments
            // 
            this.totalUserAppointments.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.totalUserAppointments.Location = new System.Drawing.Point(845, 796);
            this.totalUserAppointments.Name = "totalUserAppointments";
            this.totalUserAppointments.Size = new System.Drawing.Size(364, 57);
            this.totalUserAppointments.TabIndex = 16;
            this.totalUserAppointments.Text = "Total Number of User Appointments";
            this.totalUserAppointments.UseVisualStyleBackColor = true;
            this.totalUserAppointments.Click += new System.EventHandler(this.totalUserAppointments_Click);
            // 
            // calendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1626, 926);
            this.Controls.Add(this.totalUserAppointments);
            this.Controls.Add(this.appointmentsByUser);
            this.Controls.Add(this.numberAppointmentTypesByMonth);
            this.Controls.Add(this.selectAppointmentsDay);
            this.Controls.Add(this.appointmentsByDay);
            this.Controls.Add(this.showWeekAppointments);
            this.Controls.Add(this.showMonthAppointments);
            this.Controls.Add(this.showAllAppointments);
            this.Controls.Add(this.editAppointmentButton);
            this.Controls.Add(this.deleteAppointmentButton);
            this.Controls.Add(this.createAppointmentButton);
            this.Controls.Add(this.appointmentsTableLabel);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.appointmentsTable);
            this.Name = "calendar";
            this.Text = "calendar";
            ((System.ComponentModel.ISupportInitialize)(this.appointmentsTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView appointmentsTable;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label appointmentsTableLabel;
        private System.Windows.Forms.Button createAppointmentButton;
        private System.Windows.Forms.Button deleteAppointmentButton;
        private System.Windows.Forms.Button editAppointmentButton;
        private System.Windows.Forms.RadioButton showAllAppointments;
        private System.Windows.Forms.RadioButton showMonthAppointments;
        private System.Windows.Forms.RadioButton showWeekAppointments;
        private System.Windows.Forms.RadioButton appointmentsByDay;
        private System.Windows.Forms.DateTimePicker selectAppointmentsDay;
        private System.Windows.Forms.Button numberAppointmentTypesByMonth;
        private System.Windows.Forms.Button appointmentsByUser;
        private System.Windows.Forms.Button totalUserAppointments;
    }
}