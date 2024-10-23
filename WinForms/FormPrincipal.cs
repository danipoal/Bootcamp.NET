using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms
{
    public partial class FormPrincipal : Form
    {
        
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if( !string.IsNullOrEmpty(nameBox.Text))
                button1.Text = nameBox.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormTask f = new FormTask();
            f.Show();
            
        }
    }
}
