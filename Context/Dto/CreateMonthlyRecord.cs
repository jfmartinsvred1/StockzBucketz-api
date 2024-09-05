using stockz_bucketz_api.Models;
using System.ComponentModel.DataAnnotations;

namespace stockz_bucketz_api.Context.Dto
{
    public class CreateMonthlyRecord
    {
        public CreateMonthlyRecord(string portfolioId, int monthly, int year, double value)
        {
            PortfolioId = portfolioId;
            Monthly = monthly;
            Year = year;
            Value = value;
        }

        public string PortfolioId { get; set; }
        public int Monthly { get; set; }
        public int Year { get; set; }
        public double Value { get; set; }
    }
}
