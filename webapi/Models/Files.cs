using System;
using System.Collections.Generic;

namespace webapi 
{
    public partial class Files
    {
        public Files()
        {
            Orderfiles = new HashSet<Orderfiles>();
        }

        public int IdFiles { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int UserId { get; set; }
        public sbyte? IsDeleted { get; set; }
        public DateTimeOffset AdditionTime { get; set; }
        public DateTimeOffset LastUpdate { get; set; }

        public Users User { get; set; }
        public ICollection<Orderfiles> Orderfiles { get; set; }
    }
}
