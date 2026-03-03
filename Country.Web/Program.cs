using Country.MVC.Services;
using Country.Web.Service;

namespace Country.Web
{
    public class Program
    {
        public static void Main(string[] args)
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

            #endregion

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
                pattern: "{controller=Country}/{action=Index}/{id?}");
            //Boobalan
            app.Run();
        }
    }
}
