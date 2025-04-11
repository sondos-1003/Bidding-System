using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace EntitiesTest.Entities
{
    public class EvaluationCriterion
    {
        [Required]
        public Guid Id { get; set; }
        public Guid TenderId { get; set; }
        public Tender Tender { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Weight { get; set; }
    }
}
