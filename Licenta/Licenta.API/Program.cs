using Licenta.API;
using Licenta.API.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterServices();

var app = builder.Build();

app.RegisterMiddlewares();

app.RegisterCoursesEndpoints();

app.Run();