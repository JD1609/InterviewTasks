global using WebCalculator.Client.Services.Interfaces;
global using WebCalculator.Client.Services;
global using WebCalculator.Shared;
global using WebCalculator.Shared.Responses;
global using WebCalculator.Shared.Requests;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WebCalculator.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Services
builder.Services.AddScoped<ICalculationService, CalculationService>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
