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
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.informacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
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
            this.informacionToolStripMenuItem,
            this.cerrarSesiónToolStripMenuItem});
            this.hospitalToolStripMenuItem.Name = "hospitalToolStripMenuItem";
            this.hospitalToolStripMenuItem.Size = new System.Drawing.Size(94, 29);
            this.hospitalToolStripMenuItem.Text = "Hospital";
            // 
            // nuevoHospitalToolStripMenuItem
            // 
            this.nuevoHospitalToolStripMenuItem.Name = "nuevoHospitalToolStripMenuItem";
            this.nuevoHospitalToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.nuevoHospitalToolStripMenuItem.Text = "Nuevo";
            // 
            // abrirHospitalToolStripMenuItem
            // 
            this.abrirHospitalToolStripMenuItem.Name = "abrirHospitalToolStripMenuItem";
            this.abrirHospitalToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.abrirHospitalToolStripMenuItem.Text = "Abrir";
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            this.cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            this.cerrarSesiónToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
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
            this.trabajadoresToolStripMenuItem.Click += new System.EventHandler(this.trabajadoresToolStripMenuItem_Click);
            // 
            // pacientesToolStripMenuItem
            // 
            this.pacientesToolStripMenuItem.Name = "pacientesToolStripMenuItem";
            this.pacientesToolStripMenuItem.Size = new System.Drawing.Size(214, 34);
            this.pacientesToolStripMenuItem.Text = "Pacientes";
            this.pacientesToolStripMenuItem.Click += new System.EventHandler(this.pacientesToolStripMenuItem_Click);
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
            // panelContenedor
            // 
            this.panelContenedor.Location = new System.Drawing.Point(-1, 33);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(1023, 472);
            this.panelContenedor.TabIndex = 1;
            // 
            // informacionToolStripMenuItem
            // 
            this.informacionToolStripMenuItem.Name = "informacionToolStripMenuItem";
            this.informacionToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.informacionToolStripMenuItem.Text = "Informacion";
            this.informacionToolStripMenuItem.Click += new System.EventHandler(this.informacionToolStripMenuItem_Click);
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 502);
            this.Controls.Add(this.panelContenedor);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MenuPrincipal";
            this.Text = "MenuPrincipal";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.ToolStripMenuItem informacionToolStripMenuItem;
    }
}