using AutoMapper;
using Microsoft.EntityFrameworkCore;
using stockz_bucketz_api.Context.Dto;
using stockz_bucketz_api.Interfaces;
using stockz_bucketz_api.Models;

namespace stockz_bucketz_api.Context.Dao
{
    public class PortfolioDao : IPortfolioDao
    {
        public AppDbContext _context;
        public IMapper _mapper;

        public PortfolioDao(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Create(CreatePortfolioDto Dto)
        {
            var portfolio = _mapper.Map<Portfolio>(Dto);
            if(portfolio.PortfolioId.Length==0)
            {
                throw new Exception("Erro ao criar o portfolio");
            }
            await _context.Portfolios.AddAsync(portfolio);
            await _context.SaveChangesAsync();  

        }

        public async Task<ReadPortfolioDto> GetByUserId(string userId)
        {
            var portfolio = _mapper.Map<ReadPortfolioDto>(await _context.Portfolios.Include(p=>p.MonthlyRecords).Include(p=>p.Transactions).Include(p=>p.Stocks).FirstOrDefaultAsync(p => p.PortfolioId == userId));
            if(portfolio == null)
            {
                throw new Exception("Portfolio inexistente.");
            }
            portfolio.CalculatePortfolio();
            return portfolio;
        }

    }
}
