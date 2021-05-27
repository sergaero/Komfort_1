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
    public partial class DelTypeForm : Form
    {
        public DelTypeForm()
        {
            InitializeComponent();
        }

        private void btnDelType_Click(object sender, EventArgs e)
        {
            
            if (this.textBox1.Text != "")
            {
                Type type = new Type();
                type.deleteType(this.textBox1.Text);
            }
            this.Close();
        }

        private void DelTypeForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "productDataSet.Type". При необходимости она может быть перемещена или удалена.
            this.typeTableAdapter.Fill(this.productDataSet.Type);

        }

        private void DelTypeForm_Activated(object sender, EventArgs e)
        {
            this.textBox1.Focus();
            
        }
    }
}
