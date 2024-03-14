using System.ComponentModel.DataAnnotations;

namespace Section_18_EntityFrameworkCore_PracticeCode.Models
{
    public class SignInModel
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
