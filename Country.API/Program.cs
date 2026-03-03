using Country.API.AutoMapper;
using Country.API.Data;
using Country.API.Repository.Implementations;
using Country.API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Country.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            #region DB Configuration

            string sqlConn = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(sqlConn);
            });
            #endregion

            #region AutoMapper Configuration
            builder.Services.AddAutoMapper(typeof(MappingProfile));
            #endregion

            #region GenericRepository Configuration

            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            #endregion

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            #region Seeding the database
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                DbInitializer.Initialize(context);
            }

            #endregion




            app.UseSwagger();
            app.UseSwaggerUI();


            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.MapGet("/", () => "World API is running on Azure");

            app.Run();
        }
    }
}
