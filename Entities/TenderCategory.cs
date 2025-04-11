using System.ComponentModel.DataAnnotations;

namespace EntitiesTest.Entities
{
    public class TenderCategory
    {
        [Required]
        public Guid TenderId { get; set; }
        public Tender Tender { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
