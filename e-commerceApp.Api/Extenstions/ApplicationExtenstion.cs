using e_commerceApp.Application.Configs.Payment;
using e_commerceApp.Application.Mapping;
using e_commerceApp.Application.Services.Implementation;
using e_commerceApp.Application.Services.Interface;
using e_commerceApp.Shared.Data;
using e_commerceApp.Shared.Models.Auth;
using e_commerceApp.Shared.Models.Email;
using e_commerceApp.Shared.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace e_commerceApp.Api.Extenstions
{
    public static class ApplicationExtenstion
    {
        public static void AddSingletonServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddEndpointsApiExplorer();
            serviceCollection.AddSwaggerGen(c =>
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

            serviceCollection.AddDistributedMemoryCache();

            //serviceCollection.AddControllers().AddJsonOptions(options =>
            //{
            //    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
            //    options.JsonSerializerOptions.MaxDepth = 32; 
            //});
            serviceCollection.Configure<StripeSettings>(configuration.GetSection("Stripe"));

            serviceCollection.AddAutoMapper(typeof(MappingConfig));

            var emailConfig = configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>();
            serviceCollection.AddSingleton(emailConfig);
            serviceCollection.AddScoped<IEmailService, EmailService>();

            serviceCollection.AddScoped<ITokenService, TokenService>();
            serviceCollection.AddScoped<IUserService, UserService>();
            serviceCollection.AddScoped<IPaymentService, PaymentService>();

            serviceCollection.Configure<IdentityOptions>(
                options => options.SignIn.RequireConfirmedEmail = false);

            serviceCollection.Configure<PayPalSettings>(configuration.GetSection("PayPal"));
            serviceCollection.AddScoped<IProductService, ProductService>();
            serviceCollection.AddScoped<IOrderService, OrderService>();
            serviceCollection.AddScoped<ShoppingCartService>();
            serviceCollection.AddScoped<ICategoryService, CategoryService>();
            serviceCollection.AddScoped<IEmployeeService, EmployeeService>();


            //builder.Services.AddScoped(u => ShoppingCartService.GetShoppingCart(u));
            //services.AddHttpContextAccessor();
            serviceCollection.AddMemoryCache();
            serviceCollection.AddDistributedMemoryCache(); 
            serviceCollection.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(60);
                options.Cookie.HttpOnly = true; 
            });
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            serviceCollection.AddDbContext<EcommDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Default"),
                sqlOption => sqlOption.EnableRetryOnFailure(50)
                ));

            serviceCollection.AddIdentity<User, Role>(opt => {
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.User.RequireUniqueEmail = true;
            })
              .AddEntityFrameworkStores<EcommDbContext>()
              .AddDefaultTokenProviders();


            serviceCollection.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
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
            serviceCollection.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder => builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });
            var apiBaseUrl = configuration.GetValue<string>("ApiSettings:BaseUrl");
            serviceCollection.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                    policy.WithOrigins(apiBaseUrl)  
                          .AllowAnyHeader()
                          .AllowAnyMethod());
            });
        }
    }
}
