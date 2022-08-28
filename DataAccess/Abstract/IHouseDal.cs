using Entities.Concrete;
using Core.DataAccess;
using Entities.ComplexTypes;

namespace DataAccess.Abstract
{
    public interface IHouseDal : IEntityRepository<House>
    {
        
        HouseForGetResidentDto GetHouseForGetResidentDto(int id);
    }
}