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
    public partial class AddSaleForm : Form
    {
        public ulong saleID;
        public ulong productID;
        public string saleDate = string.Empty;
        public int count = 0;
        public ulong employeeID = 0;
        public AddSaleForm()
        {
            InitializeComponent();

        }

        private void AddSaleForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "productDataSet.Product". При необходимости она может быть перемещена или удалена.
            this.productTableAdapter.Fill(this.productDataSet.Product);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "productDataSet.Employee". При необходимости она может быть перемещена или удалена.
            this.employeeTableAdapter.Fill(this.productDataSet.Employee);

        }

        private void btnAddSale_Click(object sender, EventArgs e)
        {
            
            
            //проверка на непустоту
            //if (this.comboBoxProduct.Text != "" && this.textBoxSaleDate.Text != "" && this.textBoxSaleCount.Text != "" && this.comboBoxEmployee.Text != "")
                if (this.comboBoxProduct.Text != "" && this.textBoxSaleCount.Text != "" && this.comboBoxEmployee.Text != "")
                {
                //проверка на правильное преобразование
                if (ulong.TryParse(this.comboBoxProduct.Text, out productID) && (this.comboBoxEmployee.SelectedValue!=null)&& ulong.TryParse(this.comboBoxEmployee.SelectedValue.ToString(), out employeeID))
                //if (ulong.TryParse(this.comboBoxProduct.Text, out productID)  && ulong.TryParse(this.comboBoxEmployee.SelectedValue.ToString(), out employeeID))
                //if (ulong.TryParse(this.comboBoxProduct.Text, out productID) && ulong.TryParse(this.comboBoxEmployee.Text, out employeeID))
                {
                    //productID = ulong.Parse(this.comboBoxProduct.Text);
                    //saleDate = this.textBoxSaleDate.Text;
                    saleDate = this.dateTimePickerSaleDate.Text;
                    count = int.Parse(this.textBoxSaleCount.Text);
                    //MessageBox.Show(this.comboBoxEmployee.SelectedValue.ToString());
                    //string sss = "ПЕРВЫЙ"+productID.ToString() + "  " + saleDate + "  " + count.ToString() + "  " + employeeID.ToString();
                    //MessageBox.Show(sss);

                    //непосредственно добавляем продажу в БД
                    Sale sale = new Sale();
                    sale.addSale(productID,saleDate, count, employeeID);

                }
                //string s = "ВТОРОЙ"+productID.ToString() + "  "+ saleDate + "  " + count.ToString() + "  " + employeeID.ToString();
                //MessageBox.Show(s);
            }
            else
                MessageBox.Show("Введите правильные данные о продаже");

        }
    }
}
