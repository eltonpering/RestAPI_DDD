using Entities.Entities;
using Infrastructure.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Web_ECommerce.Controllers
{
    //  [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[Controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        public readonly ContextBase _ContextBase;

        public CustomerController(ContextBase contexto)
        {
            _ContextBase = contexto;
        }

        // api/customer
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> Get()
        {
            try
            {
                return _ContextBase.Customer.Include(x => x.AddressCustomer).Include(x => x.PhoneCustomer).ToList();
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to get Customers in database");
            }
        }


        // api/customer/1
        [HttpGet("{id}", Name = "GetCustomer")]
        public ActionResult<Customer> Get(int id)
        {

            try
            {
                var customer = _ContextBase.Customer.FirstOrDefault(p => p.Id == id);

                if (customer == null)
                {
                    return NotFound($"The Customer with id={id} not found");
                }
                return customer;
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error while get Customer in database");
            }
        }

        // api/customer
        [HttpPost]
        public ActionResult Post([FromBody] Customer customer)
        {
            try
            {
                _ContextBase.Customer.Add(customer);
                _ContextBase.SaveChanges();

                return new CreatedAtRouteResult("GetCustomer",
                    new { id = customer.Id }, customer);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error while creeating the Customer");
            }
        }

        // api/customer/1
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Customer customer)
        {

            try
            {
                if (id != customer.Id)
                {
                    return BadRequest($"The Customer could not be updated with id ={id}");
                }

                _ContextBase.Entry(customer).State = EntityState.Modified;
                _ContextBase.SaveChanges();
                return Ok();
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error while updating the Customer");
            }           
        }

        //  api/customer/1
        [HttpDelete("{id}")]
        public ActionResult<Customer> Delete(int id)
        {
            try
            {
                var customer = _ContextBase.Customer.FirstOrDefault(p => p.Id == id);

                if (customer == null)
                {
                    return NotFound($"The Customer with id = {id} was not found");
                }

                _ContextBase.Customer.Remove(customer);
                _ContextBase.SaveChanges();
                return customer;
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error while updating the Customer");
            }
        }
    }
}
