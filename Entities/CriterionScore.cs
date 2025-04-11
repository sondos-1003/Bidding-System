namespace EntitiesTest.Entities
{
    public class CriterionScore
    {
        public Guid Id { get; set; }
        public Guid EvaluationId { get; set; }
        public Evaluation Evaluation { get; set; }
        public Guid CriterionId { get; set; }
        public EvaluationCriterion Criterion { get; set; }
        public decimal Score { get; set; }
        public string Comments { get; set; }
    }
}
