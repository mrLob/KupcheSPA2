using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using webapi.Models;

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
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Addresses address)
        {
            Addresses newAddr = new Addresses();
            newAddr.Street = address.Street;
            newAddr.Number = address.Number;
            newAddr.Flat = address.Flat;
            newAddr.CityId = 1;
            using( servicedbContext db = new servicedbContext() )
            {
                await db.Addresses.AddAsync(newAddr);
                await db.SaveChangesAsync();
            }
            return RedirectToAction("LastImage");
        }
    }
}