using System;
using System.Collections.Generic;

namespace webapi
{
    public partial class Companyorders
    {
        public int IdCompanyOrders { get; set; }
        public int IdCompanies { get; set; }
        public int IdOrders { get; set; }

        public Companies Companies { get; set; }
        public Orders Orders { get; set; }
    }
}
