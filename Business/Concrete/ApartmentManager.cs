using System.Collections.Generic;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ApartmentManager : IApartmentService
    {
        private readonly IApartmentDal _apartmentDal;

        public ApartmentManager(IApartmentDal apartmentDal)
        {
            _apartmentDal = apartmentDal;
        }

        public void Add(Apartment apartment)
        {
            _apartmentDal.Add(apartment);
        }

        public void Delete(Apartment apartment)
        {
            _apartmentDal.Delete(apartment);
        }

        public List<Apartment> GetAll()
        {
            return _apartmentDal.GetList();
        }

        public Apartment GetById(int id)
        {
            return _apartmentDal.Get(x=>x.Id == id);
        }

        public void Update(Apartment apartment)
        {
            _apartmentDal.Update(apartment);
        }
    }
}