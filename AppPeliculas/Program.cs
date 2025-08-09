using Microsoft.EntityFrameworkCore;
using AppPeliculas.Models;
using Microsoft.AspNetCore.Identity;
namespace AppPeliculas
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddMemoryCache();//session
            builder.Services.AddSession();//session
            builder.Services.AddDbContext<PeliculaContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("conexion")));

            //Autenticacion y Autorizacion
            builder.Services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<PeliculaContext>().AddDefaultTokenProviders();


            var app = builder.Build();

            //Desplegar la web en Azure
            using(var scope=app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<PeliculaContext>();
                if(context.Database.IsRelational())
                {
                    context.Database.Migrate();
                }
            }

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

            app.UseSession(); // habilita session

            app.UseAuthentication(); // habilita autenticacion
            app.UseAuthorization(); // habilita autorizacion

            app.MapAreaControllerRoute(
               name: "adminrutalistar",
               areaName:"Admin",
               pattern: "Admin/{controller=Pelicula}/{action=Index}/genero-{genero}/estudio-{estudio}");

            app.MapAreaControllerRoute(
                name: "admindefault",
                areaName: "Admin",
                pattern: "Admin/{controller=Pelicula}/{action=Index}/{id?}/{slug?}");


            app.MapControllerRoute(
               name: "rutalistar",
               pattern: "{controller=Home}/{action=Index}/genero-{genero}/estudio-{estudio}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}/{slug?}");

            app.Run();
        }
    }
}
