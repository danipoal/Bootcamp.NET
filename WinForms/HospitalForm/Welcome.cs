using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HospitalForm
{
    public partial class Welcome : UserControl
    {
        public event EventHandler LoadCompleted;  // Evento para notificar la finalización
        public Welcome()
        {
            InitializeComponent();
            progressBar.Minimum = 0;
            progressBar.Maximum = 20;  // 3 segundos en intervalos de 100 ms
            progressBar.Value = 0;

            timer.Interval = 100;  // 100 ms
            timer.Tick += Timer_Tick;

        }
        public void StartLoading()
        {
            progressBar.Value = 0;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (progressBar.Value < progressBar.Maximum)
            {
                progressBar.Value++;
            }
            else
            {
                timer.Stop();
                OnLoadCompleted(EventArgs.Empty);
            }
        }

        protected virtual void OnLoadCompleted(EventArgs e)
        {
            LoadCompleted?.Invoke(this, e);
        }


    }
}
