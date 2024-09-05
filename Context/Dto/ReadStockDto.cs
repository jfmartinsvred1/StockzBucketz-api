using stockz_bucketz_api.Models;
using System.ComponentModel.DataAnnotations;

namespace stockz_bucketz_api.Context.Dto
{
    public class ReadStockDto
    {
        public int Id { get; set; }
        public string PortfolioId { get; set; }
        public double UnitPrice { get; set; }
        public string Code { get; set; }
        public int Amount { get; set; }
        public double Value { get; set; }
        public double Cost { get; set; }
        public double MediumPrice { get; set; }
        public double Earnings { get; set; }
    }
}
