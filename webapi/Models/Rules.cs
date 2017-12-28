using System;
using System.Collections.Generic;

namespace webapi
{
    public partial class Rules
    {
        public Rules()
        {
            Users = new HashSet<Users>();
        }

        public int IdRules { get; set; }
        public string Name { get; set; }
        public sbyte? IsDeleted { get; set; }
        public DateTimeOffset AdditionTime { get; set; }
        public DateTimeOffset LastUpdate { get; set; }

        public ICollection<Users> Users { get; set; }
    }
}
