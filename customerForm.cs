using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calendarApp
{
    public partial class customerForm : Form
    {
        private DBConnection dbCon;
        private int userId;
       
        public customerForm(DBConnection dbCon, int userId)
        {
            this.userId = userId;
            this.dbCon = dbCon;
            InitializeComponent();
            getTable();
        }
        public void getTable()
        {
            this.refreshCustomerTable();
        }
        public void refreshCustomerTable()
        {
            try
            {
                //VarribleKeeper.MySQLConnectionString = your connection string
                //info being your table name
                string MySQLConnectionString = "Server = localhost; database = client_schedule; UID = sqlUser; password = Passw0rd!";
                ;
                MySqlConnection mysqlCon = new MySqlConnection(MySQLConnectionString);
                mysqlCon.Open();

                MySqlDataAdapter MyDA = new MySqlDataAdapter();
                string sqlSelectAll = "SELECT customerName, address, phone, city, country, customerId, address.addressId, city.cityId, country.countryId FROM customer, address, city, country " +
                    "   WHERE customer.addressId = address.addressId AND address.cityId = city.cityId AND city.countryId = country.countryId;";
                MyDA.SelectCommand = new MySqlCommand(sqlSelectAll, mysqlCon);

                DataTable table = new DataTable();
                MyDA.Fill(table);

                BindingSource bSource = new BindingSource();
                bSource.DataSource = table;

                customerTable.DataSource = bSource;
                
            }
            catch (MySqlException err)
            {
                Console.WriteLine("Error: " + err.ToString());
            }
        }
        private void newCustomerButton_Click(object sender, EventArgs e)
        {
            customerEdit customerEdit = new customerEdit(this.dbCon, this, this.userId);
            customerEdit.ShowDialog();
        }
        private void editCustomerButton_Click(object sender, EventArgs e)
        {
            if (customerTable.SelectedRows.Count > 0)
            {
                int customerId = Convert.ToInt32(customerTable.SelectedRows[0].Cells["customerId"].Value);
                int addressId = Convert.ToInt32(customerTable.SelectedRows[0].Cells["addressId"].Value);
                int cityId = Convert.ToInt32(customerTable.SelectedRows[0].Cells["cityId"].Value);
                int countryId = Convert.ToInt32(customerTable.SelectedRows[0].Cells["countryId"].Value);
                string customerName = Convert.ToString(customerTable.SelectedRows[0].Cells["customerName"].Value);
                string phone = Convert.ToString(customerTable.SelectedRows[0].Cells["phone"].Value);
                string address = Convert.ToString(customerTable.SelectedRows[0].Cells["address"].Value);
                string city = Convert.ToString(customerTable.SelectedRows[0].Cells["city"].Value);
                string country = Convert.ToString(customerTable.SelectedRows[0].Cells["country"].Value);
                customerEdit customerEdit = new customerEdit(this.dbCon, this, this.userId, customerId, addressId, cityId, countryId, customerName, phone, address, city, country);
                this.Dispose();
                customerEdit.ShowDialog();
            }
            else
            {
                MessageBox.Show("You must select a single row to edit");
            }
        }

        private void calendarButton_Click(object sender, EventArgs e)
        {
            calendar calendar = new calendar(this.userId);
            this.Dispose();
            calendar.ShowDialog();
        }

        private void deleteCustomerButton_Click(object sender, EventArgs e) // for deleting a customer record
        {
            if (customerTable.SelectedRows.Count > 0)
            {
                var confirmResult = MessageBox.Show("Are you sure to delete this item ??",
                                         "Confirm Delete!!",
                                         MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    int customerId = Convert.ToInt32(customerTable.SelectedRows[0].Cells["customerId"].Value);
                    string query = $"DELETE FROM customer WHERE customerId = {customerId};";
                    var cmd = new MySqlCommand(query, this.dbCon.Connection);
                    cmd.ExecuteNonQuery();
                    this.Visible = false;
                    this.Dispose();
                    customerForm newCustomerForm = new customerForm(dbCon, this.userId);
                    newCustomerForm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("You must select a single row to delete");
            }
        }
    }
}
