namespace stockz_bucketz_api.Context.Dto
{
    public class CreateMonthlyRecordWithDate
    {
        public string PortfolioId { get; set; }
        public DateTime Date { get; set; }
        public double Value { get; set; }

        public CreateMonthlyRecord GenerateMonthlyRecord()
        {
            CreateMonthlyRecord monthlyRecord = new CreateMonthlyRecord(PortfolioId,Date.Month,Date.Year,Value);
            return monthlyRecord;
        }
    }
}
