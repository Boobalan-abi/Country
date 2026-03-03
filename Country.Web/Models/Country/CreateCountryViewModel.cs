using System.ComponentModel.DataAnnotations;

namespace Country.MVC.Models.Country
{
    public class CreateCountryViewModel
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(3)]
        public string ShortDesc { get; set; }

        [Required]
        [MaxLength(5)]
        public string CountryCode { get; set; }


    }
}