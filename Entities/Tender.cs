using System.ComponentModel.DataAnnotations;

namespace EntitiesTest.Entities
{
    public class Tender
    {
        [Required]
        public Guid TenderId { get; set; }
        public int? CreatedById { get; set; }
        public string ReferenceNumber { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid OrganizationId { get; set; }
        public Organization Organization { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ClosingDate { get; set; }
        public TenderType TenderType { get; set; }
        public decimal? BudgetRangeLower { get; set; }
        public decimal? BudgetRangeUpper { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public TenderStatus Status { get; set; }
        
        public User CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastModifiedAt { get; set; }

        public ICollection<TenderCategory> Categories { get; set; }
        public ICollection<TenderDocument> Documents { get; set; }
        public ICollection<Bid> Bids { get; set; }
        public ICollection<EligibilityCriterion> EligibilityCriteria { get; set; }
        public ICollection<EvaluationCriterion> EvaluationCriteria { get; set; }
        public ICollection<Evaluation> Evaluations { get; set; }
    }

    public enum TenderType { Open, Restricted, SingleSource }
    public enum TenderStatus { Draft, Published, Closed, Awarded, Cancelled }

}
