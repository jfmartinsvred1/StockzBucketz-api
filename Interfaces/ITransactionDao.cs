using stockz_bucketz_api.Context.Dto;
using stockz_bucketz_api.Models;

namespace stockz_bucketz_api.Interfaces
{
    public interface ITransactionDao
    {
        Task Create(CreateTransactionDto dto);
        Task<ICollection<ReadTransactionDto>> List();
        CreateMonthlyRecord CreateMonthly(CreateTransactionDto Dto);
    }
}
