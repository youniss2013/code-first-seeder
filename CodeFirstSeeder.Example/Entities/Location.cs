using System.Collections.Generic;

namespace CodeFirstSeeder.Example.Entities
{
    public class Location
    {
        public Location()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }

        public string City { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}