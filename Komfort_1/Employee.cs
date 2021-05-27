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
    class Employee
    {
        //ПОЛЯ
        ulong employeeID = 0;
        string employeeFIO = string.Empty;
        string employeePosition = string.Empty;

        //СВОЙСТВА

        //КОНСТРУКТОРЫ

        //МЕТОДЫ
        public void addEmployee(string newEmplFIO, string  newEmplPos)
        {
            //соединяемса с БД
            DB db = new DB();
            db.OpenConnection();
            //в адаптере строки из таблицы Employee
            SqlDataAdapter adapt = new SqlDataAdapter("SELECT * FROM Employee", db.getConnection());
            //ДатаСет
            DataSet ds = new DataSet("Employee");
            //заполним датасет из адаптера
            adapt.Fill(ds, "Employee");

            //поиск свободного индекса в таблице
            int countRow = ds.Tables["Employee"].Rows.Count;    //количество строк в таблице Employee
            int i = 0;
            //объявить вектор размером countRow
            List<int> list = new List<int>(countRow);
            //заполнить list Значениями столбца employeeID
            
            using (SqlCommand cmd = new SqlCommand(string.Format("SELECT * FROM Employee"), db.getConnection()))
            {
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    list.Add((int)dr["employeeID"]);
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
            string sql = string.Format("INSERT INTO Employee" +
                "(employeeID, employeeFIO, employeePosition) Values" +
                "('{0}', '{1}', '{2}')", minFree, newEmplFIO, newEmplPos);

            //выполнить sql-оператор с применением нашего подключения
            using (SqlCommand cmd = new SqlCommand(sql, db.getConnection()))
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Сотрудник добавлен в базу данных");
            }
            db.CloseConnection();
        } //addEmployee()

        public bool deleteEmployee(ulong idDelEmpl)
        {
            bool b = false;
            int idEmplInSale = -1; //сщтрудники в таблице Sale
            //соединяемса с БД
            DB db = new DB();
            db.OpenConnection();
            //в адаптере строки из таблицы Employee
            SqlDataAdapter adapt = new SqlDataAdapter("SELECT * FROM Employee", db.getConnection());
            SqlDataAdapter adaptSale = new SqlDataAdapter("SELECT * FROM Sale", db.getConnection());  //табла, где ищем, если есть - не удалять
            //ДатаСет Empl
            DataSet ds = new DataSet("Employee");
            //ДатаСет 
            ds.Tables.Add("Sale");
           // DataSet dsEmpl = new DataSet("Employee");
            //заполним датасет из адаптера
            adapt.Fill(ds, "Employee");
            adaptSale.Fill(ds, "Sale");     //пробуем в одном Датасете разместить две таблы и работать с ними

            //поиск ИД сотрудника в таблице Sale
            string sqlSale = string.Format("SELECT * FROM Sale WHERE employeeID = '{0}'", idDelEmpl);
            using (SqlCommand cmdSale = new SqlCommand(sqlSale, db.getConnection()))
            {
                SqlDataReader drSale = cmdSale.ExecuteReader();
                while (drSale.Read())
                {
                    idEmplInSale = (int)drSale["employeeID"];
                }
                drSale.Close();
            }

            if (idEmplInSale == -1) //если ИД сотрудника не найден в таблице Sale то удаляем
            {
                string sql = string.Format("DELETE FROM Employee WHERE employeeID = '{0}'", idDelEmpl.ToString());
                using (SqlCommand cmd = new SqlCommand(sql, db.getConnection()))
                {
                    try
                    {
                        string s = string.Empty;
                        s = "Сотрудник с кодом " + idDelEmpl + " удалён из базы данных";
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
            else
            {
                string s2 = "Сотрудник с кодом " + idDelEmpl + " связан с продажей(ами) и не может быть удалён!";
                MessageBox.Show(s2);
            }

            adapt.Dispose();
            adaptSale.Dispose();
            ds.Dispose();
            db.CloseConnection();
            return b;
        } //deleteEmployee()

        public string ShowListEmployee(ulong employeeId)
        {
            string str = string.Empty;
            return str;
        }

        public string SearchEmployee(ulong employeeId)
        {
            string str = string.Empty;
            return str;
        }

        
    }
}
