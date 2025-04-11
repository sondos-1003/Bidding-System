using System.Reflection;

namespace EntitiesTest.Entities
{
    public class Evaluation
    {
        public Guid Id { get; set; }
        public Guid TenderId { get; set; }
        public Tender Tender { get; set; }
        public int EvaluatorId { get; set; }
        public User Evaluator { get; set; }
        public Guid BidId { get; set; }
        public Bid Bid { get; set; }
        public DateTime EvaluationDate { get; set; }
        public string Notes { get; set; }

        public ICollection<CriterionScore> Scores { get; set; }
    }
}
