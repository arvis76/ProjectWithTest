using ConsoleApp.Interfaces;
using System.Diagnostics;

namespace ConsoleApp.Services;

public class CustomerService : ICustomerService
{
    private readonly IFileService _fileService = new FileService();
    private List<ICustomer> _customers = new List<ICustomer>();
    private readonly string _filePath = @"c:\projects\contacts.json";

    public bool AddCustomerToList(ICustomer customer)
    {
        try
        {
            if (!_customers.Any(x => x.Email == customer.Email))
            {
                _customers.Add(customer);
                string json = JsonConvert.SerializeObject(_customers, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
                var result = _fileService.SaveContentToFile(_filePath, json);
                return result;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;

    }

    public IEnumerable<ICustomer> GetCustomersFromList()
    {
        try
        {
            var content = _fileService.GetContentFromFile(_filePath);
            if (!string.IsNullOrEmpty(content))
            {
                _customers = JsonConvert.DeserializeObject<List<ICustomer>>(content, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All })!;
                return _customers;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public ICustomer GetCustomerFromList(string Email)
    {
        try
        {
            GetCustomersFromList();

            var customer = _customers.FirstOrDefault(x => x.Email == Email);
            return customer ??= null!;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }



    public ICustomer DeleteCustomerFromList(string Email)
    {
        try
        {
            var customer = _customers.FirstOrDefault(y => y.Email == Email);
            if (customer != null)
            {
                _customers.Remove(customer);
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

}
