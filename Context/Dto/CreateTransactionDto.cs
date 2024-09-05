using System.ComponentModel.DataAnnotations;

namespace stockz_bucketz_api.Context.Dto
{
    public class CreateTransactionDto
    {
        [Required]
        public string PortfolioId { get; set; }
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
    }
}
