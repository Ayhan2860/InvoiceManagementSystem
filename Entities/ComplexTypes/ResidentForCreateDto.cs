namespace Entities.ComplexTypes
{
    public class ResidentForCreateDto
    {
        public int HouseId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalyId { get; set; }
        public string Email { get; set; }
        public string IsOwner { get; set; }
        public string PhoneNumber { get; set; }
    }
}