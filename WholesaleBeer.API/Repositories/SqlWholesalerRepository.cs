using Microsoft.EntityFrameworkCore;
using WholesaleBeer.API.Data;
using WholesaleBeer.API.Models.Domain;
using WholesaleBeer.API.Repositories.Interfaces;

namespace WholesaleBeer.API.Repositories
{
    public class SqlWholesalerRepository : IWholesalerRepository
    {
        private readonly WholesaleBeerDbContext _wholesaleBeerDbContext;

        public SqlWholesalerRepository(WholesaleBeerDbContext wholesaleBeerDbContext)
        {
            _wholesaleBeerDbContext = wholesaleBeerDbContext;
        }

        public async Task<List<Wholesaler>> GetAllAsync()
        {
            return await _wholesaleBeerDbContext.Wholesalers.ToListAsync();
        }
    }
}
