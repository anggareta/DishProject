using Blazored.LocalStorage;
using Blazored.Toast;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RestoProject.Client.Services.CategoryService;
using RestoProject.Client.Services.DishService;
using RestoProject.Client.Services.CartService;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IDishService, DishService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazoredToast();

await builder.Build().RunAsync();
