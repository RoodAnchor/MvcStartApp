using Microsoft.EntityFrameworkCore;
using MvcStartApp.DAL.Db;
using MvcStartApp.DAL.Repositories;
using MvcStartApp.Middleware;
using MvcStartApp.Services.Logging.Extensions;

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

            builder.Logging.AddFileLogger();
            builder.Logging.AddDbLogger();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
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
