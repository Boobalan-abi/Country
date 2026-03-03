using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Country.API.Models.State;

namespace Country.API.Models.City
{
    public class CityModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "City name is required.")]
        [MaxLength(100, ErrorMessage = "City name cannot exceed 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "State is required.")]
        public int StateId { get; set; }  // Foreign key

        [ForeignKey("StateId")]
        public StateModel State { get; set; }  // Navigation property
    }
}