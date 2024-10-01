namespace WholesaleBeer.API.Models.Domain
{
    public class OrderDetail
    {
        public Guid Id { get; set; }
        public Guid BeerId { get; set; }
        public Guid WholesalerId { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }

        // Navigation properties
        public Beer Beer { get; set; }
        public Wholesaler Wholesaler { get; set; }
    }
}