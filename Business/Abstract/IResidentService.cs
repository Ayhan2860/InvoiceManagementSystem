using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.ComplexTypes;

namespace Business.Abstract
{
    public interface IResidentService
    {
        IResult CreateResident(ResidentForCreateDto resident);
    }
}