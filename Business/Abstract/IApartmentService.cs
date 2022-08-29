using System.Collections.Generic;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IApartmentService
    {
        List<Apartment> GetAll();
        Apartment GetById(int id);
        void Add(Apartment apartment);
        void Update(Apartment apartment);
        void Delete(Apartment apartment);
    }
}