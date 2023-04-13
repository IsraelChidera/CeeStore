using CeeStore.DAL.Entities;
using CeeStore.Extension;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace CeeStore
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
            builder.Services.ConfigureCors();
            builder.Services.ConfigureIISIntegration();
            builder.Services.ConfigureLoggerService();
            builder.Services.ConfigureSqlContext(builder.Configuration);
            builder.Services.AddAuthentication();
            builder.Services.ConfigureIdentity();
            builder.Services.ConfigureServices();
            builder.Services.AddAutoMapper(Assembly.Load("CeeStore.BLL"));
            builder.Services.ConfigureJWT(builder.Configuration);
            //grants super admin access to all routes
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("SuperAdminPolicy", policy =>
                    policy.RequireRole("SuperAdmin"));
            });

            //Adding content negotiation
            /*builder.Services.AddControllers(config =>
            {
                config.RespectBrowserAcceptHeader = true;
            }).AddXmlDataContractSerializerFormatters();*/

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                //c.EnableAnnotations();
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cee store", Version = "v1" });


                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description =
                        "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\""
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    },
                });
            });
            // Add services to the container.
            builder.Services.AddHttpContextAccessor();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            
            // Create the SuperAdmin role and user
            using var scope = app.Services.CreateScope();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

            //bool superAdminRoleExists = await roleManager.RoleExistsAsync("SuperAdmin");

            /*if (!superAdminRoleExists)
            {
                // Create the SuperAdmin role
                if (!await roleManager.RoleExistsAsync("SuperAdmin"))
                {
                    await roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
                }

                // Create the SuperAdmin user with the role
                var superAdmin = new AppUser
                {
                    UserName = "SuperAdminIsrael",
                    Email = "superadmin@example.com"
                };
                var result = await userManager.CreateAsync(superAdmin, "SuperAdminPassword1@");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(superAdmin, "SuperAdmin");
                }
            }

            */

            await app.RunAsync();
        }
    }
}