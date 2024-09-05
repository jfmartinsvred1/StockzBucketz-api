using System.ComponentModel.DataAnnotations;

namespace stockz_bucketz_api.Models
{
    public class Stock
    {
        public Stock(string portfolioId, string code, int amount , double mediumPrice, double earnings, double unitPrice)
        {
            PortfolioId = portfolioId;
            Code = code;
            Amount = amount;
            MediumPrice = mediumPrice;
            Value = unitPrice * amount;
            Earnings = earnings;
            UnitPrice = unitPrice;
            Cost = mediumPrice * amount;
        }

        [Key]
        public int Id { get; set; }
        public string PortfolioId { get; set; }
        public Portfolio Portfolio { get; set; }
        public double UnitPrice { get; set; }
        public string Code { get; set; }
        public int Amount { get; set; }
        public double Value { get; set; }
        public double Cost { get; set; }
        public double MediumPrice { get; set; }
        public double Earnings { get; set; }

        public void Buy(int amount, double unitPrice, double oldCost, int amountOld)
        {
            var buyCost = amount * unitPrice;
            var newCost = buyCost + oldCost;
            var newAmount = amount + amountOld;
            var average = newCost / newAmount;

            this.Amount = newAmount;
            this.MediumPrice = average;
            this.Cost = newCost;
        }
        public void Sell(int amount)
        {
            this.Amount -= amount;
            var newValue = this.Amount * this.UnitPrice;
            var newCost = this.Amount * this.MediumPrice;
            this.Value = newValue;
            this.Cost = newCost;
        }
    }
}
