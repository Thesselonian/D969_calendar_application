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
            selectAppointmentsDay.Visible = false; // hide the appointment day selector
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
                foreach (DataRow row in table.Rows) // loop over rows in datatable and mutate start and end dates to local time
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
                    try
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
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
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
            currencyManager1.SuspendBinding(); // remove bindings to facilitate toggling display of rows
            DateTime currentDateTime = DateTime.Now;
            string currentMonth = currentDateTime.ToString("MM");
            foreach (DataGridViewRow row in appointmentsTable.Rows) // loop over rows
            {
                if (Convert.ToString(row.Cells[0].Value) != "") // only for rows that have data. Don't care about empty row at bottom
                {
                    string startDateAndTime = Convert.ToString(row.Cells[2].Value);
                    string startDate = startDateAndTime.Split(' ')[0];
                    string[] dateComponents = startDate.Split('/');
                    int month = Convert.ToInt32(dateComponents[0]);
                    int day = Convert.ToInt32(dateComponents[1]);
                    int year = Convert.ToInt32(dateComponents[2]);
                    DateTime rowStartDateTime = new DateTime(year, month, day);
                    if (showAllAppointments.Checked == true) // if show all rows is checked show every row
                    {
                        selectAppointmentsDay.Visible = false; // hide the appointment day selector
                        row.Visible = true;
                    }
                    else if (showMonthAppointments.Checked == true) // if show month appointments is checked
                    {
                        selectAppointmentsDay.Visible = false; // hide the appointment day selector
                        if (rowStartDateTime.ToString("MM") == currentMonth) // if row startdate month is same as current month show the row. Otherwise hide it
                        {
                            row.Visible = true;
                        }
                        else
                        {
                            row.Visible = false;
                        }
                    }
                    else if (showWeekAppointments.Checked == true) // for show appointments during current week
                    {
                        selectAppointmentsDay.Visible = false; // hide the appointment day selector
                        if (DatesAreInTheSameWeek(currentDateTime, rowStartDateTime))
                        {
                            row.Visible = true;
                        }
                        else
                        {
                            row.Visible = false;
                        }
                    }
                    else if(appointmentsByDay.Checked == true){
                        selectAppointmentsDay.Visible = true; // show the appointment day selector
                        string selectedDate = selectAppointmentsDay.Value.ToString("yyyy-MM-dd");
                        string rowDate = rowStartDateTime.ToString("yyyy-MM-dd");
                        // lambda expression to compare two dates in string format. Returns true or false depending on if they are the same. This is an excellent use of lambda expression because it consolidates a bunch of logic into two lines.
                        Func<string, string, bool> compareDates = (compareDateOne, compareDateTwo) => { return compareDateOne == compareDateTwo; }; 
                        row.Visible = compareDates(selectedDate, rowDate);
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

        private void selectAppointmentsDay_ValueChanged(object sender, EventArgs e)
        {
            showAppointments(appointmentsByDay, new EventArgs());
        }

        private void numberAppointmentTypesByMonth_Click(object sender, EventArgs e)
        {
            appointmentsReport appointmentsReport = new appointmentsReport(this.userId, "Number of Types By Month");
            this.Visible = false;
            this.Dispose();
            appointmentsReport.ShowDialog();
        }

        private void appointmentsByUser_Click(object sender, EventArgs e)
        {
            appointmentsReport appointmentsReport = new appointmentsReport(this.userId, "Appointments by User");
            this.Visible = false;
            this.Dispose();
            appointmentsReport.ShowDialog();
        }

        private void totalUserAppointments_Click(object sender, EventArgs e)
        {
            appointmentsReport appointmentsReport = new appointmentsReport(this.userId, "Total Appointments");
            this.Visible = false;
            this.Dispose();
            appointmentsReport.ShowDialog();
        }
    }
}
