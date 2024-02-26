using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4.LINQ_FIRST_AND_FIRSTORDEFAULT
{
    //class Employee
    //{
    //    public int EmpId { get; set; }
    //    public string EmpName { get; set; }
    //    public string Job { get; set; }
    //    public double Salary { get; set; }
    //}
    //class Program
    //{
    //    static void Main()
    //    {
    //        List<Employee> employees = new List<Employee>()
    //        {
    //        new Employee() { EmpId = 1, EmpName = "Henry", Job = "Deisgner", Salary = 100000 },
    //        new Employee() { EmpId = 2, EmpName = "YUVI", Job = "Manager", Salary = 20000 },
    //        new Employee() { EmpId = 3, EmpName = "Rishi", Job = "Manager", Salary = 3000 }
    //        };


    //        //Where
    //        List<Employee> filteredEmployees = employees.Where(emp => emp.Job == "Manager").ToList();
    //        Console.WriteLine(filteredEmployees[0].EmpId + "," + filteredEmployees[1].EmpId);

    //        //First
    //        Employee firstManager = employees.First(emp => emp.Job == "Manager");
    //        Console.WriteLine(firstManager.EmpId + "," + firstManager.EmpName);

    //        //FirstOrDefault
    //        Employee firstManager2 = employees.FirstOrDefault(emp => emp.Job == "Clerk");
    //        if(firstManager2 != null)
    //        {
    //            Console.WriteLine(firstManager2.EmpId + "," + firstManager2.EmpName);
    //        }
    //        else
    //        {
    //            Console.WriteLine("No clerk in the list");
    //        }



    //        Console.ReadKey();

    //    }
    //}
}
