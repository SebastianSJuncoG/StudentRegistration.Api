using Microsoft.EntityFrameworkCore;
using StudentRegistration.Data.DAL;
using StudentRegistration.Data.Interfaces;
using StudentRegistration.Data.Models;
using StudentRegistration.Services.Implementations;
using StudentRegistration.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<StudentRegistrationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Configuración de Cors
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// Capa de datos
builder.Services.AddScoped<IStudentsRepository, StudentDAL>();
builder.Services.AddScoped<IProgramRepository, ProgramDAL>();
builder.Services.AddScoped<IUsersLoginRepository, UserDAL>();
builder.Services.AddScoped<ISubjectRepository, SubjectDAL>();

// Capa de servicio
builder.Services.AddScoped<IStudentsService, StudentService>();
builder.Services.AddScoped<IProgramService, ProgramService>();
builder.Services.AddScoped<IUsersLoginService, UserLoginService>();
builder.Services.AddScoped<ISubjectService, SubjectService>();

// Servicios para el Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();
    // Para habilitar el Swagger
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
