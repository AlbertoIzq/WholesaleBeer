using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WholesaleBeer.API.Models.Domain;
using WholesaleBeer.API.Repositories.Interfaces;

namespace WholesaleBeer.Utility
{
    public interface IOrderDetailPriceCalculator
    {
        public Task<double> CalculatePrice(OrderDetail orderDetail);
    }
}
