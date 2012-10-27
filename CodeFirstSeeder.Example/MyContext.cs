using System.Data.Entity;
using CodeFirstSeeder.Example.Entities;

namespace CodeFirstSeeder.Example
{
    public class MyContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Role> Roles { get; set; }
    }
}