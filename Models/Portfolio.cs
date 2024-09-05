using System.ComponentModel.DataAnnotations;

namespace stockz_bucketz_api.Models
{
    public class Portfolio
    {

        [Key]
        public string PortfolioId { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
        public ICollection<Stock> Stocks { get; set; }
        public double Profitability { get; set; }
        public double Patrimony { get; set; }
        public double AcquisitionCost { get; set; }
        public double AccumulatedEarnings { get; set; }
        public double Profit { get; set; }
        public ICollection<MonthlyRecord> MonthlyRecords { get; set; }

        public void CalculatePortfolio()
        {
            foreach (var stock in Stocks)
            {
                this.AcquisitionCost += stock.Cost;
            }
        }
    }
}
