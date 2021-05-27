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
    public partial class DelFirmForm : Form
    {
        public DelFirmForm()
        {
            InitializeComponent();
        }

        private void btnDelFirm_Click(object sender, EventArgs e)
        {
            if (this.textBoxDelFirm.Text != "")
            {
                Firm firm = new Firm();
                firm.deleteFirm(this.textBoxDelFirm.Text);
            }
            this.Close();
        }

        private void DelFirmForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "productDataSet.Firm". При необходимости она может быть перемещена или удалена.
            this.firmTableAdapter.Fill(this.productDataSet.Firm);

        }

        private void textBoxDelFirm_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewDelFirm_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
