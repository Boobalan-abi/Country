using Country.API.Models.City;
using Country.API.Models.Country;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Country.API.DTOs.StateDto
{
    public class StateResponseDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CountryId { get; set; }
    }
}
