using System;
using System.Collections.Generic;

namespace webapi 
{
    public partial class Country
    {
        public Country()
        {
            City = new HashSet<City>();
        }

        public int IdCountry { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public DateTimeOffset AdditionTime { get; set; }
        public DateTimeOffset LastUpdate { get; set; }

        public ICollection<City> City { get; set; }
    }
}
