using System.Collections.Generic;

namespace MainNotus.business.Services
{
    public interface IService<T>
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        T AddUpdate(T entity);
        void Remove(T entity);
    }
}
