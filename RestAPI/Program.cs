using Microsoft.EntityFrameworkCore;
using RestAPI.Model.restDbContext;
using RestAPI.Servicos;
using RestAPI.Servicos.Implementacoes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var connection = builder.Configuration["SqlConnection:SqlConnectionString"];
builder.Services.AddDbContext<rest_api_db_context>(options => options.UseSqlServer(connection));
builder.Services.AddScoped<IPessoaService, PessoaServiceImplementation>();

builder.Services.AddApiVersioning();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();