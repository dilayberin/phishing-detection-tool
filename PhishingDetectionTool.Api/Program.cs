using PhishingDetectionTool.Application.Interfaces;
using PhishingDetectionTool.Application.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IPhishingAnalyzerService, PhishingAnalyzerService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Phishing Detection API");
    options.RoutePrefix = string.Empty;
});

app.MapControllers();

app.Run();