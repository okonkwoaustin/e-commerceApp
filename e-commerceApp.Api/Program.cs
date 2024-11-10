using e_commerceApp.Application.Mapping;
using e_commerceApp.Application.Configs.Payment;
using e_commerceApp.Application.Services.Implementation;
using e_commerceApp.Application.Services.Interface;
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

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
{
    options.SuppressMapClientErrors = true;
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "E-Commerce App", Version = "v1" });

    //c.AddServer(new OpenApiServer { Url = "" });

    var securitySchema = new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer schema. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        }
    };
    c.AddSecurityDefinition("Bearer", securitySchema);
    var securityRequirement = new OpenApiSecurityRequirement();
    securityRequirement.Add(securitySchema, new[] { "Bearer" });
    c.AddSecurityRequirement(securityRequirement);
});

var services = builder.Services;
var configuration = builder.Configuration;

services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));

builder.Services.AddAutoMapper(typeof(MappingConfig));
//Add email configuration
var emailConfig = configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>();
services.AddSingleton(emailConfig);
services.AddScoped<IEmailService, EmailService>();

services.AddScoped<ITokenService, TokenService>();
services.AddScoped<IUserService, UserService>();
services.AddScoped<IPaymentService, PaymentService>();


//Add config for Required email
services.Configure<IdentityOptions>(
    options => options.SignIn.RequireConfirmedEmail = false);

services.Configure<PayPalSettings>(configuration.GetSection("PayPal"));
services.AddScoped<IProductService, ProductService>();
services.AddScoped<IOrderService, OrderService>();
services.AddScoped<IShoppingCartService, ShoppingCartService>();
services.AddScoped<ICategoryService, CategoryService>();
services.AddScoped<IEmployeeService, EmployeeService>();
services.AddHttpContextAccessor();

services.AddDbContext<EcommDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Default"),
    sqlOption => sqlOption.EnableRetryOnFailure(50)
    ));

services.AddIdentity<User, Role>(opt => {
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequireDigit = false;
    opt.Password.RequireLowercase = false;
    opt.Password.RequireUppercase = false;
    opt.User.RequireUniqueEmail = true;
})
  .AddEntityFrameworkStores<EcommDbContext>()
  .AddDefaultTokenProviders();

services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ClockSkew = TimeSpan.Zero,
            ValidIssuer = configuration["Authentication:JwtBearer:Issuer"],
            ValidAudience = configuration["Authentication:JwtBearer:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Authentication:JwtBearer:SecretKey"]))

        };
    });
//services.AddCors(options =>
//{
//    options.AddPolicy("AllowAll",
//        builder => builder
//            .AllowAnyOrigin()
//            .AllowAnyMethod()
//            .AllowAnyHeader());
//});
var apiBaseUrl = builder.Configuration.GetValue<string>("ApiSettings:BaseUrl");
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.WithOrigins(apiBaseUrl)  // Allow requests from Blazor Server
              .AllowAnyHeader()
              .AllowAnyMethod());
});

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
