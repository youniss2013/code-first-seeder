using System.Data.Entity;

namespace CodeFirstSeeder.Xml
{
    /// <summary>
    /// An implementation of IDatabaseInitializer that will always recreate and re-seed the database the first time that a context is used in the app domain.
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    public class DropCreateDatabaseAlways<TContext> : System.Data.Entity.DropCreateDatabaseAlways<TContext> where TContext : DbContext
    {
        private readonly string _xmlSeedFilename;

        /// <summary>
        /// Seed data will be used from {YourContextClassName}.xml
        /// </summary>
        public DropCreateDatabaseAlways()
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="xmlSeedFilename">Custom XML seed data filename</param>
        public DropCreateDatabaseAlways( string xmlSeedFilename )
        {
            _xmlSeedFilename = xmlSeedFilename;
        }

        protected override void Seed( TContext context )
        {
            var seeder = new XmlSeeder<TContext>( context, _xmlSeedFilename );
            seeder.Seed();

            base.Seed( context );
        }
    }
}