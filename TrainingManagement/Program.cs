using Microsoft.EntityFrameworkCore;
using TrainingManagement.Context;
using TrainingManagement.Repository;

namespace TrainingManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<TrainingDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("UserDbConnection"));

            });
            builder.Services.AddTransient<InterfaceUser, TrainingRepository>();
            builder.Services.AddTransient<InterfaceCourse, CourseRepository>();

            builder.Services.AddTransient<InterfaceBatch, BatchRepository>();
            builder.Services.AddTransient<InterfaceRequest, RequestRepository>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
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