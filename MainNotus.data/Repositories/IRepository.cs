using System.Collections.Generic;

namespace MainNotus.data.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void AddUpdate(T entity);
        void Remove(T entity);
    }
}
