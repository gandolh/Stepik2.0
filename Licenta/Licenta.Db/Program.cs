using Licenta.Db;
using Licenta.Db.Seeder;
using Licenta.Db.Seeder.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

internal class Program
{
    private static async Task Main(string[] args)
    {
        IConfiguration configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        .AddCommandLine(args)
        .Build();
        IDatabaseConnectionSettings settings = new DatabaseConnectionSettings();
        configuration.GetSection("Database").Bind(settings);
        IDbFactory dbFactory = new NpgsqlDbFactory(settings);
        dbFactory.Context().Open();
        var transaction = dbFactory.Context().BeginTransaction();
        IDapperDbClient dbClient = new DapperDbClient(dbFactory, transaction);
        DataSeeder dataSeed = new DataSeeder(dbClient);
        await dataSeed.Seed();
        Console.WriteLine("Starting");
        Console.WriteLine("Done");
    }
}