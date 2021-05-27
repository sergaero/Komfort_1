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
    class TrMark
    {
        //ПОЛЯ
        ulong trMarkID = 0;
        string trMarkName = string.Empty;
       

        //СВОЙСТА


        //КОНСТРУКТОРЫ


        //МЕТОДЫ

        //добавить фирму
        public void addTrMark(string newTrMark)
        {
            //соединяемса с БД
            DB db = new DB();
            db.OpenConnection();
            //в адаптере строки из таблицы TrMark
            SqlDataAdapter adapt = new SqlDataAdapter("SELECT * FROM TrMark", db.getConnection());
            //ДатаСет
            DataSet ds = new DataSet("TrMark");
            //заполним датасет из адаптера
            adapt.Fill(ds, "TrMark");

            //поиск свободного индекса в таблице
            int countRow = ds.Tables["TrMark"].Rows.Count;    //количество строк в таблице TrMark
            int i = 0;
            //объявить вектор размером countRow
            List<int> list = new List<int>(countRow);
            //заполнить list Значениями столбца trMarkID
            //SqlCommand cmd = new SqlCommand(string.Format("SELECT * FROM Type"), db.getConnection());
            using (SqlCommand cmd = new SqlCommand(string.Format("SELECT * FROM TrMark"), db.getConnection()))
            {
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    list.Add((int)dr["trMarkID"]);
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
            string sql = string.Format("INSERT INTO TrMark" +
                "(trMarkID, trMarkName) Values" +
                "('{0}', '{1}')", minFree, newTrMark);

            //выполнить sql-оператор с применением нашего подключения
            using (SqlCommand cmd = new SqlCommand(sql, db.getConnection()))
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Марка добавлена в базу данных");
            }
            db.CloseConnection();
        } //addTrMark()

        //удалить марку
        public bool deleteTrMark(string delTrMark)
        {
            //
            //
            bool b = false; //то что возвратит ф-ция при успешном удалении
            int idTrMarkInProd = -1;
            int idTrMark;
            //поиск ID Марки по Имени
            idTrMark = SearchIDTrMark(delTrMark);
            //соединяемса с БД
            DB db = new DB();
            db.OpenConnection();
            //в адаптере строки из таблицы TrMark
            SqlDataAdapter adaptTrMark = new SqlDataAdapter("SELECT * FROM TrMark", db.getConnection());        //табла, где будем удалять
            SqlDataAdapter adaptProduct = new SqlDataAdapter("SELECT * FROM Product", db.getConnection());  //табла, где ищем, если есть - не удалять
            //ДатаСет Марки
            DataSet ds = new DataSet("TrMark");
            //ДатаСет Продукты
            DataSet dsPr = new DataSet("Product");
            //заполним датасет из адаптера Марки
            adaptTrMark.Fill(ds, "TrMark");
            //заполним датасет из адаптера Продукты
            adaptProduct.Fill(dsPr, "Product");

            if (idTrMark != -1)   //если Марка существует, то есть найдена в таблице Марок
            {
                //поиск найденного ИД в таблице Продукты
                string sqlPr = string.Format("SELECT * FROM Product WHERE trmarkID = '{0}'", idTrMark);
                using (SqlCommand cmdPr = new SqlCommand(sqlPr, db.getConnection()))
                {
                    SqlDataReader drPr = cmdPr.ExecuteReader();
                    while (drPr.Read())
                    {
                        idTrMarkInProd = (int)drPr["trMarkID"];
                    }
                    drPr.Close();
                }
                //MessageBox.Show(idTypeInProd.ToString());
                if (idTrMarkInProd == -1) //если ИД Марки не найден в таблице Продукты то удаляем
                {
                    string sql = string.Format("DELETE FROM TrMark WHERE trMarkID = '{0}'", idTrMark.ToString());
                    using (SqlCommand cmd = new SqlCommand(sql, db.getConnection()))
                    {
                        try
                        {
                            string s = string.Empty;
                            s = "Марка " + delTrMark + " удалена из базы данных";
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
                //если Марка найдена в таблице продукты, значит нельзя удалять
                else
                {
                    string s2 = "Марка " + delTrMark + " связана с продуктом(ами) и не может быть удалена!";
                    MessageBox.Show(s2);
                }
            }
            else
            {
                string s1 = "Марка с именем " + delTrMark + " не найдена в БД";
                MessageBox.Show(s1);
            }

            db.CloseConnection();

            return b;
        }

        //
        public string ShowListOfTrMark(string listTrMark)
        {
            //
            string str = string.Empty;

            return str;
        }

        //
        public string SearchTrMark(string searchTrMark)
        {
            string str = string.Empty;

            return str;
        }


        public int SearchIDTrMark(string nameTrMark)
        {
            int id = -1;
            //соединяемса с БД
            DB db = new DB();
            db.OpenConnection();
            SqlDataAdapter adaptProduct = new SqlDataAdapter("SELECT * FROM TrMark", db.getConnection());
            DataSet dsT = new DataSet("TrMark");
            adaptProduct.Fill(dsT, "TrMark");
            string sql = string.Format("SELECT trMarkID FROM TrMark WHERE trMarkName = '{0}'", nameTrMark);
            using (SqlCommand cmd = new SqlCommand(sql, db.getConnection()))
            {
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    id = (int)dr["trMarkID"];
                }
                dr.Close();
            }
            db.CloseConnection();
            return id;
        }
    }
}
