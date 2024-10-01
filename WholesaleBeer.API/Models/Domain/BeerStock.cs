namespace WholesaleBeer.API.Models.Domain
{
    public class BeerStock
    {
        public Guid Id { get; set; }
        public Guid BeerId { get; set; }
        public Guid WholesalerId { get; set; }
        public int StockLeft { get; set; }
    }
}