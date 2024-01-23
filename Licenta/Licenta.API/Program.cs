using Licenta.API.Services;
using Licenta.Db.Repositories;
using Licenta.Db.Seeder;
using Licenta.Db.Seeder.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

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
    services.AddScoped<AccountService>();
    services.AddScoped<CodeEvaluationEntryService>();
    services.AddScoped<ModuleService>();
    services.AddScoped<QuizVariantService>();


    // repositories
    services.AddScoped<CourseRepository>();
    services.AddScoped<ExerciseRepository>();
    services.AddScoped<LessonRepository>();
    services.AddScoped<StudentRepository>();
    services.AddScoped<SubmissionRepository>();
    services.AddScoped<TeacherRepository>();
    services.AddScoped<UserRepository>();
    services.AddScoped<CodeEvalEntryRepository>();
    services.AddScoped<ModuleRepository>();
    services.AddScoped<QuizVariantsRepository>();

}




var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
// Add services to the container.

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidIssuer = config["Jwt:Issuer"],
        ValidAudience = config["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey
            (Encoding.UTF8.GetBytes(config["Jwt:Key"]!)),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true
    };
}).AddCookie("Cookies");


builder.Services.AddAuthorization();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => { 
    c.EnableAnnotations();
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement{{
                        new OpenApiSecurityScheme { Reference = new OpenApiReference {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }},
                        Array.Empty<string>()
                    }
                });
});
ConfigureDI(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
