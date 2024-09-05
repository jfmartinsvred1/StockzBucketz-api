using stockz_bucketz_api.Models;
using System.ComponentModel.DataAnnotations;

namespace stockz_bucketz_api.Context.Dto
{
    public class ReadMonthlyRecord
    {
        [Key]
        public int Id { get; set; }
        public int Monthly { get; set; }
        public int Year { get; set; }
        public double Value { get; set; }
    }
}
