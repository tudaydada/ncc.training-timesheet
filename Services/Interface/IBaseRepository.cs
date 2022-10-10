using Microsoft.EntityFrameworkCore;

namespace TimeSheet.Services.Interface
{
    public interface IBaseRepository<T> where T : class
    {
        T GetById(int id);
        public IEnumerable<T> Find(Func<T, bool> predicate);
        DbSet<T> GetAll();
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int id);
        void SaveChanges();
    }
}
