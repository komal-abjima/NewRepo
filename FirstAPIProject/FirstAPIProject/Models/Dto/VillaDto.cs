using System.ComponentModel.DataAnnotations;

namespace FirstAPIProject.Models.Dto
{
    public class VillaDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public int Occupacy { get; set; }
        public int sqft { get; set; }
    }
}
