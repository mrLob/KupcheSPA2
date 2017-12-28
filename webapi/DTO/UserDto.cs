namespace webapi.DTO
{
    public class UserDto
    {
        public int IdUser { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public string Telephone { get; set; }
        public int PositionId { get; set; }
        public int RulesId { get; set; }
        public int CompanyId { get; set; }
        public sbyte? IsDeleted { get; set; }
        public sbyte? IsBlocked { get; set; } 
    }
}