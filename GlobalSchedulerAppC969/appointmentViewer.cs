using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace GlobalSchedulerAppC969
{
    public partial class appointmentViewer : Form
    {
        private MySqlConnection _connection;
        private DateTimePicker _apptDate;
        public appointmentViewer(MySqlConnection dbconnection, DateTimePicker apptDate, bool monthly)
        {
            InitializeComponent();
            _apptDate = apptDate;
            _connection = dbconnection;
            if (!monthly)
            {
                loadDailyAppointments();
            }
            else
            {
                loadMonthlyAppointments();
            }
        }
        private void loadDailyAppointments()
        {
            var selectedDate = _apptDate.Value.Date.ToString("yyyy-MM-dd");
            appointmentDateLabel.Text += selectedDate;
            string sqlString = $"SELECT type, customer.customerName, CONCAT(cast(start as time), ' - ', cast(end as time)) AS scheduleTime FROM appointment, customer WHERE appointment.customerId = customer.customerId AND cast(start as date) = '{selectedDate}';";
            MySqlCommand command = new MySqlCommand(sqlString, _connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);

            DataTable datatable = new DataTable();
            adapter.Fill(datatable);

            appointmentsDataGridView.DataSource = datatable;
        }
        private void loadMonthlyAppointments()
        {
            var month = _apptDate.Value.Month;
            var year = _apptDate.Value.Year;
            appointmentDateLabel.Text += $"{month}/{year}";
            string sqlString = $"SELECT type, customer.customerName, CONCAT(cast(start as time), ' - ', cast(end as time)) AS scheduleTime FROM appointment, customer WHERE appointment.customerId = customer.customerId AND EXTRACT(MONTH FROM start) = {month} AND EXTRACT(YEAR FROM start) = {year};";
            MySqlCommand cmd = new MySqlCommand(sqlString, _connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            adapter.Fill(dt);

            appointmentsDataGridView.DataSource = dt;
        }

        private void appointmentsViewer_Load(object sender, System.EventArgs e)
        {

        }
    }
}
