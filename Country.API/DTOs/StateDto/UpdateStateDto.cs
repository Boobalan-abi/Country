using System.ComponentModel.DataAnnotations;

namespace Country.API.DTOs.StateDto
{
    public class UpdateStateDto
    {

        [Required(ErrorMessage = "State name is required.")]
        [MaxLength(100, ErrorMessage = "State name cannot exceed 100 characters.")]
        public string Name { get; set; }

        // Foreign key property
        [Required(ErrorMessage = "Country is required.")]
        public int CountryId { get; set; }
    }
}
