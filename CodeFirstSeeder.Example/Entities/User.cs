using System.Collections.Generic;

namespace CodeFirstSeeder.Example.Entities
{
    public class User
    {
        public User()
        {
            Roles = new HashSet<Role>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public virtual Location Location { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}