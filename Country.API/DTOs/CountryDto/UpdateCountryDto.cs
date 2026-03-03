using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Country.API.DTOs.CountryDto
{
    public class UpdateCountryDto
    {

        [Required(ErrorMessage = "Country name is required.")]
        [MaxLength(100, ErrorMessage = "Country name cannot exceed 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Short description is required.")]
        [MaxLength(3, ErrorMessage = "Short description can have a maximum of 3 characters.")]
        public string ShortDesc { get; set; }

        [Required(ErrorMessage = "Country code is required.")]
        [MaxLength(5, ErrorMessage = "Country code can have a maximum of 5 characters.")]
        public string CountryCode { get; set; }
    }
}
