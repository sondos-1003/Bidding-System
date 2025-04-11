using System.ComponentModel.DataAnnotations;

namespace EntitiesTest.Entities
{
    public class UserRole
    {
        [Required] public int UserId { get; set; }
        public User Users { get; set; }

        public Guid RoleId { get; set; }
        public Role Role { get; set; }
    }
}
