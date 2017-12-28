using System;
using System.Collections.Generic;

namespace webapi
{
    public partial class Rooms
    {
        public Rooms()
        {
            Messages = new HashSet<Messages>();
            Roomusers = new HashSet<Roomusers>();
        }

        public int IdRooms { get; set; }
        public string Name { get; set; }
        public int CreatorId { get; set; }
        public sbyte? IsDeleted { get; set; }
        public sbyte? IsCompanyRoom { get; set; }
        public DateTimeOffset AdditionTime { get; set; }
        public DateTimeOffset LastUpdate { get; set; }

        public Users Creator { get; set; }
        public ICollection<Messages> Messages { get; set; }
        public ICollection<Roomusers> Roomusers { get; set; }
    }
}
