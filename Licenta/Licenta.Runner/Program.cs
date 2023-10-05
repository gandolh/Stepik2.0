using Licenta.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var config = new ConfigurationBuilder()
       .SetBasePath(Directory.GetCurrentDirectory())
       .AddJsonFile("config.json", optional: true)
       .Build();

var builder = new HostBuilder()
          .ConfigureServices(services =>
             services.AddHostedService<KafkaListener>());


var host = builder.Build();

host.Run();
