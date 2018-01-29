using System;
using System.Collections.Generic;

namespace webapi 
{
    public partial class Addresses
    {
        public Addresses()
        {
            Companies = new HashSet<Companies>();
        }

        public int IdAddress { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Flat { get; set; }
        public string Zip { get; set; }
        public string Geomap { get; set; }
        public int CityId { get; set; }
        public sbyte? IsDeleted { get; set; }
        public DateTimeOffset AdditionTime { get; set; }
        public DateTimeOffset LastUpdate { get; set; }

        public City City { get; set; }
        public ICollection<Companies> Companies { get; set; }
    }
}
