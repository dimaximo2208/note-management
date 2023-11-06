using System.ComponentModel;

namespace Models.DTO
{
    public class NoteDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Text { get; set; }
        public DateTime? InsertDate { get; set; }
        public DateTime? LastUpdate { get; set; }
    }

    public class CreateOrUpdateNoteDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Text { get; set; }
    }
}
