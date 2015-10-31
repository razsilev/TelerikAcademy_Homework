using System;

class CompanyAndItsManager
{
    static void Main()
    {
        // company info
        string companyName = "";
        string companyAddress = "";
        string companyPhoneNumber = "";
        string companyFax = "";
        string companyWebSite = "";

        // manager info
        string managerFirstName = "";
        string managerLastName = "";
        int managerAge = 0;
        string managerPhoneNumber = "";

        // read company data
        Console.Write("Enter company name:         ");
        companyName = Console.ReadLine();

        Console.Write("Enter company addres:       ");
        companyAddress = Console.ReadLine();

        Console.Write("Enter company phone number: ");
        companyPhoneNumber = Console.ReadLine();

        Console.Write("Enter company fax number:   ");
        companyFax = Console.ReadLine();

        Console.Write("Enter company web site:     ");
        companyWebSite = Console.ReadLine();

        // read manager data
        Console.WriteLine();
        Console.Write("Enter manager first name:   ");
        managerFirstName = Console.ReadLine();

        Console.Write("Enter manager last name:    ");
        managerLastName = Console.ReadLine();

        Console.Write("Enter manager age:          ");
        managerAge = Int32.Parse(Console.ReadLine());

        Console.Write("Enter manager phone number: ");
        managerPhoneNumber = Console.ReadLine();

        // print company data
        Console.WriteLine();
        Console.WriteLine("     Company information");
        Console.WriteLine("name:         " + companyName);
        Console.WriteLine("address:      " + companyAddress);
        Console.WriteLine("phone number: " + companyPhoneNumber);
        Console.WriteLine("fax:          " + companyFax);
        Console.WriteLine("web site:     " + companyWebSite);

        // print manager data
        Console.WriteLine();
        Console.WriteLine("     Manager information");
        Console.WriteLine("first name:   " + managerFirstName);
        Console.WriteLine("last name:    " + managerLastName);
        Console.WriteLine("age:          " + managerAge);
        Console.WriteLine("phone number: " + managerPhoneNumber);
    }
}