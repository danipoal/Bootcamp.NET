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
    public partial class InfoView : UserControl
    {
        public InfoView(Hospital hospital)
        {
            InitializeComponent();
            UpdateCountInfo(hospital);
        }

        public void UpdateCountInfo(Hospital hospital)
        {
            int countMed = hospital.GetTypeList<Medico>().Count;
            int countPac = hospital.GetTypeList<Paciente>().Count;
            int countCit = hospital.GetCitas().Count;

            Console.WriteLine(countMed);
            countMedicos.Text = countMed + "";
            countPacientes.Text = countPac + "";
            countCitas.Text = countCit + "";


        }
    }
}
