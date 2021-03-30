using System.Data.Entity;

namespace MainNotus.business.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext context;
        public UnitOfWork(DbContext context)
        {
            this.context = context;
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
