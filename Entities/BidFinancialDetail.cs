namespace EntitiesTest.Entities
{
    public class BidFinancialDetail
    {
        public Guid Id { get; set; }
        public Guid BidId { get; set; }
        public Bid Bid { get; set; }
        public string ItemDescription { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public string Notes { get; set; }
    }
}
