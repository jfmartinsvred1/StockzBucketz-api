using AutoMapper;
using Microsoft.EntityFrameworkCore;
using stockz_bucketz_api.Context.Dto;
using stockz_bucketz_api.Interfaces;
using stockz_bucketz_api.Models;

namespace stockz_bucketz_api.Context.Dao
{
    public class TransactionDao : ITransactionDao
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public TransactionDao(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Create(CreateTransactionDto dto)
        {
            var transaction = _mapper.Map<Transaction>(dto);

            await _context.Transactions.AddAsync(transaction);
            await _context.SaveChangesAsync();
        }

        public CreateMonthlyRecord CreateMonthly(CreateTransactionDto Dto)
        {
            CreateMonthlyRecord monthlyRecordDto = new CreateMonthlyRecord(Dto.PortfolioId,Dto.Date.Month, Dto.Date.Year,(Dto.Amount*Dto.UnitPrice));
            return monthlyRecordDto;
        }

        public async Task<ICollection<ReadTransactionDto>> List()
        {
            return _mapper.Map<ICollection<ReadTransactionDto>>(await _context.Transactions.ToListAsync());
        }
    }
}
