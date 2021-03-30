using MainNotus.data.Contexts;
using System.Data.Entity;

namespace MainNotus.data.Repositories
{
    public class LanguageRepository : GenericRepository<Language>
    {
        public LanguageRepository(DbContext context) : base(context)
        {
        }
    }
}
