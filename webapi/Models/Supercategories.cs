using System;
using System.Collections.Generic;

namespace webapi 
{
    public partial class Supercategories
    {
        public Supercategories()
        {
            Activitytypes = new HashSet<Activitytypes>();
            Subcategory = new HashSet<Subcategory>();
        }

        public int IdSuperCategories { get; set; }
        public string Name { get; set; }
        public DateTimeOffset AdditionTime { get; set; }
        public DateTimeOffset LastUpdate { get; set; }

        public ICollection<Activitytypes> Activitytypes { get; set; }
        public ICollection<Subcategory> Subcategory { get; set; }
    }
}
