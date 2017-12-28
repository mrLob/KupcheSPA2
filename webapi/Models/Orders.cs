using System;
using System.Collections.Generic;

namespace webapi
{
    public partial class Orders
    {
        public Orders()
        {
            Orderfiles = new HashSet<Orderfiles>();
            Orderimages = new HashSet<Orderimages>();
        }

        public int IdOrders { get; set; }
        public string Caption { get; set; }
        public string Text { get; set; }
        public string Geomap { get; set; }
        public decimal? Cost { get; set; }
        public int? Viewers { get; set; }
        public int UsersId { get; set; }
        public sbyte? ThereImages { get; set; }
        public sbyte? ThereFiles { get; set; }
        public sbyte? IsDeleted { get; set; }
        public DateTimeOffset AdditionTime { get; set; }
        public DateTimeOffset LastUpdate { get; set; }

        public Users Users { get; set; }
        public ICollection<Orderfiles> Orderfiles { get; set; }
        public ICollection<Orderimages> Orderimages { get; set; }
    }
}
