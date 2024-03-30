namespace Ecommerce_Website.Models
{
    using System.ComponentModel.DataAnnotations;

    namespace Employee_Mngmt_Project.Models
    {
        public class UserModel

        {
            [Key]
            public int Id { get; set; }
            public string FullName { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            

        }
    }
}
