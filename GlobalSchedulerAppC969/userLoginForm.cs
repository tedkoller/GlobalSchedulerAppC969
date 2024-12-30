using System;
using System.IO;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace GlobalSchedulerAppC969
{
    public partial class userLoginForm : Form
    {
        private readonly MySqlConnection _dbConnection;

        public userLoginForm(MySqlConnection connection)
        {
            _dbConnection = connection;
            InitializeComponent();
            verifyLog(); 
        }

        // Event handler for form load
        private void loginFormLoad(object sender, EventArgs e)
        {
        }

        private void verifyLog()
        {
            string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Login_History.txt");
            if (!File.Exists(logFilePath))
            {
                File.Create(logFilePath).Dispose();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void loginButton_Click(object sender, EventArgs e)
        {
            string enteredUsername = usernameTextbox.Text.Trim();
            string enteredPassword = pwdTextbox.Text.Trim();

            // validate input
            if (string.IsNullOrEmpty(enteredUsername) || string.IsNullOrEmpty(enteredPassword))
            {
                showUserAlert("Please enter both username and password.", "Error");
                return;
            }

            string userId = await verifiyUserCreds(enteredUsername, enteredPassword);
            if (userId != null)
            {
                recordLogin(enteredUsername, DateTime.Now, true);
                launchRecordsForm(enteredUsername, userId);
            }
            else
            {
                recordLogin(enteredUsername, DateTime.Now, false);
                showUserAlert("The username and password do not match.", "Login Failed");
            }
        }

        private async Task<string> verifiyUserCreds(string username, string password)
        {
            const string query = "SELECT userId FROM user WHERE userName = @username AND password = @password;";
            try
            {
                if (_dbConnection.State != ConnectionState.Open)
                {
                    await _dbConnection.OpenAsync();
                }

                using (var command = new MySqlCommand(query, _dbConnection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);
                    object result = await command.ExecuteScalarAsync();
                    return result?.ToString();
                }
            }
            catch (MySqlException ex)
            {
                showUserAlert($"Database connection error: {ex.Message}", "Error");
                return null;
            }
            finally
            {
                if (_dbConnection.State == ConnectionState.Open)
                {
                    await _dbConnection.CloseAsync();
                }
            }
        }

        private void launchRecordsForm(string username, string userId)
        {
            DateTime loginTime = DateTime.Now;
            var recordsForm = new recordManagerForm(_dbConnection, username, userId, loginTime);
            this.Hide();
            recordsForm.ShowDialog();
            this.Show();
        }

        private void showUserAlert(string message, string title)
        {
            MessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void recordLogin(string username, DateTime loginTime, bool isSuccess)
        {
            string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Login_History.txt");
            string status = isSuccess ? "SUCCESS" : "FAILED";
            string logEntry = $"{loginTime:yyyy-MM-dd HH:mm:ss} - Username: '{username}' - Status: {status}";

            try
            {
                File.AppendAllText(logFilePath, logEntry + Environment.NewLine);
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Failed to write to log file: {ex.Message}");
            }
        }

        // KeyDown event for the password textbox
        private void pwdTextbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginButton_Click(sender, e);
            }
        }
    }
}
