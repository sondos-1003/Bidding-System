using System.ComponentModel.DataAnnotations;

namespace EntitiesTest.Entities
{
    public class Bidder
    {
        [Required]
        public Guid Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string CompanyName { get; set; }
        public string RegistrationNumber { get; set; }
        public string TaxIdentificationNumber { get; set; }
        public string Address { get; set; }
        public string ContactPerson { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public int YearEstablished { get; set; }

        public ICollection<Bid> Bids { get; set; }
        public ICollection<PastExperience> PastExperiences { get; set; }
        public ICollection<FinancialStatement> FinancialStatements { get; set; }
    }
}
