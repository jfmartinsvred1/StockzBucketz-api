

using stockz_bucketz_api.Models;

namespace stockz_bucketz_api.Context.Dto
{
    public class ReadPortfolioDto
    {
        public ICollection<ReadTransactionDto> Transactions { get; set; }
        public ICollection<ReadStockDto> Stocks { get; set; }
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
                Patrimony += stock.Value;
                AcquisitionCost += stock.Cost;
                AccumulatedEarnings+= stock.Earnings;
            }
            if(Patrimony==0 && AcquisitionCost==0)
            {
                Profitability=0;
            }
            else
            {
                Profitability = ((Patrimony / AcquisitionCost) * 100) - 100;
            }
            Profit = Patrimony - AcquisitionCost;
        }
    }
}
