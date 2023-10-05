using Licenta.Runner;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddHostedService<RunnerService>();

var host = builder.Build();
host.Run();
