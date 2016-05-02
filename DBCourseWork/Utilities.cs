using System.Data.SqlClient;

namespace DBCourseWork
{
    public static class Utilities
    {
        public static string ConnectionStringBuilder(string userId, string password)
        {
            var connStr = new SqlConnectionStringBuilder
            {
                ApplicationName = "DBCourseWork",
                Password = password,
                UserID = userId,
                MultipleActiveResultSets = true,
                DataSource = "ANDREW-ON-FIRE",
                InitialCatalog = "BookStoreDb",
                IntegratedSecurity = true
            };
            return connStr.ConnectionString;
        }


    }
}