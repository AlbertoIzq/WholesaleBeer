using Microsoft.EntityFrameworkCore;
using WholesaleBeer.API.Data;
using WholesaleBeer.API.Models.Domain;
using WholesaleBeer.API.Repositories.Interfaces;

namespace WholesaleBeer.API.Repositories
{
    public class SqlOrderDetailRepository : IOrderDetailRepository
    {
        private readonly WholesaleBeerDbContext _wholesaleBeerDbContext;

        public SqlOrderDetailRepository(WholesaleBeerDbContext wholesaleBeerDbContext)
        {
            _wholesaleBeerDbContext = wholesaleBeerDbContext;
        }

        public async Task<OrderDetail> CreateAsync(OrderDetail orderDetail)
        {
            await _wholesaleBeerDbContext.OrderDetails.AddAsync(orderDetail);
            await _wholesaleBeerDbContext.SaveChangesAsync();

            // Populate Beer and Wholesaler navigation property
            OrderDetail orderDetailReturn = await _wholesaleBeerDbContext.OrderDetails
                .Include(x => x.Beer)
                .Include(x => x.Beer.Brewery)
                .Include(x => x.Wholesaler)
                .FirstOrDefaultAsync(x => x.Id == orderDetail.Id);

            return orderDetailReturn;
        }

        public async Task<List<OrderDetail>> GetAllAsync()
        {
            return await _wholesaleBeerDbContext.OrderDetails
                .Include(x => x.Beer)
                .Include(x => x.Beer.Brewery)
                .Include(x => x.Wholesaler)
                .ToListAsync();
        }
    }
}
