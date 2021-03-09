using Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationApp.Interfaces
{
    public interface  InterfaceAddressApp : InterfaceGenericaApp<Address>
    {
        Task AddAddress(Address customer);
        Task UpdateAddress(Address customer);
        Task DeleteAddress(Address customer);
        Task<List<Address>> ListAddressbyId(int addressId);
    }
}
