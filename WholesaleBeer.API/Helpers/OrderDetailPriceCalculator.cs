using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WholesaleBeer.API.Models.Domain;
using WholesaleBeer.API.Repositories.Interfaces;

namespace WholesaleBeer.Utility
{
    public class OrderDetailPriceCalculator
    {
        private readonly IBeerRepository _beerRepository;

        public OrderDetailPriceCalculator(IBeerRepository beerRepository)
        {
            _beerRepository = beerRepository;
        }

        public async Task<double> CalculatePrice(OrderDetail orderDetail)
        {
            var beerOrdered = await _beerRepository.GetByIdAsync(orderDetail.BeerId);
            var priceBeer = beerOrdered.Price;
            double price = orderDetail.Quantity * priceBeer;

            // Apply discount
            if (orderDetail.Quantity > SD.DISCOUNT_B_MIN_BEERS)
            {
                price *= (1 - SD.DISCOUNT_B);
            }
            else if (orderDetail.Quantity > SD.DISCOUNT_A_MIN_BEERS)
            {
                price *= (1 - SD.DISCOUNT_A);
            }

            return price;
        }
    }
}
