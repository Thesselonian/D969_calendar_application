using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calendarApp
{
    public partial class loginForm : Form
    {
        private String regionName; // data member to hold the name of the region that the user is in
        public loginForm()
        {
            InitializeComponent();
            var regionInfo = RegionInfo.CurrentRegion; // instantiate class for region info
            var displayName = regionInfo.DisplayName;
            this.regionName = displayName;
            loginStatus.Text = "You are located in region " + this.regionName;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string providedUsername = loginUsername.Text;
            string providedPassword = loginPassword.Text;
            if(providedUsername != "" &&  providedPassword != "")
            {
                string connectionString = "Server=localhost; database=client_schedule; UID=sqlUser; password=Passw0rd!";
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                string query = "SELECT count(username) FROM user WHERE username = '" + providedUsername + "' AND password = '" + providedPassword + "';";
                var cmd = new MySqlCommand(query, connection);
                int numberResultRows = Convert.ToInt32(cmd.ExecuteScalar());
                if(numberResultRows > 0 )
                {
                    query = "SELECT userId FROM user WHERE username = '" + providedUsername + "' AND password = '" + providedPassword + "';";
                    cmd = new MySqlCommand(query, connection);
                    int userId = Convert.ToInt32(cmd.ExecuteScalar());
                    customerForm customerForm = new customerForm(userId);
                    this.Visible = false;
                    string appointmentsQuery = string.Format("SELECT * FROM appointment, customer WHERE userId = {0} AND appointment.customerId = customer.customerId;", userId);
                    cmd = new MySqlCommand(appointmentsQuery, connection);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        withinFifteenMinutes(reader);

                    }
                    customerForm.Show();
                }
                else
                {
                    string unsuccessfulLoginNote = "The username and password do not match.";
                    string translateTo = CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "en" ? ("de") : (CultureInfo.CurrentCulture.TwoLetterISOLanguageName);
                    string translated = Translate(unsuccessfulLoginNote, CultureInfo.CurrentCulture.TwoLetterISOLanguageName);
                    loginStatus.Text = "You are located in region " + this.regionName + "\r\n" + unsuccessfulLoginNote + "\r\n" + translated;
                }
                connection.Close();
            }
            else
            {
                MessageBox.Show("Must provide a valid username and password");
            }
        }
        private void withinFifteenMinutes(MySqlDataReader reader) // a function to check if appointment is within 15 minutes of current time. If it is a popup is displayed to notify user
        {
            DateTime currentDateTime = DateTime.Now;
            DateTime fifteenMinutesFromNow = currentDateTime.AddMinutes(15);
            DateTime appointmentDateTimeLocal = reader.GetDateTime("start").ToLocalTime();
            if (appointmentDateTimeLocal >= currentDateTime && appointmentDateTimeLocal <= fifteenMinutesFromNow)
            {
                MessageBox.Show(string.Format("Appointment with {0} involving {1} at {2} is within the next fifteen minutes.", Convert.ToString(reader["customerName"]), Convert.ToString(reader["type"]), appointmentDateTimeLocal.ToString()), "Upcoming Appointment");
            }
        }
        public String Translate(String word, string toLanguage) // function to translate error message to another language
        {
            var fromLanguage = "en";//Deutsch
            var url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl={fromLanguage}&tl={toLanguage}&dt=t&q={Uri.EscapeDataString(word)}";
            var webClient = new WebClient
            {
                Encoding = System.Text.Encoding.UTF8
            };
            var result = webClient.DownloadString(url);
            try
            {
                result = result.Substring(4, result.IndexOf("\"", 4, StringComparison.Ordinal) - 4);
                return result;
            }
            catch
            {
                return "Error";
            }
        }
    }
}
