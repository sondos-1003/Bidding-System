namespace EntitiesTest.Entities
{
    public class Notification
    {
        public Guid Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; }
        public NotificationType Type { get; set; }
        public Guid RelatedEntityId { get; set; }
    }

    public enum NotificationType { TenderPublished, BidSubmitted, BidStatusChanged, EvaluationCompleted }
}
