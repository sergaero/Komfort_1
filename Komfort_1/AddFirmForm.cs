using System;
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
    public partial class AddFirmForm : Form
    {
        public AddFirmForm()
        {
            InitializeComponent();
        }

        private void BtnAddFirm_Click(object sender, EventArgs e)
        {
            if ((this.textBoxFirmName.Text != "") && (this.textBoxFirmCountry.Text !="") && (this.textBoxFirmName.Text.Length <50) && (this.textBoxFirmCountry.Text.Length <50))
            {
                Firm newF = new Firm();
                newF.addFirm(this.textBoxFirmName.Text, this.textBoxFirmCountry.Text);
            }
            else
            {
                MessageBox.Show("Введите правильные данные о фирме (непустые и не длиннее 50 символов).");
            }
            this.textBoxFirmName.Text = "";
            this.textBoxFirmCountry.Text = "";
        }

        private void textBoxFirmName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBoxFirmCountry_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
