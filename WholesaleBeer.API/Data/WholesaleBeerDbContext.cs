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
    }
}
