using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4.ELEMENTAT_AND_ELEMENTATORDEFAULT
{
    class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string Job { get; set; }
        public double Salary { get; set; }
    }
    class Program
    {
        static void Main()
        {
            List<Employee> employees = new List<Employee>()
            {
            new Employee() { EmpId = 1, EmpName = "Henry", Job = "Deisgner", Salary = 100000 },
            new Employee() { EmpId = 2, EmpName = "YUVI", Job = "Manager", Salary = 20000 },
            new Employee() { EmpId = 3, EmpName = "Rishi", Job = "Manager", Salary = 3000 }
            };


            //ElementAt
            Employee resultEmp = employees.Where(emp => emp.Job == "Manager").ElementAt(1);
            Console.WriteLine(resultEmp.EmpId + "," + resultEmp.EmpName);

            //ElementAtOrDefault
            Employee resultEmp2 = employees.Where(emp => emp.Job == "Clerk").ElementAtOrDefault(4);
            if (resultEmp2 != null)
            {
                Console.WriteLine(resultEmp2.EmpId + "," + resultEmp2.EmpName);
            }
            else
            {
                Console.WriteLine("No clerk in the list");
            }



            Console.ReadKey();

        }
    }
}
