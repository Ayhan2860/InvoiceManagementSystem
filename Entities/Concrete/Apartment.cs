using Core.Entities;

namespace Entities.Concrete
{
    public class Apartment : IEntity
    {
        public int Id { get; set; }
        public int NumberOfFloors { get; set; }
        public int NumberOfHousesOnTheFloors { get; set; }
        public string BlockName { get; set; }
    }
}