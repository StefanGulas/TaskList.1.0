using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace TaskListV2.DataAccess
{
    public class HelperDataAccess
    {
        public static IDbConnection Conn()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionToSql"].ConnectionString);

        }
    }
}

