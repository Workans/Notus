namespace MainNotus.business.DTO
{
    public class NoteDTO
    {
        public int NoteId { get; set; }
        public string NoteName { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public int LanguageId { get; set; }
    }
}
