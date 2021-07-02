using System.Data.Entity;
using KleintechTestTask.Core.Models;
using KleintectTestTask.Data.Migrations;

namespace KleintectTestTask.Data
{
    public class KleintechTestTaskDbContext : DbContext, IKleintechTestTaskDbContext
    {
        public KleintechTestTaskDbContext() : base("KleintechTestTaskDbContext")
        {
            Database.SetInitializer<KleintechTestTaskDbContext>(
                new MigrateDatabaseToLatestVersion
                    <KleintechTestTaskDbContext,Configuration>());
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
