using Domain.Interfaces.InterfaceCustomer;
using Entities.Entities;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Repositories
{
    public class RepositoryCustomer : RepositoryGenerics<Customer>, ICustomer
    {

        private readonly DbContextOptions<ContextBase> _optionsbuilder;

        public RepositoryCustomer()
        {
            _optionsbuilder = new DbContextOptions<ContextBase>();
        }

        public async Task<List<Customer>> ListCustomer(Expression<Func<Customer, bool>> exCustomer)
        {
            using (var banco = new ContextBase(_optionsbuilder))
            {
                return await banco.Customer.Where(exCustomer).AsNoTracking().ToListAsync();
            }
        }

        public async Task<List<Customer>> ListCustumerbyId(int customerId)
        {
            using (var banco = new ContextBase(_optionsbuilder))
            {
                return await banco.Customer.Where(p => p.Id == customerId).AsNoTracking().ToListAsync();
            }
        }
    }
}
