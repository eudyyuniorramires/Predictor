using Logica.Interfaces;
using Logica.Services; // Asegúrate que PredictionService esté aquí
using Logica.Models;   // Para PredictionModeSingleton
using Predictor.ViewModels;
using static Logica.Models.PredictionModeSinglenton; // Para los ViewModels

namespace Predictor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Registrar servicios CORRECTAMENTE
            builder.Services.AddSingleton<IPredictionService, PredictionService>();

            // Registrar el Singleton de forma adecuada
            builder.Services.AddSingleton<PredictionModeSingleton>(provider =>
                PredictionModeSingleton.Instance);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
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