using System;
using System.Collections.Generic;

namespace webapi 
{
    public partial class Currencies
    {
        public Currencies()
        {
            Pricelist = new HashSet<Pricelist>();
        }

        public int IdCurrencies { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public DateTimeOffset AdditionTime { get; set; }
        public DateTimeOffset LastUpdate { get; set; }

        public ICollection<Pricelist> Pricelist { get; set; }
    }
}
