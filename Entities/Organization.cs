using System.Reflection;

namespace EntitiesTest.Entities
{
    public class Organization
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string RegistrationNumber { get; set; }
        public string Address { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }

        public ICollection<Tender> Tenders { get; set; }
    }
}
