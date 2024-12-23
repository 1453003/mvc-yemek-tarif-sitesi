using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Microsoft.Extensions.Options;
using Repositories;
using Services.Contracts;
using Services;



namespace yedim
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<RepositoryContext>(options=>
            {
                
                options.UseSqlite(builder.Configuration.GetConnectionString("sqlconnection"),
                b => b.MigrationsAssembly("yedim"));

            });
            builder.Services.AddScoped<IRepositoryManager, RepositoryManger>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IServiceManager, ServiceManager>();
            builder.Services.AddScoped<IProductService, ProductManager>();
            builder.Services.AddScoped<ICategoryService, CategoryManager>();



            var app = builder.Build();// veri tabanýný her yerde kullanmamýzý saðlar 

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

            app.MapAreaControllerRoute(
     name: "Admin",
     areaName: "Admin",
     pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}"
 );

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"
            );




            app.Run();
        }
    }
}
