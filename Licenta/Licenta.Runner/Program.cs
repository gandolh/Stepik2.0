using Licenta.Runner;

var builder = Host.CreateApplicationBuilder(args);

IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables()
    .AddCommandLine(args)
    .Build();


builder.Services.AddSingleton(configuration);
builder.Services.AddSingleton<RunnerConfig, RunnerConfig>();

builder.Services.AddHostedService<RunnerService>();

var host = builder.Build();
host.Run();

