using System;
using System.Collections.Generic;

namespace webapi
{
    public partial class City
    {
        public City()
        {
            Addresses = new HashSet<Addresses>();
        }

        public int IdCity { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public DateTimeOffset AdditionTime { get; set; }
        public DateTimeOffset LastUpdate { get; set; }

        public Country Country { get; set; }
        public ICollection<Addresses> Addresses { get; set; }
    }
}
