using System;
using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.EmailSender;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Entities.ComplexTypes;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ResidentManager : IResidentService
    {
         private readonly IHouseService _houseService;
         private readonly IUserService _userService;
         private readonly IEmailSender _emailSender;
         private readonly IOperationClaimService _operationClaimService;
         private readonly IUserOperationClaimService _userOperationClaimService;

        public ResidentManager
        (
        IHouseService houseService,
        IUserService userService,
        IEmailSender emailSender,
        IOperationClaimService operationClaimService,
        IUserOperationClaimService userOperationClaimService)
        {
            _houseService = houseService;
            _userService = userService;
            _emailSender = emailSender;
            _operationClaimService = operationClaimService;
            _userOperationClaimService = userOperationClaimService;
        }

        public IResult CreateResident(ResidentForCreateDto resident)
        {
            var user = _userService.GetByEmail(resident.Email);
            var house = _houseService.GetById(resident.HouseId).Data;
          
            if(user.Success)
            {
                return new ErrorResult("Bu Site Sakinin Kaydı Daha Önce Oluşturulmuş");
            }
            if(house.State)
            {
                     return new ErrorResult("Bu ev doludur lütfen boş bir ev seçiniz"); 
            }
            string randomPassword= "12345"; //RandomPassword();
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(randomPassword, out passwordHash, out passwordSalt);
            var newUser = new User{
                FirstName = resident.FirstName,
                LastName = resident.LastName,
                Email = resident.Email,
                NationalyId = resident.NationalyId,
                PhoneNumber = resident.PhoneNumber,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };
            var userAdded = _userService.Add(newUser);
            if(userAdded.Success)
            {
                 user = _userService.GetByEmail(resident.Email);
                 
                 var updateHouse = new House
                 {
                      Id = house.Id,
                      TypeInfo = house.TypeInfo,
                      ApartmentId = house.ApartmentId,
                      FloorNumber = house.FloorNumber,
                      DoorNumber = house.DoorNumber,
                      UserId = user.Data.Id,
                      IsOwner = resident.IsOwner == "Owner" ? true : false,
                      State = true
                 };
                 
                 _houseService.Update(updateHouse);
                 var role = _operationClaimService.GetName("User").Data;
                 var claim = new UserOperationClaim { UserId = user.Data.Id, OperationClaimId = role.Id };
                 _userOperationClaimService.Add(claim);
               // var message = new Message(new string[] {user.Data.Email}, "Create Password",randomPassword);
                //_emailSender.SendEMail(message);
                return new SuccessResult();
            }
            else
              return new ErrorResult(); 
         
        }

        private string  RandomPassword()
        {
            string randomPassword = "";
            var random = new Random();
            for (int i = 1; i <= 8; i++)
            {
                randomPassword += ((char)(random.Next(48, 91))).ToString();
            }
            return randomPassword;
        }
    }
}