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

namespace Empleados
{
    public partial class Form1 : Form
    {
        public SqlConnection Connection;
        public Form1()
        {
            InitializeComponent();
            string connectionString = @"
    Data Source=85.208.21.117,54321;" +
    "Initial Catalog=AriEmployees;" +
    "User ID=sa;" +
    "Password= Sql#123456789;" +
    "TrustServerCertificate=True;";

            Connection = new SqlConnection(connectionString);
            UpdateConnectionButtons();
        }

        private void connectBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Connection.Open();
                MessageBox.Show("Conexión establecida con éxito.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar: {ex.Message}");
            }
            finally
            {
                UpdateConnectionButtons();
            }
        }

        private void disconnectBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Connection.Close();
                MessageBox.Show("Conexión cerrada.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al desconectar: {ex.Message}");
            }
            finally
            {
                UpdateConnectionButtons();
            }
        }
        private void UpdateConnectionButtons()
        {
            // El botón de conectar estará habilitado solo si la conexión está cerrada
            connectBtn.Enabled = Connection.State == ConnectionState.Closed;

            // El botón de desconectar estará habilitado solo si la conexión está abierta
            disconnectBtn.Enabled = Connection.State == ConnectionState.Open;

            insertBtn.Enabled = Connection.State == ConnectionState.Open;
            verBtn.Enabled = Connection.State == ConnectionState.Open;
        }

        private void insertBtn_Click(object sender, EventArgs e)
        {
            InsertJob insertView = new InsertJob();
            insertView.Show();
        }

        private void verBtn_Click(object sender, EventArgs e)
        {
            VerJobs verJobsView = new VerJobs();
            verJobsView.Show();
        }
    }
}
