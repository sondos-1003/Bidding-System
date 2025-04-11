using System.ComponentModel.DataAnnotations;

namespace EntitiesTest.Entities
{
    public class User
    {
        [Required]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastLogin { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<Notification> Notifications { get; set; }
        public ICollection<Evaluation> Evaluations { get; set; }
        public ICollection <Tender> Tends{ get; set; }
        public Bidder BidderProfile { get; set; }
    }
}
