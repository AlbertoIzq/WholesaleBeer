using System.ComponentModel.DataAnnotations;
using WholesaleBeer.API.Models.Domain;

namespace WholesaleBeer.API.Models.DTO
{
    public class OrderDetailDto
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public BeerDto Beer { get; set; }
        public Wholesaler Wholesaler { get; set; }
    }
}
