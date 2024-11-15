using e_commerceApp.Application.Mapping;
using e_commerceApp.Application.Configs.Payment;
using e_commerceApp.Application.Services.Implementation;
using e_commerceApp.Shared.Data;
using e_commerceApp.Shared.Models;
using e_commerceApp.Shared.Models.Auth;
using e_commerceApp.Shared.Models.Email;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Microsoft.AspNetCore.Authentication.Cookies;
using e_commerceApp.Application.Services.Interface;
using e_commerceApp.Api.Extenstions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingletonServices(builder.Configuration);

builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
{
    options.SuppressMapClientErrors = true;
});

//builder.Services.AddControllers();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
Stripe.StripeConfiguration.ApiKey = builder.Configuration.GetSection("Stripe:SecretKey").Get<string>();
app.UseHttpsRedirection();

app.UseCors("AllowAll");
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
