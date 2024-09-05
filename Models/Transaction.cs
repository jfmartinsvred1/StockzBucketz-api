using System.ComponentModel.DataAnnotations;

namespace stockz_bucketz_api.Models
{
    public class Transaction
    {
        [Key]
        public int IdTransaction { get; set; }
        public string PortfolioId { get; set; }
        public Portfolio Portfolio { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]  
        public double UnitPrice { get; set; }


        public Stock AddNewStock(double price)
        {
            Stock stock = new Stock(
                this.PortfolioId,
                this.Code,
                this.Amount,
                this.UnitPrice,
                0,
                this.UnitPrice
                );
            return stock;
        }

        public Stock UpdateStock(Stock stock)
        {
            if (Type.ToLower() == "buy")
            {
                stock.Buy(this.Amount, this.UnitPrice, stock.Cost, stock.Amount);
                
            }
            else
            {
                stock.Sell(this.Amount);

            }
            return stock;
        }


    }
}
