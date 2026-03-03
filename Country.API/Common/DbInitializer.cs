using Country.API.Data;
using Country.API.Models.Country;
using Country.API.Models.State;
using Country.API.Models.City;

namespace Country.API
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            // Ensure database is created
            context.Database.EnsureCreated();

            // Check if any countries exist
            if (context.countries.Any())
            {
                return;   // DB has been seeded
            }

            // Seed Countries
            var countries = new List<CountryModel>
            {
                new CountryModel { Name = "USA", ShortDesc="US", CountryCode="001" },
                new CountryModel { Name = "India", ShortDesc="IN", CountryCode="091" },
                new CountryModel { Name = "Canada", ShortDesc="CA", CountryCode="002" }
            };

            context.countries.AddRange(countries);
            context.SaveChanges();

            // Seed States
            var states = new List<StateModel>
            {
                new StateModel { Name="California", CountryId = countries.Single(c => c.Name=="USA").Id },
                new StateModel { Name="Texas", CountryId = countries.Single(c => c.Name=="USA").Id },
                new StateModel { Name="Maharashtra", CountryId = countries.Single(c => c.Name=="India").Id },
                new StateModel { Name="Ontario", CountryId = countries.Single(c => c.Name=="Canada").Id }
            };

            context.states.AddRange(states);
            context.SaveChanges();

            // Seed Cities
            var cities = new List<CityModel>
            {
                new CityModel { Name="Los Angeles", StateId = states.Single(s => s.Name=="California").Id },
                new CityModel { Name="Houston", StateId = states.Single(s => s.Name=="Texas").Id },
                new CityModel { Name="Mumbai", StateId = states.Single(s => s.Name=="Maharashtra").Id },
                new CityModel { Name="Toronto", StateId = states.Single(s => s.Name=="Ontario").Id }
            };

            context.cities.AddRange(cities);
            context.SaveChanges();
        }
    }
}