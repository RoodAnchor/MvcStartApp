using Microsoft.EntityFrameworkCore;
using MvcStartApp.DAL.Db;
using MvcStartApp.DAL.Repositories;
using MvcStartApp.Middleware;

namespace MvcStartApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var dbConnection = builder.Configuration.GetConnectionString("DefaultConnection");

            // Add services to the container.
            builder.Services.AddSingleton<IBlogRepository, BlogRepository>();
            builder.Services.AddSingleton<ILogsRepository, LogsRepository>();
            builder.Services.AddDbContext<BlogContext>(options => options.UseSqlServer(dbConnection), ServiceLifetime.Singleton);
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseMiddleware<LoggingMiddleware>();
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
