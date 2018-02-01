using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Models;
using webapi.DTO;

namespace  webapi.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        [HttpGet]
        public IEnumerable<Orders> GetOrders()
        {
            using(servicedbContext db = new servicedbContext())
            {
                IEnumerable<Orders> tender =  db.Orders.Where(o => o.IsDeleted == 0).ToList();
                Console.WriteLine("Get response orders!");
                return tender;
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetFiltered(int id)
        {
            if(id == null || id == 0) return BadRequest();
            List<Orders> ordList = new List<Orders>();
            using(servicedbContext db = new servicedbContext())
            {
                IEnumerable<Companyorders> companyOrds =  db.Companyorders.Where(co => co.IdCompanies == id).ToList();
                if(companyOrds == null || companyOrds.Count() == 0) return BadRequest("No orders for company!");
                foreach(var co in companyOrds)
                {
                    ordList.Add(db.Orders.Where(o => o.IdOrders == co.IdOrders).FirstOrDefault());
                }
            }
            IEnumerable<Orders> ords = ordList;
            Console.WriteLine("Get response filter!");
            return Ok(ords);
        }
        [HttpPost]
        public IActionResult PostOrders([FromBody]OrderDto orderDto)
        {
            Console.WriteLine("Post order:");
            if(ModelState.IsValid)
            {                
                Orders neworder = new Orders();                
                neworder.Caption = orderDto.Caption.Trim();
                neworder.Description = orderDto.Description.Trim();
                neworder.Cost = orderDto.Cost;
                neworder.Url = DateTime.Now.ToString();
                neworder.UpTo = orderDto.UpTo;
                neworder.UsersId = 1;                
                using(servicedbContext db = new servicedbContext())
                {
                    Console.WriteLine("Post order: " + neworder.Caption.ToString());
                    db.Orders.Add(neworder);
                    Companyorders newRelation = new Companyorders();
                    newRelation.IdCompanies = orderDto.CompanyId;
                    newRelation.IdOrders = neworder.IdOrders;
                    db.Companyorders.Add(newRelation);
                    db.SaveChanges();
                    Console.WriteLine("Post response order: " + neworder.Caption.ToString());
                    return Ok(neworder);
                }
            }
            else
            {
                Console.WriteLine(ModelState.ValidationState);
                return BadRequest(ModelState.ValidationState);
            }
        }
    }
    
}