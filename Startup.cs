/*
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNet.OData.Builder;
using JwtAuthForBooks.Models;
using System.Text;

namespace YourProjectNamespace
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // JWT Authentication ekleyin
            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "your_issuer",
                        ValidAudience = "your_audience",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your_secret_key"))
                    };
                });

            // OData ekleyin
            services.AddOData(options =>
            {
                options.AddModel("odata", builder =>
                {
                    builder.EntitySet<Book>("Books");
                    builder.EntitySet<BookInformation>("BookInformations");
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapODataRoute("odata", "odata", GetEdmModel());
            });
        }

        private IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            // Entity türlerinizi burada tanımlayın
            builder.EntitySet<Book>("Books");
            builder.EntitySet<BookInformation>("BookInformations");

            return builder.GetEdmModel();
        }
    }
}
*/


using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using JwtAuthForBooks.Models;
using Microsoft.OData.Edm;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNet.OData.Builder;
using System;
using Microsoft.AspNetCore.Identity;
using JwtAuthForBooks.IdentityModels;

namespace JwtAuthForBooks
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            //services.AddScoped<IBookService, BookService>();
            // Veritabanı ve servis bağımlılıklarını ekleyin
            services.AddDbContext<YourDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
            


            services.AddIdentity<UserLoginRequest, UserRoles>(options =>
            {
                 // Kullanıcı adı, e-posta doğrulama ve benzeri ayarları burada yapılandırabilirsiniz.
                options.User.AllowedUserNameCharacters = "abcçdefgğhiıjklmnoöpqrsştuüvwxyzABCÇDEFGĞHIİJKLMNOÖPQRSŞTUÜVWXYZ0123456789-";
                options.User.RequireUniqueEmail = true;

                //  şifre gereksinimleri gibi Identity ayarlarını burada yapılandırabilirsiniz.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequiredLength = 8;



                // Oturum ayarlarını yapabilirsiniz.
                options.SignIn.RequireConfirmedAccount = true;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            })

            .AddEntityFrameworkStores<YourDbContext>()
            .AddRoleManager<RoleManager<UserRoles>>()
            .AddDefaultTokenProviders();






            // JWT Authentication ekleyin
            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "your_issuer",
                        ValidAudience = "your_audience",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your_secret_key"))
                    };
                });

            // OData ekleyin ve yapılandırın
            services.AddControllers().AddOData(options =>
            {
                var builder = new ODataConventionModelBuilder();
                builder.EntitySet<BookInformations>("Book");
                options.AddRouteComponents("odata", builder.GetEdmModel());
            });

            


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

           app.UseAuthentication();
            app.UseAuthorization();

            // OData yönlendiricisini ekleyin
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }


    }
}
