using System;
using System.Text;
using System.Security.Claims;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using webapi.DTO;
using webapi.Models;
using webapi.Helpers;
using webapi.Services;
using System.Linq;

namespace webapi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private IMapper _mapper;
        private IUserService _userService;
        private readonly AppSettings _appSettings;
        public UsersController( IUserService userService,
            IMapper mapper, 
            IOptions<AppSettings> appSettings )
        {
            _userService = userService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]UserDto userDto)
        {            
            var authUser = _userService.Authenticate(userDto.Email, userDto.Pass);
            if( authUser == null) 
                return Unauthorized();
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
              Subject = new ClaimsIdentity(new Claim[]
              {
                  new Claim(ClaimTypes.Name, authUser.IdUsers.ToString())
              }),
              Expires = DateTime.UtcNow.AddDays(7),
              SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)    

            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            servicedbContext context = new servicedbContext();
            var rules = context.Rules.Where(r => r.IdRules == authUser.RulesId);
            var company = context.Companies.Where(c => c.IdCompany == authUser.CompanyId);
            Console.WriteLine("Return auth of "+ authUser.Email);
            return Ok(new {
                IdUser = authUser.IdUsers,
                Email = authUser.Email,
                LastName = authUser.LastName,
                FirstName = authUser.FirstName,
                SecondName = authUser.SecondName,
                Telephone = authUser.Telephone,
                isDeleted = authUser.IsDeleted,
                isBlocked = authUser.IsBlocked,
                Rule = rules,
                Company = company,
                Token = tokenString
            });
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Register([FromBody]UserDto userDto)
        {
            var regUser = _mapper.Map<Users>(userDto);
            try
            {
                Console.WriteLine("Register user!");
                _userService.Create(regUser, userDto.Pass);
                return Ok();
            }
            catch(AppException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            var userDto = _mapper.Map<IList<UserDto>>(users);
            return Ok(userDto);
        }
        
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetById(id);
            var userDto = _mapper.Map<UserDto>(user);
            return Ok(userDto);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id,[FromBody]UserDto userDto)
        {
            var updUser = _mapper.Map<Users>(userDto);
            updUser.IdUsers = id;
            
            try
            {
                _userService.Update(updUser,userDto.Pass);
                return Ok();
            }
            catch(AppException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}