using System;
using System.Collections.Generic;

namespace webapi 
{
    public partial class Nomenclatures
    {
        public Nomenclatures()
        {
            Goods = new HashSet<Goods>();
        }

        public int IdNomenclatures { get; set; }
        public string Name { get; set; }
        public sbyte? IsDeleted { get; set; }
        public DateTimeOffset AdditionTime { get; set; }
        public DateTimeOffset LastUpdate { get; set; }

        public ICollection<Goods> Goods { get; set; }
    }
}
