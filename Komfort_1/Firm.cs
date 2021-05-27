using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Komfort_1
{
    class Firm
    {
        //ПОЛЯ
        ulong firmID = 0;
        string firmName = string.Empty;
        string firmCountry = string.Empty;

        //СВОЙСТА


        //КОНСТРУКТОРЫ


        //МЕТОДЫ

        //добавить фирму
        public void addFirm(string newFirm, string newCountry)
        {
            //соединяемса с БД
            DB db = new DB();
            db.OpenConnection();
            //в адаптере строки из таблицы Firm
            SqlDataAdapter adapt = new SqlDataAdapter("SELECT * FROM Firm", db.getConnection());
            //ДатаСет
            DataSet ds = new DataSet("Firm");
            //заполним датасет из адаптера
            adapt.Fill(ds, "Firm");

            //поиск свободного индекса в таблице
            int countRow = ds.Tables["Firm"].Rows.Count;    //количество строк в таблице Firm
            int i = 0;
            //объявить вектор размером countRow
            List<int> list = new List<int>(countRow);
            //заполнить list Значениями столбца firmID
            //SqlCommand cmd = new SqlCommand(string.Format("SELECT * FROM Type"), db.getConnection());
            using (SqlCommand cmd = new SqlCommand(string.Format("SELECT * FROM Firm"), db.getConnection()))
            {
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    list.Add((int)dr["firmID"]);
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


            //сформировать sql-оператор
            string sql = string.Format("INSERT INTO Firm" +
                "(firmID, firmName, firmCountry) Values" +
                "('{0}', '{1}', '{2}')", minFree, newFirm, newCountry);

            //выполнить sql-оператор с применением нашего подключения
            using (SqlCommand cmd = new SqlCommand(sql, db.getConnection()))
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Фирма добавлена в базу данных");
            }
            db.CloseConnection();


        } //addFirm()

        //удалить фирму
        public bool deleteFirm(string delFirm)
        {
            bool b = false; //то что возвратит ф-ция при успешном удалении
            int idFirmInProd = -1;
            int idFirm;
            //поиск ID Типа по Имени
            idFirm = SearchIDFirm(delFirm);
            //соединяемса с БД
            DB db = new DB();
            db.OpenConnection();
            //в адаптере строки из таблицы Firm
            SqlDataAdapter adaptFirm = new SqlDataAdapter("SELECT * FROM Firm", db.getConnection());        //табла, где будем удалять
            SqlDataAdapter adaptProduct = new SqlDataAdapter("SELECT * FROM Product", db.getConnection());  //табла, где ищем, если есть - не удалять
            //ДатаСет Фирмы
            DataSet ds = new DataSet("Firm");
            //ДатаСет Продукты
            DataSet dsPr = new DataSet("Product");
            //заполним датасет из адаптера Фирмы
            adaptFirm.Fill(ds, "Firm");
            //заполним датасет из адаптера Продукты
            adaptProduct.Fill(dsPr, "Product");

            if (idFirm != -1)   //если Фирма существует, то есть найдена в таблице Фирм
            {
                //поиск найденного ИД в таблице Продукты
                string sqlPr = string.Format("SELECT * FROM Product WHERE firmID = '{0}'", idFirm);
                using (SqlCommand cmdPr = new SqlCommand(sqlPr, db.getConnection()))
                {
                    SqlDataReader drPr = cmdPr.ExecuteReader();
                    while (drPr.Read())
                    {
                        idFirmInProd = (int)drPr["firmID"];
                    }
                    drPr.Close();
                }
                //MessageBox.Show(idFirmInProd.ToString());
                if (idFirmInProd == -1) //если ИД Фирмы не найден в таблице Продукты то удаляем
                {
                    string sql = string.Format("DELETE FROM Firm WHERE firmID = '{0}'", idFirm.ToString());
                    using (SqlCommand cmd = new SqlCommand(sql, db.getConnection()))
                    {
                        try
                        {
                            string s = string.Empty;
                            s = "Фирма " + delFirm + " удалёна из базы данных";
                            cmd.ExecuteNonQuery();
                            MessageBox.Show(s);
                            b = true;
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                //если Фирма найдена в таблице продукты, значит нельзя удалять
                else
                {
                    string s2 = "Фирма " + delFirm + " связана с продуктом(ами) и не может быть удалена!";
                    MessageBox.Show(s2);
                }
            }
            else
            {
                string s1 = "Фирма с именем " + delFirm + " не найдена в БД";
                MessageBox.Show(s1);
            }

            db.CloseConnection();



            return b;
        } //deleteFirm()

        //
        public string ShowListOfFirm(string listFirm)
        {
            //
            string str = string.Empty;

            return str;
        }

        //
        public string SearchFirm(string searchFirm)
        {
            string str = string.Empty;

            return str;
        }

        public int SearchIDFirm(string nameFirm)
        {
            int id = -1;
            //соединяемса с БД
            DB db = new DB();
            db.OpenConnection();
            SqlDataAdapter adaptProduct = new SqlDataAdapter("SELECT * FROM Firm", db.getConnection());
            DataSet dsF = new DataSet("Firm");
            adaptProduct.Fill(dsF, "Firm");
            string sql = string.Format("SELECT firmID FROM Firm WHERE firmName = '{0}'", nameFirm);
            using (SqlCommand cmd = new SqlCommand(sql, db.getConnection()))
            {
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    id = (int)dr["firmID"];
                }
                dr.Close();
            }
            db.CloseConnection();
            return id;
        } //SearchIDFirm()

    }
}
