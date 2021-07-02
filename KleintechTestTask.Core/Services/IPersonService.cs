using KleintechTestTask.Core.Models;

namespace KleintechTestTask.Core.Services
{
    public interface IPersonService : IEntityService<Person>
    {
        Person GetFullPerson(int id);
    }
}
