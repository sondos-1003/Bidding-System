namespace EntitiesTest.Entities
{
    public class TenderDocument
    {
        public Guid Id { get; set; }
        public Guid TenderId { get; set; }
        public Tender Tender { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FilePath { get; set; }
        public long FileSize { get; set; }
        public string ContentType { get; set; }
        public DateTime UploadedAt { get; set; }
    }
}
