using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4.LINQ_LAST_AND_LASTORDEFAULT
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


            //Where
            List<Employee> filteredEmployees = employees.Where(emp => emp.Job == "Manager").ToList();
            Console.WriteLine(filteredEmployees[filteredEmployees.Count - 1].EmpId + "," + filteredEmployees[filteredEmployees.Count - 1].EmpName + "," + filteredEmployees[filteredEmployees.Count - 1].Job);

            //Last
            Employee lastManager = employees.Last(emp => emp.Job == "Manager");
            Console.WriteLine(lastManager.EmpId + "," + lastManager.EmpName);

            //FirstOrDefault
            Employee lastManager2 = employees.LastOrDefault(emp => emp.Job == "Clerk");
            if (lastManager2 != null)
            {
                Console.WriteLine(lastManager2.EmpId + "," + lastManager2.EmpName);
            }
            else
            {
                Console.WriteLine("No clerk in the list");
            }



            Console.ReadKey();

        }
    }
}
