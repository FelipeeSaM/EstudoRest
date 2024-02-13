using Microsoft.EntityFrameworkCore;
using RestAPI.Model.restDbContext;
using RestAPI.Business;
using RestAPI.Business.Implementacoes;
using RestAPI.Repository;
using RestAPI.Repository.Implementacoes;
using RestAPI.Repository.Generic;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Rewrite;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1",
        new OpenApiInfo {
            Title = "Estudando Rest",
            Version = "v1",
            Description = "Curso: https://www.udemy.com/course/restful-apis-do-0-a-nuvem-com-aspnet-core-e-docker",
            Contact = new OpenApiContact {
                Name = "Felipe",
                Url = new Uri ("https://github.com/FelipeeSaM")
            }
        }
    );
});

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

#region swagger
app.UseSwagger();
app.UseSwaggerUI(c => {
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "swagger endpoints nome");
});
var option = new RewriteOptions();
option.AddRedirect("^$", "swagger");
app.UseRewriter(option);
app.UseAuthentication();
#endregion

app.UseAuthorization();

app.MapControllers();

app.Run();