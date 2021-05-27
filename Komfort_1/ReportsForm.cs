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
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;

namespace Komfort_1
{

    public partial class ReportsForm : Form
    {

        public ReportsForm()
        {
            InitializeComponent();
        }

        private void ReportsForm_Activated(object sender, EventArgs e)
        {
            //this.typeTableAdapter.Fill(productDataSet.Type);
            //this.firmTableAdapter.Fill(productDataSet.Firm);
        }

        private void productDataSetBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void ReportsForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "productDataSet.Firm". При необходимости она может быть перемещена или удалена.
            this.firmTableAdapter.Fill(this.productDataSet.Firm);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "productDataSet.Type". При необходимости она может быть перемещена или удалена.
            this.typeTableAdapter.Fill(this.productDataSet.Type);
            
            //Rep1
            this.rbRep1All.Checked = true;
            this.cbRep1Type.Enabled = false;
            this.cbRep1Firm.Enabled = false;
            this.tbRep1CostOt.Enabled = false;
            this.tbRep1CostDo.Enabled = false;
            //Rep3
            this.rbRep3All.Checked = true;
            this.cbRep3Type.Enabled = false;
            this.cbRep3Firm.Enabled = false;

            //Rep4
            this.rbRep4Type.Checked = true;
        }

        private void rbRep1All_CheckedChanged(object sender, EventArgs e)
        {
            this.cbRep1Type.Enabled = false;
            this.cbRep1Firm.Enabled = false;
            this.tbRep1CostOt.Enabled = false;
            this.tbRep1CostDo.Enabled = false;
        }

        private void rbRep1Type_CheckedChanged(object sender, EventArgs e)
        {
            this.cbRep1Type.Enabled = true;
            this.cbRep1Firm.Enabled = false;
            this.tbRep1CostOt.Enabled = false;
            this.tbRep1CostDo.Enabled = false;
        }

        private void rbRep1Firm_CheckedChanged(object sender, EventArgs e)
        {
            this.cbRep1Type.Enabled = false;
            this.cbRep1Firm.Enabled = true;
            this.tbRep1CostOt.Enabled = false;
            this.tbRep1CostDo.Enabled = false;
        }

        private void rbRep1Cost_CheckedChanged(object sender, EventArgs e)
        {
            this.cbRep1Type.Enabled = false;
            this.cbRep1Firm.Enabled = false;
            this.tbRep1CostOt.Enabled = true;
            this.tbRep1CostDo.Enabled = true;
        }

        private void btnRep1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(this.cbRep1Type.SelectedValue.ToString());
            //MessageBox.Show(this.cbRep1Firm.SelectedValue.ToString());
            if (this.rbRep1All.Checked) rep1All();
            if (this.rbRep1Type.Checked) rep1Type((int)this.cbRep1Type.SelectedValue);
            if (this.rbRep1Firm.Checked) rep1Firm((int)this.cbRep1Firm.SelectedValue);

