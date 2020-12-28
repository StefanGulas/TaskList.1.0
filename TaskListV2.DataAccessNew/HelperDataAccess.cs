using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace TaskListV2.DataAccessNew
{
    public static class HelperDataAccess
    {
        public static IDbConnection Conn(string connectionString)
        {
            return new SQLiteConnection(ConfigurationManager.ConnectionStrings[connectionString].ConnectionString);

        }
    }
}

