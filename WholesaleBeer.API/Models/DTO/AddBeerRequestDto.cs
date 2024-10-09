using System.ComponentModel.DataAnnotations;
using WholesaleBeer.API.Models.Domain;

namespace WholesaleBeer.API.Models.DTO
{
    public class AddBeerRequestDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(0, 100, ErrorMessage = "Alcohol content percentage must be between 0 and 100")]
        public double AlcoholContentPercentage { get; set; }
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public double Price { get; set; }
        [Required]
        public Guid BreweryId { get; set; }
    }
}
