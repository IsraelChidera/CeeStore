using CeeStore.BLL.Services;
using CeeStore.BLL.ServicesContract;
using CeeStore.DAL;
using CeeStore.DAL.Entities;
using CeeStore.DAL.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using IAuthenticationService = CeeStore.BLL.ServicesContract.IAuthenticationService;

namespace CeeStore.Extension
{
    public static class ServiceExtension
    {
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentity<AppUser, IdentityRole>(opt =>
            {
                opt.Password.RequiredLength = 8;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireDigit = true;
                opt.Password.RequireUppercase = true;
                opt.User.RequireUniqueEmail = true;
                opt.Password.RequireLowercase = false;
            })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

        }

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(
                opts => opts.UseSqlServer(configuration.GetConnectionString("DefaultConn"),
                optss => optss.EnableRetryOnFailure()
            ));
        }

        /*optionsBuilder.UseSqlServer(connectionString, options =>
    options.EnableRetryOnFailure());*/

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork<AppDbContext>>();
            services.AddTransient<IAuthenticationService, BLL.Services.AuthenticationService>();            
            services.AddTransient<IProductService, ProductService>();
        }

        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });
        }

        public static void ConfigureIISIntegration(this IServiceCollection services) =>
        services.Configure<IISOptions>(options =>
        {

        });


        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }


        public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
        {
            //save your secret keys in an environment variable rather than in code
            //using the statememnt below.
            //open the cmd window as an administrator
            //This is going to create a system environment variable
            //setx REPORTAPISECRET "ReportAPISecretKey" /M
            var jwtSettings = configuration.GetSection("JwtSettings");
            var secretKey = Environment.GetEnvironmentVariable("SECRET") ?? "Fk24632Pz3gyJLYeYqJ6D8qELyNPUubr8vstypCgfMAC8Jyb3B";

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(opts =>
                {
                    opts.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSettings["validIssuer"],
                        ValidAudience = jwtSettings["validAudience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                    };
                });


        }
    }
}
