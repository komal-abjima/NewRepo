using System.ComponentModel.DataAnnotations;

namespace Ecommerce_Website.Models
{
    public class Product
    {
        [Key]
        public int id { get; set; }
        public string title {  get; set; }
        public string price { get; set; }
        public string description { get; set; }
        public string category { get; set; }
        public string image { get; set; }
        public string rating { get; set; }
    }
}
