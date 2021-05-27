using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Komfort_1
{
    public partial class Rep4Form : Form
    {
        //ПОЛЯ
        //это в 3 отчёте надо, а здесь для пробы
        int idType;
        public Rep4Form()
        {
            InitializeComponent();
        }

        //св-ва
        public int rep4type { set
                {
                    idType = value;
                }
            }

        private void Rep4Form_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "productDataSet.Sale". При необходимости она может быть перемещена или удалена.
            //this.saleTableAdapter.Fill(this.productDataSet.Sale);

            DB db = new DB();
            db.OpenConnection();
            //надо не продукт выбирать а тип же
            string sql = "SELECT count, productID, saleDate FROM Sale WHERE productID = " + idType;
            SqlDataAdapter a = new SqlDataAdapter(sql, db.getConnection());
            DataSet dsSale = new DataSet("Sale");
            a.Fill(dsSale, "Sale");
            this.chart1.DataSource = dsSale;
            //chart1.Series["SeriesSale"].Points.AddXY()
            chart1.Series["SeriesSale"].XValueMember = "saleDate";
            chart1.Series["SeriesSale"].YValueMembers = "count";
            chart1.DataBind();

            db.CloseConnection();

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
