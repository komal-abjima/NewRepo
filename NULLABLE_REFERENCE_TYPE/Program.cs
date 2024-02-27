class Employee
{
    public int x { get; set; }

}
class EmployeeLogic
{
    public Employee? GetEmployee()
    {
        return null;

    }
}

class Program
{
    static void Main(string[] args)
    {
        EmployeeLogic el = new EmployeeLogic();
        Employee? emp = el.GetEmployee();
        if(emp != null) { 
        Console.WriteLine(emp.x);
        }
        else
        {
            Console.WriteLine("It is null");
        }
        Console.ReadKey();
    }
}
