using GlobalSchedulerAppC969;
using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace GlobalSchedulerAppC969
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string connectionString = ConfigurationManager.ConnectionStrings["mySqlKey"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connectionString);

            try
            {
                conn.Open();
                Application.Run(new userLoginForm(conn));
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Database connection error: " + ex.Message);
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
    }
}
