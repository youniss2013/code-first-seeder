using System;
using System.Data.Entity;
using CodeFirstSeeder.Example.Entities;

namespace CodeFirstSeeder.Example
{
    internal class Program
    {
        private static void Main( string[] args )
        {
            Database.SetInitializer( new Xml.DropCreateDatabaseAlways<MyContext>() );

            var context = new MyContext();

            foreach ( Location location in context.Locations )
            {
                Console.WriteLine( location.City );

                foreach ( User user in location.Users )
                {
                    Console.WriteLine( String.Format( "\t{0} {1} {2}", user.Name, user.Age, user.Gender) );

                    foreach ( Role role in user.Roles )
                    {
                        Console.WriteLine( String.Format( "\t\t\t{0}", role.Name ) );
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine( "Press ENTER to end" );
            Console.ReadLine();
        }
    }
}