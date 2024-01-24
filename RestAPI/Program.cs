using Microsoft.EntityFrameworkCore;
using RestAPI.Model.restDbContext;
using RestAPI.Business;
using RestAPI.Business.Implementacoes;
using RestAPI.Repository;
using RestAPI.Repository.Implementacoes;
using RestAPI.Repository.Generic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var connection = builder.Configuration["SqlConnection:SqlConnectionString"];
builder.Services.AddDbContext<rest_api_db_context>(options => options.UseSqlServer(connection));
builder.Services.AddScoped<IPessoaBusiness, PessoaBusinessImplementation>();
//builder.Services.AddScoped<IPessoaRepository, PessoaRepositoryImplementation>();
builder.Services.AddScoped<ILivroBusiness, LivroBusinessImplementation>();
//builder.Services.AddScoped<ILivrosRepository, LivrosRepositoryImplementation>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddApiVersioning();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();