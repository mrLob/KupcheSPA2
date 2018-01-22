using System;
using System.Collections.Generic;

namespace webapi
{
    public partial class Companies
    {
        public Companies()
        {
            Companyactivity = new HashSet<Companyactivity>();
            Companyorders = new HashSet<Companyorders>();
            Pricelist = new HashSet<Pricelist>();
            Users = new HashSet<Users>();
        }

        public int IdCompany { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Contacts { get; set; }
        public string About { get; set; }
        public string Pan { get; set; }
        public int AddressId { get; set; }
        public sbyte? IsDeleted { get; set; }
        public DateTimeOffset AdditionTime { get; set; }
        public DateTimeOffset LastUpdate { get; set; }
        public int? ImageId { get; set; }

        public Addresses Address { get; set; }
        public Images Image { get; set; }
        public ICollection<Companyactivity> Companyactivity { get; set; }
        public ICollection<Companyorders> Companyorders { get; set; }
        public ICollection<Pricelist> Pricelist { get; set; }
        public ICollection<Users> Users { get; set; }
    }
}
