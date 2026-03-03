using System.ComponentModel.DataAnnotations;

namespace Country.MVC.Models.State
{
    public class UpdateStateViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int CountryId { get; set; }
    }
}