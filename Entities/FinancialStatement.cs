namespace EntitiesTest.Entities
{
    public class FinancialStatement
    {
        public Guid Id { get; set; }
        public Guid BidderId { get; set; }
        public Bidder Bidder { get; set; }
        public int Year { get; set; }
        public decimal Revenue { get; set; }
        public decimal Profit { get; set; }
        public decimal Assets { get; set; }
        public decimal Liabilities { get; set; }
        public string FilePath { get; set; }
        public DateTime UploadedAt { get; set; }
    }
}
