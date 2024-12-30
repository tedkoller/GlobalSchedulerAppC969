using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace GlobalSchedulerAppC969
{
    public partial class appointmentForm : Form
    {
        // Database connection and user details
        private readonly MySqlConnection _dbConnection;
        private readonly string _currentUserId;
        private readonly string _currentUsername;
        private readonly recordManagerForm _parentForm;
        private readonly string _appointmentId;
        private readonly bool _isLocalTime;
        private readonly string _creationDate = DateTime.UtcNow.ToString("yyyy-MM-dd");

        private string _appointmentType;
        private string _customerId;
        private DateTime _appointmentStart;
        private DateTime _appointmentEnd;

        public appointmentForm(
            MySqlConnection connection,
            recordManagerForm parentForm,
            string userId,
            string username,
            bool isLocalTime,
            string appointmentId = "")
        {
            InitializeComponent();

            _dbConnection = connection;
            _currentUserId = userId;
            _currentUsername = username;
            _parentForm = parentForm;
            _appointmentId = appointmentId;
            _isLocalTime = isLocalTime;

            SetupDateTimePickers();

            if (!string.IsNullOrEmpty(_appointmentId))
            {
                LoadAppointmentData();
            }
        }

        private void SetupDateTimePickers()
        {
            selectStart.Format = DateTimePickerFormat.Custom;
            selectStart.CustomFormat = "yyyy-MM-dd hh:mm:ss tt";
            selectEnd.Format = DateTimePickerFormat.Custom;
            selectEnd.CustomFormat = "yyyy-MM-dd hh:mm:ss tt";
            selectStart.Value = _isLocalTime ? DateTime.Now : DateTime.UtcNow;
            selectEnd.Value = _isLocalTime ? DateTime.Now : DateTime.UtcNow;
        }

        private void LoadAppointmentData()
        {
            try
            {
                string query = @"SELECT type, customerId, start, end 
                                 FROM appointment 
                                 WHERE appointmentId = @appointmentId;";
                using (var command = new MySqlCommand(query, _dbConnection))
                {
                    command.Parameters.AddWithValue("@appointmentId", _appointmentId);

                    if (_dbConnection.State == ConnectionState.Closed)
                    {
                        _dbConnection.Open();
                    }

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            _appointmentType = reader["type"].ToString();
                            inputType.Text = _appointmentType;

                            _customerId = reader["customerId"].ToString();
                            inputCustomer.Text = _customerId;

                            _appointmentStart = ConvertToLocalOrUtc(DateTime.Parse(reader["start"].ToString()));
                            selectStart.Value = _appointmentStart;

                            _appointmentEnd = ConvertToLocalOrUtc(DateTime.Parse(reader["end"].ToString()));
                            selectEnd.Value = _appointmentEnd;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading appointment data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_dbConnection.State == ConnectionState.Open)
                {
                    _dbConnection.Close();
                }
            }
        }

        private DateTime ConvertToLocalOrUtc(DateTime dateTime)
        {
            return _isLocalTime ? dateTime.ToLocalTime() : dateTime.ToUniversalTime();
        }

        private void SaveAppointmentButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateAppointmentDetails())
                {
                    if (string.IsNullOrEmpty(_appointmentId))
                    {
                        AddNewAppointment();
                    }
                    else
                    {
                        UpdateExistingAppointment();
                    }

                    // Refresh appointments in the parent form
                    if (_isLocalTime)
                    {
                        _parentForm.setupLocalAppointmentDataGrid();
                    }
                    else
                    {
                        _parentForm.setupAppointmentDataGrid();
                    }
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving appointment: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddNewAppointment()
        {
            string insertQuery = @"INSERT INTO appointment 
                                   (customerId, userId, type, title, description, location, contact, url, start, end, createDate, createdBy, lastUpdateBy) 
                                   VALUES 
                                   (@customerId, @userId, @type, @title, @description, @location, @contact, @url, @start, @end, @createDate, @createdBy, @lastUpdateBy);";

            executeAppointmentQuery(insertQuery, isUpdate: false);
        }

        private void UpdateExistingAppointment()
        {
            string updateQuery = @"UPDATE appointment SET 
                                   customerId = @customerId, 
                                   type = @type, 
                                   title = @title, 
                                   description = @description, 
                                   start = @start, 
                                   end = @end, 
                                   lastUpdateBy = @lastUpdateBy 
                                   WHERE appointmentId = @appointmentId;";

            executeAppointmentQuery(updateQuery, isUpdate: true);
        }

        private void executeAppointmentQuery(string query, bool isUpdate)
        {
            using (var command = new MySqlCommand(query, _dbConnection))
            {
                command.Parameters.AddWithValue("@customerId", inputCustomer.Text.Trim());
                command.Parameters.AddWithValue("@userId", _currentUserId);
                command.Parameters.AddWithValue("@type", inputType.Text.Trim());
                command.Parameters.AddWithValue("@title", inputType.Text.Trim()); 
                command.Parameters.AddWithValue("@description", inputType.Text.Trim());
                command.Parameters.AddWithValue("@location", string.Empty);
                command.Parameters.AddWithValue("@contact", string.Empty);
                command.Parameters.AddWithValue("@url", string.Empty);      
                command.Parameters.AddWithValue("@start", FormatDateTime(selectStart.Value));
                command.Parameters.AddWithValue("@end", FormatDateTime(selectEnd.Value));
                command.Parameters.AddWithValue("@createDate", _creationDate);
                command.Parameters.AddWithValue("@createdBy", _currentUsername);
                command.Parameters.AddWithValue("@lastUpdateBy", _currentUsername);

                if (isUpdate)
                {
                    if (!int.TryParse(_appointmentId, out int parsedAppointmentId))
                    {
                        MessageBox.Show("Invalid Appointment ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    command.Parameters.AddWithValue("@appointmentId", parsedAppointmentId);
                }

                try
                {
                    if (_dbConnection.State == ConnectionState.Closed)
                    {
                        _dbConnection.Open();
                    }

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error executing appointment query: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (_dbConnection.State == ConnectionState.Open)
                    {
                        _dbConnection.Close();
                    }
                }
            }
        }

        private string FormatDateTime(DateTime dateTime)
        {
            DateTime utcDateTime = _isLocalTime ? dateTime.ToUniversalTime() : dateTime;
            return utcDateTime.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private bool ValidateAppointmentDetails()
        {
            bool isValid = ValidateInputFields() && ValidateBusinessHours() && !IsOverlappingAppointment();
            return isValid;
        }

        private bool ValidateInputFields()
        {
            bool isValid = true;

            // Validate appointment type
            if (string.IsNullOrWhiteSpace(inputType.Text))
            {
                SetError(inputType, appointmentTypeHelper, "Type is required.");
                isValid = false;
            }
            else
            {
                ClearError(inputType, appointmentTypeHelper);
            }

            // Validate customer ID
            if (string.IsNullOrWhiteSpace(inputCustomer.Text))
            {
                SetError(inputCustomer, customerIdHelper, "Customer ID is required.");
                isValid = false;
            }
            else if (!DoesCustomerExist(inputCustomer.Text.Trim()))
            {
                SetError(inputCustomer, customerIdHelper, "Customer ID does not exist.");
                isValid = false;
            }
            else
            {
                ClearError(inputCustomer, customerIdHelper);
            }

            return isValid;
        }

        private void SetError(Control control, ToolTip toolTip, string message)
        {
            toolTip.Active = true;
            toolTip.Show(message, control);
            control.BackColor = Color.LightCoral;
        }

        private void ClearError(Control control, ToolTip toolTip)
        {
            toolTip.Active = false;
            control.BackColor = SystemColors.Window;
        }

        private bool DoesCustomerExist(string customerId)
        {
            string query = "SELECT COUNT(*) FROM customer WHERE customerId = @customerId;";
            using (var command = new MySqlCommand(query, _dbConnection))
            {
                command.Parameters.AddWithValue("@customerId", customerId);

                try
                {
                    if (_dbConnection.State == ConnectionState.Closed)
                    {
                        _dbConnection.Open();
                    }

                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error validating customer ID: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                finally
                {
                    if (_dbConnection.State == ConnectionState.Open)
                    {
                        _dbConnection.Close();
                    }
                }
            }
        }

        private bool ValidateBusinessHours()
        {
            DateTime startUtc = selectStart.Value.ToUniversalTime();
            DateTime endUtc = selectEnd.Value.ToUniversalTime();

            TimeZoneInfo estZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            DateTime startEst = TimeZoneInfo.ConvertTimeFromUtc(startUtc, estZone);
            DateTime endEst = TimeZoneInfo.ConvertTimeFromUtc(endUtc, estZone);

            if (!IsWithinBusinessHours(startEst) || !IsWithinBusinessHours(endEst))
            {
                MessageBox.Show("Appointments must be scheduled between 9 AM and 5 PM EST, Monday to Friday.", "Invalid Time", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (endEst <= startEst)
            {
                MessageBox.Show("End time must be after start time.", "Invalid Time", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool IsWithinBusinessHours(DateTime dateTime)
        {
            bool isWeekday = dateTime.DayOfWeek != DayOfWeek.Saturday && dateTime.DayOfWeek != DayOfWeek.Sunday;
            bool isBusinessHour = dateTime.TimeOfDay >= TimeSpan.FromHours(9) && dateTime.TimeOfDay < TimeSpan.FromHours(17);
            return isWeekday && isBusinessHour;
        }

        private bool IsOverlappingAppointment()
        {
            DateTime newStartUtc = selectStart.Value.ToUniversalTime();
            DateTime newEndUtc = selectEnd.Value.ToUniversalTime();

            string query = @"SELECT appointmentId, start, end 
                             FROM appointment 
                             WHERE customerId = @customerId 
                             AND appointmentId != @appointmentId;";

            using (var command = new MySqlCommand(query, _dbConnection))
            {
                command.Parameters.AddWithValue("@customerId", inputCustomer.Text.Trim());
                if (int.TryParse(_appointmentId, out int parsedAppointmentId))
                {
                    command.Parameters.AddWithValue("@appointmentId", parsedAppointmentId);
                }
                else
                {
                    command.Parameters.AddWithValue("@appointmentId", 0);
                }

                try
                {
                    if (_dbConnection.State == ConnectionState.Closed)
                    {
                        _dbConnection.Open();
                    }

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateTime existingStart = DateTime.Parse(reader["start"].ToString()).ToUniversalTime();
                            DateTime existingEnd = DateTime.Parse(reader["end"].ToString()).ToUniversalTime();

                            if (newStartUtc < existingEnd && newEndUtc > existingStart)
                            {
                                MessageBox.Show("Appointment times overlap with an existing appointment.", "Overlap Detected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return true;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error checking overlapping appointments: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return true; // Assume overlapping if error occurs
                }
                finally
                {
                    if (_dbConnection.State == ConnectionState.Open)
                    {
                        _dbConnection.Close();
                    }
                }
            }

            return false;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void InputType_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(inputType.Text))
            {
                ClearError(inputType, appointmentTypeHelper);
            }
        }

        private void InputCustomer_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(inputCustomer.Text))
            {
                ClearError(inputCustomer, customerIdHelper);
            }
        }

        private void appointmentForm_Load(object sender, EventArgs e)
        {

        }
    }
}
