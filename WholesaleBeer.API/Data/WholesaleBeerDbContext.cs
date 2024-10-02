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

            // Seed to the database
            modelBuilder.Entity<Brewery>().HasData(breweries);
            modelBuilder.Entity<Wholesaler>().HasData(wholesalers);
        }
    }
}
