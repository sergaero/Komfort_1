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
    class Type
    {
        //ПОЛЯ
        ulong typeID = 0;
        string typeName = string.Empty;

        //СВОЙСТА


        //КОНСТРУКТОРЫ


        //МЕТОДЫ
        //добавить тип
        public void addType(string newType)
        {
            //соединяемса с БД
            DB db = new DB();
            db.OpenConnection();
            //в адаптере строки из таблицы Type
            SqlDataAdapter adapt = new SqlDataAdapter("SELECT * FROM Type", db.getConnection());
            //ДатаСет
            DataSet ds = new DataSet("Type");
            //заполним датасет из адаптера
            adapt.Fill(ds, "Type");

            //поиск свободного индекса в таблице
            int countRow = ds.Tables["Type"].Rows.Count;    //количество строк в таблице Type
            int i = 0;
            //объявить вектор размером countRow
            List<int> list = new List<int>(countRow);
            //заполнить list Значениями столбца typeID
            //SqlCommand cmd = new SqlCommand(string.Format("SELECT * FROM Type"), db.getConnection());
            using (SqlCommand cmd = new SqlCommand(string.Format("SELECT * FROM Type"), db.getConnection()))
            {
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    list.Add((int)dr["typeID"]);
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
            string sql = string.Format("INSERT INTO Type" +
                "(typeID, typeName) Values" +
                "('{0}', '{1}')", minFree, newType);

            //выполнить sql-оператор с применением нашего подключения
            using (SqlCommand cmd = new SqlCommand(sql, db.getConnection()))
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Тип добавлен в базу данных");
            }
            db.CloseConnection();
        } //addType()
       


        //удалить тип
        public bool deleteType(string delType)
        {
            //
            bool b = false; //то что возвратит ф-ция при успешном удалении
            int idTypeInProd = -1;
            int idType;
            //поиск ID Типа по Имени
            idType = SearchIDType(delType);
            //соединяемса с БД
            DB db = new DB();
            db.OpenConnection();
            //в адаптере строки из таблицы Type
            SqlDataAdapter adaptType = new SqlDataAdapter("SELECT * FROM Type", db.getConnection());        //табла, где будем удалять
            SqlDataAdapter adaptProduct = new SqlDataAdapter("SELECT * FROM Product", db.getConnection());  //табла, где ищем, если есть - не удалять
            //ДатаСет Типы
            DataSet ds = new DataSet("Type");
            //ДатаСет Продукты
            DataSet dsPr = new DataSet("Product");
            //заполним датасет из адаптера Типы
            adaptType.Fill(ds, "Type");
            //заполним датасет из адаптера Продукты
            adaptProduct.Fill(dsPr, "Product");

            if (idType != -1)   //если Тип существует, то есть найден в таблице типов
            {
                //поиск найденного ИД в таблице Продукты
                string sqlPr = string.Format("SELECT * FROM Product WHERE typeID = '{0}'", idType);
                using (SqlCommand cmdPr = new SqlCommand(sqlPr, db.getConnection()))
                {
                    SqlDataReader drPr = cmdPr.ExecuteReader();
                    while (drPr.Read())
                    {
                        idTypeInProd = (int)drPr["typeID"];
                    }
                    drPr.Close();
                }
                //MessageBox.Show(idTypeInProd.ToString());
                if (idTypeInProd == -1) //если ИД Типа не найден в таблице Продукты то удаляем
                {
                    string sql = string.Format("DELETE FROM Type WHERE typeID = '{0}'", idType.ToString());
                    using (SqlCommand cmd = new SqlCommand(sql, db.getConnection()))
                    {
                        try
                        {
                            string s = string.Empty;
                            s = "Тип " + delType + " удалён из базы данных";
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
                //если Тип найден в таблице продукты, значит нельзя удалять
                else
                {
                    string s2 = "Тип " + delType + " связан с продуктом(ами) и не может быть удалён!";
                    MessageBox.Show(s2);
                }
            }
            else
            {
                string s1 = "Тип с именем " + delType + " не найден в БД";
                MessageBox.Show(s1);
            }

            db.CloseConnection();

            return b;
        } //deleteType()

        //
        public string ShowListOfType(string listType)
        {
            //
            string str = string.Empty;

            return str;
        }

        //SearchType(string)
        public string SearchType(string searchType)
        {
            string str = string.Empty;

            return str;
        }

        //поиск ИД Типа по Имени
        public int SearchIDType(string nameType)
        {
            int id = -1;
            //соединяемса с БД
            DB db = new DB();
            db.OpenConnection();
            SqlDataAdapter adaptProduct = new SqlDataAdapter("SELECT * FROM Type", db.getConnection());
            DataSet dsT = new DataSet("Type");
            adaptProduct.Fill(dsT, "Type");
            string sql = string.Format("SELECT typeID FROM Type WHERE typeName = '{0}'", nameType);
            using (SqlCommand cmd = new SqlCommand(sql, db.getConnection()))
            {
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    id = (int)dr["typeID"];
                }
                dr.Close();
            }
            db.CloseConnection();
            return id;
        } //SearchIDType()

    }
}
