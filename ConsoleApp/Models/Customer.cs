using ConsoleApp.Interfaces;

namespace ConsoleApp.Models;

internal class Customer : ICustomer
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string StreetName { get; set; } = null!;
    public string StreetNumber { get; set; } = null!;
    public string TownName { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
}
