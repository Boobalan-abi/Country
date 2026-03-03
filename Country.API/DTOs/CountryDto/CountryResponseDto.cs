using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Country.API.DTOs.CountryDto
{
    public class CountryResponseDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ShortDesc { get; set; }

        public string CountryCode { get; set; }
    }
}
