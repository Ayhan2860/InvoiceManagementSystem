namespace Core.Entities.Concrete
{
    public class Person:IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalyId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}