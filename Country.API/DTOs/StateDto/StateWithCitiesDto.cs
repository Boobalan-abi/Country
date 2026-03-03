using Country.API.DTOs.CityDto;

namespace Country.API.DTOs.StateDto
{
    public class StateWithCitiesDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CountryId { get; set; }

        public ICollection<CityResponseDto> Cities { get; set; }
    }
}
