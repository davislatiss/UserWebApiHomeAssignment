using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KleintechTestTask.Core.Models;
using KleintechTestTask.Core.Services;
using KleintectTestTask.Data;

namespace KleintechTestTask.Services
{
    public class EntityService<T> : DbService, IEntityService<T> where T : Entity

    {
        public EntityService(KleintechTestTaskDbContext context) : base(context)
        {

        }

        public void Create(T entity)
        {
            Create<T>(entity);
        }

        public void Delete(T entity)
        {
            Delete<T>(entity);
        }

        public IEnumerable<T> Get()
        {
            return Get<T>();
        }

        public T GetById(int id)
        {
            return GetById<T>(id);
        }

        public IQueryable<T> Query()
        {
            return Query<T>();
        }

        public void Update(T entity)
        {
            Update<T>(entity);
        }
    }
}
