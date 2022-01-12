using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Skylark.Models;
using Skylark.Security;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using ReflectionIT.Mvc.Paging;
using Microsoft.Extensions.Hosting;

namespace Skylark
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddScoped<Security.ISignInManager, Security.SignInManager>();
            services.AddScoped<Security.IAuthenticationService, LdapAuthenticationService>();

            services.AddDbContext<SkylarkDBContext>(options => options.UseNpgsql(Configuration.GetConnectionString("SkylarkDBContext")));

            services.AddIdentity<User, Role>(options =>
            {
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_\\";
            }).AddEntityFrameworkStores<SkylarkDBContext>();

            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/Home/AccessDenied";
                options.Cookie.Name = CookieAuthenticationDefaults.AuthenticationScheme;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.LoginPath = "/UserAccounts/Login";
                options.SlidingExpiration = true;
            });

            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
            {
                options.LoginPath = new PathString("/UserAccounts/Login");
                options.AccessDeniedPath = new PathString("/UserAccounts/AccessDenied");
            });

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddRazorPages();

            services.AddPaging(options => {
                options.ViewName = "Bootstrap4";
                options.HtmlIndicatorDown = " <span>&darr;</span>";
                options.HtmlIndicatorUp = " <span>&uarr;</span>";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider ServiceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
                //app.UseXXssProtection(options => options.EnabledWithBlockMode());
                //app.UseXContentTypeOptions();
                //app.UseXfo(options => options.Deny());
                app.Use(async (ctx, next) =>
                {
                    ctx.Request.GetTypedHeaders().CacheControl = new Microsoft.Net.Http.Headers.CacheControlHeaderValue()
                    {
                        NoCache = true
                    };

                    ctx.Response.Headers[Microsoft.Net.Http.Headers.HeaderNames.Vary] = new string[] { "Accept-Encoding" };

                    await next();
                });
            }

            var cultureInfo = new CultureInfo("en-ZA");
            cultureInfo.NumberFormat.CurrencySymbol = "R";
            cultureInfo.NumberFormat.NumberDecimalSeparator = ".";
            cultureInfo.NumberFormat.NumberGroupSeparator = ",";
            cultureInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            cultureInfo.NumberFormat.CurrencyGroupSeparator = ",";
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            app.UseCookiePolicy();
            CreateRoles(ServiceProvider).Wait();
        }

        private async Task CreateRoles(IServiceProvider serviceProvider)
        {
            //adding customs roles : Question 1
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<Role>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<User>>();
            string[] roleNames = { "Admin", "User" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    //create the roles and seed them to the database: Question 2
                    roleResult = await RoleManager.CreateAsync(new Role(roleName));
                }
            }

            //Here you could create a super user who will maintain the web app
            User poweruser = new User
            {
                UserName = "ABZM583",
                Logon = "ABZM583",
                Email = "Zakes.Manyoni@absa.africa",
                EmailConfirmed = true
            };

            string userPWD = "$Kylark#202";
            User _user = await UserManager.FindByNameAsync("ABZM583");

            if (_user == null)
            {
                IdentityResult createPowerUser = await UserManager.CreateAsync(poweruser, userPWD);
                if (createPowerUser.Succeeded)
                {
                    //here we tie the new user to the role : Question 3
                    await UserManager.AddToRoleAsync(poweruser, "Admin");

                }
            }
        }
    }
}
