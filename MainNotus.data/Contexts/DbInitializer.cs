using System.Collections.Generic;
using System.Data.Entity;

namespace MainNotus.data.Contexts
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<NotusContext>
    {
        protected override void Seed(NotusContext context)
        {

            context.Languages.AddRange(new List<Language>
            {
                new Language { LanguageName="C#"},
                new Language { LanguageName="C++"},
                new Language { LanguageName="JavaScript"},
                new Language { LanguageName="T-SQL"}
            });
            context.Notes.AddRange(new List<Note>
            {
                new Note
                {
                    NoteName="Ex1",
                    ShortDescription="Ex1",
                    FullDescription="Ex1",
                    LanguageId=1
                },
                new Note
                {
                    NoteName="Ex2",
                    ShortDescription="Ex2",
                    FullDescription="Ex2",
                    LanguageId=3
                }
            });

            context.SaveChanges();
        }
    }
}
