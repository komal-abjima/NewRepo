using System.ComponentModel.DataAnnotations;

namespace Employee_Mngmt_Project.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public int Salary { get; set; }
    }
}
