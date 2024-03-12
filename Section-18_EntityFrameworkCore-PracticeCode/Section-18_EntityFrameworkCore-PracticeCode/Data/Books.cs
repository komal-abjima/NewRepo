using System.ComponentModel.DataAnnotations;

namespace Section_18_EntityFrameworkCore_PracticeCode.Data
{
    public class Books
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Title is can't be empty.")]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
