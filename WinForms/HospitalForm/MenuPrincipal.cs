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
            UserControl1 user = new UserControl1(hospital);
            MostrarUserControlEnPanel(user);
        }

    }
}
