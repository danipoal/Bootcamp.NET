﻿using System;
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
    public partial class FormTask : Form
    {
        public FormTask()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool isAllSelected = true;

            if (string.IsNullOrWhiteSpace(TitleBox.Text) || string.IsNullOrWhiteSpace(LocationComboBox.Text)
                || string.IsNullOrWhiteSpace(TypeComboBox.Text) || string.IsNullOrWhiteSpace(CriticityComboBox.Text)
                || string.IsNullOrWhiteSpace(richTextBox1.Text) || string.IsNullOrWhiteSpace(dateTimePicker1.Text)
                || string.IsNullOrWhiteSpace(numericUpDown1.Text) || string.IsNullOrWhiteSpace(StatusComboBox.Text)
                || string.IsNullOrWhiteSpace(PercentComboBox.Text)
                || (!ProdCheck.Checked && !PreprodCheck.Checked && !DemoCheck.Checked))
            {
                isAllSelected = false;
            }

            if (isAllSelected)
            {
                label1_Click(sender, e);
                MessageBox.Show("Información enviada");
            }
            else
            {
                MessageBox.Show("Faltan campos por rellenar");
            }
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) {
            dateTimePicker1.Format = DateTimePickerFormat.Short;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
