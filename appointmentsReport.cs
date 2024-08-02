using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calendarApp
{
    public partial class appointmentsReport : Form
    {
        string type;
        int userId;
        public appointmentsReport(int userId, string type)
        {
            InitializeComponent();
            this.type = type;
            this.userId = userId;
            Func<string, string, string> concatenate = (concatenated, nextLine) => (concatenated += nextLine); // here is a lambda expression used in each of the report. It is helpful for understanding how the concatenation of the report works.
            if(type == "Number of Types By Month")
            {
                appointmentReportTextboxLabel.Text = "Number of Appointment Types By Month";
                string connectionString = "Server=localhost; database=client_schedule; UID=sqlUser; password=Passw0rd!";
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                string query = "SELECT COUNT(count) AS count, month, year FROM (SELECT COUNT(appointmentId) AS count, MONTH(start) AS month, YEAR(start) AS year FROM appointment GROUP BY year, month, type) AS t1 GROUP BY month, year;";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                string report = "";
                while(reader.Read())
                {
                    string nextLine = string.Format("Year: {0} Month: {1} Number of Types: {2}\r\n", Convert.ToString(reader.GetInt32("year")), Convert.ToString(reader.GetInt32("month")), Convert.ToString(reader.GetInt32("count")));
                    report = concatenate(report, nextLine);
                    //report += string.Format("Year: {0} Month: {1} Number of Types: {2}\r\n", Convert.ToString(reader.GetInt32("year")), Convert.ToString(reader.GetInt32("month")), Convert.ToString(reader.GetInt32("count")));
                }
                appointmentReportTextbox.Text = report;
                connection.Close();
            }
            else if(type == "Appointments by User")
            {
                appointmentReportTextboxLabel.Text = "Appointments by User";
                string connectionString = "Server=localhost; database=client_schedule; UID=sqlUser; password=Passw0rd!";
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                string query = "SELECT * FROM appointment, user, customer WHERE appointment.userId = user.userId AND appointment.customerId = customer.customerId ORDER BY user.userId ASC;";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                string report = "";
                string previousUser = ""; // a string to hold the userName for the record from the previous iteration of the while loop
                string currentUser = "";
                while (reader.Read())
                {
                    currentUser = reader.GetString("userName");
                    DateTime startUtc = reader.GetDateTime("start");
                    DateTime startLocal = startUtc.ToLocalTime();                    
                    DateTime endUtc = reader.GetDateTime("end");
                    DateTime endLocal = endUtc.ToLocalTime();
                    if(currentUser != previousUser)
                    {
                        if(previousUser != "")
                        {
                            report += "\r\n \r\n";
                        }
                        report = concatenate(report, "Appointments for " + currentUser + "\r\n");
                        //report += "Appointments for " + currentUser + "\r\n";
                    }
                    report += string.Format("Appointment type: {0} beginning at time {1} ending at time {2} with customer {3}\r\n", Convert.ToString(reader.GetString("type")), startLocal.ToString(), endLocal.ToString(), Convert.ToString(reader.GetString("customerName")));
                    previousUser = currentUser;
                }
                appointmentReportTextbox.Text = report;
                connection.Close();
            }            
            else if(type == "Total Appointments")
            {
                appointmentReportTextboxLabel.Text = "Total Number of Appointments";
                string connectionString = "Server=localhost; database=client_schedule; UID=sqlUser; password=Passw0rd!";
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                string query = "SELECT COUNT(appointmentId) FROM appointment;";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                int numberAppointments = Convert.ToInt32(cmd.ExecuteScalar());
                string report = "";
                report = concatenate(report, string.Format("There are {0} total appointments", numberAppointments));
                appointmentReportTextbox.Text = report;
                //appointmentReportTextbox.Text = string.Format("There are {0} total appointments", numberAppointments);
                connection.Close();
            }
        }

        private void backToCalendar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Dispose();
            calendar calendar = new calendar(this.userId);
            calendar.ShowDialog();
        }
    }
}
