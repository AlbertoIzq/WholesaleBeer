namespace WholesaleBeer.API.Models.Domain
{
    public class Beer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double AlcoholContentPercentage { get; set; }
        public double Price { get; set; }
        public Guid BreweryId { get; set; }

        // Navigation properties
        public Brewery Brewery { get; set; }
    }
}