using Microsoft.EntityFrameworkCore;
using TimeSheet.Data;

namespace TimeSheet.Services.Interface.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly TimeSheetDataContext Context;
        public BaseRepository(TimeSheetDataContext context)
        {
            Context = context;
        }
        public void Create(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            Context.Set<T>().Remove(entity);
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return Context.Set<T>().Where(predicate);
        }

        public DbSet<T> GetAll()
        {
            return Context.Set<T>();
        }

        public T GetById(int id)
        {
            return Context.Set<T>().Find(id);
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        public void Update(T entity)
        {
            Context.Set<T>().Update(entity);
        }
    }
}
