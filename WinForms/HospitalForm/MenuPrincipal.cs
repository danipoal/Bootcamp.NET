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
    public partial class MenuPrincipal : Form
    {
        public Hospital hospital;
        public MenuPrincipal(Hospital hospitalSeleccionado)
        {
            
            InitializeComponent();
            hospital = hospitalSeleccionado;
            hospital.AñadirDefault();
            InfoView info = new InfoView(hospital);
            MostrarUserControlEnPanel(info);
        }
        private void LimpiarPanel(Control contenedor)
        {
            for (int i = contenedor.Controls.Count - 1; i >= 0; i--)
            {
                Control control = contenedor.Controls[i];
                if (control is Panel || control is GroupBox || control.HasChildren)
                {
                    LimpiarPanel(control);  // Llamada recursiva para limpiar subcontenedores
                }
                contenedor.Controls.Remove(control);
                control.Dispose();  // Esto elimina el control y libera sus recursos
            }
        }

        private void MostrarUserControlEnPanel(UserControl uc)
        {
            // Asegurarse de que el panel esté limpio antes de cargar un nuevo UserControl
            panelContenedor.Controls.Clear();

            uc.Dock = DockStyle.Fill; // Asegura que el UserControl se ajuste completamente al espacio del panel

            // Añadir el UserControl al panel y mostrarlo
            panelContenedor.Controls.Add(uc);
            uc.Show();
        }
        private void medicosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PersonList user = new PersonList(hospital, ePersonaType.Medico);
            LimpiarPanel(panelContenedor);
            MostrarUserControlEnPanel(user);

        }

        private void trabajadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PersonList user = new PersonList(hospital, ePersonaType.Empleado);
            LimpiarPanel(panelContenedor);
            MostrarUserControlEnPanel(user);
        }

        private void pacientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PersonList user = new PersonList(hospital, ePersonaType.Paciente);
            LimpiarPanel(panelContenedor);
            MostrarUserControlEnPanel(user);
        }

        private void informacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InfoView info = new InfoView(hospital);
            LimpiarPanel(panelContenedor);
            MostrarUserControlEnPanel(info);
        }
    }
}
