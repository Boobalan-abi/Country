using System.ComponentModel.DataAnnotations;

namespace Country.MVC.Models.State
{
    public class CreateStateViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int CountryId { get; set; }
    }
}