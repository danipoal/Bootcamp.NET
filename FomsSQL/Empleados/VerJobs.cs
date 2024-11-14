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
    enum eCrud
    {
        Create,
        Read,
        Update,
        Delete
    }
    public partial class VerJobs : Form
    {
        SqlConnection Connection;
        List<Job> jobs;
        int rowIndex;
        public VerJobs(SqlConnection connection)
        {
            InitializeComponent();
            Connection = connection;
            jobs = new List<Job>(getJobs());
            fillComponent(jobs);
        }
        public List<Job> getJobs()
        {
            List<Job> jobs = new List<Job>();

            string query = "SELECT * FROM jobs";
            SqlCommand sqlCommand = new SqlCommand(query, Connection);

            //Se usa un lector para leer la extraccion de dichos datos. 
            SqlDataReader reader = sqlCommand.ExecuteReader();

            //Leemos filas devueltas, uno x uno
            while (reader.Read()) {

                //reader.Get espera el indice de columna, no el nombre
                //Por lo tanto hay encontrar el indice y luego usarlo

                int jobIdIndex = reader.GetOrdinal("job_id");
                int jobId = reader.GetInt32(jobIdIndex);

                string jobName = reader.GetString(reader.GetOrdinal("job_title"));

                int minIndex = reader.GetOrdinal("min_salary");
                int maxIndex = reader.GetOrdinal("max_salary");

                decimal? minSalary = reader.IsDBNull(minIndex) ? null : (decimal?)reader.GetDecimal(minIndex);
                decimal? maxSalary = reader.IsDBNull(maxIndex) ? null : (decimal?)reader.GetDecimal(maxIndex);

                Job job = new Job(jobId, jobName, minSalary, maxSalary);
                jobs.Add(job);
            }
            reader.Close();
            return jobs;
        }
        public void fillComponent(List<Job> jobs)
        {
            dataGridView.DataSource = jobs;
        }

        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //Se ejecuta al terminar de editar
        }
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Saca el n fila de la celda que pulsas
            rowIndex = e.RowIndex;

        }
        private void CRUD()
        {

        }
    }
}
