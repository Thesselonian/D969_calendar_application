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
                string query = "SELECT COUNT(appointmentId) AS numberAppointments, userName FROM appointment, user, customer WHERE appointment.userId = user.userId AND appointment.customerId = customer.customerId GROUP BY user.userId;";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                string report = "";
                while (reader.Read())
                {
                    string userName = reader.GetString("userName");
                    string numberAppointments = Convert.ToString(reader.GetInt32("numberAppointments"));
                    report = concatenate(report, string.Format("User {0} has a total of {1} appointments\r\n", userName, numberAppointments));
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
