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
    public partial class TablesForm : Form
    {
        public TablesForm()
        {
            InitializeComponent();
        }

        private void btnAddSale_Click(object sender, EventArgs e)
        {
            AddSaleForm addSale = new AddSaleForm();
            addSale.ShowDialog();
        }

        private void TablesForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void btnRemoveSale_Click(object sender, EventArgs e)
        {
            DelSaleForm delSale = new DelSaleForm();
            delSale.ShowDialog();
        }

        private void btnAddType_Click(object sender, EventArgs e)
        {
            addTypeForm addT = new addTypeForm();
            addT.ShowDialog();
        }

        private void btnRemoveType_Click(object sender, EventArgs e)
        {
            DelTypeForm delT = new DelTypeForm();
            delT.ShowDialog();
        }

        private void btnAddFirm_Click(object sender, EventArgs e)
        {
            AddFirmForm addFirmForm = new AddFirmForm();
            addFirmForm.ShowDialog();
        }

        private void btnRemoveFirm_Click(object sender, EventArgs e)
        {
            DelFirmForm delF = new DelFirmForm();
            delF.ShowDialog();
        }

        private void btnAddMark_Click(object sender, EventArgs e)
        {
            AddTrMarkForm addMarkF = new AddTrMarkForm();
            addMarkF.ShowDialog();
        }

        private void btnRemoveMark_Click(object sender, EventArgs e)
        {
            DelMarkForm delM = new DelMarkForm();
            delM.ShowDialog();
        }

        private void btnAddEmpl_Click(object sender, EventArgs e)
        {
            AddEmployeeForm addEmplF = new AddEmployeeForm();
            addEmplF.ShowDialog();
        }

        private void btnDelEmpl_Click(object sender, EventArgs e)
        {
            DelEmplForm delE = new DelEmplForm();
            delE.ShowDialog();
        }
    }
}
