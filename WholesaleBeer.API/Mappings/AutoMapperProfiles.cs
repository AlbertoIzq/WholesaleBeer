using AutoMapper;
using WholesaleBeer.API.Models.Domain;
using WholesaleBeer.API.Models.DTO;

namespace WholesaleBeer.API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AddBeerRequestDto, Beer>();
            CreateMap<Beer, BeerDto>().ReverseMap();

            CreateMap<AddBeerStockRequestDto, BeerStock>();
            CreateMap<BeerStock, BeerStockDto>().ReverseMap();
        }
    }
}
