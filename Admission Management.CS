using System;

public class Student
{
    private int studentId;
    private string studentName;
    private string course;
    private bool hostel;
    private bool bus;

    public Student(int id, string name, string courseName, bool hostelFacility, bool busFacility)
    {
        studentId = id;
        studentName = name;
        course = courseName;
        hostel = hostelFacility;
        bus = busFacility;
    }

    public void DisplayDetails(double scholarship, int totalFees)
    {
        Console.WriteLine("\n========== Student Admission Details ==========");
        Console.WriteLine("Student ID      : " + studentId);
        Console.WriteLine("Student Name    : " + studentName);
        Console.WriteLine("Course          : " + course);
        Console.WriteLine("Hostel Facility : " + (hostel ? "Yes" : "No"));
        Console.WriteLine("Bus Facility    : " + (bus ? "Yes" : "No"));
        Console.WriteLine("Scholarship     : " + scholarship + "%");
        Console.WriteLine("Total Fees      : ₹" + totalFees);
    }
}

class Program
{
    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        const int CourseFee = 50000;
        const int HostelFee = 30000;
        const int BusFee = 10000;

        char choice;

        do
        {
            int id;
            string name, course;
            double percentage;

            Console.WriteLine("\n==================================");
            Console.WriteLine("      STUDENT ADMISSION FORM");
            Console.WriteLine("==================================");

            Console.Write("Enter 12th Percentage: ");
            percentage = Convert.ToDouble(Console.ReadLine());

            if (percentage < 50)
            {
                Console.WriteLine("\nStudent is NOT eligible for admission.");
            }
            else
            {
                Console.Write("Enter Student ID: ");
                id = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Student Name: ");
                name = Console.ReadLine();

                Console.Write("Enter Course Name: ");
                course = Console.ReadLine();

                Console.Write("Do you want Hostel Facility? (Y/N): ");
                bool hostel = Console.ReadLine().ToUpper() == "Y";

                Console.Write("Do you want Bus Facility? (Y/N): ");
                bool bus = Console.ReadLine().ToUpper() == "Y";

               
                double scholarship = 0;

                if (percentage >= 90)
                    scholarship = 50;
                else if (percentage >= 80)
                    scholarship = 30;
                else if (percentage >= 70)
                    scholarship = 20;
                else if (percentage >= 60)
                    scholarship = 10;

                int totalFee = CourseFee;

                if (hostel)
                    totalFee += HostelFee;

                if (bus)
                    totalFee += BusFee;

                int scholarshipAmount = (int)(CourseFee * scholarship / 100);
                totalFee -= scholarshipAmount;

                Student s = new Student(id, name, course, hostel, bus);

                Console.WriteLine("\n------- Fee Details ---------");
                Console.WriteLine("Course Fee   : ₹" + CourseFee);

                if (hostel)
                    Console.WriteLine("Hostel Fee  : ₹" + HostelFee);

                if (bus)
                    Console.WriteLine("Bus Fee  : ₹" + BusFee);

                Console.WriteLine("Scholarship : " + scholarship + "%");
                Console.WriteLine("Scholarship Amount: ₹" + scholarshipAmount);

                s.DisplayDetails(scholarship, totalFee);

                Console.WriteLine("\nAdmission Successful.");
            }

            Console.Write("\nDo you want to add another student? (Y/N): ");
            choice = Convert.ToChar(Console.ReadLine().ToUpper());

        } while (choice == 'Y');

        Console.WriteLine("\nThank You!");
    }
}