using Microsoft.AspNetCore.Http;

namespace EntitiesTest.DTOs
{
    public class FileUploadDto
    {
        public int RelatedEntityId { get; set; } // e.g., TenderId or BidId
        public IFormFile File { get; set; }
        public string FileType { get; set; } // e.g., "TenderDocument", "BidDocument"
    }
}
