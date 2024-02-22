using ProgramClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class Objects
    {
        static void Main()
        {
            List<Product> products = new List<Product>();
            string choice;
            do
            {
                Console.Write("Enter Product Id:");
                int pid = int.Parse(Console.ReadLine());
                Console.Write("Enter Product Name:");
                string pname = Console.ReadLine();
                Console.Write("Enter Price:");
                double price = double.Parse(Console.ReadLine());
                Console.Write("Enter date of manufacture:(yyyy-mm-dd)");
                DateTime dom = DateTime.Parse(Console.ReadLine());

                Product product = new Product() { productId = pid, productName = pname, Price = price, DateOfManufacture = dom };
                products.Add(product);

                Console.WriteLine("Product Added\n");
                Console.WriteLine("Do you want to continue?(Yes/No):");
                choice = Console.ReadLine();

            }while(choice != "No" && choice != "no" && choice != "n" && choice != "N");

            Console.WriteLine("\n Products:");
            foreach(Product item in products)
            {
                Console.WriteLine(item.productId + "," + item.productName + "," + item.Price + "," + item.DateOfManufacture.ToShortDateString());
            }

            Console.ReadKey();
        
        
        }
    }
}
