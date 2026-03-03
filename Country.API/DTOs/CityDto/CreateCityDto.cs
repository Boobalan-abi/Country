using System.ComponentModel.DataAnnotations;

namespace Country.API.DTOs.CityDto
{
    public class CreateCityDto
    {
        [Required(ErrorMessage = "City name is required.")]
        [MaxLength(100, ErrorMessage = "City name cannot exceed 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "State is required.")]
        public int StateId { get; set; }  // Foreign key
    }
}
