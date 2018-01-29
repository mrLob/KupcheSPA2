using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using webapi.Models;
using webapi.DTO;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    public class AddressesController : Controller
    {
        public AddressesController(){}

        public IActionResult LastAddress()
        {
            using( servicedbContext db = new servicedbContext() )
            {
                return Ok(db.Addresses.Last());
            }
        }
        [HttpGet]
        public IEnumerable<Addresses> GetAll()
        {
            using( servicedbContext db = new servicedbContext() )
            {
                IEnumerable<Addresses> addr = db.Addresses.Where(a => a.IsDeleted == 0).ToList();
                return addr;
            }
        }
        [HttpPost]
        public IActionResult Create([FromBody]AddressDto address)
        {
            if(ModelState.IsValid)
            {
                Addresses newAddr = new Addresses();
                newAddr.Street = address.Street;
                newAddr.Number = address.Number;
                newAddr.Flat = address.Flat;
                newAddr.CityId = 1;
                using( servicedbContext db = new servicedbContext() )
                {
                    db.Addresses.Add(newAddr);
                    db.SaveChanges();
                }
                return Ok(new{
                    IdAddress = newAddr.IdAddress
                    });
            }
            else
            {
                return BadRequest(ModelState.ValidationState);
            }
        }
    }
}