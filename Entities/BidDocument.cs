namespace EntitiesTest.Entities
{
    public class BidDocument
    {
        public Guid Id { get; set; }
        public Guid BidId { get; set; }
        public Bid Bid { get; set; }
        public DocumentType DocumentType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FilePath { get; set; }
        public long FileSize { get; set; }
        public string ContentType { get; set; }
        public DateTime UploadedAt { get; set; }
    }

    public enum DocumentType { TechnicalProposal, FinancialProposal, CompanyProfile, Certificate, Other }

}
