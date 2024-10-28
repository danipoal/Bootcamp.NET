namespace HospitalForm
{
    partial class MenuPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.hospitalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoHospitalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirHospitalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.medicosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.medicosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.trabajadoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pacientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionCitasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaCitaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verCitasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tituloText = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.countCitas = new System.Windows.Forms.Label();
            this.countPacientes = new System.Windows.Forms.Label();
            this.countMedicos = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hospitalToolStripMenuItem,
            this.medicosToolStripMenuItem,
            this.gestionCitasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1022, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // hospitalToolStripMenuItem
            // 
            this.hospitalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoHospitalToolStripMenuItem,
            this.abrirHospitalToolStripMenuItem,
            this.cerrarSesiónToolStripMenuItem});
            this.hospitalToolStripMenuItem.Name = "hospitalToolStripMenuItem";
            this.hospitalToolStripMenuItem.Size = new System.Drawing.Size(94, 29);
            this.hospitalToolStripMenuItem.Text = "Hospital";
            // 
            // nuevoHospitalToolStripMenuItem
            // 
            this.nuevoHospitalToolStripMenuItem.Name = "nuevoHospitalToolStripMenuItem";
            this.nuevoHospitalToolStripMenuItem.Size = new System.Drawing.Size(218, 34);
            this.nuevoHospitalToolStripMenuItem.Text = "Nuevo";
            // 
            // abrirHospitalToolStripMenuItem
            // 
            this.abrirHospitalToolStripMenuItem.Name = "abrirHospitalToolStripMenuItem";
            this.abrirHospitalToolStripMenuItem.Size = new System.Drawing.Size(218, 34);
            this.abrirHospitalToolStripMenuItem.Text = "Abrir";
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            this.cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            this.cerrarSesiónToolStripMenuItem.Size = new System.Drawing.Size(218, 34);
            this.cerrarSesiónToolStripMenuItem.Text = "Cerrar Sesión";
            // 
            // medicosToolStripMenuItem
            // 
            this.medicosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.medicosToolStripMenuItem1,
            this.trabajadoresToolStripMenuItem,
            this.pacientesToolStripMenuItem});
            this.medicosToolStripMenuItem.Name = "medicosToolStripMenuItem";
            this.medicosToolStripMenuItem.Size = new System.Drawing.Size(73, 29);
            this.medicosToolStripMenuItem.Text = "Editar";
            // 
            // medicosToolStripMenuItem1
            // 
            this.medicosToolStripMenuItem1.Name = "medicosToolStripMenuItem1";
            this.medicosToolStripMenuItem1.Size = new System.Drawing.Size(214, 34);
            this.medicosToolStripMenuItem1.Text = "Medicos";
            this.medicosToolStripMenuItem1.Click += new System.EventHandler(this.medicosToolStripMenuItem1_Click);
            // 
            // trabajadoresToolStripMenuItem
            // 
            this.trabajadoresToolStripMenuItem.Name = "trabajadoresToolStripMenuItem";
            this.trabajadoresToolStripMenuItem.Size = new System.Drawing.Size(214, 34);
            this.trabajadoresToolStripMenuItem.Text = "Trabajadores";
            // 
            // pacientesToolStripMenuItem
            // 
            this.pacientesToolStripMenuItem.Name = "pacientesToolStripMenuItem";
            this.pacientesToolStripMenuItem.Size = new System.Drawing.Size(214, 34);
            this.pacientesToolStripMenuItem.Text = "Pacientes";
            // 
            // gestionCitasToolStripMenuItem
            // 
            this.gestionCitasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaCitaToolStripMenuItem,
            this.verCitasToolStripMenuItem,
            this.editarToolStripMenuItem});
            this.gestionCitasToolStripMenuItem.Name = "gestionCitasToolStripMenuItem";
            this.gestionCitasToolStripMenuItem.Size = new System.Drawing.Size(128, 29);
            this.gestionCitasToolStripMenuItem.Text = "Gestion citas";
            // 
            // nuevaCitaToolStripMenuItem
            // 
            this.nuevaCitaToolStripMenuItem.Name = "nuevaCitaToolStripMenuItem";
            this.nuevaCitaToolStripMenuItem.Size = new System.Drawing.Size(196, 34);
            this.nuevaCitaToolStripMenuItem.Text = "Nueva cita";
            // 
            // verCitasToolStripMenuItem
            // 
            this.verCitasToolStripMenuItem.Name = "verCitasToolStripMenuItem";
            this.verCitasToolStripMenuItem.Size = new System.Drawing.Size(196, 34);
            this.verCitasToolStripMenuItem.Text = "Ver Citas";
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(196, 34);
            this.editarToolStripMenuItem.Text = "Editar";
            // 
            // tituloText
            // 
            this.tituloText.AutoSize = true;
            this.tituloText.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tituloText.Location = new System.Drawing.Point(386, 69);
            this.tituloText.Name = "tituloText";
            this.tituloText.Size = new System.Drawing.Size(318, 46);
            this.tituloText.TabIndex = 0;
            this.tituloText.Text = "Hospital Joan 23";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(86, 179);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 167);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Datos:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Medicos";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Pacientes";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Citas";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.countCitas, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.countPacientes, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.countMedicos, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(86, 229);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // countCitas
            // 
            this.countCitas.AutoSize = true;
            this.countCitas.Location = new System.Drawing.Point(103, 66);
            this.countCitas.Name = "countCitas";
            this.countCitas.Size = new System.Drawing.Size(18, 20);
            this.countCitas.TabIndex = 6;
            this.countCitas.Text = "0";
            // 
            // countPacientes
            // 
            this.countPacientes.AutoSize = true;
            this.countPacientes.Location = new System.Drawing.Point(103, 33);
            this.countPacientes.Name = "countPacientes";
            this.countPacientes.Size = new System.Drawing.Size(18, 20);
            this.countPacientes.TabIndex = 5;
            this.countPacientes.Text = "0";
            // 
            // countMedicos
            // 
            this.countMedicos.AutoSize = true;
            this.countMedicos.Location = new System.Drawing.Point(103, 0);
            this.countMedicos.Name = "countMedicos";
            this.countMedicos.Size = new System.Drawing.Size(18, 20);
            this.countMedicos.TabIndex = 4;
            this.countMedicos.Text = "0";
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(620, 179);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(343, 170);
            this.chart1.TabIndex = 3;
            this.chart1.Text = "chart1";
            // 
            // panelContenedor
            // 
            this.panelContenedor.Location = new System.Drawing.Point(0, 36);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(1010, 463);
            this.panelContenedor.TabIndex = 4;
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 502);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tituloText);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panelContenedor);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MenuPrincipal";
            this.Text = "MenuPrincipal";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hospitalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoHospitalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirHospitalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem medicosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem medicosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem trabajadoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pacientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionCitasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevaCitaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verCitasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.Label tituloText;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label countCitas;
        private System.Windows.Forms.Label countPacientes;
        private System.Windows.Forms.Label countMedicos;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Panel panelContenedor;
    }
}