using System;
using System.Collections.Generic;

namespace webapi
{
    public partial class Orderfiles
    {
        public int IdOrderFiles { get; set; }
        public int OrderId { get; set; }
        public int FileId { get; set; }

        public Files File { get; set; }
        public Orders Order { get; set; }
    }
}
