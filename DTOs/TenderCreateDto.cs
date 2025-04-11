using System;

namespace EntitiesTest.DTOs
{
    public class TenderCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public int CreatedByUserId { get; set; }
    }
}
