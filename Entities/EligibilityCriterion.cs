using System.Reflection;

namespace EntitiesTest.Entities
{
    public class EligibilityCriterion
    {
        public Guid Id { get; set; }
        public Guid TenderId { get; set; }
        public Tender Tender { get; set; }
        public string Description { get; set; }
        public bool IsMandatory { get; set; }
    }
}
