using System;
using System.Collections.Generic;

namespace webapi 
{
    public partial class Positions
    {
        public Positions()
        {
            Users = new HashSet<Users>();
        }

        public int IdPositions { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public DateTimeOffset AdditionTime { get; set; }
        public DateTimeOffset LastUpdate { get; set; }

        public ICollection<Users> Users { get; set; }
    }
}
