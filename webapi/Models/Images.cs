using System;
using System.Collections.Generic;

namespace webapi
{
    public partial class Images
    {
        public Images()
        {
            Companies = new HashSet<Companies>();
            Orderimages = new HashSet<Orderimages>();
        }

        public int IdImages { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public int? UserId { get; set; }
        public sbyte? IsDeleted { get; set; }
        public DateTimeOffset AdditionTime { get; set; }
        public DateTimeOffset LastUpdate { get; set; }

        public Users User { get; set; }
        public ICollection<Companies> Companies { get; set; }
        public ICollection<Orderimages> Orderimages { get; set; }
    }
}
