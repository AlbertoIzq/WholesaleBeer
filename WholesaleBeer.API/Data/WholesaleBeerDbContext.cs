using Microsoft.EntityFrameworkCore;
using WholesaleBeer.API.Models.Domain;

namespace WholesaleBeer.API.Data
{
    public class WholesaleBeerDbContext : DbContext
    {
        public WholesaleBeerDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Beer> Beers { get; set; }
        public DbSet<Brewery> Breweries { get; set; }
        public DbSet<Wholesaler> Wholesalers { get; set; }
        public DbSet<BeerStock> BeerStocks { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Data to seed
            var beers = new List<Beer>()
            {
                new Beer
                {
                    Id = Guid.Parse("771F94AC-9BD6-4C82-2457-08DCE27BE8AE"),
                    Name = "Orval",
                    AlcoholContentPercentage = 6.2,
                    Price = 3.7,
                    BreweryId = Guid.Parse("8DB2BB14-5AE6-4894-9AAB-205D29BFB176")
                },
                new Beer
                {
                    Id = Guid.Parse("6E3B4A15-AE20-40A1-114A-08DCE2D288AD"),
                    Name = "Rochefort 10",
                    AlcoholContentPercentage = 11.3,
                    Price = 4.1,
                    BreweryId = Guid.Parse("91D8C67C-C92B-48A4-95B3-77182BFCBF73")
                },
                new Beer
                {
                    Id = Guid.Parse("7AEFCEE4-347F-4184-114B-08DCE2D288AD"),
                    Name = "Rochefort 8",
                    AlcoholContentPercentage = 9.2,
                    Price = 3.05,
                    BreweryId = Guid.Parse("91D8C67C-C92B-48A4-95B3-77182BFCBF73")
                },
                new Beer
                {
                    Id = Guid.Parse("5B71078E-3E4E-495C-C75B-08DCE2D581F8"),
                    Name = "Trappist Westvleteren 12",
                    AlcoholContentPercentage = 10.2,
                    Price = 2.33,
                    BreweryId = Guid.Parse("53965366-20B3-4F2D-9972-A886D6972C1F")
                },
                new Beer
                {
                    Id = Guid.Parse("7503FAEB-F43C-428A-C75C-08DCE2D581F8"),
                    Name = "Trappist Westvleteren 8",
                    AlcoholContentPercentage = 8.0,
                    Price = 2.04,
                    BreweryId = Guid.Parse("53965366-20B3-4F2D-9972-A886D6972C1F")
                },
                new Beer
                {
                    Id = Guid.Parse("527fad60-6791-41d7-aadb-439805a5957b"),
                    Name = "Chimay Bleu",
                    AlcoholContentPercentage = 9.0,
                    Price = 3.6,
                    BreweryId = Guid.Parse("36A69969-2A36-4F96-B037-B5603FE94A78")
                },
                new Beer
                {
                    Id = Guid.Parse("b333123a-b777-41bc-a457-d6b28c2acb91"),
                    Name = "Westmalle Tripel",
                    AlcoholContentPercentage = 9.5,
                    Price = 2.69,
                    BreweryId = Guid.Parse("62410140-4FB9-4662-8EF6-B5AA9DD7AA5D")
                }
            };

            var breweries = new List<Brewery>()
            {
                new Brewery
                {
                    Id = Guid.Parse("53965366-20b3-4f2d-9972-a886d6972c1f"),
                    Name = "Abbaye St Sixte Westvleteren"
                },
                new Brewery
                {
                    Id = Guid.Parse("62410140-4fb9-4662-8ef6-b5aa9dd7aa5d"),
                    Name = "Abbaye Notre Dame du Sacre Coeur de Westmalle"
                },
                new Brewery
                {
                    Id = Guid.Parse("91d8c67c-c92b-48a4-95b3-77182bfcbf73"),
                    Name = "Abbaye Notre Dame de St Remy"
                },
                new Brewery
                {
                    Id = Guid.Parse("8db2bb14-5ae6-4894-9aab-205d29bfb176"),
                    Name = "Abbaye d'Orval"
                },
                new Brewery
                {
                    Id = Guid.Parse("36a69969-2a36-4f96-b037-b5603fe94a78"),
                    Name = "Abbaye de Notre Dame de Scourmont"
                }
            };

            var wholesalers = new List<Wholesaler>()
            {
                new Wholesaler
                {
                    Id = Guid.Parse("9fc5f185-c6c3-4bcd-90c0-74e35304d69c"),
                    Name = "Belgibeer"
                },
                new Wholesaler
                {
                    Id = Guid.Parse("5c8e5f49-652b-42b0-8418-cd5a0ddba3fd"),
                    Name = "Bollaert Wijnhuis"
                },
                new Wholesaler
                {
                    Id = Guid.Parse("57ed2087-b816-4dcd-a3f1-3451822bb545"),
                    Name = "Bierhandel Dekoninck"
                },
                new Wholesaler
                {
                    Id = Guid.Parse("34acf5ff-19c2-477c-8a5b-b89b479002ce"),
                    Name = "Drinks Center Fontana"
                },
                new Wholesaler
                {
                    Id = Guid.Parse("0ffec24c-e643-410d-aafb-e0cefa0934b1"),
                    Name = "Drink Services - Brasserie Corman"
                },
            };

            var beerStocks = new List<BeerStock>()
            {
                new BeerStock
                {
                    Id = Guid.Parse("0d646172-29dd-41f8-aa1e-8483980cb9ef"),
                    BeerId = Guid.Parse("771F94AC-9BD6-4C82-2457-08DCE27BE8AE"),
                    WholesalerId = Guid.Parse("9fc5f185-c6c3-4bcd-90c0-74e35304d69c"),
                    StockLeft = 150
                },
                new BeerStock
                {
                    Id = Guid.Parse("677d69a7-1c81-4b19-b178-8a473390e96a"),
                    BeerId = Guid.Parse("6E3B4A15-AE20-40A1-114A-08DCE2D288AD"),
                    WholesalerId = Guid.Parse("9fc5f185-c6c3-4bcd-90c0-74e35304d69c"),
                    StockLeft = 80
                },
                new BeerStock
                {
                    Id = Guid.Parse("13e5a2f2-cf06-4cd7-83e2-03cd681878ef"),
                    BeerId = Guid.Parse("7AEFCEE4-347F-4184-114B-08DCE2D288AD"),
                    WholesalerId = Guid.Parse("5c8e5f49-652b-42b0-8418-cd5a0ddba3fd"),
                    StockLeft = 15
                },
            };

            // Seed to the database
            modelBuilder.Entity<Beer>().HasData(beers);
            modelBuilder.Entity<Brewery>().HasData(breweries);
            modelBuilder.Entity<BeerStock>().HasData(beerStocks);
            modelBuilder.Entity<Wholesaler>().HasData(wholesalers);
        }
    }
}
