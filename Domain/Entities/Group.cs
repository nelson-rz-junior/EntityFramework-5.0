using System.Collections.Generic;

namespace EntityFramework5.Domain.Entities
{
    public class Group
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<User> Users { get; set; }

        public ICollection<Membership> Memberships { get; set; }
    }
}
