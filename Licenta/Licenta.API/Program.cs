using Licenta.API.Services;
using Licenta.Db.Repositories;
using Licenta.Db.Seeder;
using Licenta.Db.Seeder.Interfaces;

static void ConfigureDI(IServiceCollection services)
{
    services.AddSingleton<IDatabaseConnectionSettings, DatabaseConnectionSettings>();
    services.AddSingleton<IDbFactory, NpgsqlDbFactory>();
    services.AddScoped<IDapperDbClient, DapperDbClient>();

    // services
    services.AddScoped<CourseService>();
    services.AddScoped<ExerciseService>();
    services.AddScoped<LessonService>();
    services.AddScoped<StudentService>();
    services.AddScoped<SubmissionService>();
    services.AddScoped<TeacherService>();


    // repositories
    services.AddScoped<CourseRepository>();
    services.AddScoped<ExerciseRepository>();
    services.AddScoped<LessonRepository>();
    services.AddScoped<StudentRepository>();
    services.AddScoped<SubmissionRepository>();
    services.AddScoped<TeacherRepository>();

}




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => { c.EnableAnnotations(); });
ConfigureDI(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
