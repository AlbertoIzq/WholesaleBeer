using System.ComponentModel.DataAnnotations;
using WholesaleBeer.API.Models.Domain;

namespace WholesaleBeer.API.Models.DTO
{
    public class BeerStockDto
    {
        public Guid Id { get; set; }
        public int StockLeft { get; set; }

        public Beer Beer { get; set; }
        public Wholesaler Wholesaler { get; set; }
    }
}
