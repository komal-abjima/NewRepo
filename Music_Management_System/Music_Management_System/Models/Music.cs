using System.ComponentModel.DataAnnotations;

namespace Music_Management_System.Models
{
    public class Music
    {
        [Key]
        public int Id { get; set; }

        public string Image { get; set; }
        public string SongName { get; set; }
        public string SingerName { get; set; }
        public int ReleaseYear { get; set; }
        public string MovieName { get; set; }
        public string SongType { get; set; }

    }
}
