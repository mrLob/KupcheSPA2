using System;
using System.Collections.Generic;

namespace webapi
{
    public partial class Goods
    {
        public Goods()
        {
            Pricelist = new HashSet<Pricelist>();
        }

        public int IdGoods { get; set; }
        public string Params { get; set; }
        public decimal Cost { get; set; }
        public int NomenclaturesId { get; set; }
        public int? UnitId { get; set; }
        public int SubcategoryId { get; set; }
        public sbyte? IsDeleted { get; set; }
        public DateTimeOffset AdditionTime { get; set; }
        public DateTimeOffset LastUpdate { get; set; }

        public Nomenclatures Nomenclatures { get; set; }
        public Subcategory Subcategory { get; set; }
        public Units Unit { get; set; }
        public ICollection<Pricelist> Pricelist { get; set; }
    }
}
