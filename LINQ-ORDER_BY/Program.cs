using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4.LINQ_ORDER_BY
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


    //        //IOrderedEnumerable<Employee> sortedEmployee = employees.OrderBy(emp => emp.EmpName);
    //        //IOrderedEnumerable<Employee> sortedEmployee = employees.OrderBy(emp => emp.Salary);
    //        IOrderedEnumerable<Employee> sortedEmployee = employees.OrderByDescending(emp => emp.Job).ThenBy(emp=>emp.EmpName);

    //        foreach (Employee item in sortedEmployee)
    //        {
    //            Console.WriteLine(item.EmpId + "," + item.EmpName + "," + item.Job + "," + item.Salary);
    //        }

    //        Console.ReadKey();

    //    }
    //}
}
