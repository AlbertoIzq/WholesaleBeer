namespace WholesaleBeer.API.Models.Domain
{
    public class Beer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float AlcoholContentPercentage { get; set; }
        public float Price { get; set; }
        public Guid BreweryId { get; set; }

        // Navigation properties
        public Brewery Brewery { get; set; }
    }
}