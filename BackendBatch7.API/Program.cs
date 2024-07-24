using BackendBatch7.API.Installers;
using Serilog;
using Serilog.Formatting.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.InstallerServiceInAssembly(builder.Configuration);

builder.Host.UseSerilog((ctx, config) =>
{
    config.WriteTo.File(
         path: AppDomain.CurrentDomain.BaseDirectory + "logs/log-.txt",
         rollingInterval: RollingInterval.Day,
         rollOnFileSizeLimit: true,
         formatter: new JsonFormatter()).MinimumLevel.Information();
});

var app = builder.Build();
app.UseSerilogRequestLogging();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app cors
app.UseCors("corsapp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
