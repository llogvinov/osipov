using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace DBConnection
{
    public partial class Form1 : Form
    {
        private SqlConnection connection = new SqlConnection();
        //private const string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True";
        private string connectionString = GetConnectionStringByName("DBConnect.NorthwindConnectionString");

        public Form1()
        {
            InitializeComponent();
            this.connection.StateChange += new StateChangeEventHandler(this.connection_StateChange);
        }

        private void connection_StateChange(object sender, StateChangeEventArgs e)
        {
            подключитьсяКБДToolStripMenuItem.Enabled = (e.CurrentState == ConnectionState.Closed);
            асинхронноеПодключениеToolStripMenuItem.Enabled = (e.CurrentState == ConnectionState.Closed);
            отключитьсяОтБДToolStripMenuItem.Enabled = (e.CurrentState == ConnectionState.Open);
        }

        private void Form1_Load(object sender, EventArgs e)
        { }

        private void ConnectToDb_Click(object sender, EventArgs e)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();
                    MessageBox.Show("Соединение с базой данных " +
                    connection.Database + " выполнено успешно " + "\nСервер: " +
                    connection.DataSource);
                }
                else
                {
                    MessageBox.Show("Соединение с базой данных уже установлено");
                }
            }
            catch (SqlException XcpSQL)
            {
                foreach (SqlError se in XcpSQL.Errors)
                {
                    MessageBox.Show(se.Message, "Источник ошибки: " + se.Source,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                }
            }
            catch (Exception Xcp)
            {
                MessageBox.Show(Xcp.Message, "Unexpected Exception",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisconnectFromDb_Click(object sender, EventArgs e)
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
                MessageBox.Show("Соединение с базой данных закрыто");
            }
            else
            {
                MessageBox.Show("Соединение с базой данных уже закрыто");
            }
        }

        private async void AsyncConnectToDb_Click(object sender, EventArgs e)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.ConnectionString = connectionString;
                    await connection.OpenAsync();
                    MessageBox.Show("Соединение с базой данных " +
                    connection.Database + " выполнено успешно " + "\nСервер: " +
                    connection.DataSource);
                }
                else
                {
                    MessageBox.Show("Соединение с базой данных уже установлено");
                }
            }
            catch
            {
                MessageBox.Show("Ошибка соединения с базой данных");
            }
        }

        private void ConnectionList_Click(object sender, EventArgs e)
        {
            ConnectionStringSettingsCollection settings = ConfigurationManager.ConnectionStrings;
            if (settings != null)
            {
                foreach (ConnectionStringSettings cs in settings)
                {
                    string str = String.Format("Name = " + cs.Name + 
                        "\nProviderName = " + cs.ProviderName + 
                        "\nConnectionString = " + cs.ConnectionString);
                    MessageBox.Show(str, "Параметры подключений");
                }
            }
        }

        static string GetConnectionStringByName(string name)
        {
            string returnValue = null;
            ConnectionStringSettings settings =
            ConfigurationManager.ConnectionStrings[name];
            if (settings != null) returnValue = settings.ConnectionString;
            return returnValue;
        }
    }
}
