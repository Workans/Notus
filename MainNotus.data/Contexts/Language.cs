using System.Collections;
using System.Collections.Generic;

namespace MainNotus.data.Contexts
{
    public class Language
    {
        public int LanguageId { get; set; }
        public string LanguageName { get; set; }
        public virtual Note Note { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
    }
}
