using System;
using System.Windows.Forms;

namespace WinForms
{
    partial class FormTask
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
            this.TitleBox = new System.Windows.Forms.TextBox();
            this.LocationComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TypeComboBox = new System.Windows.Forms.ComboBox();
            this.CriticityComboBox = new System.Windows.Forms.ComboBox();
            this.ProdCheck = new System.Windows.Forms.CheckBox();
            this.PreprodCheck = new System.Windows.Forms.CheckBox();
            this.DemoCheck = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.StatusComboBox = new System.Windows.Forms.ComboBox();
            this.PercentComboBox = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.MailCheckBox = new System.Windows.Forms.CheckBox();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.CalcelButton = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Title";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(520, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Location";
            // 
            // TitleBox
            // 
            this.TitleBox.Location = new System.Drawing.Point(96, 57);
            this.TitleBox.Name = "TitleBox";
            this.TitleBox.Size = new System.Drawing.Size(204, 26);
            this.TitleBox.TabIndex = 2;
            // 
            // LocationComboBox
            // 
            this.LocationComboBox.FormattingEnabled = true;
            this.LocationComboBox.Location = new System.Drawing.Point(524, 55);
            this.LocationComboBox.Name = "LocationComboBox";
            this.LocationComboBox.Size = new System.Drawing.Size(205, 28);
            this.LocationComboBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(92, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Type";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(306, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Criticity";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(547, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "Environment";
            // 
            // TypeComboBox
            // 
            this.TypeComboBox.FormattingEnabled = true;
            this.TypeComboBox.Location = new System.Drawing.Point(96, 174);
            this.TypeComboBox.Name = "TypeComboBox";
            this.TypeComboBox.Size = new System.Drawing.Size(104, 28);
            this.TypeComboBox.TabIndex = 7;
            this.TypeComboBox.Text = "Incident";
            // 
            // CriticityComboBox
            // 
            this.CriticityComboBox.FormattingEnabled = true;
            this.CriticityComboBox.Location = new System.Drawing.Point(310, 174);
            this.CriticityComboBox.Name = "CriticityComboBox";
            this.CriticityComboBox.Size = new System.Drawing.Size(104, 28);
            this.CriticityComboBox.TabIndex = 8;
            this.CriticityComboBox.Text = "Minor";
            // 
            // ProdCheck
            // 
            this.ProdCheck.AutoSize = true;
            this.ProdCheck.Location = new System.Drawing.Point(551, 177);
            this.ProdCheck.Name = "ProdCheck";
            this.ProdCheck.Size = new System.Drawing.Size(68, 24);
            this.ProdCheck.TabIndex = 9;
            this.ProdCheck.Text = "Prod";
            this.ProdCheck.UseVisualStyleBackColor = true;
            // 
            // PreprodCheck
            // 
            this.PreprodCheck.AutoSize = true;
            this.PreprodCheck.Location = new System.Drawing.Point(551, 207);
            this.PreprodCheck.Name = "PreprodCheck";
            this.PreprodCheck.Size = new System.Drawing.Size(91, 24);
            this.PreprodCheck.TabIndex = 10;
            this.PreprodCheck.Text = "Preprod";
            this.PreprodCheck.UseVisualStyleBackColor = true;
            // 
            // DemoCheck
            // 
            this.DemoCheck.AutoSize = true;
            this.DemoCheck.Location = new System.Drawing.Point(551, 237);
            this.DemoCheck.Name = "DemoCheck";
            this.DemoCheck.Size = new System.Drawing.Size(78, 24);
            this.DemoCheck.TabIndex = 11;
            this.DemoCheck.Text = "Demo";
            this.DemoCheck.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(92, 267);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "Description";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(96, 303);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(633, 112);
            this.richTextBox1.TabIndex = 13;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(92, 451);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 20);
            this.label7.TabIndex = 14;
            this.label7.Text = "Start Date";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(520, 451);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(140, 20);
            this.label8.TabIndex = 15;
            this.label8.Text = "Duration (in hours)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(520, 536);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(133, 20);
            this.label9.TabIndex = 17;
            this.label9.Text = "Percent complete";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(92, 536);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 20);
            this.label10.TabIndex = 16;
            this.label10.Text = "Status";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // StatusComboBox
            // 
            this.StatusComboBox.FormattingEnabled = true;
            this.StatusComboBox.Location = new System.Drawing.Point(96, 585);
            this.StatusComboBox.Name = "StatusComboBox";
            this.StatusComboBox.Size = new System.Drawing.Size(121, 28);
            this.StatusComboBox.TabIndex = 18;
            this.StatusComboBox.Text = "Planned";
            // 
            // PercentComboBox
            // 
            this.PercentComboBox.FormattingEnabled = true;
            this.PercentComboBox.Items.AddRange(new object[] {
            "1 %",
            "2 %",
            "3 %",
            "4 %",
            "5 %",
            "6 %",
            "7 %",
            "8 %",
            "9 %",
            "10 %",
            "11 %",
            "12 %",
            "13 %",
            "14 %",
            "15 %",
            "16 %",
            "17 %",
            "18 %",
            "19 %",
            "20 %",
            "21 %",
            "22 %",
            "23 %",
            "24 %",
            "25 %",
            "26 %",
            "27 %",
            "28 %",
            "29 %",
            "30 %",
            "31 %",
            "32 %",
            "33 %",
            "34 %",
            "35 %",
            "36 %",
            "37 %",
            "38 %",
            "39 %",
            "40 %",
            "41 %",
            "42 %",
            "43 %",
            "44 %",
            "45 %",
            "46 %",
            "47 %",
            "48 %",
            "49 %",
            "50 %",
            "51 %",
            "52 %",
            "53 %",
            "54 %",
            "55 %",
            "56 %",
            "57 %",
            "58 %",
            "59 %",
            "60 %",
            "61 %",
            "62 %",
            "63 %",
            "64 %",
            "65 %",
            "66 %",
            "67 %",
            "68 %",
            "69 %",
            "70 %",
            "71 %",
            "72 %",
            "73 %",
            "74 %",
            "75 %",
            "76 %",
            "77 %",
            "78 %",
            "79 %",
            "80 %",
            "81 %",
            "82 %",
            "83 %",
            "84 %",
            "85 %",
            "86 %",
            "87 %",
            "88 %",
            "89 %",
            "90 %",
            "91 %",
            "92 %",
            "93 %",
            "94 %",
            "95 %",
            "96 %",
            "97 %",
            "98 %",
            "99 %",
            "100 %"});
            this.PercentComboBox.Location = new System.Drawing.Point(524, 585);
            this.PercentComboBox.Name = "PercentComboBox";
            this.PercentComboBox.Size = new System.Drawing.Size(121, 28);
            this.PercentComboBox.TabIndex = 19;
            this.PercentComboBox.Text = "0 %";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = " ";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(96, 494);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 26);
            this.dateTimePicker1.TabIndex = 20;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // MailCheckBox
            // 
            this.MailCheckBox.AutoSize = true;
            this.MailCheckBox.Location = new System.Drawing.Point(96, 658);
            this.MailCheckBox.Name = "MailCheckBox";
            this.MailCheckBox.Size = new System.Drawing.Size(315, 24);
            this.MailCheckBox.TabIndex = 21;
            this.MailCheckBox.Text = "Check here if you want to send an email";
            this.MailCheckBox.UseVisualStyleBackColor = true;
            // 
            // SubmitButton
            // 
            this.SubmitButton.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.SubmitButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SubmitButton.Location = new System.Drawing.Point(681, 658);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(98, 33);
            this.SubmitButton.TabIndex = 22;
            this.SubmitButton.Text = "Submint";
            this.SubmitButton.UseVisualStyleBackColor = false;
            this.SubmitButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // CalcelButton
            // 
            this.CalcelButton.Location = new System.Drawing.Point(547, 658);
            this.CalcelButton.Name = "CalcelButton";
            this.CalcelButton.Size = new System.Drawing.Size(98, 33);
            this.CalcelButton.TabIndex = 23;
            this.CalcelButton.Text = "Cancel";
            this.CalcelButton.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(524, 494);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 26);
            this.numericUpDown1.TabIndex = 25;
            // 
            // FormTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 703);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.CalcelButton);
            this.Controls.Add(this.SubmitButton);
            this.Controls.Add(this.MailCheckBox);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.PercentComboBox);
            this.Controls.Add(this.StatusComboBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.DemoCheck);
            this.Controls.Add(this.PreprodCheck);
            this.Controls.Add(this.ProdCheck);
            this.Controls.Add(this.CriticityComboBox);
            this.Controls.Add(this.TypeComboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LocationComboBox);
            this.Controls.Add(this.TitleBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormTask";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TitleBox;
        private System.Windows.Forms.ComboBox LocationComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox TypeComboBox;
        private System.Windows.Forms.ComboBox CriticityComboBox;
        private System.Windows.Forms.CheckBox ProdCheck;
        private System.Windows.Forms.CheckBox PreprodCheck;
        private System.Windows.Forms.CheckBox DemoCheck;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox StatusComboBox;
        private System.Windows.Forms.ComboBox PercentComboBox;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.CheckBox MailCheckBox;
        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.Button CalcelButton;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}

