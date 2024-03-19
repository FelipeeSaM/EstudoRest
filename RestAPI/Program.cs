using Microsoft.EntityFrameworkCore;
using RestAPI.Model.restDbContext;
using RestAPI.Business;
using RestAPI.Business.Implementacoes;
using RestAPI.Repository;
using RestAPI.Repository.Implementacoes;
using RestAPI.Repository.Generic;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Rewrite;
using RestAPI.Configurations.ServicesToken;
using RestAPI.Configurations.ServicesToken.Implementations;
using RestAPI.Configurations;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection.Extensions;
using BenchmarkDotNet.Running;

var builder = WebApplication.CreateBuilder(args);
var summary = BenchmarkRunner.Run<TestandoBenchMark>();
// Add services to the container.
#region jwt
var tokenConfigs = new TokenConfiguration();
new ConfigureFromConfigurationOptions<TokenConfiguration>(builder.Configuration.GetSection("TokenConfigurations")).Configure(tokenConfigs);
builder.Services.AddSingleton(tokenConfigs);

builder.Services.AddCors(options => options.AddDefaultPolicy(builder => {
    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
}));

builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options => {
    options.TokenValidationParameters = new TokenValidationParameters {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = tokenConfigs.Issuer,
        ValidAudience = tokenConfigs.Audiencia,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenConfigs.Segredo))
    };
});

builder.Services.AddAuthorization(auth => {
    auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
        .RequireAuthenticatedUser().Build());
});
#endregion

builder.Services.AddControllers();

#region swagger
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
#endregion

var connection = builder.Configuration["SqlConnection:SqlConnectionString"];
builder.Services.AddDbContext<rest_api_db_context>(options => options.UseSqlServer(connection));
builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddScoped<IPessoaBusiness, PessoaBusinessImplementation>();
//builder.Services.AddScoped<IPessoaRepository, PessoaRepositoryImplementation>();
builder.Services.AddScoped<IPessoaRepository, PessoaRepository>();
builder.Services.AddScoped<ILivroBusiness, LivroBusinessImplementation>();
builder.Services.AddScoped<IArquivoBusiness, ArquivoBusinessImplementation>();
//builder.Services.AddScoped<ILivrosRepository, LivrosRepositoryImplementation>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddScoped<ILoginBusiness, LoginBusinessImplementation>();
builder.Services.AddTransient<ITokenService, TokenService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddApiVersioning();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseCors();

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