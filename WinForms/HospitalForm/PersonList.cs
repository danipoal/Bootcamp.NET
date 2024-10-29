using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalForm
{
    public partial class PersonList : UserControl
    {
        public PersonList(Hospital hospital, ePersonaType type)
        {
            
            InitializeComponent();
            dataGridView1.DataSource = null;
            if (type == ePersonaType.Medico)
            {
                dataGridView1.DataSource = hospital.GetTypeList<Medico>();
                //Nombre salario especialidad
                dataGridView1.Columns["Nombre"].DisplayIndex = 0;
                dataGridView1.Columns["Salario"].DisplayIndex = 1;
                dataGridView1.Columns["Especialidad"].DisplayIndex = 2;



            }
            else if (type == ePersonaType.Paciente)
            {
                // nOMBRE SALARIO
                dataGridView1.DataSource = hospital.GetTypeList<Paciente>();
                //Columna de Medico asignable no editable (es un objeto)
                dataGridView1.Columns["MedicoAsignado"].ReadOnly = true;
                dataGridView1.Columns["Nombre"].DisplayIndex = 0;
                dataGridView1.Columns["MedicoAsignado"].DisplayIndex = 1;


            }
            else if (type == ePersonaType.Empleado)
            {
                //DA ERROR
                dataGridView1.DataSource = hospital.GetTypeList<Empleado>();
                dataGridView1.Columns["Nombre"].DisplayIndex = 0;
                dataGridView1.Columns["Salario"].DisplayIndex = 1;

            }

            dataGridView1.AllowUserToOrderColumns = true;

            // Suponiendo que las columnas ya están añadidas al DataGridView, establece el orden inicial
            //dataGridView1.Columns["Id"].DisplayIndex = 0;
            //dataGridView1.Columns["Nombre"].DisplayIndex = 1;
            //dataGridView1.Columns["Edad"].DisplayIndex = 2;


        }

    }
}
