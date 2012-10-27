using System.Data.Entity;

namespace CodeFirstSeeder.Xml
{
    /// <summary>
    /// An implementation of IDatabaseInitializer that will recreate and re-seed the database only if the database does not exist.
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    public class CreateDatabaseIfNotExists<TContext> : System.Data.Entity.CreateDatabaseIfNotExists<TContext> where TContext : DbContext
    {
        private readonly string _xmlSeedFilename;

        /// <summary>
        /// Seed data will be used from {YourContextClassName}.xml
        /// </summary>
        public CreateDatabaseIfNotExists()
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="xmlSeedFilename">Custom XML seed data filename</param>
        public CreateDatabaseIfNotExists( string xmlSeedFilename )
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