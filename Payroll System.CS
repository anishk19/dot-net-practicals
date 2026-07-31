using System;

interface IPayroll
{
    void CalculateSalary();
}

class Employee
{
    protected int empId;
    protected string empName;
    protected string department;
    protected int experience;

    public Employee(int id, string name, string dept, int exp)
    {
        empId = id;
        empName = name;
        department = dept;
        experience = exp;
    }

    public void DisplayDetails()
    {
        Console.WriteLine("\n================================");
        Console.WriteLine("        EMPLOYEE DETAILS");
        Console.WriteLine("================================");
        Console.WriteLine("Employee ID      : " + empId);
        Console.WriteLine("Employee Name    : " + empName);
        Console.WriteLine("Department       : " + department);
        Console.WriteLine("Experience       : " + experience + " Years");
    }

    protected double GetBonus()
    {
        if (experience >= 6)
            return 1000;
        else if (experience >= 3)
            return 500;
        else
            return 0;
    }
}

class FullTimeEmployee : Employee, IPayroll
{
    private double salary;

    public FullTimeEmployee(int id, string name, string dept, int exp, double sal)
        : base(id, name, dept, exp)
    {
        salary = sal;
    }

    public void CalculateSalary()
    {
        double bonus = GetBonus();
        double gross = salary + bonus;
        double tax = gross * 0.10;
        double net = gross - tax;

        DisplayDetails();
        Console.WriteLine("Role             : Full Time");
        Console.WriteLine("Basic Salary     : $" + salary);
        Console.WriteLine("Experience Bonus : $" + bonus);
        Console.WriteLine("Tax (10%)        : $" + tax);
        Console.WriteLine("Net Salary       : $" + net);
    }
}

class PartTimeEmployee : Employee, IPayroll
{
    private int hours;
    private double rate;

    public PartTimeEmployee(int id, string name, string dept, int exp, int h, double r)
        : base(id, name, dept, exp)
    {
        hours = h;
        rate = r;
    }

    public void CalculateSalary()
    {
        double salary = hours * rate;
        double bonus = GetBonus();
        double gross = salary + bonus;
        double tax = gross * 0.10;
        double net = gross - tax;

        DisplayDetails();
        Console.WriteLine("Role             : Part Time");
        Console.WriteLine("Hours Worked     : " + hours);
        Console.WriteLine("Rate Per Hour    : $" + rate);
        Console.WriteLine("Basic Salary     : $" + salary);
        Console.WriteLine("Experience Bonus : $" + bonus);
        Console.WriteLine("Tax (10%)        : $" + tax);
        Console.WriteLine("Net Salary       : $" + net);
    }
}

class Manager : Employee, IPayroll
{
    private double salary;

    public Manager(int id, string name, string dept, int exp, double sal)
        : base(id, name, dept, exp)
    {
        salary = sal;
    }

    public void CalculateSalary()
    {
        double allowance = 2000;
        double bonus = GetBonus();
        double gross = salary + allowance + bonus;
        double tax = gross * 0.10;
        double net = gross - tax;

        DisplayDetails();
        Console.WriteLine("Role             : Manager");
        Console.WriteLine("Basic Salary     : $" + salary);
        Console.WriteLine("Manager Allowance: $" + allowance);
        Console.WriteLine("Experience Bonus : $" + bonus);
        Console.WriteLine("Tax (10%)        : $" + tax);
        Console.WriteLine("Net Salary       : $" + net);
    }
}

class Intern : Employee, IPayroll
{
    private double stipend;

    public Intern(int id, string name, string dept, int exp, double st)
        : base(id, name, dept, exp)
    {
        stipend = st;
    }

    public void CalculateSalary()
    {
        double bonus = GetBonus();
        double gross = stipend + bonus;
        double tax = gross * 0.10;
        double net = gross - tax;

        DisplayDetails();
        Console.WriteLine("Role             : Intern");
        Console.WriteLine("Stipend          : $" + stipend);
        Console.WriteLine("Experience Bonus : $" + bonus);
        Console.WriteLine("Tax (10%)        : $" + tax);
        Console.WriteLine("Net Salary       : $" + net);
    }
}

class Program
{
    static void Main(string[] args)
    {
        int choice;

        do
        {
            Console.Clear();

            Console.WriteLine("==============================================");
            Console.WriteLine("        ABC TECHNOLOGIES PVT. LTD.");
            Console.WriteLine("==============================================");
            Console.WriteLine("Address : Rajkot, Gujarat");
            Console.WriteLine("Contact : +91-9876543210");
            Console.WriteLine("==============================================");

            Console.WriteLine("\nEMPLOYEE REGISTRATION");

            Console.Write("Enter Employee ID : ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Employee Name : ");
            string name = Console.ReadLine();

            Console.WriteLine("\nSelect Department");
            Console.WriteLine("1. IT");
            Console.WriteLine("2. HR");
            Console.WriteLine("3. Finance");
            Console.WriteLine("4. Marketing");
            Console.Write("Enter Choice : ");

            int deptChoice = Convert.ToInt32(Console.ReadLine());

            string department = "";

            switch (deptChoice)
            {
                case 1:
                    department = "IT";
                    break;
                case 2:
                    department = "HR";
                    break;
                case 3:
                    department = "Finance";
                    break;
                case 4:
                    department = "Marketing";
                    break;
                default:
                    department = "General";
                    break;
            }

            Console.Write("Enter Experience (Years) : ");
            int exp = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nChoose Employee Role");
            Console.WriteLine("1. Full Time");
            Console.WriteLine("2. Part Time");
            Console.WriteLine("3. Manager");
            Console.WriteLine("4. Intern");
            Console.Write("Enter Choice : ");

            int role = Convert.ToInt32(Console.ReadLine());

            IPayroll employee = null;

            switch (role)
            {
                case 1:
                    Console.Write("Enter Monthly Salary : $");
                    double fsalary = Convert.ToDouble(Console.ReadLine());

                    employee = new FullTimeEmployee(id, name, department, exp, fsalary);
                    break;

                case 2:
                    Console.Write("Enter Hours Worked : ");
                    int hours = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter Rate Per Hour : $");
                    double rate = Convert.ToDouble(Console.ReadLine());

                    employee = new PartTimeEmployee(id, name, department, exp, hours, rate);
                    break;

                case 3:
                    Console.Write("Enter Monthly Salary : $");
                    double msalary = Convert.ToDouble(Console.ReadLine());

                    employee = new Manager(id, name, department, exp, msalary);
                    break;

                case 4:
                    Console.Write("Enter Monthly Stipend : $");
                    double stipend = Convert.ToDouble(Console.ReadLine());

                    employee = new Intern(id, name, department, exp, stipend);
                    break;

                default:
                    Console.WriteLine("Invalid Role Selected.");
                    break;
            }

            if (employee != null)
            {
                Console.WriteLine("\n================================");
                Console.WriteLine("         SALARY SLIP");
                Console.WriteLine("================================");

                employee.CalculateSalary();
            }

            Console.WriteLine("\n--------------------------------");
            Console.WriteLine("1. Register Another Employee");
            Console.WriteLine("2. Exit");
            Console.Write("Enter Choice : ");
            choice = Convert.ToInt32(Console.ReadLine());

        } while (choice == 1);

        Console.WriteLine("\nThank You for Using Employee Payroll System.");
    }
}