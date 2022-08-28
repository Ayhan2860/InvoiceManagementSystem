namespace Core.Entities.Concrete
{
    public class User:Person, IEntity
    {
        
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}