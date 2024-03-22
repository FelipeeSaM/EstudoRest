using Consuming_api.Extensions;
using OpenAI_API;

var builder = WebApplication.CreateBuilder(args);
builder.AddChatGpt(/*builder.Configuration*/);
builder.AddSerilog(builder.Configuration, "Consumindo API do gpt com .net 8");

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwagger(builder.Configuration);
builder.Services.AddScoped<OpenAIAPI>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwaggerDoc();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
