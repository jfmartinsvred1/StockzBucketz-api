using AutoMapper;
using stockz_bucketz_api.Context.Dto;
using stockz_bucketz_api.Models;

namespace stockz_bucketz_api.Profiles
{
    public class StockProfile:Profile
    {
        public StockProfile()
        {
            CreateMap<Stock, ReadStockDto>();
        }
    }
}
