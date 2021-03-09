using Entities.Entities;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Web_ECommerce.Controllers;
using Xunit;

namespace UnitTestRestAPI
{
    public class CustomerUnitTestController
    {
        public static DbContextOptions<ContextBase> dbContextOptions { get; }

        public static string connectionString =
           "Data Source=LAPTOP-L03EIPVD;Initial Catalog=RESTAPI_DB;Integrated Security=False;User ID=sa;Password=1234;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";

        static CustomerUnitTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<ContextBase>()
               .UseSqlServer(connectionString)
               .Options;
        }


        public CustomerUnitTestController()
        {
            var context = new ContextBase(dbContextOptions);

            //Popular registros no banco de dados
            //COMENTAR AS DUAS LINHA ABAIXO APOS PRIMEIRA EXECUÇÃO, POIS O BD ESTARÁ POPULADO
            DBUnitTestsMockInitializer db = new DBUnitTestsMockInitializer();
            db.Seed(context);
        }


        //testes unitários================================================
        // testar o método GET
        //====================================Get =====================================
        [Fact]
        public void GetAddressById_Return_OkResult()
        {
            var context = new ContextBase(dbContextOptions);            

            //Arrange  
            var controller = new CustomerController(context);

            //Act  
            var data = controller.Get();
            Console.WriteLine(data);

            //Assert  
            Assert.IsType<List<Customer>>(data.Value);
        }

    }
}
