using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Mysqlx.Expr;
using Org.BouncyCastle.Bcpg;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;

namespace calendarApp
{
    public partial class appointmentForm : Form
    {
        private int userId;
        private int appointmentId;
        private bool edit;
        public appointmentForm(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            this.edit = false;
            // get customers, populate combobox
            string MySQLConnectionString = "Server=localhost; database=client_schedule; UID=sqlUser; password=Passw0rd!";
            MySqlConnection connection = new MySqlConnection(MySQLConnectionString);
            string command = "SELECT customerId, customerName FROM customer;";
            MySqlDataAdapter cmd = new MySqlDataAdapter(command, connection);
            DataTable dt = new DataTable();
            cmd.Fill(dt);
            foreach(DataRow row in dt.Rows)
            {
                string rows = string.Format("{0}:{1}", row.ItemArray[0], row.ItemArray[1]);
                customerComboBox.Items.Add(rows);
            }
        }        
        public appointmentForm(int userId, int appointmentId)
        {
            InitializeComponent();
            this.userId = userId;
            this.appointmentId = appointmentId;
            this.edit = true;
            // get customers, populate combobox
            string MySQLConnectionString = "Server=localhost; database=client_schedule; UID=sqlUser; password=Passw0rd!";
            
            string command = "SELECT customerId, customerName FROM customer;";
            MySqlConnection customerConnection = new MySqlConnection(MySQLConnectionString);
            MySqlDataAdapter cmd = new MySqlDataAdapter(command, customerConnection);
            DataTable dt = new DataTable();
            cmd.Fill(dt);
            foreach(DataRow row in dt.Rows)
            {
                string rows = string.Format("{0}:{1}", row.ItemArray[0], row.ItemArray[1]);
                customerComboBox.Items.Add(rows);
            }
            customerConnection.Close();
            MySqlConnection connection = new MySqlConnection(MySQLConnectionString);
            connection.Open();
            string appointmentQuery = $"SELECT * FROM appointment, customer WHERE appointmentId = {appointmentId} AND appointment.customerId = customer.customerId;";
            var appointmentCommand = new MySqlCommand(appointmentQuery, connection);
            MySqlDataReader reader = appointmentCommand.ExecuteReader();
            while (reader.Read()) // read data to data base and set form inputs accordingly
            {
                customerComboBox.SelectedIndex = customerComboBox.FindStringExact($"{Convert.ToString(reader["customerId"])}:{Convert.ToString(reader["customerName"])}");
                appointmentType.Text = Convert.ToString(reader["type"]);
                DateTime startDateTimeUtc = reader.GetDateTime("start");
                DateTime startDateTimeLocal = startDateTimeUtc.ToLocalTime();
                DateTime endDateTimeUtc = reader.GetDateTime("end");
                DateTime endDateTimeLocal = endDateTimeUtc.ToLocalTime();
                appointmentStart.Value = startDateTimeLocal;
                appointmentStartTime.Value = startDateTimeLocal;
                appointmentEnd.Value = endDateTimeLocal;
                appointmentEndTime.Value = endDateTimeLocal;
            }
            connection.Close();
        }
        private bool validateAppointmentTime(DateTime startDateTime, DateTime endDateTime) //provide start and end datetime's in UTC and the database will be queried to see if there are any currently existing appointments for the user during the timeframe
        {
            string MySQLConnectionString = "Server=localhost; database=client_schedule; UID=sqlUser; password=Passw0rd!";
            MySqlConnection connection = new MySqlConnection(MySQLConnectionString);
            connection.Open();
            string query = $@"SELECT COUNT(appointmentId) FROM appointment WHERE ((start BETWEEN '{startDateTime.ToString("yyyy-MM-dd HH:mm:ss")}' AND '{endDateTime.ToString("yyyy-MM-dd HH:mm:ss")}')
                OR (end BETWEEN '{startDateTime.ToString("yyyy-MM-dd HH:mm:ss")}' AND '{endDateTime.ToString("yyyy-MM-dd HH:mm:ss")}'))AND appointmentId <> {this.appointmentId};";
            Console.WriteLine(query);
            var cmd = new MySqlCommand(query, connection);
            int numberOverlappingAppointments = Convert.ToInt32(cmd.ExecuteScalar());
            connection.Close();
            if(numberOverlappingAppointments > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void saveAppointmentButton_Click(object sender, EventArgs e)
        {
            try
            {
                bool validSubmission = true;
                string errorMessage = "";
                if(customerComboBox.SelectedItem == null) {
                    validSubmission = false;
                    errorMessage = "You must select a customer for the appointment";
                }
                if(appointmentType.Text == "")
                {
                    validSubmission = false;
                    errorMessage = "You must provide an appointment type";
                }
                DateTime startDateTime = new DateTime(appointmentStart.Value.Date.Year, appointmentStart.Value.Date.Month, appointmentStart.Value.Date.Day, appointmentStartTime.Value.Hour, appointmentStartTime.Value.Minute, 0, DateTimeKind.Local);
                DateTime startDateTimeUtc = startDateTime.ToUniversalTime();
                DateTime endDateTime = new DateTime(appointmentEnd.Value.Date.Year, appointmentEnd.Value.Date.Month, appointmentEnd.Value.Date.Day, appointmentEndTime.Value.Hour, appointmentEndTime.Value.Minute, 0, DateTimeKind.Local);
                DateTime endDateTimeUtc = endDateTime.ToUniversalTime();
                TimeZoneInfo easternTimeInfo = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
                DateTime easternStartTime = TimeZoneInfo.ConvertTimeFromUtc(startDateTimeUtc, easternTimeInfo);
                DateTime easternEndTime = TimeZoneInfo.ConvertTimeFromUtc(endDateTimeUtc, easternTimeInfo);
                DateTime businessStartTime = new DateTime(appointmentStart.Value.Date.Year, appointmentStart.Value.Date.Month, appointmentStart.Value.Date.Day, 09, 0, 0); // DateTime structs to represent start and end of business day in eastern time.
                DateTime businessEndTime = new DateTime(appointmentStart.Value.Date.Year, appointmentStart.Value.Date.Month, appointmentStart.Value.Date.Day, 17, 0, 0);
                if(easternStartTime < businessStartTime || easternStartTime >= businessEndTime || easternEndTime <= businessStartTime || easternEndTime > businessEndTime) // if the start or end time for the appointment are outside business hours eastern time
                {
                    validSubmission = false;
                    errorMessage = "The appointment start and end times must be between 9 AM and 5 PM Eastern Standard Time.";
                }
                if (!validateAppointmentTime(startDateTimeUtc, endDateTimeUtc))
                {
                    validSubmission = false;
                    errorMessage = "Provided dates overlap with existing appointment.";
                }
                if(startDateTimeUtc >= endDateTimeUtc)
                {
                    validSubmission = false;
                    errorMessage = "Appointment end time must be after the start time.";
                }
                if (!validSubmission)
                {
                    MessageBox.Show(errorMessage);
                }
                else
                {
                    string customerSelection = customerComboBox.SelectedItem.ToString();
                    string customerId = customerSelection.Substring(0, customerSelection.IndexOf(":", 0));
                    string mysqlconnectionstring = "server=localhost; database=client_schedule; uid=sqlUser; password=Passw0rd!";
                    MySqlConnection connection = new MySqlConnection(mysqlconnectionstring);
                    connection.Open();
                    // if form is in edit mode run an update query, otherwise run an insert
                    string query = (!this.edit) ? 
                        ($@"insert into `client_schedule`.`appointment`(`customerid`,`userid`,`title`,`description`,`location`,`contact`,`type`,`url`,`start`,`end`,`createdate`,`createdby`,`lastupdate`,`lastupdateby`)
                        values({customerId}, '{this.userId}', '', '', '','', '{appointmentType.Text}','', '{startDateTimeUtc.ToString("yyyy-MM-dd HH:mm:ss")}','{endDateTimeUtc.ToString("yyyy-MM-dd HH:mm:ss")}', NOW(),'', NOW(),'');") :
                        ($@"UPDATE `client_schedule`.`appointment` SET `customerId` = {customerId}, `type` = '{appointmentType.Text}', `start` = '{startDateTimeUtc.ToString("yyyy-MM-dd HH:mm:ss")}',
                        `end` = '{endDateTimeUtc.ToString("yyyy-MM-dd HH:mm:ss")}' WHERE `appointmentId` = {this.appointmentId};");
                    var cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    calendar newCalendar = new calendar(this.userId);
                    this.Visible = false;
                    this.Dispose();
                    newCalendar.ShowDialog();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
