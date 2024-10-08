using System.ComponentModel.DataAnnotations;
using WholesaleBeer.API.Models.Domain;

namespace WholesaleBeer.API.Models.DTO
{
    public class AddOrderDetailRequestDto
    {
        [Required]
        public Guid BeerId { get; set; }
        [Required]
        public Guid WholesalerId { get; set; }
        [Required]
        [Range(0, Int32.MaxValue, ErrorMessage = "Quantity must be greater than 0")]
        public int Quantity { get; set; }
    }
}
