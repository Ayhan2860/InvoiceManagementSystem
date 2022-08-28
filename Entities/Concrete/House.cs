using Core.Entities;

namespace Entities.Concrete
{
    public class House :IEntity
    {
        public int Id { get; set; }
        public int ApartmentId { get; set; }
        public string TypeInfo { get; set; }
        public int FloorNumber { get; set; }
        public int DoorNumber { get; set; }
        public bool IsOwner { get; set; }
        public bool State { get; set; }
        public int UserId { get; set; }
    }
}