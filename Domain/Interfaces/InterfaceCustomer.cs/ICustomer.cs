using Domain.Interfaces.Generics;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfaceCustomer
{
    public interface ICustomer : IGeneric<Customer>
    {
        Task<List<Customer>> ListCustumerbyId(int customerId);

        Task<List<Customer>> ListCustomer(Expression<Func<Customer, bool>> exCustomer);
    }
}
