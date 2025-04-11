using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace EntitiesTest.Entities
{
    public class Bid
    {
        [Required]
        public Guid Id { get; set; }
        public Guid TenderId { get; set; }
        public Tender Tender { get; set; }
        public Guid BidderId { get; set; }
        public Bidder Bidder { get; set; }
        public string ReferenceNumber { get; set; }
        public DateTime SubmissionDate { get; set; }
        public BidStatus Status { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal? TechnicalScore { get; set; }
        public decimal? FinancialScore { get; set; }
        public decimal? FinalScore { get; set; }
        public bool IsWinner { get; set; }
        public string Notes { get; set; }

        public TechnicalProposal TechnicalProposal { get; set; }
        public ICollection<BidDocument> Documents { get; set; }
        public ICollection<BidFinancialDetail> FinancialDetails { get; set; }
        public ICollection<Evaluation> Evaluations { get; set; } = new List<Evaluation>();

    }

    public enum BidStatus { Draft, Submitted, UnderReview, Rejected, Awarded }
}
