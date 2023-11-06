using System.ComponentModel;

namespace Models.DB
{
    public class NOTES
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Text { get; set; }
        public DateTime? InsertDate { get; set; }
        [DefaultValue(false)]
        public bool? FlgDeleted { get; set; }
        public DateTime? LastUpdate { get; set; }
    }
}
