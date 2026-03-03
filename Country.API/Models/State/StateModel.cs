using Country.API.Models.City;
using Country.API.Models.Country;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Country.API.Models.State
{
    public class StateModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-increment
        public int Id { get; set; }

        [Required(ErrorMessage = "State name is required.")]
        [MaxLength(100, ErrorMessage = "State name cannot exceed 100 characters.")]
        public string Name { get; set; }

        // Foreign key property
        [Required(ErrorMessage = "Country is required.")]
        public int CountryId { get; set; }

        // Navigation property
        [ForeignKey("CountryId")]
        public CountryModel Country { get; set; }

        // Navigation property for Cities
        public ICollection<CityModel> Cities { get; set; } = new List<CityModel>();
    }
}