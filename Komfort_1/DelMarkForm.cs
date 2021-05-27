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
    public partial class DelMarkForm : Form
    {
        public DelMarkForm()
        {
            InitializeComponent();
        }

        private void btnDelMark_Click(object sender, EventArgs e)
        {
            if (this.textBoxDelMark.Text != "")
            {
                TrMark trM = new TrMark();
                trM.deleteTrMark(this.textBoxDelMark.Text);
            }
            this.Close();
        }

        private void DelMarkForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "productDataSet.TrMark". При необходимости она может быть перемещена или удалена.
            this.trMarkTableAdapter.Fill(this.productDataSet.TrMark);

        }
    }
}
