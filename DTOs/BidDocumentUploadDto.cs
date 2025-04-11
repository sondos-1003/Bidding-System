namespace EntitiesTest.DTOs
{
    public class BidDocumentUploadDto
    {
        public Guid BidId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FilePath { get; set; }
        public long FileSize { get; set; }
        public string ContentType { get; set; }
        public int DocumentType { get; set; } // Use int for enum binding from client
    }
}
