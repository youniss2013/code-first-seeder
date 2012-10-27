using System.Data.Entity;

namespace CodeFirstSeeder.Xml
{
    /// <summary>
    /// An implementation of IDatabaseInitializer that will DELETE, recreate,
    /// and re-seed the database only if the model has changed since
    /// the database was created. This is achieved by writing a hash of the store
    /// model to the database when it is created and then comparing that hash with
    /// one generated from the current model. Seed data is retrieved from an XML file
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    public class DropCreateDatabaseIfModelChanges<TContext> : System.Data.Entity.DropCreateDatabaseIfModelChanges<TContext> where TContext : DbContext
    {
        private readonly string _xmlSeedFilename;

        /// <summary>
        /// Seed data will be used from {YourContextClassName}.xml
        /// </summary>
        public DropCreateDatabaseIfModelChanges()
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="xmlSeedFilename">Custom XML seed data filename</param>
        public DropCreateDatabaseIfModelChanges( string xmlSeedFilename )
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