using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace TaskListV2.DataAccessNew
{
    public static class HelperDataAccess
    {
        public static IDbConnection Conn(string connectionString)
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings[connectionString].ConnectionString);

        }
    }
}

