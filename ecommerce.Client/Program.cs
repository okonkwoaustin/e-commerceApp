using e_commerceApp.Application.Services.Implementation;
using e_commerceApp.Application.Services.Interface;
using e_commerceApp.Shared.Data;
using ecommerce.Client.Components;
using ecommerce.Client.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddMudServices();


var apiBaseUrl = builder.Configuration.GetValue<string>("ApiSettings:BaseUrl");

// Register HttpClient to interact with your Web API
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiBaseUrl) });
builder.Services.AddHttpClient();


//builder.Services.AddHttpClient("ApiClient", client =>
//{
//    client.BaseAddress = new Uri("https://localhost:7141");
//});
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
//builder.Services.AddScoped<IEmployeeServices, EmployeeServices>();

builder.Services.AddDbContext<EcommDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default"),
    sqlOption => sqlOption.EnableRetryOnFailure(50)
    ));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
