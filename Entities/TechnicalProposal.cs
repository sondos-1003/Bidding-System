namespace EntitiesTest.Entities
{
    public class TechnicalProposal
    {
        public Guid Id { get; set; }
        public Guid BidId { get; set; }
        public Bid Bid { get; set; }
        public string Summary { get; set; }
        public string Methodology { get; set; }
        public string Timeline { get; set; }
        public string KeyPersonnel { get; set; }
    }
}
