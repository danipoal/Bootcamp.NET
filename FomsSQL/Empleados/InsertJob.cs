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
    public partial class InsertJob : Form
    {
        SqlConnection Connection;
        public InsertJob(SqlConnection connection)
        {
            InitializeComponent();
            Connection = connection;
        }
        public void CrearTrabajo(Job job) 
        {
            //Generamos la cadena junto con la preparacion de el Sql Comand
            String cadena = @"
            INSERT INTO jobs(job_title, min_salary, max_salary)
            VALUES (@ptitle, @pminsalary, @pmaxsalary)";
            
            SqlCommand insertar = new SqlCommand(cadena, Connection);


            //Añadimos los parametros que iran dentro de la sentencia
            SqlParameter ptitle = new SqlParameter("@ptitle", SqlDbType.VarChar, 35);
            insertar.Parameters.Add(ptitle);
            ptitle.Value = job.Titulo;

            //Tambien se debe gestionar la posibilidad de que haya un nulo
            //Que usa el objeto DBNull.Value y no un null normal
            SqlParameter pminsal = new SqlParameter("@pminsalary", SqlDbType.Decimal);
            insertar.Parameters.Add(pminsal);
            pminsal.Precision = 8;
            pminsal.Scale = 2;
            if (job.MinSalary == null)
                pminsal.Value = DBNull.Value;
            else
                pminsal.Value = job.MinSalary;


            SqlParameter pmaxsal = new SqlParameter("@pmaxsalary", SqlDbType.Decimal);
            insertar.Parameters.Add(pmaxsal);
            pmaxsal.Precision = 8;
            pmaxsal.Scale = 2; 
            if (job.MaxSalary == null)
                pmaxsal.Value = DBNull.Value;
            else
                pmaxsal.Value = job.MaxSalary;

            //Ejecutamos la sentencia
            try
            {
                insertar.ExecuteNonQuery();
            }
            catch (Exception ex) {
                MessageBox.Show($"Error al conectar: {ex.Message}");
            }
        }

        private void insertBtn_Click(object sender, EventArgs e)
        {
            decimal tmp;
            bool isNull;
            Job job = new Job();

            //Obtenemos toda la info del form y la metemos en el objeto
            job.Titulo = titleJobTBox.Text;

            isNull = decimal.TryParse(minNumeric.Text, out tmp);
            if (!isNull)
                job.MinSalary = tmp;
            else
                job.MinSalary = null;

            isNull = decimal.TryParse (maxNumeric.Text, out tmp);
            if (!isNull)
                job.MaxSalary = tmp;
            else
                job.MaxSalary = null;


            //Pasamos el objeto a la clase que hara el insert
            CrearTrabajo(job);

            //Que se ha creado correctamente
            MessageBox.Show($"Insertado {job.Titulo} con min: {job.MinSalary} y {job.MaxSalary}\n");
            
            //Cerrar form de insercion despues de eliminar cerrar el MessageBox
            this.Close();
        }
    }
}
