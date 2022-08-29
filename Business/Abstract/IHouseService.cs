using Core.Utilities.Results;
using Entities.ComplexTypes;
using Entities.Concrete;
using System.Collections.Generic;
namespace Business.Abstract
{
    public interface IHouseService
    {
        IDataResult<House> GetById(int id);
        IDataResult<List<House>> GetByApartmentId(int apartmentId);
        IDataResult<List<House>> GetAll();
        IDataResult<List<House>> GetAllState(bool state);
        IDataResult<HouseForGetResidentDto> GetDataResult(int id);
        IResult Add(House house);
        IResult Update(House house);
        IResult Delete(House house);
    }
}