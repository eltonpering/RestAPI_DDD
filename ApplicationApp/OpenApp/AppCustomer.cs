using ApplicationApp.Interfaces;
using Domain.Interfaces.InterfaceCustomer;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationApp.OpenApp
{
    public class AppCustomer : InterfaceCustomerApp
    {
        ICustomer _ICustomer;
        IServiceCustomer _IServiceCustomer;

        public AppCustomer(ICustomer ICustomer, IServiceCustomer IServiceCustomer)
        {
            _ICustomer = ICustomer;
            _IServiceCustomer = IServiceCustomer;
        }

        public async Task Add(Customer Objeto)
        {
            await _ICustomer.Add(Objeto);
        }

        public async Task AddCustomer(Customer customer)
        {
            await _IServiceCustomer.AddCustomer(customer);
        }

        public async Task DeleteCustomer(Customer customer)
        {
            await _IServiceCustomer.DeleteCustomer(customer);
        }

        public async Task UpdateCustomer(Customer customer)
        {
            await _IServiceCustomer.UpdateCustomer(customer);
        }

        public async Task Delete(Customer Objeto)
        {
            await _ICustomer.Delete(Objeto);
        }        

        public async Task<Customer> GetEntityById(int Id)
        {
            return await _ICustomer.GetEntityById(Id);
        }

        public async Task<List<Customer>> List()
        {
            return await _ICustomer.List();
        }

        public async Task Update(Customer Objeto)
        {
            await _ICustomer.Update(Objeto);
        }     

        public async Task<List<Customer>> ListCustumerbyId(int customerId)
        {
            return await _ICustomer.ListCustumerbyId(customerId);
        }

    }
}
