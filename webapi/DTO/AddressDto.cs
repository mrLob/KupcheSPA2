namespace webapi.DTO
{
    public class AddressDto
    {
        public int IdAddress { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Flat { get; set; }
        public string Zip { get; set; }
        public string Geomap { get; set; }
        public int CityId { get; set; }

    }
}