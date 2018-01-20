using System;
using System.Collections.Generic;

namespace webapi 
{
    public partial class Sessions
    {
        public int IdSessions { get; set; }
        public string Ip { get; set; }
        public int UserId { get; set; }
        public DateTimeOffset BeginTime { get; set; }

        public Users User { get; set; }
    }
}
