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
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();

            LlenarComboBoxHospitales();
        }
        private void LlenarComboBoxHospitales()
        {
            HospCombo.Items.Clear(); // Limpiar el ComboBox
            foreach (Hospital hospital in Program.Hospitales)
            {
                HospCombo.Items.Add(hospital);
                HospCombo.DisplayMember = "Nombre"; // Mostrar la propiedad nombre en el combo

            }
               

        }

        private void IniciarButton_Click(object sender, EventArgs e)
        {

            if (HospCombo.SelectedItem != null)
            {
                Hospital selectedHospital = (Hospital)HospCombo.SelectedItem;
                MenuPrincipal menuPrincipal = new MenuPrincipal(selectedHospital);
                menuPrincipal.Show();
                this.Hide(); // Opcional: Ocultar el formulario actual
            }
            else
                MessageBox.Show("Por favor, seleccione un hospital de la lista.");
        }
    }
}
