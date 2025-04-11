namespace EntitiesTest.DTOs
{
    public class EvaluationDto
    {
        public Guid BidId { get; set; }          // ✅ Must be Guid
        public int EvaluatorId { get; set; }    // ✅ Must be Guid
        public string Comments { get; set; }
       
        public int Score { get; set; } // e.g., from 1 to 10
    }
}
