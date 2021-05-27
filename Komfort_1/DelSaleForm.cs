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
    public partial class DelSaleForm : Form
    {
        public DelSaleForm()
        {
            InitializeComponent();
        }

        private void btnDelSale_Click(object sender, EventArgs e)
        {
            ulong idSale;
            if (this.textBox1.Text != "")
            {
                if (ulong.TryParse(this.textBox1.Text, out idSale))
                {
                    Sale sale = new Sale();
                    sale.deleteSale(idSale);
                }
            }
            this.Close();
        }

        private void DelSaleForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "productDataSet.Sale". При необходимости она может быть перемещена или удалена.
            this.saleTableAdapter.Fill(this.productDataSet.Sale);

        }
    }
}
