using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Music_Management_System.Models
{
    public class Music
    {
        [Key]
        public int Id { get; set; }
        [DefaultValue("https://images.unsplash.com/photo-1619983081563-430f63602796?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Nnx8bXVzaWN8ZW58MHx8MHx8fDA%3D")]
        public string Image { get; set; }
        public string SongName { get; set; }
        public string SingerName { get; set; }
        public int ReleaseYear { get; set; }
        public string MovieName { get; set; }
        public string SongType { get; set; }

    }
}
