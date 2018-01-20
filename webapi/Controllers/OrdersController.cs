using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Models;

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
        [HttpGet("{filter}")]
        public IEnumerable<Orders> GetFiltered(string filter)
        {
            using(servicedbContext db = new servicedbContext())
            {
                IEnumerable<Orders> tender =  db.Orders.Where(o => o.Users.Company.Pan == filter).ToList();
                Console.WriteLine("Get response orders!");
                return tender;
            }
        }
        [HttpPost]
        public IActionResult PostOrders([FromBody]Orders order)
        {
            Console.WriteLine("Post order:");
            if(ModelState.IsValid)
            {
                Orders neworder = new Orders();
                
                neworder.Caption = order.Caption;
                neworder.Text = order.Text;
                neworder.Cost = order.Cost;
                neworder.UsersId = 1;
                
                using(servicedbContext db = new servicedbContext())
                {
                    Console.WriteLine("Post order: " + neworder.Caption.ToString());
                    db.Orders.Add(neworder);
                    db.SaveChanges();
                    Console.WriteLine("Post response order: " + neworder.IdOrders.ToString());
                    Console.WriteLine("Post response order: " + neworder.Caption.ToString());
                    return Ok(neworder);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
    
}