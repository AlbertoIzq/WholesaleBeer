﻿using WholesaleBeer.API.Models.Domain;

namespace WholesaleBeer.API.Repositories
{
    public interface IBeerStockRepository
    {
        Task<BeerStock> CreateAsync(BeerStock beerStock);
    }
}