namespace HospitalForm
{
    partial class Inicio
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.HospCombo = new System.Windows.Forms.ComboBox();
            this.IniciarButton = new System.Windows.Forms.Button();
            this.addHospButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(212, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(356, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "ERP de Hospitales";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(295, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Seleccione su hospital:";
            // 
            // HospCombo
            // 
            this.HospCombo.FormattingEnabled = true;
            this.HospCombo.Location = new System.Drawing.Point(299, 215);
            this.HospCombo.Name = "HospCombo";
            this.HospCombo.Size = new System.Drawing.Size(167, 28);
            this.HospCombo.TabIndex = 2;
            // 
            // IniciarButton
            // 
            this.IniciarButton.Location = new System.Drawing.Point(340, 270);
            this.IniciarButton.Name = "IniciarButton";
            this.IniciarButton.Size = new System.Drawing.Size(75, 41);
            this.IniciarButton.TabIndex = 3;
            this.IniciarButton.Text = "Iniciar";
            this.IniciarButton.UseVisualStyleBackColor = true;
            this.IniciarButton.Click += new System.EventHandler(this.IniciarButton_Click);
            // 
            // addHospButton
            // 
            this.addHospButton.Location = new System.Drawing.Point(600, 398);
            this.addHospButton.Name = "addHospButton";
            this.addHospButton.Size = new System.Drawing.Size(166, 40);
            this.addHospButton.TabIndex = 4;
            this.addHospButton.Text = "Añadir Hospital";
            this.addHospButton.UseVisualStyleBackColor = true;
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.addHospButton);
            this.Controls.Add(this.IniciarButton);
            this.Controls.Add(this.HospCombo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Inicio";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox HospCombo;
        private System.Windows.Forms.Button IniciarButton;
        private System.Windows.Forms.Button addHospButton;
    }
}

