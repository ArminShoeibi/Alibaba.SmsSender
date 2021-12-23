using System.Text.Encodings.Web;
using System.Text.Json;
using Alibaba.SmsSender.API.BackgroundServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Logging.ClearProviders();
builder.Logging.AddJsonConsole(jsonConsoleFormatterOptions =>
{
    jsonConsoleFormatterOptions.JsonWriterOptions = new JsonWriterOptions
    {
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
    };
});

builder.Services.AddHostedService<SMSSenderBackgroundService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.MapControllers();

app.Run();
