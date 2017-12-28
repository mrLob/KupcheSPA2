using System;
using System.Collections.Generic;
using System.Linq;
using webapi.Models;
using webapi.Helpers;

namespace webapi.Services
{
    public interface IUserService
    {
        Users Authenticate(string username, string pass);
        IEnumerable<Users> GetAll();
        Users GetById(int id);
        Users Create(Users user, string pass);
        void Update(Users user,string pass);
        void Delete(int id);
    }
    public class UserService : IUserService
    {
        private servicedbContext _context ;
        public UserService()
        {
            _context = new servicedbContext();
        }

        public Users Authenticate(string email, string pass)
        {
            if( string.IsNullOrWhiteSpace(email) || string.IsNullOrEmpty(pass) ) 
                return null;
            using(servicedbContext db = new servicedbContext())
            {
                var authUser = db.Users.SingleOrDefault(x => x.Email == email);

                if(authUser == null) 
                    return null;
                if(!VerifyPasswordHash(pass,authUser.PassHash,authUser.PassSalt))
                    return null;
                Console.WriteLine("Return auth of "+ authUser.Email);
                return authUser;
            }
        }
        public IEnumerable<Users> GetAll()
        {   
            using(servicedbContext db = new servicedbContext())
            {
                return db.Users;
            }
        }
        public Users GetById(int id)
        {   
            using(servicedbContext db = new servicedbContext())
            {
                return db.Users.Find(id);
            }
        }
        public Users Create(Users newUser, string pass)
        {
            newUser.CompanyId = 1;
            newUser.RulesId = 1;
            newUser.PositionId = 1;
            Console.WriteLine("Create user!");
            if(string.IsNullOrWhiteSpace(pass))
                throw new AppException("Password is required");
            using(servicedbContext db = new servicedbContext())
            {
                if(_context.Users.Any(x => x.Email == newUser.Email))
                    throw new ApplicationException("Username "+newUser.Email+" is already taken");
            }
            byte[] passHash,passSalt;
            
            CreatePasswordHash(pass,out passHash,out passSalt);
            newUser.PassHash = passHash;
            newUser.PassSalt = passSalt;
            using(servicedbContext db = new servicedbContext()){
                db.Users.Add(newUser);
                db.SaveChanges();
            }
            return newUser;
        }
        public void Update(Users userParam,string pass)
        {
            var userUpd = _context.Users.Find(userParam.IdUsers);
            if(userUpd == null) 
                throw new AppException("User not found!");
            if(userParam.Email != userUpd.Email)
            {
                if( _context.Users.Any(x => x.Email == userParam.Email) )
                    throw new AppException("Email " + userParam + " is already");
            }
            userUpd.FirstName = userParam.FirstName;
            userUpd.LastName = userParam.LastName;
            userUpd.SecondName = userParam.SecondName;
            userUpd.Telephone = userParam.Telephone;
            userUpd.PositionId = userParam.PositionId;
            userUpd.RulesId = userParam.RulesId;
            userUpd.CompanyId = userParam.CompanyId;
            if(!string.IsNullOrWhiteSpace(pass))
            {
                byte[] passHash,passSalt;
                CreatePasswordHash(pass, out passHash, out passSalt);

                userUpd.PassHash = passHash;
                userUpd.PassSalt = passSalt;
            }
            _context.Users.Update(userUpd);
            _context.SaveChanges();    


        }
        public void Delete(int id)
        {
            var user = _context.Users.Find(id);
            if(user !=null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            Console.WriteLine("Pass hash create!");
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
 
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
 
        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");
 
            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }
 
            return true;
        }        
    }
}