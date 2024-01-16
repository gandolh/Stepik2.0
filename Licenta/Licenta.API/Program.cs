using Licenta.API.Services;

static void ConfigureDI(IServiceCollection services)
{
    services.AddScoped<CourseService>();
    services.AddScoped<ExerciseService>();
    services.AddScoped<LessonService>();
    services.AddScoped<StudentService>();
    services.AddScoped<SubmissionService>();
    services.AddScoped<TeacherService>();

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
