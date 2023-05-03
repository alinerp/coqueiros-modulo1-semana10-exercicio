using Microsoft.EntityFrameworkCore;
using locadoraDeCarros.Data;
using locadoraDeCarros.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
      .ConfigureApiBehaviorOptions(options => { options.SuppressModelStateInvalidFilter = true; })
      .AddJsonOptions(options =>
      {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
      });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Connection String - conecta o banco de dados
string connectionString = "Server=LAPTOP-JCQ6MH09\\SQLEXPRESS01;Database=locadoraDeCarros;Trusted_Connection=True;TrustServerCertificate=True;";

//Ingection da conexão do EF
builder.Services.AddDbContext<LocacaoContext> (options => options.UseSqlServer(connectionString));

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
