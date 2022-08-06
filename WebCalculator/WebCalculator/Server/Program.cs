global using Microsoft.EntityFrameworkCore;
global using WebCalculator.Server.Services.Interfaces;
global using WebCalculator.Server.Services;
global using WebCalculator.Server.Services.Internals.Interfaces;
global using WebCalculator.Server.Services.Internals;
global using WebCalculator.Shared;
global using WebCalculator.Shared.Responses;
using NLog;
using NLog.Web;
using Microsoft.AspNetCore.ResponseCompression;
using WebCalculator.Server.Data;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Entity framework
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Services
builder.Services.AddScoped<ICalculationService, CalculationService>();
    
    // Internals
builder.Services.AddScoped<ICalculationServiceInternal, CalculationServiceInternal>();


// NLog
builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Information);
builder.Host.UseNLog();


// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Swagger
    app.UseSwaggerUI();
    app.UseSwagger();

    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
