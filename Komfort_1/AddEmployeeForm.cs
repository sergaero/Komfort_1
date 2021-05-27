﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Komfort_1
{
    public partial class AddEmployeeForm : Form
    {
        public AddEmployeeForm()
        {
            InitializeComponent();
        }

        private void BtnAddEmpl_Click(object sender, EventArgs e)
        {
            if ((this.textBoxAddFIO.Text != "") && (this.textBoxAddPos.Text != "") && (this.textBoxAddFIO.Text.Length < 50) && (this.textBoxAddPos.Text.Length < 50))
            {
                Employee newEmp = new Employee();
                newEmp.addEmployee(this.textBoxAddFIO.Text, this.textBoxAddPos.Text);
            }
            else
            {
                MessageBox.Show("Введите правильные данные о сотруднике (непустые и не длиннее 50 символов).");
            }
            this.textBoxAddFIO.Text = "";
            this.textBoxAddPos.Text = "";
        }
    }
}
