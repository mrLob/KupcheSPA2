using System;
using System.Collections.Generic;

namespace webapi 
{
    public partial class Orderimages
    {
        public int IdOrderImages { get; set; }
        public int OrderId { get; set; }
        public int ImageId { get; set; }

        public Images Image { get; set; }
        public Orders Order { get; set; }
    }
}