            if (this.rbRep1Cost.Checked)
            {
                if (double.TryParse(this.tbRep1CostOt.Text, out double cost_ot) && double.TryParse(this.tbRep1CostDo.Text, out double cost_do))
                    rep1Cost(cost_ot, cost_do);
            }


        }

        public void rep1All()
        {
            //соединяемса с БД
            DB db = new DB();
            db.OpenConnection();
            string s = "SELECT * FROM Product";
            SqlDataAdapter adaptAll = new SqlDataAdapter(s, db.getConnection());
            DataSet dsAll = new DataSet("All");
            adaptAll.Fill(dsAll, "All");

            //для того чтобы осмысленные имена отображались, а не коды
            SqlDataAdapter adaptTypeNames = new SqlDataAdapter("SELECT * FROM Type", db.getConnection());
            SqlDataAdapter adaptFirmNames = new SqlDataAdapter("SELECT * FROM Firm", db.getConnection());
            SqlDataAdapter adaptTrMarkNames = new SqlDataAdapter("SELECT * FROM TrMark", db.getConnection());
            DataSet dsTypeNames = new DataSet("Type");
            DataSet dsFirmNames = new DataSet("Firm");
            DataSet dsTrMarkNames = new DataSet("TrMark");
            adaptTypeNames.Fill(dsTypeNames, "Type");
            adaptFirmNames.Fill(dsFirmNames, "Firm");
            adaptTrMarkNames.Fill(dsTrMarkNames, "TrMark");

            //создаём отдельную таблу для значений с осмысленными именами
            DataSet dsRep1All = new DataSet("Rep1AllNames");
            //схема таблы
            DataColumn colIdProd = new DataColumn("productID", typeof(int));
            colIdProd.Unique = false;
            colIdProd.AllowDBNull = true;
            DataColumn colTypeProd = new DataColumn("productType", typeof(string));
            colTypeProd.Unique = false;
            colTypeProd.AllowDBNull = true;
            DataColumn colFirmProd = new DataColumn("productFirm", typeof(string));
            colFirmProd.Unique = false;
            colFirmProd.AllowDBNull = true;
            DataColumn colTrMarkProd = new DataColumn("productTrMark", typeof(string));
            colTrMarkProd.Unique = false;
            colTrMarkProd.AllowDBNull = true;
            DataColumn colDateProd = new DataColumn("productDate", typeof(string));
            colDateProd.Unique = false;
            colDateProd.AllowDBNull = true;
            DataColumn colCostProd = new DataColumn("productCost", typeof(double));
            colCostProd.Unique = false;
            colCostProd.AllowDBNull = true;
            DataColumn colNumberProd = new DataColumn("productNumber", typeof(int));
            colNumberProd.Unique = false;
            colNumberProd.AllowDBNull = true;

            System.Data.DataTable dt = new System.Data.DataTable("tableRep1AllNames");
            dt.Columns.AddRange(new DataColumn[] { colIdProd, colTypeProd, colFirmProd, colTrMarkProd, colDateProd, colCostProd, colNumberProd });
            dsRep1All.Tables.Add(dt);

            //переменные в которых вместо ИД занесутся значения Name (в некоторые)
            int idForTableNames, numberForTableNames;
            string typeForTableNames, firmForTableNames, trmarkForTableNames, dateForTableNames;
            double costForTableNames;

            for (int i = 0; i < dsAll.Tables["All"].Rows.Count; i++)    //количество строк в запросе который в Зксель пойдёт
            {
                idForTableNames = (int)dsAll.Tables["All"].Rows[i]["productID"];
                typeForTableNames = SearchNameType((int)dsAll.Tables["All"].Rows[i]["typeID"]);       //почему-то берёт название столбца из физичекой таблицы
                firmForTableNames = SearchNameFirm((int)dsAll.Tables["All"].Rows[i]["firmID"]);       //--//--
                trmarkForTableNames = SearchNameTrMark((int)dsAll.Tables["All"].Rows[i]["trmarkID"]); //--//--
                dateForTableNames = (string)dsAll.Tables["All"].Rows[i]["productDateMade"]; //почему-то берёт название столбца из физичекой таблицы
                costForTableNames = (double)dsAll.Tables["All"].Rows[i]["productCost"];
                numberForTableNames = (int)dsAll.Tables["All"].Rows[i]["productNumber"];

                //таблицу заполняем строками не с ИД а с Именами
                dsRep1All.Tables["tableRep1AllNames"].Rows.Add(idForTableNames, typeForTableNames, firmForTableNames, trmarkForTableNames, dateForTableNames, costForTableNames, numberForTableNames);

            }


            Excel.Application appExcel = new Excel.Application();
            appExcel.Visible = true;
            appExcel.Workbooks.Add();
            Excel._Worksheet workSheet = appExcel.ActiveSheet;
            //заголовки
            workSheet.Cells[1, 1] = "ProductID";
            workSheet.Cells[1, 2] = "Тип";
            workSheet.Cells[1, 3] = "Фирма";
            workSheet.Cells[1, 4] = "Марка";
            workSheet.Cells[1, 5] = "Дата выпуска";
            workSheet.Cells[1, 6] = "Цена";
            workSheet.Cells[1, 7] = "Количество";

            //данные
            for (int curRow = 1; curRow <= dsRep1All.Tables["tableRep1AllNames"].Rows.Count; curRow++)
            {
                for (int curCol = 1; curCol <= dsRep1All.Tables["tableRep1AllNames"].Columns.Count; curCol++)
                {
                    workSheet.Cells[curRow + 1, curCol] = dsRep1All.Tables["tableRep1AllNames"].Rows[curRow - 1][curCol - 1].ToString();
                }
            }

        } //rep1All()


        public void rep1Type(int typeId)
        {
            //MessageBox.Show(typeId.ToString());
            //соединяемса с БД
            DB db = new DB();
            db.OpenConnection();
            string s = "SELECT * FROM Product WHERE typeID = " + typeId.ToString();
            SqlDataAdapter adaptType = new SqlDataAdapter(s, db.getConnection());
            DataSet dsType = new DataSet("Typess");
            adaptType.Fill(dsType, "Typess");

            //для того чтобы осмысленные имена отображались, а не коды
            SqlDataAdapter adaptTypeNames = new SqlDataAdapter("SELECT * FROM Type", db.getConnection());
            SqlDataAdapter adaptFirmNames = new SqlDataAdapter("SELECT * FROM Firm", db.getConnection());
            SqlDataAdapter adaptTrMarkNames = new SqlDataAdapter("SELECT * FROM TrMark", db.getConnection());
            DataSet dsTypeNames = new DataSet("Type");
            DataSet dsFirmNames = new DataSet("Firm");
            DataSet dsTrMarkNames = new DataSet("TrMark");
            adaptTypeNames.Fill(dsTypeNames, "Type");
            adaptFirmNames.Fill(dsFirmNames, "Firm");
            adaptTrMarkNames.Fill(dsTrMarkNames, "TrMark");

            //создаём отдельную таблу для значений с осмысленными именами
            DataSet dsRep1Type = new DataSet("Rep1TypeNames");
            //схема таблы
            DataColumn colIdProd = new DataColumn("productID", typeof(int));
            colIdProd.Unique = false;
            colIdProd.AllowDBNull = true;
            DataColumn colTypeProd = new DataColumn("productType", typeof(string));
            colTypeProd.Unique = false;
            colTypeProd.AllowDBNull = true;
            DataColumn colFirmProd = new DataColumn("productFirm", typeof(string));
            colFirmProd.Unique = false;
            colFirmProd.AllowDBNull = true;
            DataColumn colTrMarkProd = new DataColumn("productTrMark", typeof(string));
            colTrMarkProd.Unique = false;
            colTrMarkProd.AllowDBNull = true;
            DataColumn colDateProd = new DataColumn("productDate", typeof(string));
            colDateProd.Unique = false;
            colDateProd.AllowDBNull = true;
            DataColumn colCostProd = new DataColumn("productCost", typeof(double));
            colCostProd.Unique = false;
            colCostProd.AllowDBNull = true;
            DataColumn colNumberProd = new DataColumn("productNumber", typeof(int));
            colNumberProd.Unique = false;
            colNumberProd.AllowDBNull = true;

            System.Data.DataTable dt = new System.Data.DataTable("tableRep1TypeNames");
            dt.Columns.AddRange(new DataColumn[] { colIdProd, colTypeProd, colFirmProd, colTrMarkProd, colDateProd, colCostProd, colNumberProd });
            dsRep1Type.Tables.Add(dt);

            //переменные в которых вместо ИД занесутся значения Name (в некоторые)
            int idForTableNames, numberForTableNames;
            string typeForTableNames, firmForTableNames, trmarkForTableNames, dateForTableNames;
            double costForTableNames;

            //MessageBox.Show(dsType.Tables["Typess"].Columns[5].Caption.ToString());
            //MessageBox.Show(dsType.Tables["Typess"].Columns[4].Caption.ToString());
            for (int i = 0; i < dsType.Tables["Typess"].Rows.Count; i++)    //количество строк в запросе который в Зксель пойдёт
            {
                idForTableNames = (int)dsType.Tables["Typess"].Rows[i]["productID"];
                typeForTableNames = SearchNameType((int)dsType.Tables["Typess"].Rows[i]["typeID"]);       //почему-то берёт название столбца из физичекой таблицы
                firmForTableNames = SearchNameFirm((int)dsType.Tables["Typess"].Rows[i]["firmID"]);       //--//--
                trmarkForTableNames = SearchNameTrMark((int)dsType.Tables["Typess"].Rows[i]["trmarkID"]); //--//--
                //typeForTableNames = "qwertType";
                //firmForTableNames = "qeFirm";
                //trmarkForTableNames = "qwrMark";
                dateForTableNames = (string)dsType.Tables["Typess"].Rows[i]["productDateMade"]; //почему-то берёт название столбца из физичекой таблицы
                costForTableNames = (double)dsType.Tables["Typess"].Rows[i]["productCost"];
                numberForTableNames = (int)dsType.Tables["Typess"].Rows[i]["productNumber"];

                //таблицу заполняем строками не с ИД а с Именами
                dsRep1Type.Tables["tableRep1TypeNames"].Rows.Add(idForTableNames, typeForTableNames, firmForTableNames, trmarkForTableNames, dateForTableNames, costForTableNames, numberForTableNames);

            }


            Excel.Application appExcel = new Excel.Application();
            appExcel.Visible = true;
            appExcel.Workbooks.Add();
            Excel._Worksheet workSheet = appExcel.ActiveSheet;
            //заголовки
            workSheet.Cells[1, 1] = "ProductID";
            workSheet.Cells[1, 2] = "Тип";
            workSheet.Cells[1, 3] = "Фирма";
            workSheet.Cells[1, 4] = "Марка";
            workSheet.Cells[1, 5] = "Дата выпуска";
            workSheet.Cells[1, 6] = "Цена";
            workSheet.Cells[1, 7] = "Количество";

            //данные
            for (int curRow = 1; curRow <= dsRep1Type.Tables["tableRep1TypeNames"].Rows.Count; curRow++)
            {
                for (int curCol = 1; curCol <= dsRep1Type.Tables["tableRep1TypeNames"].Columns.Count; curCol++)
                {
                    workSheet.Cells[curRow + 1, curCol] = dsRep1Type.Tables["tableRep1TypeNames"].Rows[curRow - 1][curCol - 1].ToString();
                }
            }

            /*
            for (int curRow = 1; curRow <= dsType.Tables["Typess"].Rows.Count; curRow++)
            {
                for (int curCol = 1; curCol <= dsType.Tables["Typess"].Columns.Count; curCol++)
                {
                    workSheet.Cells[curRow + 1, curCol] = dsType.Tables["Typess"].Rows[curRow - 1][curCol - 1].ToString();
                }
            } */

        } //rep1Type()


        public void rep1Firm(int firmId)
        {
            //соединяемса с БД
            DB db = new DB();
            db.OpenConnection();
            string s = "SELECT * FROM Product WHERE firmID = " + firmId.ToString();
            SqlDataAdapter adaptFirm = new SqlDataAdapter(s, db.getConnection());
            DataSet dsFirm = new DataSet("Firmess");
            adaptFirm.Fill(dsFirm, "Firmess");

            //для того чтобы осмысленные имена отображались, а не коды
            SqlDataAdapter adaptTypeNames = new SqlDataAdapter("SELECT * FROM Type", db.getConnection());
            SqlDataAdapter adaptFirmNames = new SqlDataAdapter("SELECT * FROM Firm", db.getConnection());
            SqlDataAdapter adaptTrMarkNames = new SqlDataAdapter("SELECT * FROM TrMark", db.getConnection());
            DataSet dsTypeNames = new DataSet("Type");
            DataSet dsFirmNames = new DataSet("Firm");
            DataSet dsTrMarkNames = new DataSet("TrMark");
            adaptTypeNames.Fill(dsTypeNames, "Type");
            adaptFirmNames.Fill(dsFirmNames, "Firm");
            adaptTrMarkNames.Fill(dsTrMarkNames, "TrMark");
            //создаём отдельную таблу для значений с осмысленными именами
            DataSet dsRep1Firm = new DataSet("Rep1FirmNames");

            //схема таблы
            DataColumn colIdProd = new DataColumn("productID", typeof(int));
            colIdProd.Unique = false;
            colIdProd.AllowDBNull = true;
            DataColumn colTypeProd = new DataColumn("productType", typeof(string));
            colTypeProd.Unique = false;
            colTypeProd.AllowDBNull = true;
            DataColumn colFirmProd = new DataColumn("productFirm", typeof(string));
            colFirmProd.Unique = false;
            colFirmProd.AllowDBNull = true;
            DataColumn colTrMarkProd = new DataColumn("productTrMark", typeof(string));
            colTrMarkProd.Unique = false;
            colTrMarkProd.AllowDBNull = true;
            DataColumn colDateProd = new DataColumn("productDate", typeof(string));
            colDateProd.Unique = false;
            colDateProd.AllowDBNull = true;
            DataColumn colCostProd = new DataColumn("productCost", typeof(double));
            colCostProd.Unique = false;
            colCostProd.AllowDBNull = true;
            DataColumn colNumberProd = new DataColumn("productNumber", typeof(int));
            colNumberProd.Unique = false;
            colNumberProd.AllowDBNull = true;

            System.Data.DataTable dt = new System.Data.DataTable("tableRep1FirmNames");
            dt.Columns.AddRange(new DataColumn[] { colIdProd, colTypeProd, colFirmProd, colTrMarkProd, colDateProd, colCostProd, colNumberProd });
            dsRep1Firm.Tables.Add(dt);

            //переменные в которых вместо ИД занесутся значения Name (в некоторые)
            int idForTableNames, numberForTableNames;
            string typeForTableNames, firmForTableNames, trmarkForTableNames, dateForTableNames;
            double costForTableNames;

            for (int i = 0; i < dsFirm.Tables["Firmess"].Rows.Count; i++)    //количество строк в запросе который в Зксель пойдёт
            {
                idForTableNames = (int)dsFirm.Tables["Firmess"].Rows[i]["productID"];
                typeForTableNames = SearchNameType((int)dsFirm.Tables["Firmess"].Rows[i]["typeID"]);       //почему-то берёт название столбца из физичекой таблицы
                firmForTableNames = SearchNameFirm((int)dsFirm.Tables["Firmess"].Rows[i]["firmID"]);       //--//--
                trmarkForTableNames = SearchNameTrMark((int)dsFirm.Tables["Firmess"].Rows[i]["trmarkID"]); //--//--
                //typeForTableNames = "qwertType";
                //firmForTableNames = "qeFirm";
                //trmarkForTableNames = "qwrMark";
                dateForTableNames = (string)dsFirm.Tables["Firmess"].Rows[i]["productDateMade"]; //почему-то берёт название столбца из физичекой таблицы
                costForTableNames = (double)dsFirm.Tables["Firmess"].Rows[i]["productCost"];
                numberForTableNames = (int)dsFirm.Tables["Firmess"].Rows[i]["productNumber"];

                //таблицу заполняем строками не с ИД а с Именами
                dsRep1Firm.Tables["tableRep1FirmNames"].Rows.Add(idForTableNames, typeForTableNames, firmForTableNames, trmarkForTableNames, dateForTableNames, costForTableNames, numberForTableNames);
            }
            Excel.Application appExcel = new Excel.Application();
            appExcel.Visible = true;
            appExcel.Workbooks.Add();
            Excel._Worksheet workSheet = appExcel.ActiveSheet;
            //заголовки
            workSheet.Cells[1, 1] = "ProductID";
            workSheet.Cells[1, 2] = "Тип";
            workSheet.Cells[1, 3] = "Фирма";
            workSheet.Cells[1, 4] = "Марка";
            workSheet.Cells[1, 5] = "Дата выпуска";
            workSheet.Cells[1, 6] = "Цена";
            workSheet.Cells[1, 7] = "Количество";

            //данные
            for (int curRow = 1; curRow <= dsRep1Firm.Tables["tableRep1FirmNames"].Rows.Count; curRow++)
            {
                for (int curCol = 1; curCol <= dsRep1Firm.Tables["tableRep1FirmNames"].Columns.Count; curCol++)
                {
                    workSheet.Cells[curRow + 1, curCol] = dsRep1Firm.Tables["tableRep1FirmNames"].Rows[curRow - 1][curCol - 1].ToString();
                }
            }



        }//rep1Firm()

        public void rep1Cost(double cost_1, double cost_2)
        {

            //соединяемса с БД
            DB db = new DB();
            db.OpenConnection();
            string s = "SELECT * FROM Product WHERE (productCost <= " + cost_2.ToString() + ") AND (productCost >= " + cost_1.ToString() + ")";
            SqlDataAdapter adaptCost = new SqlDataAdapter(s, db.getConnection());
            DataSet dsCost = new DataSet("Cost");
            adaptCost.Fill(dsCost, "Cost");

            //для того чтобы осмысленные имена отображались, а не коды
            SqlDataAdapter adaptTypeNames = new SqlDataAdapter("SELECT * FROM Type", db.getConnection());
            SqlDataAdapter adaptFirmNames = new SqlDataAdapter("SELECT * FROM Firm", db.getConnection());
            SqlDataAdapter adaptTrMarkNames = new SqlDataAdapter("SELECT * FROM TrMark", db.getConnection());
            DataSet dsTypeNames = new DataSet("Type");
            DataSet dsFirmNames = new DataSet("Firm");
            DataSet dsTrMarkNames = new DataSet("TrMark");
            adaptTypeNames.Fill(dsTypeNames, "Type");
            adaptFirmNames.Fill(dsFirmNames, "Firm");
            adaptTrMarkNames.Fill(dsTrMarkNames, "TrMark");
            //создаём отдельную таблу для значений с осмысленными именами
            DataSet dsRep1Cost = new DataSet("Rep1CostNames");

            //схема таблы
            DataColumn colIdProd = new DataColumn("productID", typeof(int));
            colIdProd.Unique = false;
            colIdProd.AllowDBNull = true;
            DataColumn colTypeProd = new DataColumn("productType", typeof(string));
            colTypeProd.Unique = false;
            colTypeProd.AllowDBNull = true;
            DataColumn colFirmProd = new DataColumn("productFirm", typeof(string));
            colFirmProd.Unique = false;
            colFirmProd.AllowDBNull = true;
            DataColumn colTrMarkProd = new DataColumn("productTrMark", typeof(string));
            colTrMarkProd.Unique = false;
            colTrMarkProd.AllowDBNull = true;
            DataColumn colDateProd = new DataColumn("productDate", typeof(string));
            colDateProd.Unique = false;
            colDateProd.AllowDBNull = true;
            DataColumn colCostProd = new DataColumn("productCost", typeof(double));
            colCostProd.Unique = false;
            colCostProd.AllowDBNull = true;
            DataColumn colNumberProd = new DataColumn("productNumber", typeof(int));
            colNumberProd.Unique = false;
            colNumberProd.AllowDBNull = true;

            System.Data.DataTable dt = new System.Data.DataTable("tableRep1CostNames");
            dt.Columns.AddRange(new DataColumn[] { colIdProd, colTypeProd, colFirmProd, colTrMarkProd, colDateProd, colCostProd, colNumberProd });
            dsRep1Cost.Tables.Add(dt);

            //переменные в которых вместо ИД занесутся значения Name (в некоторые)
            int idForTableNames, numberForTableNames;
            string typeForTableNames, firmForTableNames, trmarkForTableNames, dateForTableNames;
            double costForTableNames;

            for (int i = 0; i < dsCost.Tables["Cost"].Rows.Count; i++)    //количество строк в запросе который в Зксель пойдёт
            {
                idForTableNames = (int)dsCost.Tables["Cost"].Rows[i]["productID"];
                typeForTableNames = SearchNameType((int)dsCost.Tables["Cost"].Rows[i]["typeID"]);       //почему-то берёт название столбца из физичекой таблицы
                firmForTableNames = SearchNameFirm((int)dsCost.Tables["Cost"].Rows[i]["firmID"]);       //--//--
                trmarkForTableNames = SearchNameTrMark((int)dsCost.Tables["Cost"].Rows[i]["trmarkID"]); //--//--
                dateForTableNames = (string)dsCost.Tables["Cost"].Rows[i]["productDateMade"]; //почему-то берёт название столбца из физичекой таблицы
                costForTableNames = (double)dsCost.Tables["Cost"].Rows[i]["productCost"];
                numberForTableNames = (int)dsCost.Tables["Cost"].Rows[i]["productNumber"];

                //таблицу заполняем строками не с ИД а с Именами
                dsRep1Cost.Tables["tableRep1CostNames"].Rows.Add(idForTableNames, typeForTableNames, firmForTableNames, trmarkForTableNames, dateForTableNames, costForTableNames, numberForTableNames);
            }

            Excel.Application appExcel = new Excel.Application();
            appExcel.Visible = true;
            appExcel.Workbooks.Add();
            Excel._Worksheet workSheet = appExcel.ActiveSheet;
            //заголовки
            workSheet.Cells[1, 1] = "ProductID";
            workSheet.Cells[1, 2] = "Тип";
            workSheet.Cells[1, 3] = "Фирма";
            workSheet.Cells[1, 4] = "Марка";
            workSheet.Cells[1, 5] = "Дата выпуска";
            workSheet.Cells[1, 6] = "Цена";
            workSheet.Cells[1, 7] = "Количество";

            //данные
            for (int curRow = 1; curRow <= dsRep1Cost.Tables["tableRep1CostNames"].Rows.Count; curRow++)
            {
                for (int curCol = 1; curCol <= dsRep1Cost.Tables["tableRep1CostNames"].Columns.Count; curCol++)
                {
                    workSheet.Cells[curRow + 1, curCol] = dsRep1Cost.Tables["tableRep1CostNames"].Rows[curRow - 1][curCol - 1].ToString();
                }
            }





        } //rep1Cost()


        public void rep2Date(string date)
        {
            //соединяемса с БД
            DB db = new DB();
            db.OpenConnection();
            string s = "SELECT * FROM Sale WHERE saleDate = '" + date.ToString() +"'";
            SqlDataAdapter adaptDate = new SqlDataAdapter(s, db.getConnection());
            DataSet dsDate = new DataSet("Date");
            //MessageBox.Show(s);
            adaptDate.Fill(dsDate, "Date");

            //для того чтобы осмысленные имена отображались, а не коды
            SqlDataAdapter adaptTypeNames = new SqlDataAdapter("SELECT * FROM Type", db.getConnection());
            SqlDataAdapter adaptFirmNames = new SqlDataAdapter("SELECT * FROM Firm", db.getConnection());
            SqlDataAdapter adaptTrMarkNames = new SqlDataAdapter("SELECT * FROM TrMark", db.getConnection());
            SqlDataAdapter adaptEmplNames = new SqlDataAdapter("SELECT * FROM Employee", db.getConnection());
            DataSet dsTypeNames = new DataSet("Type");
            DataSet dsFirmNames = new DataSet("Firm");
            DataSet dsTrMarkNames = new DataSet("TrMark");
            DataSet dsEmplNames = new DataSet("FIO");
            adaptTypeNames.Fill(dsTypeNames, "Type");
            adaptFirmNames.Fill(dsFirmNames, "Firm");
            adaptTrMarkNames.Fill(dsTrMarkNames, "TrMark");
            adaptEmplNames.Fill(dsEmplNames, "FIO");
            //создаём отдельную таблу для значений с осмысленными именами
            DataSet dsRep2 = new DataSet("Rep2Names");

            //схема таблы
            DataColumn colIdSale = new DataColumn("saleID", typeof(int));
            colIdSale.Unique = false;
            colIdSale.AllowDBNull = true;
            DataColumn colIdProd = new DataColumn("prodID", typeof(int));
            colIdProd.Unique = false;
            colIdProd.AllowDBNull = true;
            DataColumn colSaleDate = new DataColumn("saleDate", typeof(string));
            colSaleDate.Unique = false;
            colSaleDate.AllowDBNull = true;
            DataColumn colCount = new DataColumn("saleCount", typeof(int));
            colCount.Unique = false;
            colCount.AllowDBNull = true;
            DataColumn colFIO = new DataColumn("FIO", typeof(string));
            colFIO.Unique = false;
            colFIO.AllowDBNull = true;

            System.Data.DataTable dt = new System.Data.DataTable("tableRep2Names");
            dt.Columns.AddRange(new DataColumn[] { colIdSale, colIdProd, colSaleDate, colCount, colFIO });
            dsRep2.Tables.Add(dt);

            //переменные в которых вместо ИД занесутся значения Name
            int idSale, idProd, count;
            string dateSale, fio;

            for (int i = 0; i < dsDate.Tables["Date"].Rows.Count; i++)    //количество строк в запросе который в Зксель пойдёт
            {
                idSale = (int)dsDate.Tables["Date"].Rows[i]["saleID"];
                idProd = (int)dsDate.Tables["Date"].Rows[i]["productID"];
                dateSale = (string)dsDate.Tables["Date"].Rows[i]["saleDate"];
                count = (int)dsDate.Tables["Date"].Rows[i]["count"];
                //fio = "BBB";
                fio = SearchNameEmpl((int)dsDate.Tables["Date"].Rows[i]["employeeID"]);

                ////таблицу заполняем строками не с ИД а с Именами
                dsRep2.Tables["tableRep2Names"].Rows.Add(idSale, idProd, dateSale, count, fio);
            }




            Excel.Application appExcel = new Excel.Application();
            appExcel.Visible = true;
            appExcel.Workbooks.Add();
            Excel._Worksheet workSheet = appExcel.ActiveSheet;
            //заголовки
            workSheet.Cells[1, 1] = "Код продажи";
            workSheet.Cells[1, 2] = "Продукт";
            workSheet.Cells[1, 3] = "Дата";
            workSheet.Cells[1, 4] = "Количество";
            workSheet.Cells[1, 5] = "ФИО";

            //данные
            for (int curRow = 1; curRow <= dsRep2.Tables["tableRep2Names"].Rows.Count; curRow++)
            {
                for (int curCol = 1; curCol <= dsRep2.Tables["tableRep2Names"].Columns.Count; curCol++)
                {
                    workSheet.Cells[curRow + 1, curCol] = dsRep2.Tables["tableRep2Names"].Rows[curRow - 1][curCol - 1].ToString();
                }
            }

        } //rep2Date()

        //поиск Имени типа по ИД
        public string SearchNameType(int idType)
        {
            DB db = new DB();
            db.OpenConnection();
            string s = string.Empty;
            string sql = "SELECT * FROM Type WHERE typeID = " + idType.ToString();
            SqlDataAdapter a = new SqlDataAdapter(sql, db.getConnection());
            System.Data.DataTable dt = new System.Data.DataTable("nameType");
            a.Fill(dt);
            s = dt.Rows[0][1].ToString();
            //DataSet ds = new DataSet("dsTN");
            //a.Fill(ds,"dsTN");
            return s;
        }

        //поиск Имени фирмы по ИД
        public string SearchNameFirm(int idFirm)
        {
            DB db = new DB();
            db.OpenConnection();
            string s = string.Empty;
            string sql = "SELECT * FROM Firm WHERE firmID = " + idFirm.ToString();
            SqlDataAdapter a = new SqlDataAdapter(sql, db.getConnection());
            System.Data.DataTable dt = new System.Data.DataTable("nameFirm");
            a.Fill(dt);
            s = dt.Rows[0][1].ToString();
            return s;
        }

        //поиск Имени марки по ИД
        public string SearchNameTrMark(int idMark)
        {
            DB db = new DB();
            db.OpenConnection();
            string s = string.Empty;
            string sql = "SELECT * FROM TrMark WHERE trMarkID = " + idMark.ToString();
            SqlDataAdapter a = new SqlDataAdapter(sql, db.getConnection());
            System.Data.DataTable dt = new System.Data.DataTable("nameMark");
            a.Fill(dt);
            s = dt.Rows[0][1].ToString();
            return s;
        }

        //поиск ФИО по ИД в таблице Сотрудников
        public string SearchNameEmpl(int idEmpl)
        {
            DB db = new DB();
            db.OpenConnection();
            string s = string.Empty;
            string sql = "SELECT * FROM Employee WHERE employeeID = " + idEmpl.ToString();
            SqlDataAdapter a = new SqlDataAdapter(sql, db.getConnection());
            System.Data.DataTable dt = new System.Data.DataTable("fio");
            a.Fill(dt);
            s = dt.Rows[0][1].ToString();
            return s;
        }

        public int SearchIdType(int prodId)
        {
            int typeId;
            string s = string.Empty;
            DB db = new DB();
            db.OpenConnection();
            string sql = "SELECT * FROM Product WHERE productID = " + prodId.ToString();
            //MessageBox.Show(sql);
            SqlDataAdapter a = new SqlDataAdapter(sql, db.getConnection());
            System.Data.DataTable dt = new System.Data.DataTable("idType");
            a.Fill(dt);
            /*****************************************************************************
            for (int curRow=0; curRow<dt.Rows.Count; curRow++)
            {
                for (int curCol = 0; curCol < dt.Columns.Count; curCol++)
                {
                    s += dt.Rows[curRow][curCol].ToString().Trim() + "\t";
                }
                s += "\n";
            }
            MessageBox.Show(s);
            ******************************************************************************/
            s = dt.Rows[0]["typeID"].ToString();  //может возвратить пустую таблицу (видимо null)
            if (int.TryParse(s, out typeId))
                return typeId;
            else
                return 0; //неправильно
        }

        public int SearchIdFirm(int prodId)
        {
            int firmId;
            DB db = new DB();
            db.OpenConnection();
            string sql = "SELECT * FROM Product WHERE productID = " + prodId.ToString();
            SqlDataAdapter a = new SqlDataAdapter(sql, db.getConnection());
            System.Data.DataTable dt = new System.Data.DataTable("idFirm");
            a.Fill(dt); //может возвратить пустую таблицу (видимо null)
            if (int.TryParse(dt.Rows[0]["firmID"].ToString(), out firmId))
                return firmId;
            else
                return 0; //неправильно
        }

        public int SearchIdTrMark(int prodId)
        {
            int trMarkId;
            DB db = new DB();
            db.OpenConnection();
            string sql = "SELECT * FROM Product WHERE productID = " + prodId.ToString();
            SqlDataAdapter a = new SqlDataAdapter(sql, db.getConnection());
            System.Data.DataTable dt = new System.Data.DataTable("idTrMark");
            a.Fill(dt); //может возвратить пустую таблицу (видимо null)
            if (int.TryParse(dt.Rows[0]["trmarkID"].ToString(), out trMarkId))
                return trMarkId;
            else
                return 0; //неправильно
        }
        private void btnRep2_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            //MessageBox.Show(dateTimePicker1.Text);
            rep2Date(dateTimePicker1.Text);
            dateTimePicker1.Format = DateTimePickerFormat.Long;
        }

        private void rbRep3Type_CheckedChanged(object sender, EventArgs e)
        {
            cbRep3Firm.Enabled = false;
            cbRep3Type.Enabled = true;
        }

        private void rbRep3Firm_CheckedChanged(object sender, EventArgs e)
        {
            cbRep3Firm.Enabled = true;
            cbRep3Type.Enabled = false;
        }

        private void rbRep3All_CheckedChanged(object sender, EventArgs e)
        {
            cbRep3Firm.Enabled = false;
            cbRep3Type.Enabled = false;
        }

        private void btnRep4_Click(object sender, EventArgs e)
        {
            Rep4Form r4 = new Rep4Form();
            r4.rep4type = 2;   //передаём номер типа чрез свойство
            r4.ShowDialog();
        }

        private void btnRep3_Click(object sender, EventArgs e)
        {
            //получаем данные о периоде
            DateTime d1, d2;
            string sOt = string.Empty;
            string sDo = string.Empty;
            //
            dateTimePickerRep3Ot.Format = DateTimePickerFormat.Short;
            sOt = this.dateTimePickerRep3Ot.Text;
            bool boolD1 = DateTime.TryParse(sOt, out d1);         //использовать булеву переменную для проверки преобразования
            //sOt = d1.ToString("d");                             //короткий вид даты
            sOt = d1.ToShortDateString();                         //можно и так
            dateTimePickerRep3Ot.Format = DateTimePickerFormat.Long;
            //
            dateTimePickerRep3Do.Format = DateTimePickerFormat.Short;
            sDo = this.dateTimePickerRep3Do.Text;
            bool boolD2 = DateTime.TryParse(sDo, out d2);       //использовать булеву переменную для проверки преобразования
            sDo = d2.ToString("d");                             //короткий вид даты
            dateTimePickerRep3Do.Format = DateTimePickerFormat.Long;

            //MessageBox.Show(sOt + "   " + sDo);

            //public static int Compare (DateTime t1, DateTime t2);
            //Меньше нуля 	Момент, указанный в параметре t1, наступает раньше, чем момент, указанный в параметре t2.
            //Нуль 	Параметр t1 совпадает с параметром t2.
            //Больше нуля 	Момент, указанный в параметре t1, наступает позже, чем момент, указанный в параметре t2.

            /*
            int resultCompare = DateTime.Compare(d1, d2);
            string relationship;

                if (resultCompare < 0)
                   relationship = "is earlier than";
                else if (resultCompare == 0)
                   relationship = "is the same time as";
                else
                   relationship = "is later than";
            */

            /************************************************ПОТУГИ ДЛЯ ПРОВЕРКИ НА НЕПУСТОТУ ЯЧЕЕК
            if (boolD1 & boolD2)
            {
                if (d1 <= d2)
                {
                    MessageBox.Show("true");
                }
                else
                {
                    MessageBox.Show("false");
                }
            }                                              
            ****************************************************/

            //
            if (rbRep3All.Checked) rep3All(sOt, sDo); //все

            if (rbRep3Type.Checked)                   //тип
            { 
                //когда в комбобоксе убираешь данные
               rep3Type(sOt, sDo, (int)this.cbRep3Type.SelectedValue); //чтобы не были пустыми передаваемые данные
            }

            if (rbRep3Firm.Checked)                    //фирма
            {
                rep3Firm(sOt, sDo, (int)this.cbRep3Firm.SelectedValue);
            }

            //MessageBox.Show(d1.ToString() + "   " + d2.ToString()) ;
            //MessageBox.Show(d1.ToShortDateString() + "   " + d2.ToShortDateString());
            //string sss = sOt + sDo +"  " + (int)this.cbRep3Type.SelectedValue+ "  " + (int)this.cbRep3Firm.SelectedValue;
            //MessageBox.Show(sss);

        } //btnRep3_Click()

  
        public void rep3All(string strOt, string strDo)
        {
            //соединяемса с БД
            DB db = new DB();
            db.OpenConnection();
            string s = "SELECT * FROM Sale WHERE (saleDate_ >= '" + strOt + "') AND (saleDate_ <='" + strDo + "')";
            //string s2 = "SELECT * FROM Product";
            SqlDataAdapter adaptAll = new SqlDataAdapter(s, db.getConnection());
            //SqlDataAdapter adaptPr = new SqlDataAdapter(s2, db.getConnection());
            DataSet dsAll = new DataSet("All");
            //DataSet dsPr = new DataSet("Prod");
            //MessageBox.Show(s);
            adaptAll.Fill(dsAll, "All");
            //adaptPr.Fill(dsPr, "Prod");

            //для того чтобы осмысленные имена отображались, а не коды
            SqlDataAdapter adaptTypeNames = new SqlDataAdapter("SELECT * FROM Type", db.getConnection());
            SqlDataAdapter adaptFirmNames = new SqlDataAdapter("SELECT * FROM Firm", db.getConnection());
            SqlDataAdapter adaptTrMarkNames = new SqlDataAdapter("SELECT * FROM TrMark", db.getConnection());
            SqlDataAdapter adaptEmplNames = new SqlDataAdapter("SELECT * FROM Employee", db.getConnection());
            DataSet dsTypeNames = new DataSet("Type");
            DataSet dsFirmNames = new DataSet("Firm");
            DataSet dsTrMarkNames = new DataSet("TrMark");
            DataSet dsEmplNames = new DataSet("FIO");
            adaptTypeNames.Fill(dsTypeNames, "Type");
            adaptFirmNames.Fill(dsFirmNames, "Firm");
            adaptTrMarkNames.Fill(dsTrMarkNames, "TrMark");
            adaptEmplNames.Fill(dsEmplNames, "FIO");
            //создаём отдельную таблу для значений с осмысленными именами
            DataSet dsRep3 = new DataSet("Rep3Names");

            //схема таблы
            DataColumn colIdSale = new DataColumn("saleID", typeof(int));
            colIdSale.Unique = false;
            colIdSale.AllowDBNull = true;
            DataColumn colIdProd = new DataColumn("prodID", typeof(int));
            colIdProd.Unique = false;
            colIdProd.AllowDBNull = true;
            DataColumn colTypeProd = new DataColumn("productType", typeof(string));
            colTypeProd.Unique = false;
            colTypeProd.AllowDBNull = true;
            DataColumn colFirmProd = new DataColumn("productFirm", typeof(string));
            colFirmProd.Unique = false;
            colFirmProd.AllowDBNull = true;
            DataColumn colTrMarkProd = new DataColumn("productTrMark", typeof(string));
            colTrMarkProd.Unique = false;
            colTrMarkProd.AllowDBNull = true;
            DataColumn colSaleDate = new DataColumn("saleDate", typeof(string));
            colSaleDate.Unique = false;
            colSaleDate.AllowDBNull = true;
            DataColumn colCount = new DataColumn("saleCount", typeof(int));
            colCount.Unique = false;
            colCount.AllowDBNull = true;
            DataColumn colFIO = new DataColumn("FIO", typeof(string));
            colFIO.Unique = false;
            colFIO.AllowDBNull = true;

            System.Data.DataTable dt = new System.Data.DataTable("tableRep3Names");
            dt.Columns.AddRange(new DataColumn[] { colIdSale, colIdProd, colTypeProd, colFirmProd, colTrMarkProd, colSaleDate, colCount, colFIO });
            dsRep3.Tables.Add(dt);

            //переменные в которых вместо ИД занесутся значения Name
            int idSale, idProd, count;
            string dateSale, fio, typeForTableNames, firmForTableNames, trmarkForTableNames;



            for (int i = 0; i < dsAll.Tables["All"].Rows.Count; i++)    //количество строк в запросе который в Зксель пойдёт
            {
                idSale = (int)dsAll.Tables["All"].Rows[i]["saleID"];
                idProd = (int)dsAll.Tables["All"].Rows[i]["productID"];
                //dateSale = (string)dsAll.Tables["All"].Rows[i]["saleDate_"].ToString();
                //получить имя типа из таблицы типов dsTypeNames
                //входные данные: кодПродукта (idProd)
                //MessageBox.Show(SearchIdType(idProd).ToString());
                //MessageBox.Show(SearchIdFirm(idProd).ToString());
                //MessageBox.Show(SearchIdTrMark(idProd).ToString());
                typeForTableNames = SearchNameType(SearchIdType(idProd));
                firmForTableNames = SearchNameFirm(SearchIdFirm(idProd));
                trmarkForTableNames = SearchNameTrMark(SearchIdTrMark(idProd));

                dateSale = string.Format("{0:d}", dsAll.Tables["All"].Rows[i]["saleDate_"].ToString());
                count = (int)dsAll.Tables["All"].Rows[i]["count"];
                fio = SearchNameEmpl((int)dsAll.Tables["All"].Rows[i]["employeeID"]);


                ////таблицу заполняем строками не с ИД а с Именами
                dsRep3.Tables["tableRep3Names"].Rows.Add(idSale, idProd, typeForTableNames, firmForTableNames, trmarkForTableNames, dateSale, count, fio);
            }

            /************************************************************************************
            for (int i = 0; i < dsPr.Tables["Prod"].Rows.Count; i++)
            {
                //typeForTableNames = SearchNameType(idProd);
                //firmForTableNames = SearchNameFirm(idProd);
                //trmarkForTableNames = SearchNameTrMark(idProd);
                typeForTableNames = SearchNameType((int)dsPr.Tables["Prod"].Rows[i]["typeID"]);
                firmForTableNames = SearchNameFirm((int)dsPr.Tables["Prod"].Rows[i]["firmID"]);
                trmarkForTableNames = SearchNameTrMark((int)dsPr.Tables["Prod"].Rows[i]["trmarkID"]);
            }
            **************************************************************************************/

            Excel.Application appExcel = new Excel.Application();
            appExcel.Visible = true;
            appExcel.Workbooks.Add();
            Excel._Worksheet workSheet = appExcel.ActiveSheet;
            //заголовки
            workSheet.Cells[1, 1] = "Код продажи";
            workSheet.Cells[1, 2] = "Код продукта";
            workSheet.Cells[1, 3] = "Тип";
            workSheet.Cells[1, 4] = "Фирма";
            workSheet.Cells[1, 5] = "Марка";
            workSheet.Cells[1, 6] = "Дата продажи";
            workSheet.Cells[1, 7] = "Количество";
            workSheet.Cells[1, 8] = "ФИО продавца";

            //данные
            for (int curRow = 1; curRow <= dsRep3.Tables["tableRep3Names"].Rows.Count; curRow++)
            {
                for (int curCol = 1; curCol <= dsRep3.Tables["tableRep3Names"].Columns.Count; curCol++)
                {
                    workSheet.Cells[curRow + 1, curCol] = dsRep3.Tables["tableRep3Names"].Rows[curRow - 1][curCol - 1].ToString();
                }
            }
            db.CloseConnection();

        } //rep3All()


        public void rep3Type(string strOt, string strDo, int typeId)
        {
            //MessageBox.Show(typeId.ToString());
            //соединяемса с БД
            DB db = new DB();
            db.OpenConnection();
            string s = "SELECT * FROM Sale, Product WHERE (Sale.saleDate_ >= '" + strOt + "') AND (Sale.saleDate_ <='" + strDo + "') AND " +
                "(Sale.productID = Product.productID) AND (Product.typeID = " +  typeId.ToString() + ")";
            //string sProd = "SELECT * FROM Product WHERE"
            SqlDataAdapter adaptType = new SqlDataAdapter(s, db.getConnection());
            DataSet dsType = new DataSet("Type");
            //MessageBox.Show(s);
            adaptType.Fill(dsType, "Type");

            /*********************************************************************************************
            string str = string.Empty;
            for (int curRow = 0; curRow < dsType.Tables["Type"].Rows.Count; curRow++)
            {
                for (int curCol = 0; curCol < dsType.Tables["Type"].Columns.Count; curCol++)
                {
                    str += dsType.Tables["Type"].Rows[curRow][curCol].ToString().Trim() + "\t";
                    //s += dt.Rows[curRow][curCol].ToString().Trim() + "\t";
                }
                str += "\n";
            }
            MessageBox.Show(str);
            ***************************************************************************************************/

            //для того чтобы осмысленные имена отображались, а не коды
            SqlDataAdapter adaptTypeNames = new SqlDataAdapter("SELECT * FROM Type", db.getConnection());
            SqlDataAdapter adaptFirmNames = new SqlDataAdapter("SELECT * FROM Firm", db.getConnection());
            SqlDataAdapter adaptTrMarkNames = new SqlDataAdapter("SELECT * FROM TrMark", db.getConnection());
            SqlDataAdapter adaptEmplNames = new SqlDataAdapter("SELECT * FROM Employee", db.getConnection());
            DataSet dsTypeNames = new DataSet("Type");
            DataSet dsFirmNames = new DataSet("Firm");
            DataSet dsTrMarkNames = new DataSet("TrMark");
            DataSet dsEmplNames = new DataSet("FIO");
            adaptTypeNames.Fill(dsTypeNames, "Type");
            adaptFirmNames.Fill(dsFirmNames, "Firm");
            adaptTrMarkNames.Fill(dsTrMarkNames, "TrMark");
            adaptEmplNames.Fill(dsEmplNames, "FIO");
            //создаём отдельную таблу для значений с осмысленными именами
            DataSet dsRep3 = new DataSet("Rep3Names");

            //схема таблы
            DataColumn colIdSale = new DataColumn("saleID", typeof(int));
            colIdSale.Unique = false;
            colIdSale.AllowDBNull = true;
            DataColumn colIdProd = new DataColumn("prodID", typeof(int));
            colIdProd.Unique = false;
            colIdProd.AllowDBNull = true;
            DataColumn colTypeProd = new DataColumn("productType", typeof(string));
            colTypeProd.Unique = false;
            colTypeProd.AllowDBNull = true;
            DataColumn colFirmProd = new DataColumn("productFirm", typeof(string));
            colFirmProd.Unique = false;
            colFirmProd.AllowDBNull = true;
            DataColumn colTrMarkProd = new DataColumn("productTrMark", typeof(string));
            colTrMarkProd.Unique = false;
            colTrMarkProd.AllowDBNull = true;
            DataColumn colSaleDate = new DataColumn("saleDate", typeof(string));
            colSaleDate.Unique = false;
            colSaleDate.AllowDBNull = true;
            DataColumn colCount = new DataColumn("saleCount", typeof(int));
            colCount.Unique = false;
            colCount.AllowDBNull = true;
            DataColumn colFIO = new DataColumn("FIO", typeof(string));
            colFIO.Unique = false;
            colFIO.AllowDBNull = true;

            System.Data.DataTable dt = new System.Data.DataTable("tableRep3Names");
            dt.Columns.AddRange(new DataColumn[] { colIdSale, colIdProd, colTypeProd, colFirmProd, colTrMarkProd, colSaleDate, colCount, colFIO });
            dsRep3.Tables.Add(dt);

            //переменные в которых вместо ИД занесутся значения Name
            int idSale, idProd, count;
            string dateSale, fio, typeForTableNames, firmForTableNames, trmarkForTableNames;

            for (int i = 0; i < dsType.Tables["Type"].Rows.Count; i++)    //количество строк в запросе который в Зксель пойдёт
            {
                idSale = (int)dsType.Tables["Type"].Rows[i]["saleID"];
                idProd = (int)dsType.Tables["Type"].Rows[i]["productID"];
                typeForTableNames = SearchNameType(SearchIdType(idProd));
                firmForTableNames = SearchNameFirm(SearchIdFirm(idProd));
                trmarkForTableNames = SearchNameTrMark(SearchIdTrMark(idProd));
                //dateSale = (string)dsAll.Tables["All"].Rows[i]["saleDate_"].ToString();
                dateSale = string.Format("{0:d}", dsType.Tables["Type"].Rows[i]["saleDate_"].ToString());
                count = (int)dsType.Tables["Type"].Rows[i]["count"];
                fio = SearchNameEmpl((int)dsType.Tables["Type"].Rows[i]["employeeID"]);

                ////таблицу заполняем строками не с ИД а с Именами
                dsRep3.Tables["tableRep3Names"].Rows.Add(idSale, idProd, typeForTableNames, firmForTableNames, trmarkForTableNames, dateSale, count, fio);
            }

            Excel.Application appExcel = new Excel.Application();
            appExcel.Visible = true;
            appExcel.Workbooks.Add();
            Excel._Worksheet workSheet = appExcel.ActiveSheet;
            //заголовки
            workSheet.Cells[1, 1] = "Код продажи";
            workSheet.Cells[1, 2] = "Код продукта";
            workSheet.Cells[1, 3] = "Тип";
            workSheet.Cells[1, 4] = "Фирма";
            workSheet.Cells[1, 5] = "Марка";
            workSheet.Cells[1, 6] = "Дата продажи";
            workSheet.Cells[1, 7] = "Количество";
            workSheet.Cells[1, 8] = "ФИО продавца";

            //данные
            for (int curRow = 1; curRow <= dsRep3.Tables["tableRep3Names"].Rows.Count; curRow++)
            {
                for (int curCol = 1; curCol <= dsRep3.Tables["tableRep3Names"].Columns.Count; curCol++)
                {
                    workSheet.Cells[curRow + 1, curCol] = dsRep3.Tables["tableRep3Names"].Rows[curRow - 1][curCol - 1].ToString();
                }
            }
            db.CloseConnection();

        } //rep3Type()

        public void rep3Firm(string strOt, string strDo, int firmId)
        {
            //соединяемса с БД
            DB db = new DB();
            db.OpenConnection();
            string s = "SELECT * FROM Sale, Product WHERE (Sale.saleDate_ >= '" + strOt + "') AND (Sale.saleDate_ <='" + strDo + "') AND " +
                "(Sale.productID = Product.productID) AND (Product.firmID = " + firmId.ToString() + ")";
            //string sProd = "SELECT * FROM Product WHERE"
            SqlDataAdapter adaptFirm = new SqlDataAdapter(s, db.getConnection());
            DataSet dsFirm = new DataSet("Firm");
            //MessageBox.Show(s);
            adaptFirm.Fill(dsFirm, "Firm");

            //для того чтобы осмысленные имена отображались, а не коды
            SqlDataAdapter adaptTypeNames = new SqlDataAdapter("SELECT * FROM Type", db.getConnection());
            SqlDataAdapter adaptFirmNames = new SqlDataAdapter("SELECT * FROM Firm", db.getConnection());
            SqlDataAdapter adaptTrMarkNames = new SqlDataAdapter("SELECT * FROM TrMark", db.getConnection());
            SqlDataAdapter adaptEmplNames = new SqlDataAdapter("SELECT * FROM Employee", db.getConnection());
            DataSet dsTypeNames = new DataSet("Type");
            DataSet dsFirmNames = new DataSet("Firm");
            DataSet dsTrMarkNames = new DataSet("TrMark");
            DataSet dsEmplNames = new DataSet("FIO");
            adaptTypeNames.Fill(dsTypeNames, "Type");
            adaptFirmNames.Fill(dsFirmNames, "Firm");
            adaptTrMarkNames.Fill(dsTrMarkNames, "TrMark");
            adaptEmplNames.Fill(dsEmplNames, "FIO");
            //создаём отдельную таблу для значений с осмысленными именами
            DataSet dsRep3 = new DataSet("Rep3Names");

            //схема таблы
            DataColumn colIdSale = new DataColumn("saleID", typeof(int));
            colIdSale.Unique = false;
            colIdSale.AllowDBNull = true;
            DataColumn colIdProd = new DataColumn("prodID", typeof(int));
            colIdProd.Unique = false;
            colIdProd.AllowDBNull = true;
            DataColumn colTypeProd = new DataColumn("productType", typeof(string));
            colTypeProd.Unique = false;
            colTypeProd.AllowDBNull = true;
            DataColumn colFirmProd = new DataColumn("productFirm", typeof(string));
            colFirmProd.Unique = false;
            colFirmProd.AllowDBNull = true;
            DataColumn colTrMarkProd = new DataColumn("productTrMark", typeof(string));
            colTrMarkProd.Unique = false;
            colTrMarkProd.AllowDBNull = true;
            DataColumn colSaleDate = new DataColumn("saleDate", typeof(string));
            colSaleDate.Unique = false;
            colSaleDate.AllowDBNull = true;
            DataColumn colCount = new DataColumn("saleCount", typeof(int));
            colCount.Unique = false;
            colCount.AllowDBNull = true;
            DataColumn colFIO = new DataColumn("FIO", typeof(string));
            colFIO.Unique = false;
            colFIO.AllowDBNull = true;

            System.Data.DataTable dt = new System.Data.DataTable("tableRep3Names");
            dt.Columns.AddRange(new DataColumn[] { colIdSale, colIdProd, colTypeProd, colFirmProd, colTrMarkProd, colSaleDate, colCount, colFIO });
            dsRep3.Tables.Add(dt);

            //переменные в которых вместо ИД занесутся значения Name
            int idSale, idProd, count;
            string dateSale, fio, typeForTableNames, firmForTableNames, trmarkForTableNames;

            for (int i = 0; i < dsFirm.Tables["Firm"].Rows.Count; i++)    //количество строк в запросе который в Зксель пойдёт
            {
                idSale = (int)dsFirm.Tables["Firm"].Rows[i]["saleID"];
                idProd = (int)dsFirm.Tables["Firm"].Rows[i]["productID"];
                typeForTableNames = SearchNameType(SearchIdType(idProd));
                firmForTableNames = SearchNameFirm(SearchIdFirm(idProd));
                trmarkForTableNames = SearchNameTrMark(SearchIdTrMark(idProd));
                dateSale = string.Format("{0:d}", dsFirm.Tables["Firm"].Rows[i]["saleDate_"].ToString());
                count = (int)dsFirm.Tables["Firm"].Rows[i]["count"];
                fio = SearchNameEmpl((int)dsFirm.Tables["Firm"].Rows[i]["employeeID"]);

                ////таблицу заполняем строками не с ИД а с Именами
                dsRep3.Tables["tableRep3Names"].Rows.Add(idSale, idProd, typeForTableNames, firmForTableNames, trmarkForTableNames, dateSale, count, fio);
            }

            Excel.Application appExcel = new Excel.Application();
            appExcel.Visible = true;
            appExcel.Workbooks.Add();
            Excel._Worksheet workSheet = appExcel.ActiveSheet;
            //заголовки
            workSheet.Cells[1, 1] = "Код продажи";
            workSheet.Cells[1, 2] = "Код продукта";
            workSheet.Cells[1, 3] = "Тип";
            workSheet.Cells[1, 4] = "Фирма";
            workSheet.Cells[1, 5] = "Марка";
            workSheet.Cells[1, 6] = "Дата продажи";
            workSheet.Cells[1, 7] = "Количество";
            workSheet.Cells[1, 8] = "ФИО продавца";

            //данные
            for (int curRow = 1; curRow <= dsRep3.Tables["tableRep3Names"].Rows.Count; curRow++)
            {
                for (int curCol = 1; curCol <= dsRep3.Tables["tableRep3Names"].Columns.Count; curCol++)
                {
                    workSheet.Cells[curRow + 1, curCol] = dsRep3.Tables["tableRep3Names"].Rows[curRow - 1][curCol - 1].ToString();
                }
            }
            db.CloseConnection();
        } //rep3Firm()

    } //class ReportsForm



}
