using System.Collections.Generic;

namespace FilteringInBlazor.Database.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly SqlDbContext Context;

        protected BaseRepository(SqlDbContext context)
        {
            Context = context;
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        public T Get<T>(int id) where T : class
        {
            return Context.Set<T>().Find(id);
        }

        public void Add<T>(T toAdd) where T : class
        {
            Context.Set<T>().Add(toAdd);
        }

        public void Remove<T>(T toRemove) where T : class
        {
            Context.Set<T>().Remove(toRemove);
        }

        public void RemoveRange<T>(IEnumerable<T> toRemove) where T : class
        {
            Context.Set<T>().RemoveRange(toRemove);
        }

        public void UpdateWithNewValues<T>(T oldEntity, T newEntity) where T : class
        {
            Context.Entry(oldEntity).CurrentValues.SetValues(newEntity);
        }
    }
}