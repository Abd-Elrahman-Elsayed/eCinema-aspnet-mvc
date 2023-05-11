using eCinema.Data;
using eCinema.Data.Base;
using eCinema.Data.Services;
using eCinema.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace OufCinema
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddTransient<IEntityBaseRepository<Actor>,EntityBaseRepository<Actor>>();
            builder.Services.AddTransient<IEntityBaseRepository<Producer>, EntityBaseRepository<Producer>>();
            builder.Services.AddTransient<IEntityBaseRepository<Movie>, EntityBaseRepository<Movie>>();
            builder.Services.AddTransient<IEntityBaseRepository<Cinema>, EntityBaseRepository<Cinema>>();



            //Authentication (UserManager - SignInManager - RoleManager)
            builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();



            builder.Services.AddDbContext<AppDbContext>(con =>
            {
                con.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnetionString"));
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Seed();
            app.Run();
        }
    }
}