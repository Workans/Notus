using System.Data.Entity;

namespace MainNotus.data.Contexts
{
    public class NotusContext : DbContext
    {
        public NotusContext() : base("NotusConnect")
        {
            Database.SetInitializer(new DbInitializer());
        }

        public DbSet<Language> Languages { get; set; }
        public DbSet<Note> Notes { get; set; }
    }
}
