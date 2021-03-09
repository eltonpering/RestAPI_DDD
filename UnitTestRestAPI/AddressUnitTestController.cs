using Entities.Entities;
using FluentAssertions;
using Infrastructure.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using Web_ECommerce.Controllers;
using Xunit;

namespace UnitTestRestAPI
{
    public class AddressUnitTestController
    {
        public readonly ContextBase _ContextBase;

        public static DbContextOptions<ContextBase> dbContextOptions { get; }

        public static string connectionString =
           "Data Source=LAPTOP-L03EIPVD;Initial Catalog=RESTAPI_DB;Integrated Security=False;User ID=sa;Password=1234;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";

        static AddressUnitTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<ContextBase>()
               .UseSqlServer(connectionString)
               .Options;
        }

        public AddressUnitTestController()
        {
            var context = new ContextBase(dbContextOptions);


            //Popular registros no banco de dados
            //COMENTAR AS DUAS LINHA ABAIXO APOS PRIMEIRA EXECUÇÃO, POIS O BD ESTARÁ POPULADO
            DBUnitTestsMockInitializer db = new DBUnitTestsMockInitializer();
            db.Seed(context);
        }


        //testes unitários================================================
        // testar o método GET
        //====================================Get(int id) =====================================
        [Fact]
        public void GetAddressById_Return_OkResult()
        {
            var context = new ContextBase(dbContextOptions);

            //Arrange  
            var controller = new AddressController(context);
            var addressId = 1;

            //Act  
            var data = controller.Get(addressId);
            Console.WriteLine(data);

            //Assert  
            Assert.IsType<Address>(data.Value);
        }

        [Fact]
        public void GetAddressById_Return_NotFoundResult()
        {
            var context = new ContextBase(dbContextOptions);

            //Arrange  
            var controller = new AddressController(context);
            var addressId = 9999;

            //Act  
            var data = controller.Get(addressId);

            //Assert  
            Assert.IsType<NotFoundResult>(data.Result);
        }

        [Fact]
        public void GetAddressById_MatchResult()
        {
            var context = new ContextBase(dbContextOptions);

            //Arrange  
            var controller = new AddressController(context);
            int? addressId = 4;

            //Act  
            var data = controller.Get(addressId);

            //Assert  
            Assert.IsType<Address>(data.Value);
            var address = data.Value.Should().BeAssignableTo<Address>().Subject;

            Assert.Equal("Avenida Paulista", address.Street);
            Assert.Equal(88400000, address.Zipcode);
        }


        //====================================Post=====================================

        [Fact]
        public void Post_Address_AddValidData_Return_CreatedResult()
        {
            var context = new ContextBase(dbContextOptions);

            //Arrange  
            var controller = new AddressController(context);

            var address = new Address() { Street = "Test Addres Post 1", Number = 1234, Zipcode  = 9999999, City = "Brasília", State  = "Distrito Federal", Country  = "Brasil"};

            //Act  
            var data = controller.Post(address);

            //Assert  
            Assert.IsType<CreatedAtRouteResult>(data);
        }


        //===========================================Put =====================================

        [Fact]
        public void Put_Address_Update_ValidData_Return_OkResult()
        {

            var context = new ContextBase(dbContextOptions);

            //Arrange  
            var controller = new AddressController(context);
            var addressId = 1;

            //Act  
            var address = new Address();
            address.Id = addressId;
            address.Street = "Update Test Addres 1";
            address.Zipcode = 0000000000;

            var updatedData = controller.Put(addressId, address);

            //Assert  
            Assert.IsType<OkResult>(updatedData);
        }


        //=======================================Delete ===================================
        [Fact]
        public void Delete_Address_Return_OkResult()
        {
            var context = new ContextBase(dbContextOptions);

            //Arrange  
            var controller = new AddressController(context);
            var addressId = 5;

            //Act  
            var data = controller.Delete(addressId);

            //Assert  
            Assert.IsType<Address>(data.Value);
        }

    }
}
