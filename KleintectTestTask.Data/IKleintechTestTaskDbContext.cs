using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using KleintechTestTask.Core.Models;

namespace KleintectTestTask.Data
{
    public interface IKleintechTestTaskDbContext
    {
        DbSet<T> Set<T>() where T : class;
        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        DbSet<Person> Persons { get; set; }
        DbSet<Address> Addresses { get; set; }

        int SaveChanges();
    }
}
