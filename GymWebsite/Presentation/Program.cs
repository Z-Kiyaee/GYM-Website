using Application.Services.Implementations;
using Application.Services.Interfaces;
using Domain.IRepositories;
using Infra.Data.AppDbContext;
using Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region Builders

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            #region Repositories

            builder.Services.AddScoped<IUserRepository, UserRepository>();

            #endregion


            #region Services

            builder.Services.AddScoped<IUserService, UserService>();

            #endregion

            builder.Services.AddDbContext<GymDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("GymConnectionString"));
            });

            var app = builder.Build();



            #endregion

            #region App Services (Middlewares)

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
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();

            #endregion

        }
    }
}
