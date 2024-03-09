using System.ComponentModel.DataAnnotations;

namespace Third_API_Project.Models
{
    public class City
    {
        [Key]
        public Guid CityID { get; set; }
        [Required(ErrorMessage ="City Name can't be empty.")]
        public string? CityName { get; set; }
    }
}
