using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Komfort_1
{
    class DB
    {
        SqlConnection sqlCn = null;
        string connStr = @"Data Source=(local)\SQLEXPRESS;Initial Catalog = KomfortBD; Integrated Security = True; Pooling=False";

        //открывает подключение
        public void OpenConnection()
        {
            //правильно ли сформирована строка подключения
            sqlCn = new SqlConnection();
            sqlCn.ConnectionString = connStr;
            sqlCn.Open();
        }

        //закрывает подключение
        public void CloseConnection()
        {
            sqlCn.Close();
        }

        //
        public SqlConnection getConnection()
        {
            return sqlCn;
        }

    }
}
