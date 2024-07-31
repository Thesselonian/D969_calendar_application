using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using Org.BouncyCastle.Bcpg;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calendarApp
{
    public partial class calendar : Form // class for a calendar UI
    {
        private int userId;
        public calendar(int userId)
        {
            this.userId = userId;
            InitializeComponent();
            try
            {
                string MySQLConnectionString = "Server=localhost; database=client_schedule; UID=sqlUser; password=Passw0rd!";
                MySqlConnection mysqlCon = new MySqlConnection(MySQLConnectionString);
                mysqlCon.Open();

                MySqlDataAdapter MyDA = new MySqlDataAdapter();
                string appointmentsQuery = $"SELECT customerName, type, start, end, appointmentId, customer.customerId FROM appointment, customer WHERE userId = {this.userId} AND appointment.customerId = customer.customerId;";
                MyDA.SelectCommand = new MySqlCommand(appointmentsQuery, mysqlCon);

                DataTable table = new DataTable();
                MyDA.Fill(table);
                foreach(DataRow row in table.Rows) // loop over rows in datatable and mutate start and end dates to local time
                {
                    DateTime startDateTimeUtc = DateTime.Parse(Convert.ToString(row["start"]));
                    DateTime startDateTimeLocal = startDateTimeUtc.ToLocalTime();                    
                    DateTime endDateTimeUtc = DateTime.Parse(Convert.ToString(row["end"]));
                    DateTime endDateTimeLocal = endDateTimeUtc.ToLocalTime();
                    row["start"] = startDateTimeLocal;
                    row["end"] = endDateTimeLocal;
                }
                BindingSource bSource = new BindingSource();
                bSource.DataSource = table;

                appointmentsTable.DataSource = bSource;

            }
            catch (MySqlException err)
            {
                Console.WriteLine("Error: " + err.ToString());
            }
        }

        private void createAppointmentButton_Click(object sender, EventArgs e)
        {
            appointmentForm appointmentForm = new appointmentForm(this.userId);
            this.Dispose();
            appointmentForm.ShowDialog();
        }

        private void editAppointmentButton_Click(object sender, EventArgs e)
        {
            if (appointmentsTable.SelectedRows.Count > 0)
            {
                appointmentForm editAppointmentForm = new appointmentForm(this.userId, Convert.ToInt32(appointmentsTable.SelectedRows[0].Cells["appointmentId"].Value));
                this.Visible = false;
                this.Dispose();
                editAppointmentForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("You must selected a single appointment row to edit.");
            }
        }

        private void deleteAppointmentButton_Click(object sender, EventArgs e)
        {
            if (appointmentsTable.SelectedRows.Count > 0)
            {
                var confirmResult = MessageBox.Show("Are you sure to delete this item ??", "Confirm Delete!!", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    string MySQLConnectionString = "Server=localhost; database=client_schedule; UID=sqlUser; password=Passw0rd!";
                    MySqlConnection connection = new MySqlConnection(MySQLConnectionString);
                    connection.Open();
                    string query = $"DELETE FROM appointment WHERE appointmentId = {appointmentsTable.SelectedRows[0].Cells["appointmentId"].Value};";
                    var cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    this.Visible = false;
                    this.Dispose();
                    calendar newCalendar = new calendar(this.userId);
                    newCalendar.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("You must select a single row to delete");
            }
        }

        private void showAppointments(object sender, EventArgs e) // for filtering rows based on radio selection
        {
            CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[appointmentsTable.DataSource];
            currencyManager1.SuspendBinding();
            if (showAllAppointments.Checked == true)
            {
                foreach (DataGridViewRow row in appointmentsTable.Rows)
                {
                    row.Visible = true;
                }
            }
            else if(showMonthAppointments.Checked == true){
                DateTime currentDateTime = new DateTime();
                string currentMonth = currentDateTime.ToString("m");
                foreach (DataGridViewRow row in appointmentsTable.Rows)
                {
                    if (Convert.ToString(row.Cells[0].Value) != "")
                    {
                        DateTime rowStartDateTime = DateTime.Parse(Convert.ToString(row.Cells[2].Value));
                        Console.WriteLine(Convert.ToString(row.Cells[2].Value));
                        Console.WriteLine(rowStartDateTime.ToString("yyyy/m/dd hh:mm"));
                        if (rowStartDateTime.ToString("m") == currentMonth)
                        {
                            row.Visible = true;
                        }
                        else
                        {
                            row.Visible = false;
                        }
                    }
                }
            }
            else if (showWeekAppointments.Checked == true)
            {
                DateTime currentDateTime = new DateTime();
                foreach (DataGridViewRow row in appointmentsTable.Rows)
                {
                    if (Convert.ToString(row.Cells[0].Value) != "")
                    {
                        DateTime rowStartDateTime = DateTime.Parse(Convert.ToString(row.Cells[2].Value));
                        if (DatesAreInTheSameWeek(currentDateTime, rowStartDateTime))
                        {
                            row.Visible = true;
                        }
                        else
                        {
                            row.Visible = false;
                        }
                    }
                }
            }
        }
        private bool DatesAreInTheSameWeek(DateTime date1, DateTime date2)
        {
            var cal = System.Globalization.DateTimeFormatInfo.CurrentInfo.Calendar;
            var d1 = date1.Date.AddDays(-1 * (int)cal.GetDayOfWeek(date1));
            var d2 = date2.Date.AddDays(-1 * (int)cal.GetDayOfWeek(date2));

            return d1 == d2;
        }
    }
}
