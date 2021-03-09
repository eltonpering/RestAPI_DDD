using Entities.Entities;
using Infrastructure.Configuration;

namespace UnitTestRestAPI
{
    public class DBUnitTestsMockInitializer
    {
        public DBUnitTestsMockInitializer()
        { }


        public void Seed(ContextBase context)
        {
            context.Address.Add
            (new Address { Street  = "Avenida Imigrantes", Number = 1, Zipcode = 88100000, City = "Brasília", State = "Distrito Federal",  Country = "Brasil" });
            context.Address.Add
            (new Address { Street = "Rua Gonçalo de Carvalho", Number = 2, Zipcode = 88200000, City = "Porto Alegre", State = "Rio Grande do Sul", Country = "Brasil" });
            context.Address.Add
            (new Address { Street = "Rua das Pedras", Number = 3, Zipcode = 88300000, City = "Buzios", State = "Rio de Janeiro", Country = "Brasil" });
            context.Address.Add
            (new Address { Street = "Avenida Paulista", Number = 4, Zipcode = 88400000, City = "São Paulo", State = "São Paulo", Country = "Brasil" });

            context.Customer.Add
            (new Customer { Name = "José da Silva" });
            context.Customer.Add
            (new Customer { Name = "Maria Perreira" });
            context.Customer.Add
            (new Customer { Name = "João Santos" });

            context.PhoneCustomer.Add
            (new PhoneCustomer { CustomerId = 1, PhoneNumber = "99999999" });
            context.PhoneCustomer.Add
            (new PhoneCustomer { CustomerId = 2, PhoneNumber = "11111111" });
            context.PhoneCustomer.Add
            (new PhoneCustomer { CustomerId = 3, PhoneNumber = "91919191" });


            context.AddressCustomer.Add
            (new AddressCustomer { CustomerId = 1, AddressId = 1 });
            context.AddressCustomer.Add
            (new AddressCustomer { CustomerId = 2, AddressId = 1 });

            context.SaveChanges();
        }


    }
}
