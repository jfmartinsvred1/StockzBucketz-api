using stockz_bucketz_api.Models;
using System.ComponentModel.DataAnnotations;

namespace stockz_bucketz_api.Context.Dto
{
    public class ReadTransactionDto
    {
        public int IdTransaction { get; set; }
        public string PortfolioId { get; set; }
        public string Type { get; set; }
        public string Code { get; set; }
        public DateTime Date { get; set; }
        public int Amount { get; set; }
        public double UnitPrice { get; set; }
    }
}
