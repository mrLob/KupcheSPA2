using System;
using System.Collections.Generic;

namespace webapi 
{
    public partial class Activitytypes
    {
        public Activitytypes()
        {
            Companyactivity = new HashSet<Companyactivity>();
            InverseChildOfNavigation = new HashSet<Activitytypes>();
        }

        public int IdActivityTypes { get; set; }
        public string Name { get; set; }
        public int? ChildOf { get; set; }
        public int? CategoryId { get; set; }
        public sbyte? IsDeleted { get; set; }
        public DateTimeOffset AdditionTime { get; set; }
        public DateTimeOffset LastUpdate { get; set; }

        public Supercategories Category { get; set; }
        public Activitytypes ChildOfNavigation { get; set; }
        public ICollection<Companyactivity> Companyactivity { get; set; }
        public ICollection<Activitytypes> InverseChildOfNavigation { get; set; }
    }
}
