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
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "productDataSet.Sale". При необходимости она может быть перемещена или удалена.
            this.saleTableAdapter.Fill(this.productDataSet.Sale);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "productDataSet.Employee". При необходимости она может быть перемещена или удалена.
            this.employeeTableAdapter.Fill(this.productDataSet.Employee);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "productDataSet.TrMark". При необходимости она может быть перемещена или удалена.
            this.trMarkTableAdapter.Fill(this.productDataSet.TrMark);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "productDataSet.Firm". При необходимости она может быть перемещена или удалена.
            this.firmTableAdapter.Fill(this.productDataSet.Firm);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "typeDataSet.Type". При необходимости она может быть перемещена или удалена.
            this.typeTableAdapter.Fill(this.typeDataSet.Type);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "productDataSet.Product". При необходимости она может быть перемещена или удалена.
            this.productTableAdapter.Fill(this.productDataSet.Product);

        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.productBindingSource.EndEdit();
                this.productTableAdapter.Update(productDataSet);
                MessageBox.Show("Изменения сохранены");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnSaleSave_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(this.dataGridView2.Columns["employeeIDDataGridViewTextBoxColumn1"].ToString());

            //если мессаджБох раскомментировать, то изменения не сохраняет. Что то связано видимо с переходом фокуса
            //от ДатаГридВью
            //MessageBox.Show(this.dataGridView2[1, 2].Value.ToString());

            //if (this.dataGridView2.Columns["employeeIDDataGridViewTextBoxColumn1"].ToString() != "")
            //{
            //this.Text = this.dataGridView2.Columns["employeeIDDataGridViewTextBoxColumn1"].ToString();
            //string str = string.Empty;
            for (int i = 0; i < this.dataGridView2.RowCount; i++)
            {
                //str += this.dataGridView2[4, this.dataGridView2.CurrentCell.RowIndex].ToString();
                //str += this.dataGridView2[4, i].ToString();
                //str += "-";
                //this.Text = str;
                //int r = this.dataGridView2.RowCount - 2;
                //this.Text = this.dataGridView2[4, r].Value.ToString();
                /*
                if (this.dataGridView2[4,i].Value == null)
                    this.Text = "est pusoe znachenie ---1";
                    */
            }
                try
                {
                    this.Validate();
                    this.salesBindingSource.EndEdit();
                     //this.Text =   this.dataGridView2["employeeIDDataGridViewTextBoxColumn1", 3].Value.ToString();
                     this.saleTableAdapter.Update(productDataSet);
                    //this.productTableAdapter.Update(productDataSet);
                    MessageBox.Show("Изменения сохранены");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    //MessageBox.Show(ex.InnerException.ToString());
                    //MessageBox.Show(ex.GetType().ToString());
                }
            //}

            /***************************************************************
            int r = this.dataGridView2.RowCount - 2;
            int temp = 0;
            //for (int i = 0; i < this.dataGridView2.RowCount; i++)
            for (int i = 1; this.dataGridView2[4, i].Value != null; i++)
            {
                //MessageBox.Show(this.dataGridView2[4, i].ToString());
                
                if (this.dataGridView2[4, i].Value.ToString() == "")
                {
                    temp = i;
                    MessageBox.Show("Null " + temp.ToString());
                    //this.Text += "N"; 
                    MessageBox.Show(this.dataGridView2[4, i].ToString());
                    //this.dataGridView2[4, i].Value = 10;
                }
                else
                {
                    this.Text += "-"+i;
                }
                //if (this.dataGridView2[4, i].Value.ToString() == "")
                //    this.Text = "est pusoe znachenie -----2";
            }
            **************************************************************/

            //MessageBox.Show("Null " + temp.ToString());

            /************************
            int r = this.dataGridView2.RowCount - 2;
            this.Text = this.dataGridView2[4, r].Value.ToString();
            if (this.dataGridView2[4, r].Value.ToString() == "")
                MessageBox.Show("pustaya stroka");
            if (this.dataGridView2[4, r].Value == null)
                MessageBox.Show("Null");
                *************************************/

        }

        private void btnTablesWin_Click(object sender, EventArgs e)
        {
            TablesForm tForm = new TablesForm();
            tForm.ShowDialog();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            //B db = new DB();
            //db.OpenConnection();

            //this.saleTableAdapter.Update(productDataSet);
            
            this.saleTableAdapter.Fill(productDataSet.Sale);    //обновляет Грид с продажами
            //this.typeTableAdapter.Update(productDataSet.Type);    //необязятельно
            this.typeTableAdapter.Fill(productDataSet.Type);    //обновляет Грид с типами
            this.firmTableAdapter.Fill(productDataSet.Firm);    //обновляет Грид с фирмами
            this.trMarkTableAdapter.Fill(productDataSet.TrMark); //обновляет столбец Грид с фирмами
            this.employeeTableAdapter.Fill(productDataSet.Employee);

            //this.dataGridView1.Refresh();
            //this.salesBindingSource.ResumeBinding();         

            //dataGridView2.DataSource = salesBindingSource;
            //this.salesBindingSource.ResetBindings(true);
            //db.CloseConnection();

        }

        private void btnRepWin_Click(object sender, EventArgs e)
        {
            ReportsForm rForm = new ReportsForm();
            rForm.ShowDialog();
        }

        private void dataGridView2_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            //this.Text += "dataGridView2_DefaultValuesNeeded";
            e.Row.Cells[4].Value = 0;
        }

        private void dataGridView2_NewRowNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells[4].Value = 0;
            //this.Text += "GridView2_NewRowNeeded";
            //MessageBox.Show("GridView2_NewRowNeeded");
        }

        private void dataGridView2_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
           // MessageBox.Show("GridView2_RowsAdded");
        }

        //private void bindingNavigatorAddNewItem1_Click(object sender, DataGridViewRowEventArgs e)
        private void bindingNavigatorAddNewItem1_Click(object sender, EventArgs e)
        {
            //e.Row.Cells[4].Value = 0;


            //DataGridViewRow d = new DataGridViewRow();
            //DataGridViewRowEventArgs e1 = new DataGridViewRowEventArgs(d);
            //var e1 = (DataGridViewRowEventArgs)e;
            //this.dataGridView2_DefaultValuesNeeded(sender, e1);

            //MessageBox.Show("bindingNavigatorAddNewItem1_Click");

            //DefValEventArgs ee = new DefValEventArgs();
            
            //this.dataGridView2_DefaultValuesNeeded(sender, (EventArgs)ee);
            //ee.MyProperty.Cells[4].Value = 0;
            //ee.MyProperty2.Row.Cells[4].Value = 0;

        }

        private void salesBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {

            //this.Text += "AddingNew";
            //MessageBox.Show("AddingNew");
        }
    } //class Form1

    /*******************************НЕУДАЧНЫЕ ПОТУГИ ЗАПУСТИТЬ dataGridView2_DefaultValuesNeeded()
     * ***************************ИЗ bindingNavigatorAddNewItem1_Click()***************************
     * 
     *      public class DefValEventArgs : EventArgs
     *       {
     *          //DataGridViewRow dgr = new DataGridViewRow();
     *          public DataGridViewRow MyProperty { get; set; }
     *           public DataGridViewRowEventArgs MyProperty2 { get; set; }
     *       }
    ******************************************************/
}
