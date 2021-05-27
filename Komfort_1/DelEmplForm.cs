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
    public partial class DelEmplForm : Form
    {
        public DelEmplForm()
        {
            InitializeComponent();
        }

        private void DelEmplForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "productDataSet.Employee". При необходимости она может быть перемещена или удалена.
            this.employeeTableAdapter.Fill(this.productDataSet.Employee);

        }

        private void btnDelEmpl_Click(object sender, EventArgs e)
        {
            ulong idE;
            if (this.textBoxDelEmpl.Text != "")
            {
                if (ulong.TryParse(this.textBoxDelEmpl.Text, out idE))
                {
                    Employee empl = new Employee();
                    empl.deleteEmployee(idE);
                }
            }
            this.Close();
        }
    }
}
