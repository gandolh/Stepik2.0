using Npgsql;
using System.Data;
using System.Data.Common;
using System.Data.SqlTypes;

namespace Licenta.Db
{
    public static class DbUtils
    {

        public static object? GetDatabase(NpgsqlConnection connection, string database)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                cmd.Connection = connection;
                cmd.CommandText = $"SELECT 1 FROM pg_database WHERE datname = '{database}'";

                // Execute the SQL command and check if a result is returned
                object? result = cmd.ExecuteScalar();
                return result;
            }
        }

        internal static void CreateDb(NpgsqlConnection connection, string database)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand())
            {
                cmd.Connection = connection;

                // Use a parameterized query to set the database name dynamically
                cmd.CommandText = "CREATE DATABASE :databaseName";

                // Add a parameter to the query
                cmd.Parameters.AddWithValue("databaseName", database);

                // Execute the SQL command to create the database
                cmd.ExecuteNonQuery();

            }
        }
    }
}
