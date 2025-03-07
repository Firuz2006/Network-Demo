using Npgsql;

internal static class Program
{
    private static void Main()
    {
        const string connectionString = "Host=localhost;Username=postgres;Password=run3d;Database=postgres";// port=5432

        var databases = new List<string>();

        using (var connection = new NpgsqlConnection(connectionString))
        {
            try
            {
                connection.Open();

                using var command = new NpgsqlCommand("SELECT datname FROM pg_database", connection);
                using var reader = command.ExecuteReader();
                while (reader.Read()) databases.Add(reader.GetString(0));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        foreach (var db in databases) Console.WriteLine(db);
    }
}