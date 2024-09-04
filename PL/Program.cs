using DAL.contexts;
using Microsoft.EntityFrameworkCore;
using REPOSITORY.interfaces;
using REPOSITORY.repositers;
using SERVIES.interfaces;
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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
