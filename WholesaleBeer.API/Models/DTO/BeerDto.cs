using System.ComponentModel.DataAnnotations;
using WholesaleBeer.API.Models.Domain;

namespace WholesaleBeer.API.Models.DTO
{
    public class BeerDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float AlcoholContentPercentage { get; set; }
        public float Price { get; set; }

        public Brewery Brewery { get; set; }
    }
}
