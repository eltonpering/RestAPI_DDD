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
    public class AddressController : ControllerBase
    {
        public readonly ContextBase _ContextBase;

        public AddressController(ContextBase contexto)
        {
            _ContextBase = contexto;
        }

        // api/address
        [HttpGet]
        public ActionResult<IEnumerable<Address>> Get()
        {
            try
            {
                return _ContextBase.Address.ToList();
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to get Address in database");
            }
        }

        // api/address/1
        [HttpGet("{id}", Name = "GetAddress")]
        public ActionResult<Address> Get(int? id)
        {

            try
            {
                var address = _ContextBase.Address.FirstOrDefault(p => p.Id == id);

                if (address == null)
                {
                    return NotFound();
                }
                return address;
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error while get Address in database");
            }
        }

        // api/address
        [HttpPost]
        public ActionResult Post([FromBody] Address address)
        {
            try
            {
                _ContextBase.Address.Add(address);
                _ContextBase.SaveChanges();

                return new CreatedAtRouteResult("GetAddress",
                    new { id = address.Id }, address);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error while creeating the Address");
            }          
        }

        // api/address/1
        [HttpPut("{id}")]        
        public ActionResult Put(int id, [FromBody] Address address)
        {

            try
            {
                if (id != address.Id)
                {
                    return BadRequest();
                }

                //_ContextBase.Entry(address).State = EntityState.Modified;
                //_ContextBase.SaveChanges();

                _ContextBase.Address.Update(address);
                _ContextBase.SaveChanges();

                return Ok();
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error while updating the Address");
            }            
        }

        // api/address/1
        [HttpDelete("{id}")]
        public ActionResult<Address> Delete(int id)
        {

            try
            {
                var address = _ContextBase.Address.FirstOrDefault(p => p.Id == id);

                if (address == null)
                {
                    return NotFound();
                }

                _ContextBase.Address.Remove(address);
                _ContextBase.SaveChanges();
                return address;
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error while updating the Address");
            }
        }

    }
}
