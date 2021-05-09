using System.Collections.Generic;

namespace EntityFramework5.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Group> Groups { get; set; }

        public ICollection<Membership> Memberships { get; set; }
    }
}
