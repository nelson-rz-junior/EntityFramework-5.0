using System;

namespace EntityFramework5.Domain.Entities
{
    public class Membership
    {
        public int UserId { get; set; }
        
        public int GroupId { get; set; }
        
        public DateTime CreateDate { get; set; } = DateTime.Now;

        public User User { get; set; }

        public Group Group { get; set; }
    }
}
