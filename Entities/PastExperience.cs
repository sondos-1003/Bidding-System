namespace EntitiesTest.Entities
{
    public class PastExperience
    {
        public Guid Id { get; set; }
        public Guid BidderId { get; set; }
        public Bidder Bidder { get; set; }
        public string ProjectName { get; set; }
        public string ClientName { get; set; }
        public string Description { get; set; }
        public int YearCompleted { get; set; }
        public decimal ContractValue { get; set; }
        public string ContactPerson { get; set; }
        public string ContactPhone { get; set; }
    }
}
