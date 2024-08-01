﻿using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calendarApp
{
    public partial class customerEdit : Form
    {
        customerForm customerForm;
        int userId;
        int customerId; // data members for the various table foreign keys
        string phone;
        string customerName;
        int addressId;
        string address;
        int cityId;
        string city;
        int countryId;
        string country;
        bool edit; // whether we are editting or creating new customer
        public customerEdit(customerForm customerForm, int userId)
        {
            this.userId = userId;
            this.edit = false; // in create new customer mode
            this.customerForm = customerForm;
            InitializeComponent();
            this.customerForm.Close(); // kill the previous customer form
        }
        public customerEdit(customerForm customerForm, int userId, int customerId, int addressId, int cityId, int countryId, string customerName, string phone, string address, string city, string country)
        {
            InitializeComponent();
            this.userId = userId;
            this.customerForm = customerForm;
            this.edit = true; // in edit customer mode
            this.customerId = customerId;
            this.addressId = addressId;
            this.cityId = cityId;
            this.countryId = countryId;
            this.customerName = customerName;
            this.customerNameInput.Text = this.customerName;
            this.phone = phone;
            this.customerPhoneInput.Text = this.phone;
            this.address = address;
            this.customerAddressInput.Text = this.address;
            this.city = city;
            this.customerCityInput.Text = this.city;
            this.country = country;
            this.customerCountryInput.Text = this.country;
            this.customerForm.Close(); // kill the previous customer form
        }

        private void saveCustomerButton_Click(object sender, EventArgs e) // for saving a customer
        {
            bool validSubmission = true; // whether the form is valid or not
            string errorMessage = "";
            if(this.customerNameInput.Text == "" || this.customerAddressInput.Text == "" || this.customerPhoneInput.Text == "" || this.customerCityInput.Text == "" || this.customerCountryInput.Text == "")
            {
                validSubmission = false;
                errorMessage = "Form fields cannot be empty";
            }
            if (!Regex.Match(this.customerPhoneInput.Text, @"^[0-9-]*$").Success)
            {
                validSubmission = false;
                errorMessage = "Phone number can only contain numbers and dashes (-).";
            }
            if (validSubmission) // if all the inputs are not blank
            {
                try
                {
                    string connectionString = "Server=localhost; database=client_schedule; UID=sqlUser; password=Passw0rd!";
                    MySqlConnection connection = new MySqlConnection(connectionString);
                    connection.Open();
                    if (this.edit)
                    {
                        // update country name
                        string query = "UPDATE client_schedule.country SET country = '" + this.customerCountryInput.Text.Trim(' ') + "' WHERE countryId = '" + this.countryId + "';";
                        var cmd = new MySqlCommand(query, connection);
                        cmd.ExecuteNonQuery();
                        // update city name
                        query = "UPDATE client_schedule.city SET city = '" + this.customerCityInput.Text.Trim(' ') + "' WHERE cityId = '" + this.cityId + "';";
                        cmd = new MySqlCommand(query, connection);
                        cmd.ExecuteNonQuery();
                        // update address and phone
                        query = "UPDATE client_schedule.address SET address = '" + this.customerAddressInput.Text.Trim(' ') + "', phone = '" + this.customerPhoneInput.Text.Trim(' ') + "' WHERE addressId = '" + this.addressId + "';";
                        cmd = new MySqlCommand(query, connection);
                        cmd.ExecuteNonQuery();
                        // update customer name
                        query = "UPDATE client_schedule.customer SET customerName = '" + this.customerNameInput.Text.Trim(' ') + "' WHERE customerId = '" + this.customerId + "';";
                        cmd = new MySqlCommand(query, connection);
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        // insert country name
                        string query = "INSERT INTO `client_schedule`.`country` (`country`,`createDate`,`createdBy`,`lastUpdate`,`lastUpdateBy`) VALUES ('" + this.customerCountryInput.Text.Trim(' ') + "',CURRENT_DATE(),'',CURRENT_DATE(),'');";
                        var cmd = new MySqlCommand(query, connection);
                        cmd.ExecuteNonQuery();
                        string maxIdQuery = "SELECT MAX(countryId) FROM client_schedule.country;"; // get the id for the country that was just inserted
                        cmd = new MySqlCommand(maxIdQuery, connection);
                        int insertedCountryId = Convert.ToInt32(cmd.ExecuteScalar());
                        //insert city
                        query = $@"INSERT INTO `client_schedule`.`city` (`city`,`countryId`,`createDate`,`createdBy`,`lastUpdate`,`lastUpdateBy`) VALUES('{this.customerCityInput.Text.Trim(' ')}','{insertedCountryId}',CURRENT_DATE(),'',CURRENT_DATE(),'');";
                        cmd = new MySqlCommand(query, connection);
                        cmd.ExecuteNonQuery();
                        maxIdQuery = "SELECT MAX(cityId) FROM client_schedule.city;"; // get the id for the city that was just inserted
                        cmd = new MySqlCommand(maxIdQuery, connection);
                        int insertedCityId = Convert.ToInt32(cmd.ExecuteScalar());
                        // insert address and phone
                        query = $@"INSERT INTO `client_schedule`.`address`(`address`, `address2`, `postalCode`, `cityId`,`phone`,`createDate`,`createdBy`,`lastUpdate`,`lastUpdateBy`)
                            VALUES('{this.customerAddressInput.Text.Trim(' ')}', '', '', '{ insertedCityId }', '{this.customerPhoneInput.Text.Trim(' ')}',CURRENT_DATE(),'',CURRENT_DATE(),'');";
                        cmd = new MySqlCommand(query, connection);
                        cmd.ExecuteNonQuery();
                        maxIdQuery = "SELECT MAX(addressId) FROM client_schedule.address;"; // get the id for the address that was just inserted
                        cmd = new MySqlCommand(maxIdQuery, connection);
                        int insertedAddressId = Convert.ToInt32(cmd.ExecuteScalar());
                        // insert customer
                        query = $@"INSERT INTO `client_schedule`.`customer`(`customerName`,`addressId`,`active`,`createDate`,`createdBy`,`lastUpdate`,`lastUpdateBy`)
                            VALUES('{this.customerNameInput.Text.Trim(' ')}',{insertedAddressId},1,CURRENT_DATE(),'',CURRENT_DATE(),'');
                        ; ";
                        cmd = new MySqlCommand(query, connection);
                        cmd.ExecuteNonQuery();
                    }
                    connection.Close();
                    this.Visible = false; // hide customer edit form
                    this.Dispose();
                    customerForm customerForm = new customerForm(this.userId); // make new customer form
                    customerForm.ShowDialog(); // show newly created customer form

                }
                catch(Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
            else
            {
                MessageBox.Show(errorMessage);
            }
        }
    }
}
