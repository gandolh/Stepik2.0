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
        Console.WriteLine("Starting");
        
        IConfiguration configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        .AddCommandLine(args)
        .Build();
        IDatabaseConnectionSettings settings = new DatabaseConnectionSettings();
        configuration.GetSection("Database").Bind(settings);

        DataSeeder dataSeed = new DataSeeder(settings);
        await dataSeed.Seed();

        Console.WriteLine("Done");
    }
}