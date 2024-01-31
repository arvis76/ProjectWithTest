namespace ConsoleApp.Interfaces;

internal interface ICustomer
{
    string StreetName { get; set; }
    string StreetNumber { get; set; }
    string TownName { get; set; }

    string Email { get; set; }
    string FirstName { get; set; }
    string LastName { get; set; }
    string PhoneNumber { get; set; }
}
