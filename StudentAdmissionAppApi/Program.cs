using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using StudentAdmissionAppApi.Data.Contract;
using StudentAdmissionAppApi.Data.Implementation;
using StudentAdmissionAppApi.Models;
using StudentAdmissionAppApi.Service.Contract;
using StudentAdmissionAppApi.Service.Implementation;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(policy =>
{
    policy.AddPolicy("AllowStudentAdmissionMVC", builder =>
    {
        builder.WithOrigins("http://localhost:5159")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

// Add services to the container.

builder.Services.AddControllers();

//Database Connection
builder.Services.AddDbContextPool<AppDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("mydb"));
});


builder.Services.AddScoped<IStageService, StageService>();
builder.Services.AddScoped<IStandardService, StandardService>();
builder.Services.AddScoped<IStudentService,StudentService>();


builder.Services.AddScoped<IStageRepository, StageRepository>();
builder.Services.AddScoped<IStandardRepository, StandardRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors("AllowStudentAdmissionMVC");
app.UseAuthorization();

app.MapControllers();

app.Run();
