using MainNotus.data.Contexts;
using System.Data.Entity;

namespace MainNotus.data.Repositories
{
    public class NotesRepository : GenericRepository<Note>
    {
        public NotesRepository(DbContext context) : base(context)
        {
        }
    }
}
