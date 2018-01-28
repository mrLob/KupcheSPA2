using System;
using System.IO;
using System.Text;
using System.Security.Claims;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using webapi.DTO;
using webapi.Models;
using webapi.Helpers;
using webapi.Services;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    public class ImagesController : Controller
    {
        public IActionResult LastImage()
        {
            using(servicedbContext db = new servicedbContext())
            {
                return Ok(db.Images.Last());
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            using(servicedbContext db = new servicedbContext())
            {
                return Ok(db.Images.Find(id));
            }
        }
        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile image)
        {
            var images = Request.Form.Files;

             if (images == null || images.Count == 0)
                return Content("image not selected");
                foreach(var item in images)
                {
                    var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "files", 
                        item.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await item.CopyToAsync(stream);
                    }
                    Images newImage = new Images();
                    newImage.Name = item.Name;
                    newImage.Path = path;
                    using(servicedbContext db = new servicedbContext())
                    {
                        db.Images.Add(newImage);
                        db.SaveChanges();
                    }
                }
            return RedirectToAction("LastImage");
        }
    }
}