using System;

namespace webapi.DTO
{
    public class OrderDto
    {
        public int IdOrders { get; set; }
        public string Caption { get; set; }
        public string Description { get; set; }
        public string Geomap { get; set; }
        public decimal? Cost { get; set; }
        public int? UsersId { get; set; }
        public sbyte? ThereImages { get; set; }
        public sbyte? ThereFiles { get; set; }
        public string Url { get; set; }
        public DateTime? UpTo { get; set; }
        public int CompanyId { get; set; }
    }
}