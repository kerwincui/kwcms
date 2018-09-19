using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using kewcms.Areas.Admin.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using kewcms.Data;
using kewcms.Services;
using Microsoft.Extensions.FileProviders;
using UEditor.Core;
using Microsoft.AspNetCore.Http;

namespace kewcms {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            //使用mysql
            services.AddDbContextPool<ApplicationDbContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("MysqlConnection")));

            //使用sqlserver
            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("MSSqlConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>(options => {
                // 配置身份选项
                // 密码强度配置
                options.Password.RequireDigit = false;//是否需要数字(0-9).
                options.Password.RequiredLength = 6;//设置密码长度最小为6
                options.Password.RequireNonAlphanumeric = false;//是否包含非字母或数字字符。
                options.Password.RequireUppercase = false;//是否需要包含大写字母(A-Z).
                options.Password.RequireLowercase = false;//是否需要包含小写字母(a-z).
                options.Password.RequiredUniqueChars = 1;//需要密码中不同字符的数目.默认为1

                // 锁定设置
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);//账户锁定时长5分钟
                options.Lockout.MaxFailedAccessAttempts = 10;//10次失败的尝试将账户锁定
                options.Lockout.AllowedForNewUsers = true;//是否锁定新用户

                // 用户注册设置
                options.User.RequireUniqueEmail = true; //是否Email地址必须唯一
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";//用户名可选字符（字母大小写+数字+（-._@+））

                // 登陆配置
                options.SignIn.RequireConfirmedEmail = false;//需要确认的电子邮件登录。默认为false。
                options.SignIn.RequireConfirmedPhoneNumber = false;//需要确认的电话号码登录。默认为false。
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            services.ConfigureApplicationCookie(options => {
                //options.Cookie.Name = "YourAppCookieName";//cookied的名称. 默认为AspNetCore.Cookies.
                options.Cookie.HttpOnly = true;//是否拒绝cookie从客户端脚本访问.默认为true.
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);//Cookie保持有效的时间60分。//TimeSpan.FromDays(150);
                options.LoginPath = "/Admin/Account/Login";//在进行登录时自动重定向。
                options.LogoutPath = "/Admin/Account/Logout";//在进行注销时自动重定向。
                //options.AccessDeniedPath = "/Account/AccessDenied"; //当用户没有授权检查时将被重定向。
                //options.SlidingExpiration = true;//当TRUE时，新cookie将在当前cookie超过到期窗口一半时发出新的到期时间。默认为true。
                // Requires `using Microsoft.AspNetCore.Authentication.Cookies;`
                //options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;//401状态改为302状态并重定向到登录路径。
            });
            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddMvc();

            //Ueditor
            services.AddUEditorService();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            //配置Ueditor静态资源文件夹
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "upload")),
                RequestPath = "/upload",
                OnPrepareResponse = ctx =>
                {
                    ctx.Context.Response.Headers.Append("Cache-Control", "public,max-age=36000");
                }
            });

            app.UseMvc(routes => {
                routes.MapRoute(
                    name: "areaname",
                    template: "{Admin:exists}/{controller=Home}/{action=Index}/{id?}"
                );
                routes.MapAreaRoute(
                    name: "admin",
                    areaName: "Admin",
                    template: "Admin/{controller=Home}/{action=Index}"
                );
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
