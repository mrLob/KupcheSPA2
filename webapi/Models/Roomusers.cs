using System;
using System.Collections.Generic;

namespace webapi
{
    public partial class Roomusers
    {
        public int IdRoomUsers { get; set; }
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public sbyte? IsDeleted { get; set; }
        public DateTimeOffset AdditionTime { get; set; }
        public DateTimeOffset LastUpdate { get; set; }

        public Rooms Room { get; set; }
        public Users User { get; set; }
    }
}
