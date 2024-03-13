using Microsoft.AspNetCore.Identity;

namespace Section_18_EntityFrameworkCore_PracticeCode.Models
{
    public class ApplicationUser : IdentityUser

    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
