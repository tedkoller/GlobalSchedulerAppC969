using Google.Protobuf.Collections;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GlobalSchedulerAppC969
{
    public partial class customerForm : Form
    {
        private MySqlConnection _connection;
        private string _user;
        private recordManagerForm parent;
        private string _customerId;

        public customerForm(MySqlConnection dbconnection, string user, recordManagerForm form, string customerId = "")
        {
            InitializeComponent();
            _connection = dbconnection;
            _user = user;
            parent = form;
            _customerId = customerId;
            if (!string.IsNullOrEmpty(customerId))
            {
                setCustomer();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private string name = "";
        private string address = "";
        private string city = "";
        private string country = "";
        private string phone = "";
        private string cityId = "";
        private string countryId = "";
        private string addressId = "";
        private string datetimeOfEntry = DateTime.Now.ToString("yyyy-MM-dd");
        private void setCustomer()
        {
            try
            {
                string findCustomerSqlString = $"SELECT * FROM customer WHERE customerId = {_customerId};";
                MySqlCommand findCustomerCmd = new MySqlCommand(findCustomerSqlString, _connection);
                MySqlDataAdapter findCusAdp = new MySqlDataAdapter(findCustomerCmd);
                DataTable dt = new DataTable();
                findCusAdp.Fill(dt);

                nameInput.Text = dt.Rows[0]["customerName"].ToString();
                name = nameInput.Text;
                addressId = dt.Rows[0]["addressId"].ToString();

                string findAddressSqlString = $"SELECT * FROM address WHERE addressId = {addressId};";
                MySqlCommand findAddressCmd = new MySqlCommand(findAddressSqlString, _connection);
                MySqlDataAdapter findAddressAdp = new MySqlDataAdapter(findAddressCmd);
                DataTable dt1 = new DataTable();
                findAddressAdp.Fill(dt1);

                addressInput.Text = dt1.Rows[0]["address"].ToString();
                address = addressInput.Text;
                inputPhone.Text = dt1.Rows[0]["phone"].ToString();
                phone = inputPhone.Text;
                cityId = dt1.Rows[0]["cityId"].ToString();

                string findCitySqlString = $"SELECT * FROM city WHERE cityId = {cityId};";
                MySqlCommand findCityCmd = new MySqlCommand(findCitySqlString, _connection);
                MySqlDataAdapter findCityAdp = new MySqlDataAdapter(findCityCmd);
                DataTable dt2 = new DataTable();
                findCityAdp.Fill(dt2);

                inputCity.Text = dt2.Rows[0]["city"].ToString();
                city = inputCity.Text;
                countryId = dt2.Rows[0]["countryId"].ToString();

                string findCountrySqlString = $"SELECT * FROM country WHERE countryId = {countryId};";
                MySqlCommand findCountryCmd = new MySqlCommand(findCountrySqlString, _connection);
                MySqlDataAdapter findCountryAdp = new MySqlDataAdapter(findCountryCmd);
                DataTable dt3 = new DataTable();
                findCountryAdp.Fill(dt3);

                countryInput.Text = dt3.Rows[0]["country"].ToString();
                country = countryInput.Text;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }
        private void saveCustomerButton_Click(object sender, EventArgs e)
        {
            if (checkData())
            {
                if (string.IsNullOrEmpty(_customerId))
                {
                    //insert customer to the DB

                    //insert country
                    countryId = GetCountryId();
                    _connection.Close();
                    if (string.IsNullOrEmpty(countryId))
                    {
                        try
                        {
                            if (_connection.State == ConnectionState.Closed)
                            {
                                _connection.Open();
                            }
                            string countryInsertSqlString = $"INSERT INTO country (country, createDate, createdBy, lastUpdateBy) VALUES ('{countryInput.Text.Trim()}', '{datetimeOfEntry}', '{_user}', '{_user}');";
                            MySqlCommand countryInsertCmd = new MySqlCommand(countryInsertSqlString, _connection);
                            MySqlDataReader reader;
                            reader = countryInsertCmd.ExecuteReader();
                            _connection.Close();
                            countryId = GetCountryId();
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message);
                        }
                    }

                    //insert city
                    cityId = GetCityId();
                    if (string.IsNullOrEmpty(cityId))
                    {
                        try
                        {
                            if (_connection.State != ConnectionState.Open)
                            {
                                _connection.Open();
                            }
                            string cityInsertSqlString = $"INSERT INTO city (city, countryId, createDate, createdBy, lastUpdateBy) VALUES ('{inputCity.Text.Trim()}', '{countryId}', '{datetimeOfEntry}', '{_user}', '{_user}');";
                            MySqlCommand cityInsertCmd = new MySqlCommand(cityInsertSqlString, _connection);
                            MySqlDataReader cityReader;
                            cityReader = cityInsertCmd.ExecuteReader();
                            _connection.Close();
                            cityId = GetCityId();
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message);
                        }
                    }

                    //insert address
                    if (_connection.State != ConnectionState.Open)
                    {
                        _connection.Open();
                    }
                    string addressInsertSqlString = $"use client_schedule; INSERT INTO address (address, address2, cityId, postalCode, phone, createDate, createdBy, lastUpdateBy) VALUES ('{addressInput.Text.Trim()}', '{string.Empty}', '{cityId}', '{string.Empty}', '{inputPhone.Text.Trim()}', '{datetimeOfEntry}', '{_user}', '{_user}');";
                    MySqlCommand addressInsertCmd = new MySqlCommand(addressInsertSqlString, _connection);
                    MySqlDataReader addressReader;
                    addressReader = addressInsertCmd.ExecuteReader();
                    _connection.Close();
                    string addressId = GetAddressId();

                    //insert customer
                    if (_connection.State != ConnectionState.Open)
                    {
                        _connection.Open();
                    }
                    string customerInsertSqlString = $"use client_schedule; INSERT INTO customer (customerName, addressId, active, createDate, createdBy, lastUpdateBy) VALUES ('{nameInput.Text.Trim()}', '{addressId}', '{1}', '{datetimeOfEntry}', '{_user}', '{_user}');";
                    MySqlCommand customerInsertCmd = new MySqlCommand(customerInsertSqlString, _connection);
                    MySqlDataReader customerReader;
                    customerReader = customerInsertCmd.ExecuteReader();
                    _connection.Close();
                }
                else
                {
                    if (nameInput.Text.Trim() != name)
                    {
                        try
                        {
                            if (_connection.State == ConnectionState.Closed)
                            {
                                _connection.Open();
                            }
                            string updateNameSqlString = $"UPDATE customer SET customerName = '{nameInput.Text.Trim()}' WHERE customerId = {_customerId};";
                            MySqlCommand nameUpdateCmd = new MySqlCommand(updateNameSqlString, _connection);
                            MySqlDataReader nameReader;
                            nameReader = nameUpdateCmd.ExecuteReader();
                            _connection.Close();
                        }
                        catch(Exception ex)
                        {
                            throw new Exception(ex.Message, ex);
                        }
                    }
                    if (addressInput.Text.Trim() != address)
                    {
                        if (_connection.State == ConnectionState.Closed)
                        {
                            _connection.Open();
                        }
                        string updateAddressSqlString = $"UPDATE address SET address = '{addressInput.Text.Trim()}' WHERE addressId = {addressId};";
                        MySqlCommand addressUpdateCmd = new MySqlCommand(updateAddressSqlString, _connection);
                        MySqlDataReader addressReader;
                        addressReader = addressUpdateCmd.ExecuteReader();
                        _connection.Close();
                    }
                    if (inputCity.Text.Trim() != city)
                    {
                        try
                        {

                            var existingCity = GetCityId();
                            if (_connection.State == ConnectionState.Closed)
                            {
                                _connection.Open();
                            }
                            if (!string.IsNullOrEmpty(existingCity))
                            {
                                string existingCitySqlString = $"UPDATE address SET cityId = '{existingCity}' WHERE addressId = {addressId};";
                                MySqlCommand cityUpdateCmd = new MySqlCommand(existingCitySqlString, _connection);
                                MySqlDataReader cityReader;
                                cityReader = cityUpdateCmd.ExecuteReader();
                                _connection.Close();
                            }
                            else
                            {
                                if (_connection.State == ConnectionState.Closed)
                                {
                                    _connection.Open();
                                }
                                //insert new city and then update address with new cityID
                                string cityInsertSqlString = $"INSERT INTO city (city, countryId, createDate, createdBy, lastUpdateBy) VALUES ('{inputCity.Text.Trim()}', '{countryId}', '{datetimeOfEntry}', '{_user}', '{_user}');";
                                MySqlCommand cityInsertCmd = new MySqlCommand(cityInsertSqlString, _connection);
                                MySqlDataReader cityReader;
                                cityReader = cityInsertCmd.ExecuteReader();
                                _connection.Close();

                                cityId = GetCityId();
                                if (_connection.State == ConnectionState.Closed)
                                {
                                    _connection.Open();
                                }
                                string updateCitySqlString = $"UPDATE address SET cityId = '{cityId}' WHERE addressId = {addressId};";
                                MySqlCommand cityUpdateCmd = new MySqlCommand(updateCitySqlString, _connection);
                                MySqlDataReader cityUpdateReader;
                                cityUpdateReader = cityUpdateCmd.ExecuteReader();
                                _connection.Close();
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message, ex);
                        }
                    }

                    if (countryInput.Text.Trim() != country)
                    {
                        try
                        {
                            var existingCountry = GetCountryId();

                            if (_connection.State == ConnectionState.Closed)
                            {
                                _connection.Open();
                            }
                            if (!string.IsNullOrEmpty(existingCountry))
                            {
                                string existingCountrySqlString = $"UPDATE city SET countryId = '{existingCountry}' WHERE cityId = {cityId};";
                                MySqlCommand countryUpdateCmd = new MySqlCommand(existingCountrySqlString, _connection);
                                MySqlDataReader countryReader;
                                countryReader = countryUpdateCmd.ExecuteReader();
                                _connection.Close();
                            }
                            else
                            {
                                if (_connection.State == ConnectionState.Closed)
                                {
                                    _connection.Open();
                                }
                                string countryInsertSqlString = $"INSERT INTO country (country, createDate, createdBy, lastUpdateBy) VALUES ('{countryInput.Text.Trim()}', '{datetimeOfEntry}', '{_user}', '{_user}');";
                                MySqlCommand countryInsertCmd = new MySqlCommand(countryInsertSqlString, _connection);
                                MySqlDataReader countryReader;
                                countryReader = countryInsertCmd.ExecuteReader();
                                _connection.Close();
                                countryId = GetCountryId();
                                if (_connection.State == ConnectionState.Closed)
                                {
                                    _connection.Open();
                                }
                                string updateCountrySqlString = $"UPDATE city SET countryId = '{countryId}' WHERE cityId = {cityId};";
                                MySqlCommand countryUpdateCmd = new MySqlCommand(updateCountrySqlString, _connection);
                                MySqlDataReader countryUpdateReader;
                                countryUpdateReader = countryUpdateCmd.ExecuteReader();
                                _connection.Close();
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message, ex);
                        }

                    }
                    if (inputPhone.Text.Trim() != phone)
                    {
                        if (_connection.State == ConnectionState.Closed)
                        {
                            _connection.Open();
                        }
                        string updatePhoneSqlString = $"UPDATE address SET phone = '{inputPhone.Text.Trim()}' WHERE addressId = {addressId};";
                        MySqlCommand phoneUpdateCmd = new MySqlCommand(updatePhoneSqlString, _connection);
                        MySqlDataReader phoneReader;
                        phoneReader = phoneUpdateCmd.ExecuteReader();
                        _connection.Close();
                    }
                }

                parent.setupCustomerDataGrid();
                this.Close();
            }
        }
        private string GetCountryId()
        {
            string selectAllCountries = "use client_schedule; SELECT * FROM country;";
            MySqlCommand countryCmd = new MySqlCommand(selectAllCountries, _connection);
            MySqlDataAdapter adp = new MySqlDataAdapter(countryCmd);
            DataTable countryDt = new DataTable();
            adp.Fill(countryDt);
            string countryId = "";
            for (int i = 0; i < countryDt.Rows.Count; i++)
            {
                if (countryDt.Rows[i]["country"].ToString() == countryInput.Text)
                {
                    countryId = countryDt.Rows[i]["countryId"].ToString();
                    break;
                }
            }
            return countryId;
        }
        private string GetCityId()
        {
            string selectAllCities = "use client_schedule; SELECT * FROM city;";
            MySqlCommand cityCmd = new MySqlCommand(selectAllCities, _connection);
            MySqlDataAdapter cityAdp = new MySqlDataAdapter(cityCmd);
            DataTable cityDt = new DataTable();
            cityAdp.Fill(cityDt);
            string cityId = "";
            for (int i = 0; i < cityDt.Rows.Count; i++)
            {
                if (cityDt.Rows[i]["city"].ToString() == inputCity.Text)
                {
                    cityId = cityDt.Rows[i]["cityId"].ToString();
                    break;
                }
            }
            return cityId;
        }
        private string GetAddressId()
        {
            string selectAllAddresses = "SELECT * FROM address;";
            MySqlCommand addressCmd = new MySqlCommand(selectAllAddresses, _connection);
            MySqlDataAdapter addressAdp = new MySqlDataAdapter(addressCmd);
            DataTable addressDt = new DataTable();
            addressAdp.Fill(addressDt);
            string addressId = "";
            for (int i = 0; i < addressDt.Rows.Count; i++)
            {
                if (addressDt.Rows[i]["address"].ToString() == addressInput.Text)
                {
                    addressId = addressDt.Rows[i]["addressId"].ToString();
                    break;
                }
            }
            return addressId;
        }
        private bool checkData()
        {
            bool valid = false;

            if (string.IsNullOrEmpty(nameInput.Text.Trim()))
            {
                nameToolTip.Active = true;
                nameToolTip.Show("Name is required.", nameInput);
                nameInput.BackColor = Color.Red;
                valid = false;
            }
            else
            {
                nameInput.BackColor = Color.White;
                nameToolTip.Active = false;
                valid = true;
            }

            if (string.IsNullOrEmpty(addressInput.Text.Trim()))
            {
                addressToolTip.Active = true;
                addressToolTip.Show("Address is required.", addressInput);
                addressInput.BackColor = Color.Red;
                valid = false;
            }
            else
            {
                addressInput.BackColor = Color.White;
                addressToolTip.Active = false;
                valid = true;
            }

            if (string.IsNullOrEmpty(inputCity.Text.Trim()))
            {
                cityToolTip.Active = true;
                cityToolTip.Show("City is required.", inputCity);
                inputCity.BackColor = Color.Red;
                valid = false;
            }
            else
            {
                inputCity.BackColor = Color.White;
                cityToolTip.Active = false;
                valid = true;
            }

            if (string.IsNullOrEmpty(countryInput.Text.Trim()))
            {
                countryToolTip.Active = true;
                countryToolTip.Show("Country is required.", countryInput);
                countryInput.BackColor = Color.Red;
                valid = false;
            }
            else
            {
                countryInput.BackColor = Color.White;
                countryToolTip.Active = false;
                valid = true;
            }

            if (string.IsNullOrEmpty(inputPhone.Text.Trim()))
            {
                phoneToolTip.Active = true;
                phoneToolTip.Show("Phone is required.", inputPhone);
                inputPhone.BackColor = Color.Red;
                valid = false;
            }
            else
            {
                Match match = Regex.Match(inputPhone.Text, @"^[0-9-]*$");
                if (!match.Success)
                {
                    phoneToolTip.Active = true;
                    phoneToolTip.Show("Phone can only be numbers and dashes.", inputPhone);
                    inputPhone.BackColor = Color.Red;
                    valid = false;
                }
                else
                {
                    inputPhone.BackColor = Color.White;
                    phoneToolTip.Active = false;
                    valid = true;
                }
            }

            return valid;
        }

        private void nameTextbox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nameInput.Text.Trim()))
            {
                nameToolTip.Active = true;
                nameToolTip.Show("Name is required.", nameInput);
                nameInput.BackColor = Color.Red;
            }
            else
            {
                nameInput.BackColor = Color.White;
                nameToolTip.Active = false;
            }
        }

        private void addressTextbox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(addressInput.Text.Trim()))
            {
                addressToolTip.Active = true;
                addressToolTip.Show("Address is required.", addressInput);
                addressInput.BackColor = Color.Red;
            }
            else
            {
                addressInput.BackColor = Color.White;
                addressToolTip.Active = false;
            }
        }

        private void cityTextbox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(inputCity.Text.Trim()))
            {
                cityToolTip.Active = true;
                cityToolTip.Show("City is required.", inputCity);
                inputCity.BackColor = Color.Red;
            }
            else
            {
                inputCity.BackColor = Color.White;
                cityToolTip.Active = false;
            }
        }

        private void countryTextbox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(countryInput.Text.Trim()))
            {
                countryToolTip.Active = true;
                countryToolTip.Show("Country is required.", countryInput);
                countryInput.BackColor = Color.Red;
            }
            else
            {
                countryInput.BackColor = Color.White;
                countryToolTip.Active = false;
            }
        }

        private void phoneTextbox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(inputPhone.Text.Trim()))
            {
                phoneToolTip.Active = true;
                phoneToolTip.Show("Phone is required.", inputPhone);
                inputPhone.BackColor = Color.Red;
            }
            else
            {
                inputPhone.BackColor = Color.White;
                phoneToolTip.Active = false;
            }
        }

        private void customerForm_Load(object sender, EventArgs e)
        {

        }
    }
}
