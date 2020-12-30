using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace TaskListV2.DataAccessNew
{
    public static class HelperDataAccess
    {
        public static IDbConnection ConnSql(string connectionString)
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings[connectionString].ConnectionString);

        }
    public static IDbConnection ConnSQLite(string connectionString)
    {
      return new SQLiteConnection(ConfigurationManager.ConnectionStrings[connectionString].ConnectionString);

    }
  }
}

