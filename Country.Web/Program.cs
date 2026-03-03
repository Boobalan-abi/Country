using System;
using System.IO;
using Country.MVC.Services;
using Country.Web.Service;

namespace Country.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var builder = WebApplication.CreateBuilder(args);

                // Add services to the container.
                builder.Services.AddControllersWithViews();

                #region HttpClient and BaseAddress Configuration
                builder.Services.AddHttpClient("ApiClient", client =>
                {
                    client.BaseAddress = new Uri("https://countryapi.azurewebsites.net/api/");
                });
                #endregion

                #region Country, State, City Services Registration
                builder.Services.AddScoped<ICountryService, CountryService>();
                builder.Services.AddScoped<IStateService, StateService>();
                #endregion

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
                    pattern: "{controller=Country}/{action=Index}/{id?}");

                app.Run();
            }
            catch (Exception ex)
            {
                // Log to a file so we can see it in Kudu or App Service logs
                var logFile = Path.Combine(AppContext.BaseDirectory, "startup-error.txt");
                File.WriteAllText(logFile, ex.ToString());

                // Optionally, also log to console
                Console.WriteLine(ex);

                // Rethrow so the web host fails visibly
                throw;
            }
        }
    }
}