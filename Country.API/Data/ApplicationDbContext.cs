using Country.API.Models.City;
using Country.API.Models.Country;
using Country.API.Models.State;
using Microsoft.EntityFrameworkCore;

namespace Country.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<CountryModel> countries { get; set; }
        public DbSet<StateModel> states { get; set; }
        public DbSet<CityModel> cities { get; set; }

    }
}
