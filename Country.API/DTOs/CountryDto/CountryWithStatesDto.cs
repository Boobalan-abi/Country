using Country.API.DTOs.StateDto;

namespace Country.API.DTOs.CountryDto
{
    public class CountryWithStatesDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ShortDesc { get; set; }

        public string CountryCode { get; set; }

        public ICollection<StateWithCitiesDto> States { get; set; }
    }
}
