using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace MainNotus.data.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        DbContext context;
        IDbSet<T> table;
        public GenericRepository(DbContext context)
        {
            this.context = context;
            table = this.context.Set<T>();
        }
        public void AddUpdate(T entity)
        {
            table.AddOrUpdate(entity);
            context.SaveChanges();
        }

        public T Get(int id) => table.Find(id);

        public IEnumerable<T> GetAll() => table;

        public void Remove(T entity)
        {
            table.Remove(entity);
            context.SaveChanges();
        }
    }
}
