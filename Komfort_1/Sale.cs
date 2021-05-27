using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;



namespace Komfort_1
{
    class Sale 
    {
        //ПОЛЯ
        ulong saleID = 0;
        ulong productID = 0;
        string saleDate = string.Empty;
        int count = 0;
        ulong employeeID = 0;

        //СВОЙСТВА

        //КОНСТРУКТОРЫ

        //МЕТОДЫ
        public void addSale(ulong prodID, string saleD, int c, ulong emplID)
        {
            
            //соединяемса с БД
            DB db = new DB();
            db.OpenConnection();
            //в адаптере строки из таблицы Sale
            SqlDataAdapter adapt = new SqlDataAdapter("SELECT * FROM Sale", db.getConnection());
            //ДатаСет
            DataSet ds = new DataSet("Sale");
            //заполним датасет из адаптера
            adapt.Fill(ds, "Sale");

            //поиск свободного индекса в таблице
            int countRow = ds.Tables["Sale"].Rows.Count;    //количество строк в таблице Sale
            int i = 0;
            //объявить вектор размером countRow
            List<int> list = new List<int>(countRow);
            //заполнить list Значениями столбца saleID
            //SqlCommand cmd = new SqlCommand(string.Format("SELECT * FROM Sale"), db.getConnection());
            using (SqlCommand cmd = new SqlCommand(string.Format("SELECT * FROM Sale"), db.getConnection()))
            {
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    list.Add((int)dr["saleID"]);
                }
                dr.Close();
            }
            list.Sort();
            int max = list.Max();
            //найти минимальный свободный индекс
            int minFree = -1;
            while (i < max)
            {
                if (i == list[i])
                {
                    i++;
                }
                else
                {
                    minFree = i;
                    break;
                }
            } //while
            //если свободный индекс не найден то своб. индекс равен max+1
            if (minFree == -1) minFree = max + 1;


            saleID = (ulong)minFree;
            productID = prodID;
            saleDate = saleD;
            count = c;
            employeeID = emplID;
            //сформировать sql-оператор
            string sql = string.Format("INSERT INTO Sale" +
                "(saleID, productID, saleDate_, count, employeeID) Values" +
                "('{0}', '{1}', '{2}', '{3}', {4})", saleID, productID, saleDate, count, employeeID);

            //выполнить sql-оператор с применением нашего подключения
            using (SqlCommand cmd = new SqlCommand(sql, db.getConnection()))
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Продажа добавлена в базу данных");
            }
            db.CloseConnection();

        } //addSale()
        

       /*
        public void addSale()
        {
            //соединяемса с БД
            DB db = new DB();
            db.OpenConnection();
            //в адаптере строки из таблицы Sale
            SqlDataAdapter adapt = new SqlDataAdapter("SELECT * FROM Sale", db.getConnection());
            //ДатаСет
            DataSet ds = new DataSet("Sale");
            //заполним датасет из адаптера
            adapt.Fill(ds, "Sale");
            //считываем введённые данные в переменные из формы
            AddSaleForm addS = new AddSaleForm();
            saleID = 125;
            productID = addS.productID;
            saleDate = addS.saleDate;
            count = addS.count;
            employeeID = addS.employeeID;

            //сформировать sql-оператор
            string sql = string.Format("INSERT INTO Sale" +
                "(saleID, productID, saleDate, count, employeeID) Values" +
                "('{0}', '{1}', '{2}', '{3}', {4})", saleID, productID, saleDate, count, employeeID);

            //выполнить sql-оператор с применением нашего подключения
            using (SqlCommand cmd = new SqlCommand(sql, db.getConnection()))
            {
                cmd.ExecuteNonQuery();
            }
            db.CloseConnection();

        } //addSale()   */

        public bool deleteSale(ulong idDel)
        {
            bool b=false;
            //соединяемса с БД
            DB db = new DB();
            db.OpenConnection();
            //в адаптере строки из таблицы Sale
            SqlDataAdapter adapt = new SqlDataAdapter("SELECT * FROM Sale", db.getConnection());
            //ДатаСет
            DataSet ds = new DataSet("Sale");
            //заполним датасет из адаптера
            adapt.Fill(ds, "Sale");

            string sql = string.Format("DELETE FROM Sale WHERE saleID = '{0}'", idDel);
            using (SqlCommand cmd = new SqlCommand(sql, db.getConnection()))
            {
                try
                {
                    string s = string.Empty;
                    s = "Продажа с кодом " + idDel.ToString() + " удалена из базы данных";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(s);
                    b = true;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            db.CloseConnection();
            return b;
        } //deleteSale

        public string ShowInfoSale(ulong saleId)
        {
            string str = string.Empty;
            return str;
        }

        public string SearchSale(ulong saleId)
        {
            string str = string.Empty;
            return str;
        }


    }
}
