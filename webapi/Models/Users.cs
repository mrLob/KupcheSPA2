using System;
using System.Collections.Generic;

namespace webapi
{
    public partial class Users
    {
        public Users()
        {
            Files = new HashSet<Files>();
            Images = new HashSet<Images>();
            Messages = new HashSet<Messages>();
            Orders = new HashSet<Orders>();
            Rooms = new HashSet<Rooms>();
            Roomusers = new HashSet<Roomusers>();
            Sessions = new HashSet<Sessions>();
        }

        public int IdUsers { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public int PositionId { get; set; }
        public int RulesId { get; set; }
        public int CompanyId { get; set; }
        public sbyte? IsDeleted { get; set; }
        public sbyte? IsBlocked { get; set; }
        public DateTimeOffset AdditionTime { get; set; }
        public DateTimeOffset LastUpdate { get; set; }
        public byte[] PassHash { get; set; }
        public byte[] PassSalt { get; set; }

        public Companies Company { get; set; }
        public Positions Position { get; set; }
        public Rules Rules { get; set; }
        public ICollection<Files> Files { get; set; }
        public ICollection<Images> Images { get; set; }
        public ICollection<Messages> Messages { get; set; }
        public ICollection<Orders> Orders { get; set; }
        public ICollection<Rooms> Rooms { get; set; }
        public ICollection<Roomusers> Roomusers { get; set; }
        public ICollection<Sessions> Sessions { get; set; }
    }
}
