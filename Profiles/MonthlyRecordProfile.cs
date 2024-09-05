using AutoMapper;
using stockz_bucketz_api.Context.Dto;
using stockz_bucketz_api.Models;

namespace stockz_bucketz_api.Profiles
{
    public class MonthlyRecordProfile:Profile
    {
        public MonthlyRecordProfile()
        {
            CreateMap<CreateMonthlyRecord, MonthlyRecord>();
            CreateMap<MonthlyRecord, ReadMonthlyRecord>();
        }
    }
}
