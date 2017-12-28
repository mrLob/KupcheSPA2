using System;
using System.Collections.Generic;

namespace webapi
{
    public partial class Companyactivity
    {
        public int IdCompanyActivity { get; set; }
        public int CompanyId { get; set; }
        public int ActivityTypeId { get; set; }
        public DateTimeOffset AdditionTime { get; set; }
        public DateTimeOffset LastUpdate { get; set; }

        public Activitytypes ActivityType { get; set; }
        public Companies Company { get; set; }
    }
}
