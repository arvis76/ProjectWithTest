using ConsoleApp.Interfaces;
using ConsoleApp.Models;

namespace ConsoleApp.Services;

internal class MenuService
{
    private readonly ICustomerService _customerService = new CustomerService();
    public void ShowMainMenu()
    {
        while (true)
        {
            DisplayMenuTile("Main Menu");
            Console.WriteLine("  1. Add Customer");
            Console.WriteLine();
            Console.WriteLine("  2. Viem Customer list");
            Console.WriteLine();
            Console.WriteLine("  3. Delete User");
            Console.WriteLine();
            Console.WriteLine("  0. Exit");
            Console.WriteLine();
            Console.Write("  Enter your option: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    ShowAddCustomerOption();
                    break;
                case "2":
                    ShowViewCustomerListOption();
                    break;
                case "3":
                    ShowDeleteCustomerOption();
                    break;
                case "0":
                    ShowExitApplicationOption();
                    break;
                default:
                    Console.WriteLine("This is not a option please try again");
                    Console.ReadKey();
                    break;
            }
        }

    }
    private void ShowExitApplicationOption()
    {
        Console.Clear();
        Console.Write("Are you sure you want to exit? (y/n) :");
        var option = Console.ReadLine() ?? "";

        if (option.Equals("y", StringComparison.OrdinalIgnoreCase))
        {
            Environment.Exit(0);
        }

    }

    public void ShowAddCustomerOption()
    {
        ICustomer customer = new Customer();


        DisplayMenuTile("Add a new customer");
        Console.Write(" First name: ");
        customer.FirstName = Console.ReadLine()!;
        Console.Write(" Last name: ");
        customer.LastName = Console.ReadLine()!;
        Console.Write(" Email: ");
        customer.Email = Console.ReadLine()!;
        Console.Write(" Street name: ");
        customer.StreetName = Console.ReadLine()!;
        Console.Write(" Street number: ");
        customer.StreetNumber = Console.ReadLine()!;
        Console.Write(" City: ");
        customer.TownName = Console.ReadLine()!;
        Console.Write(" Phone number: ");
        customer.PhoneNumber = Console.ReadLine()!;

        _customerService.AddCustomerToList(customer);





    }
    public void ShowViewCustomerListOption()
    {
        DisplayMenuTile("Customer list");
        var customers = _customerService.GetCustomersFromList();
        foreach (var customer in customers)
        {

            Console.WriteLine($"\n Firstname: {customer.FirstName}\n Lastname: {customer.LastName}\n Email: {customer.Email}\n Streetname: {customer.StreetName}\n Streetnumber: {customer.StreetNumber}\n City: {customer.TownName}\n Phone number: {customer.PhoneNumber}");
            Console.ReadKey();

        }


    }




    private void DisplayMenuTile(string title)
    {

        Console.Clear();
        Console.WriteLine(" --------------------");
        Console.WriteLine($" {title} ");
        Console.WriteLine(" --------------------");
        Console.WriteLine();
    }

    public void ShowDeleteCustomerOption()
    {

        Console.Clear();
        Console.Write("Are you sure you want delete? (y/n) :");
        var option = Console.ReadLine() ?? "";

        if (option.Equals("y"))
        {
            Console.Write("Write the email adress that you want to delete: ");

            _customerService.DeleteCustomerFromList(option);
            Console.ReadKey();
        }

    }
}
