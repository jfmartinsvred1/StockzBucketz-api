using stockz_bucketz_api.Context.Dto;

namespace stockz_bucketz_api.Interfaces
{
    public interface IPortfolioDao
    {
        Task Create(CreatePortfolioDto Dto);
        Task<ReadPortfolioDto> GetByUserId(string userId);
    }
}
