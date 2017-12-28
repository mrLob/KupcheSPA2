using System;
using System.Collections.Generic;

namespace webapi
{
    public partial class Signinup
    {
        public int IdSignInUp { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public DateTimeOffset? ActivatedIn { get; set; }
        public sbyte? IsActivated { get; set; }
        public DateTimeOffset ExpiredIn { get; set; }
    }
}
