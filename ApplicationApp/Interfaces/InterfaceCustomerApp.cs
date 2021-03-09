using Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationApp.Interfaces
{
    public interface InterfaceCustomerApp : InterfaceGenericaApp<Customer>
    {
        Task AddCustomer(Customer customer);
        Task UpdateCustomer(Customer customer);
        Task DeleteCustomer(Customer customer);
        Task<List<Customer>> ListCustumerbyId(int customerId);
    }
}
