using Domain.Interfaces.InterfaceCustomer;
using Domain.Interfaces.InterfaceServices;
using Entities.Entities;
using System;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceCustomer : IServiceCustomer
    {
        private readonly ICustomer _ICustomer;

        public ServiceCustomer(ICustomer ICustomer)
        {
            _ICustomer = ICustomer;
        }

        public async Task AddCustomer(Customer customer)
        {            
           await _ICustomer.Add(customer);          
        }

        public async Task DeleteCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
