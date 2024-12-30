using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace GlobalSchedulerAppC969
{
    public partial class reportViewer : Form
    {
        private MySqlConnection _connection;
        public reportViewer(MySqlConnection dbconnection, string reportContent, string additionalParam = "")
        {
            InitializeComponent();
            _connection = dbconnection;

            if (!string.IsNullOrEmpty(reportContent))
            {
                // Display report content if provided.
                reportTypeLabel.Text = reportContent;
                userScheduleDataGridView.Visible = false;
            }
            else if (!string.IsNullOrEmpty(additionalParam))
            {
                reportTypeLabel.Text = $"Additional Parameter: {additionalParam}";
                userScheduleDataGridView.Visible = false;
            }
            else
            {
                reportTypeLabel.Text = "No data to display.";
            }
        }

        // Load event handler for the reportViewer form.
        private void reportViewerForm_Load(object sender, EventArgs e)
        {
        }

        private void userScheduleDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
