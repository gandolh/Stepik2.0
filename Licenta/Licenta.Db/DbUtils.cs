using Npgsql;
using NpgsqlTypes;

namespace Licenta.Db
{
    public static class DbUtils
    {

        public static object? GetDatabase(NpgsqlConnection connection, string database)
        {
            using NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = $"SELECT 1 FROM pg_database WHERE datname = '{database}'";

            // Execute the SQL command and check if a result is returned
            object? result = cmd.ExecuteScalar();
            return result;
        }

        internal static void CreateDb(NpgsqlConnection connection, string database)
        {
            using NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = connection;

            // Use a parameterized query to set the database name dynamically
            cmd.CommandText = $"CREATE DATABASE {database}";

            // Execute the SQL command to create the database
            cmd.ExecuteNonQuery();
        }

        internal static void DropDb(NpgsqlConnection connection, string database)
        {
            using NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = connection;

            // Use a parameterized query to set the database name dynamically
            cmd.CommandText = $"DROP DATABASE {database}";

            // Execute the SQL command to create the database
            cmd.ExecuteNonQuery();
        }

        internal static bool TableExists(NpgsqlCommand command, string tableName)
        {
            // Use a SQL query to check if the table exists in the database.
            command.CommandText = "SELECT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_name = @tableName)";
            command.Parameters.AddWithValue("@tableName", NpgsqlDbType.Text, tableName);

            // Execute the query and retrieve the result.
            bool tableExists = (bool?)command.ExecuteScalar() ?? false;

            return tableExists;
        }
    }
}
