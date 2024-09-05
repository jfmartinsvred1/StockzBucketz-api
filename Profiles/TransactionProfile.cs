using AutoMapper;
using stockz_bucketz_api.Context.Dto;
using stockz_bucketz_api.Models;

namespace stockz_bucketz_api.Profiles
{
    public class TransactionProfile:Profile
    {
        public TransactionProfile()
        {
            CreateMap<CreateTransactionDto, Transaction>();
            CreateMap<Transaction, ReadTransactionDto>();
        }
    }
}
