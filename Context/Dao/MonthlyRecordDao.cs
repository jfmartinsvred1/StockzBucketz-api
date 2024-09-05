using AutoMapper;
using stockz_bucketz_api.Context.Dto;
using stockz_bucketz_api.Interfaces;
using stockz_bucketz_api.Models;

namespace stockz_bucketz_api.Context.Dao
{
    public class MonthlyRecordDao : IMonthlyRecordDao
    {
        private AppDbContext _appDbContext;
        private IMapper _mapper;

        public MonthlyRecordDao(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task Create(CreateMonthlyRecord dto)
        {
            var monthlyRecord = _mapper.Map<MonthlyRecord>(dto);

            await _appDbContext.MonthlyRecords.AddAsync(monthlyRecord);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
