using System.ComponentModel.DataAnnotations;

namespace stockz_bucketz_api.Models
{
    public class MonthlyRecord
    {
        [Key]
        public int Id { get; set; }
        public string PortfolioId { get; set; }
        public Portfolio Portfolio { get; set; }
        public string Monthly { get; set; }
        public string Year { get; set; }
        public double Value { get; set; }
    }
}
