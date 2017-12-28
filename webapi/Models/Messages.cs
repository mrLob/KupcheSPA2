using System;
using System.Collections.Generic;

namespace webapi
{
    public partial class Messages
    {
        public int MsgId { get; set; }
        public string Text { get; set; }
        public int UsersId { get; set; }
        public int RoomId { get; set; }
        public sbyte? IsDeleted { get; set; }
        public sbyte? IsViewed { get; set; }
        public DateTimeOffset AdditionTime { get; set; }
        public DateTimeOffset LastUpdate { get; set; }

        public Rooms Room { get; set; }
        public Users Users { get; set; }
    }
}
