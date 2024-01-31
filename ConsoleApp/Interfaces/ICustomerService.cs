namespace ConsoleApp.Interfaces;

internal interface ICustomerService
{
    bool AddCustomerToList(ICustomer customer);
    IEnumerable<ICustomer> GetCustomersFromList();
    ICustomer GetCustomerFromList(string Email);
    ICustomer DeleteCustomerFromList(string Email);
}
