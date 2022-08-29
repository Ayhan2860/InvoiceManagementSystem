
using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using Core.Utilities.Results;
using Core.Utilities.Business;
using Entities.ComplexTypes;

namespace Business.Concrete
{
    public class HouseManager : IHouseService
    {
        private readonly IHouseDal _houseDal;
        private readonly IApartmentService _apartmentService;

        public HouseManager(IHouseDal houseDal, IApartmentService apartmentService)
        {
            _houseDal = houseDal;
            _apartmentService = apartmentService;
        }
        
        public IResult Add(House house)
        {
            var result = BusinessRules.Run(IsDoorExists(house.DoorNumber),
              CheckIfNumberOfHousesInTheFloorLimitExceded(house.ApartmentId, house.FloorNumber),
              CheckIfNumberOfHousesInTheApartmentLimitExceded(house.ApartmentId),
               IsFloorExists(house.ApartmentId, house.FloorNumber)
              );
              if (result != null)
             {
                return result;
             }
            _houseDal.Add(house);
            return new SuccessResult();
        }

        public IResult Delete(House house)
        {
            _houseDal.Delete(house);
            return new SuccessResult();
        }

        public IDataResult<List<House>> GetAll()
        {
            return new SuccessDataResult<List<House>> (_houseDal.GetList());
        }

        public IDataResult<List<House>> GetByApartmentId(int apartmentId)
        {
           return new SuccessDataResult<List<House>>(_houseDal.GetList(x => x.ApartmentId == apartmentId || apartmentId == 0));
        }

        public IDataResult<House> GetById(int id)
        {
            return new SuccessDataResult<House> (_houseDal.Get(h => h.Id == id));
        }

        public IResult Update(House house)
        {
             var  hs =  GetById(house.Id).Data;
             if(hs.FloorNumber != house.FloorNumber || hs.DoorNumber != house.DoorNumber)
             {
                var result = BusinessRules.Run(IsDoorExists(house.DoorNumber),
              CheckIfNumberOfHousesInTheFloorLimitExceded(house.ApartmentId, house.FloorNumber),
              CheckIfNumberOfHousesInTheApartmentLimitExceded(house.ApartmentId),
               IsFloorExists(house.ApartmentId, house.FloorNumber)
              );
                if (result != null)
                {
                return result;
                }
             }
             _houseDal.Update(house);
              return new SuccessResult();
        }

         private IResult CheckIfNumberOfHousesInTheFloorLimitExceded(int id, int floor)
        {
            int num = _apartmentService.GetById(id).NumberOfHousesOnTheFloors;
            var homeCount = _houseDal.GetList(x => x.FloorNumber == floor).ToList().Count;
            if(homeCount >= num)
            {
                return new ErrorResult($"Aynı Kata En Fazla {num} Daire Eklenebilir");
            }
             return new SuccessResult();
        }

         private IResult CheckIfNumberOfHousesInTheApartmentLimitExceded(int apartmentId)
        {
            var apartment = _apartmentService.GetById(apartmentId);
            var homes = _houseDal.GetList(x => x.ApartmentId == apartmentId);
            int num = (apartment.NumberOfHousesOnTheFloors * apartment.NumberOfFloors);
            int homeCount = homes.ToList().Count;
            if(homeCount >= num)
            {
                return new ErrorResult($"Bu Apartmana En Fazla {num} Daire Eklenebilir");
            }
            return new SuccessResult();
        }

         private  IResult IsDoorExists(int doorNumber)
        {
            var home = _houseDal.Get(x => x.DoorNumber == doorNumber);
            if(home is null)
            {
                return new SuccessResult();
            }
            return new ErrorResult("Bu kapı numarası eklenmiş");
        }

         private  IResult IsFloorExists(int apartmentId, int floorNumber)
        {
            var apartment = _apartmentService.GetById(apartmentId);

            if(floorNumber < 1 || floorNumber >  apartment.NumberOfFloors)
            {
                return new ErrorResult("Lütfen Daire Katını Kontrol Ediniz");
            }
            return new SuccessResult();
        }

        public IDataResult<List<House>> GetAllState(bool state)
        {
            return new SuccessDataResult<List<House>>(_houseDal.GetList(x => x.State == state));
        }

        public IDataResult<HouseForGetResidentDto> GetDataResult(int id)
        {
           
             var houseForDetail = _houseDal.GetHouseForGetResidentDto(id);
          
             if(houseForDetail == null)
             return new ErrorDataResult<HouseForGetResidentDto>("Bu ev boş");
            return new SuccessDataResult<HouseForGetResidentDto>(houseForDetail);

        }

      
    }
}