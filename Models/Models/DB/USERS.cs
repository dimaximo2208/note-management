using System.ComponentModel;

namespace Models.DB
{
    public class USERS
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? InsertDate { get; set; }
        [DefaultValue(false)]
        public bool? FlgDeleted { get; set; }
    }
}
