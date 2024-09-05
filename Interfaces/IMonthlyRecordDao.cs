using stockz_bucketz_api.Context.Dto;

namespace stockz_bucketz_api.Interfaces
{
    public interface IMonthlyRecordDao
    {
        Task Create(CreateMonthlyRecord dto);
    }
}
