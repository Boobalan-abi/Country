using System.ComponentModel.DataAnnotations;

namespace Country.MVC.Models.City
{
    public class UpdateCityViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int StateId { get; set; }
    }
}