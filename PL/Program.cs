using DAL.contexts;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using REPOSITORY.interfaces;
using REPOSITORY.repositers;
using SERVIES.interfaces;
using SERVIES.mapping;
using SERVIES.services;

namespace PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllersWithViews();                        //mvc

            builder.Services.AddDbContext<CompanyDbcontext> (option =>                            //register servies(dbcontext)  //to read (connection string from appsettings)
            {

                option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

            });


            /* builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();          //register service(IDepartment Repository) to inject it in (....)      .. ده لو معملتش (service layer)*/

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();                                //register service(unit of work to save changes) to inject it in (...)
            builder.Services.AddScoped<IDepartmentService, DepartmentService>();                  //register service(IDepartment service) to inject it in (....)
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            builder.Services.AddAutoMapper(x => x.AddProfile(new Employeeprofile()));        //register service (automapper)
            builder.Services.AddAutoMapper(x =>x.AddProfile(new Departmentprofile()));

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(config =>
            {
                config.Password.RequiredUniqueChars = 2;
                config.Password.RequireNonAlphanumeric = true;
                config.Password.RequireUppercase = true;
                config.Password.RequireDigit = true;
                config.Password.RequiredLength = 6;
                config.Password.RequireLowercase = true;
                config.Password.RequireUppercase = true;
                config.Lockout.MaxFailedAccessAttempts = 5;
                config.Lockout.AllowedForNewUsers = true;
                config.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromHours(1);

            }).AddEntityFrameworkStores<CompanyDbcontext>()                               //register dbcontext(data of identity) ال config اللي حطيتها وبقوله dbcontext ديه
              .AddDefaultTokenProviders();

            builder.Services.ConfigureApplicationCookie(option =>

            {
                option.Cookie.HttpOnly = true;
                option.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                option.SlidingExpiration = true;
                option.LoginPath = "/Account/Login";
                option.LogoutPath = "/Account/Logout";
                option.AccessDeniedPath = "/Account/AccessDenied";
                option.Cookie.Name = "cookie";
                option.Cookie.SameSite=SameSiteMode.Strict;
            });

            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();                            //middlewares

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
