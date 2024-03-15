namespace Crud_API_Project_First.Models
{
    public class SuperHerocs
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Place { get; set; } = string.Empty;
    }
}
