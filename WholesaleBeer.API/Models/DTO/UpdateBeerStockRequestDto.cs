using System.ComponentModel.DataAnnotations;
using WholesaleBeer.API.Models.Domain;

namespace WholesaleBeer.API.Models.DTO
{
    public class UpdateBeerStockRequestDto
    {
        [Required]
        public Guid BeerId { get; set; }
        [Required]
        public Guid WholesalerId { get; set; }
        [Required]
        [Range(0, Int32.MaxValue, ErrorMessage = "Stock must be greater than 0")]
        public int StockLeft { get; set; }
    }
}
