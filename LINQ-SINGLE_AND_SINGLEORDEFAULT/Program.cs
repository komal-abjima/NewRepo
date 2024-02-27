using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4.LINQ_SINGLE_AND_SINGLEORDEFAULT
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
    //        new Employee() { EmpId = 1, EmpName = "Henry", Job = "Designer", Salary = 100000 },
    //        new Employee() { EmpId = 2, EmpName = "YUVI", Job = "Manager", Salary = 20000 },
    //        new Employee() { EmpId = 3, EmpName = "Rishi", Job = "Manager", Salary = 3000 }
    //        };


    //        //Single - it takes only single element coz in this DEsigner is acceptable but manager throws an error because it is two 
    //        Employee resultEmp = employees.Single(emp => emp.Job == "Designer");
    //        Console.WriteLine(resultEmp.EmpId + "," + resultEmp.EmpName);

    //        //SingleOrDefault
    //        Employee resultEmp2 = employees.SingleOrDefault(emp => emp.Job == "Clerk");
    //        if (resultEmp2 != null)
    //        {
    //            Console.WriteLine(resultEmp2.EmpId + "," + resultEmp2.EmpName);
    //        }
    //        else
    //        {
    //            Console.WriteLine("No clerk in the list");
    //        }



    //        Console.ReadKey();

    //    }
    //}
}
