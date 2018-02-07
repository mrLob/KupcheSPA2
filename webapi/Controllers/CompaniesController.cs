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
using AutoMapper;

namespace  webapi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class CompaniesController : Controller
    {
        private IMapper _mapper;
        public CompaniesController(IMapper mapper)
        {
            _mapper = mapper;
        }
        [AllowAnonymous]
        [HttpGet]
        public IEnumerable<Companies> GetAll()
        {
             using(servicedbContext db = new servicedbContext())
            {
                IEnumerable<Companies> companies =  db.Companies.Where(c => c.IsDeleted == 0 ).ToList();
                Console.WriteLine("Get response Companies!");
                return companies;
            }
        }        
        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult GetById(int? id)
        {
            if(id == null || id == 0) return BadRequest();
             using(servicedbContext db = new servicedbContext())
            {
                var company =  db.Companies.Where(c => c.IsDeleted == 0 && c.IdCompany == id).First();
                var companyDto =  _mapper.Map<CompanyDto>(company);
                Console.WriteLine("Get response Companies by ID!");
                return Ok(companyDto);
            }
        }


        [HttpPost]
        public IActionResult Create()
        {
            return Ok();
        }

    }
}