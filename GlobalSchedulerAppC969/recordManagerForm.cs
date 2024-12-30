using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GlobalSchedulerAppC969
{
    public partial class recordManagerForm : Form
    {
        private MySqlConnection _connection;
        private string _user;
        private string _userId;
        private DateTime _loginTime;

        public recordManagerForm(MySqlConnection connection, string username, string userId, DateTime loginTime)
        {
            InitializeComponent();
            _connection = connection;
            _user = username;
            _userId = userId;
            _loginTime = loginTime;

            checkUpcomingAppointment();
            setupCustomerDataGrid();
            if (localApptsRadio.Checked)
            {
                setupLocalAppointmentDataGrid();
            }
            else
            {
                setupAppointmentDataGrid();
            }
            monthlyApptViewPicker.Format = DateTimePickerFormat.Custom;
            monthlyApptViewPicker.CustomFormat = "MMMM yyyy";
        }

        private void checkUpcomingAppointment()
        {
            string sqlString = "SELECT userId, start FROM appointment;";
            MySqlCommand cmd = new MySqlCommand(sqlString, _connection);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["userId"].ToString() == _userId)
                {
                    var dbTime = DateTime.Parse(dr["start"].ToString()).ToLocalTime();
                    var timeNow = DateTime.Now.ToLocalTime();
                    if (dbTime.Date == timeNow.Date)
                    {
                        var diff = dbTime.Subtract(timeNow);
                        if (diff.TotalMinutes <= 15 && diff.TotalMinutes >= 0)
                        {
                            MessageBox.Show("You have an upcoming appointment in 15 minutes or less!");
                            break;
                        }
                    }
                }
            }
        }
        public void setupAppointmentDataGrid()
        {
            string sqlString = "use client_schedule; SELECT type, customer.customerName, cast(start as date) AS scheduleDate,  CONCAT(cast(start as time), ' - ', cast(end as time)) AS scheduleTime FROM appointment, customer WHERE appointment.customerId = customer.customerId;";
            MySqlCommand cmd = new MySqlCommand(sqlString, _connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            adapter.Fill(dt);

            appointmentDataGrid.DataSource = dt;
            DataGridViewColumn column = new DataGridViewColumn();
            column = appointmentDataGrid.Columns[2];
            column.Width = 75;
        }
        public void setupLocalAppointmentDataGrid()
        {
            string sqlString = "SELECT type, customer.customerName, cast(start as date) AS scheduleDate,  CONCAT(cast(start as time), ' - ', cast(end as time)) AS scheduleTime FROM appointment, customer WHERE appointment.customerId = customer.customerId;";
            MySqlCommand cmd = new MySqlCommand(sqlString, _connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            adapter.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                DateTime convertedStartTime = DateTime.SpecifyKind(
                        DateTime.Parse(dr["scheduleTime"].ToString().Split('-')[0]),
                        DateTimeKind.Utc);
                DateTime convertedEndTime = DateTime.SpecifyKind(
                        DateTime.Parse(dr["scheduleTime"].ToString().Split('-')[1]),
                        DateTimeKind.Utc);
                var startDt = convertedStartTime.ToLocalTime().ToString("hh:mm:ss tt");
                var endDt = convertedEndTime.ToLocalTime().ToString("hh:mm:ss tt");
                dr["scheduleTime"] = $"{startDt} - {endDt}";
            }

            appointmentDataGrid.DataSource = dt;
            DataGridViewColumn column = new DataGridViewColumn();
        }
        public void setupCustomerDataGrid()
        {
            string sqlString = "use client_schedule; SELECT customerId, customerName, address, phone FROM customer, address WHERE customer.addressId = address.addressId;";
            MySqlCommand cmd = new MySqlCommand(sqlString, _connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            adapter.Fill(dt);

            customerDataGrid.DataSource = dt;
        }
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void logUserExit(object sender, FormClosedEventArgs e)
        {

            File.AppendAllText("Login_History.txt", $"{_user} logged in at {_loginTime}\n");
            Application.Exit();
        }

        private void addCustomerButton_Click(object sender, EventArgs e)
        {
            var addCustomerForm = new customerForm(_connection, _user, this);
            addCustomerForm.Text = "Add Customer";
            addCustomerForm.ShowDialog();
        }

        private void updateCustomerButton_Click(object sender, EventArgs e)
        {
            if (customerDataGrid.SelectedRows.Count > 0)
            {
                string customerId = retrieveCustomerId();
                var addCustomerForm = new customerForm(_connection, _user, this, customerId);
                addCustomerForm.Text = "Update Customer";
                addCustomerForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Must select a customer to update.");
            }
        }

        private void deleteCustomerButton_Click(object sender, EventArgs e)
        {
            if (customerDataGrid.SelectedRows.Count > 0)
            {
                var confirmation = MessageBox.Show("Are you sure you would like to delete this customer?", "Confirm Deletion", MessageBoxButtons.YesNo);
                if (confirmation == DialogResult.Yes)
                {
                    string customerId = retrieveCustomerId();
                    if (_connection.State != ConnectionState.Open)
                    {
                        _connection.Open();
                    }
                    string deleteCustomerSqlString = $"DELETE FROM customer WHERE customerId = '{customerId}';";
                    MySqlCommand cmd = new MySqlCommand(deleteCustomerSqlString, _connection);
                    MySqlDataReader reader;
                    reader = cmd.ExecuteReader();
                    _connection.Close();
                    setupCustomerDataGrid();
                }
            }
            else
            {
                MessageBox.Show("Must select a customer to delete.");
            }
        }

        private string retrieveCustomerId(bool appt = false)
        {
            try
            {
                string customerId = "";
                for (int i = 0; i < customerDataGrid.SelectedRows.Count; i++)
                {
                    string name = "";
                    if (!appt)
                    {
                        name = customerDataGrid.SelectedRows[i].Cells[1].Value.ToString();
                    }
                    else
                    {
                        name = appointmentDataGrid.SelectedRows[i].Cells[1].Value.ToString();
                    }

                    //find customerID
                    string sqlString = $"SELECT customerId FROM customer WHERE customerName = '{name}';";
                    MySqlCommand cmd = new MySqlCommand(sqlString, _connection);
                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        customerId = dt.Rows[j]["customerId"].ToString();
                    }
                }
                return customerId;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        private string retrieveAppntId()
        {
            try
            {
                string appointmentId = "";
                for (int i = 0; i < appointmentDataGrid.SelectedRows.Count; i++)
                {
                    string customerId = retrieveCustomerId(true);
                    string scheduledDate = localApptsRadio.Checked ? $"{DateTime.Parse(appointmentDataGrid.SelectedRows[i].Cells[2].Value.ToString()).ToUniversalTime().ToString("yyyy-MM-dd")}" : $"{DateTime.Parse(appointmentDataGrid.SelectedRows[i].Cells[2].Value.ToString()).ToString("yyyy-MM-dd")}";
                    string scheduleTime = localApptsRadio.Checked ? $"{DateTime.Parse(appointmentDataGrid.SelectedRows[i].Cells[3].Value.ToString().Split('-')[0]).ToUniversalTime().ToString("HH:mm:ss")}" : $"{DateTime.Parse(appointmentDataGrid.SelectedRows[i].Cells[3].Value.ToString().Split('-')[0]).ToString("HH:mm:ss")}";

                    //find appointmentID
                    string sqlString = $"SELECT appointmentId FROM appointment WHERE customerId = '{customerId}' AND start = '{scheduledDate} {scheduleTime}';";
                    MySqlCommand cmd = new MySqlCommand(sqlString, _connection);
                    MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        appointmentId = dt.Rows[j]["appointmentId"].ToString();
                    }
                }
                return appointmentId;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        private void deleteApptButton_Click(object sender, EventArgs e)
        {
            if (appointmentDataGrid.SelectedRows.Count > 0)
            {
                var confirmation = MessageBox.Show("Are you sure you would like to delete this appointment?", "Confirm Deletion", MessageBoxButtons.YesNo);
                if (confirmation == DialogResult.Yes)
                {
                    if (_connection.State != ConnectionState.Open)
                    {
                        _connection.Open();
                    }
                    var appointmentId = retrieveAppntId();
                    string deleteApptSqlString = $"DELETE FROM appointment WHERE appointmentId = '{appointmentId}';";
                    MySqlCommand cmd = new MySqlCommand(deleteApptSqlString, _connection);
                    MySqlDataReader reader;
                    reader = cmd.ExecuteReader();
                    _connection.Close();
                    if (localApptsRadio.Checked)
                    {
                        setupLocalAppointmentDataGrid();
                    }
                    else
                    {
                        setupAppointmentDataGrid();
                    }
                }
            }
            else
            {
                MessageBox.Show("Must select an appointment to delete.");
            }
        }

        private void updateApptButton_Click(object sender, EventArgs e)
        {
            if (appointmentDataGrid.SelectedRows.Count > 0)
            {
                string appointmentId = retrieveAppntId();
                var form = new appointmentForm(_connection, this, _userId, _user, localApptsRadio.Checked, appointmentId);
                form.Text = "Update Appointment";
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Must select an appointment to update.");
            }
        }

        private void addAppointmenttButton_Click(object sender, EventArgs e)
        {
            var form = new appointmentForm(_connection, this, _userId, _user, localApptsRadio.Checked);
            form.Text = "Add Appointment";
            form.ShowDialog();
        }

        private void refreshDailyApptView(object sender, EventArgs e)
        {
            var dailyApptsForm = new appointmentViewer(_connection, ApptByDayPicker, false);
            dailyApptsForm.Text = "Daily Appointments";
            dailyApptsForm.ShowDialog();
        }

        private void toggleLocalApptView(object sender, EventArgs e)
        {

            if (localApptsRadio.Checked)
            {
                setupLocalAppointmentDataGrid();
            }

        }

        private void toggleGlobalApptView(object sender, EventArgs e)
        {
            if (utcApptsRadio.Checked)
            {
                setupAppointmentDataGrid();
            }
        }

        private void generateApptTypeReport(object sender, EventArgs e)
        {
            string sqlString = "SELECT type, start FROM appointment;";
            MySqlCommand cmd = new MySqlCommand(sqlString, _connection);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);

            var collection = dt.Rows.Cast<DataRow>().ToList();
            string report = "";

            string[] monthNames = { "January", "February", "March", "April", "May", "June",
                            "July", "August", "September", "October", "November", "December" };

            for (int i = 1; i <= 12; i++)
            {
                var count = collection
                    .Where(row => DateTime.Parse(row["start"].ToString()).Month == i)
                    .Select(row => row["type"].ToString())
                    .Distinct()
                    .Count();

                report += $"{monthNames[i - 1]} has {count} unique appointment type(s)\n";
            }

            var form = new reportViewer(_connection, report);
            form.ShowDialog();
        }

        private void userScheduleButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(userIdScheduleTextBox.Text))
            {
                try
                {
                    string sqlString = @"
                SELECT 
                    customer.customerName, 
                    CAST(start AS date) AS scheduleDate
                FROM appointment 
                JOIN customer ON appointment.customerId = customer.customerId 
                WHERE customer.customerId = @customerId
                ORDER BY start ASC
                LIMIT 1;";

                    MySqlCommand cmd = new MySqlCommand(sqlString, _connection);
                    cmd.Parameters.AddWithValue("@customerId", userIdScheduleTextBox.Text.Trim());

                    if (_connection.State != ConnectionState.Open)
                    {
                        _connection.Open();
                    }

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string customerName = reader["customerName"].ToString();
                            string scheduleDate = Convert.ToDateTime(reader["scheduleDate"]).ToString("MMMM dd, yyyy");

                            string report = $"{customerName} has an appointment on {scheduleDate}.";

                            var reportForm = new reportViewer(_connection, report);
                            reportForm.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("The Customer ID does not have any appointments.", "No Appointments Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error retrieving customer schedule: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (_connection.State == ConnectionState.Open)
                    {
                        _connection.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Must enter a Customer ID to view schedule.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private void nextAppointmentButton_Click(object sender, EventArgs e)
        {
            string sqlString = @"
        SELECT 
            customer.customerName, 
            start 
        FROM appointment 
        JOIN customer ON appointment.customerId = customer.customerId 
        ORDER BY start ASC
        LIMIT 1;";

            try
            {
                MySqlCommand cmd = new MySqlCommand(sqlString, _connection);
                if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string customerName = reader["customerName"].ToString();
                        string report = $"The next upcoming appointment is with {customerName}.";

                        var form = new reportViewer(_connection, report);
                        form.ShowDialog();
                    }
                    else
                    {
                        string report = "There are no upcoming appointments.";
                        var form = new reportViewer(_connection, report);
                        form.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving next appointment: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
        }

        private void refreshMonthlyView(object sender, EventArgs e)
        {
            var dailyApptsForm = new appointmentViewer(_connection, monthlyApptViewPicker, true);
            dailyApptsForm.Text = "Monthly Appointments";
            dailyApptsForm.ShowDialog();
        }

        private void RecordsForm_Load(object sender, EventArgs e)
        {

        }

        private void userIdScheduleTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
