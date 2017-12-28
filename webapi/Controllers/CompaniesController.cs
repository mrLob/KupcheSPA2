using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using webapi.Models;

namespace  webapi.Controllers

{
    [Authorize]
    [Route("api/[controller]")]
    public class CompaniesController : Controller
    {
        [AllowAnonymous]
        [HttpGet]
        public IEnumerable<Companies> GetAll()
        {
             using(servicedbContext db = new servicedbContext())
            {
                IEnumerable<Companies> companies =  db.Companies.ToList();
                Console.WriteLine("Get response Companies!");
                return companies;
            }
        }

        [HttpPost]
        public IActionResult Create()
        {
            return Ok();
        }

    }
}