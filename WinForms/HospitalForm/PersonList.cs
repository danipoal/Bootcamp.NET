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
        ePersonaType tipoVisible;
        BindingList<Medico> listaMedicos;
        BindingList<Empleado> listaEmpleados;
        BindingList<Paciente> listaPacientes;


        public PersonList(Hospital hospital, ePersonaType type)
        {
            InitializeComponent();
            dataGridView1.DataSource = null;
            tipoVisible = type;
            //Inicializar las binding lists
            listaMedicos = new BindingList<Medico> (hospital.GetTypeList<Medico>());
            listaEmpleados = new BindingList<Empleado>(hospital.GetTypeList<Empleado>());
            listaPacientes = new BindingList<Paciente>(hospital.GetTypeList<Paciente>());

            // Suscribir a eventos
            listaMedicos.ListChanged += (sender, e) => OnListChanged(e, hospital, listaMedicos);
            listaEmpleados.ListChanged += (sender, e) => OnListChanged(e, hospital, listaEmpleados);
            listaPacientes.ListChanged += (sender, e) => OnListChanged(e, hospital, listaPacientes);
            
            dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;
            dataGridView1.CurrentCellDirtyStateChanged += DataGridView1_CurrentCellDirtyStateChanged;
            //Colocar en los dataSOurce y ordenar columnas
            if (type == ePersonaType.Medico)
            {
                dataGridView1.DataSource = listaMedicos;
                //Nombre salario especialidad
                dataGridView1.Columns["Nombre"].DisplayIndex = 0;
                dataGridView1.Columns["Salario"].DisplayIndex = 1;
                dataGridView1.Columns["Especialidad"].DisplayIndex = 2;
            }
            else if (type == ePersonaType.Paciente)
            {
                foreach (var paciente in listaPacientes)
                {
                    if (paciente.MedicoAsignado != null)
                    {
                        paciente.MedicoAsignado = listaMedicos.FirstOrDefault(m => m.Id == paciente.MedicoAsignado.Id);
                    }
                }
                dataGridView1.DataSource = listaPacientes;
                //Columna de Medico asignable no editable (es un objeto)


                //Configurar el comboBox para elegir medico desde paciente
                DataGridViewComboBoxColumn medicoColumn = new DataGridViewComboBoxColumn();
                medicoColumn = dataGridView1.Columns["MedicoAsignado"] as DataGridViewComboBoxColumn;
                //Si no hay nada, se crea
                if (medicoColumn == null)
                {
                    medicoColumn = new DataGridViewComboBoxColumn();
                    medicoColumn.Name = "MedicoAsignado";
                    medicoColumn.HeaderText = "Médico Asignado";
                    dataGridView1.Columns.Add(medicoColumn);
                }


                //Enlazamos el combo con los posibles medicos
                medicoColumn.DataSource = listaMedicos;  // Asume listaMedicos como BindingList<Medico>
                medicoColumn.DisplayMember = "Nombre";  // Propiedad de Medico que se mostrará
                medicoColumn.ValueMember = "Self";  // Esto asume que quieres vincular el objeto Medico completo

                //dataGridView1.Columns["MedicoAsignado"].ReadOnly = true;
                dataGridView1.Columns["Nombre"].DisplayIndex = 0;
                dataGridView1.Columns["MedicoAsignado"].DisplayIndex = 1;
            }
            else if (type == ePersonaType.Empleado)
            {
                dataGridView1.DataSource = listaEmpleados;
                dataGridView1.Columns["Nombre"].DisplayIndex = 0;
                dataGridView1.Columns["Salario"].DisplayIndex = 1;
            }
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.AllowUserToAddRows = true;
        }

        private void OnListChanged<T>(ListChangedEventArgs e, Hospital hospital, BindingList<T> list) where T : Persona
        {
            if (e.ListChangedType == ListChangedType.ItemAdded)
            {
                T newPerson = list[e.NewIndex];
                hospital.Personas.Add(newPerson);
            }
            // Agregar otros tipos de cambios si es necesario (ItemDeleted, ItemChanged)
        }
        private void DataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            // Si es una columna de comboBox, esto forzará que el cambio se cometa inmediatamente
            if (dataGridView1.IsCurrentCellDirty)
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica que el cambio ocurra en la columna 'MedicoAsignado'
            if (e.ColumnIndex == dataGridView1.Columns["MedicoAsignado"].Index && e.RowIndex >= 0)
            {
                // Obtén el Paciente correspondiente a la fila editada
                Paciente paciente = dataGridView1.Rows[e.RowIndex].DataBoundItem as Paciente;
                if (paciente != null)
                {
                    // Obtén el Medico seleccionado en el ComboBox
                    var comboBoxCell = dataGridView1.Rows[e.RowIndex].Cells["MedicoAsignado"] as DataGridViewComboBoxCell;
                    if (comboBoxCell != null && comboBoxCell.Value != null)
                    {
                        // Actualiza el MedicoAsignado del Paciente con el Medico seleccionado
                        paciente.MedicoAsignado = comboBoxCell.Value as Medico;
                    }
                }
            }
        }

    }
}
