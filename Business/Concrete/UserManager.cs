using System.Collections.Generic;
using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

       
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult();
        }

        public IResult Delete(User user)
        {
           _userDal.Delete(user);
            return new SuccessResult();
        }

        public IDataResult<User> GetByEmail(string email)
        {
            var user = _userDal.Get(u => u.Email == email);
            if(user is not null)
            {
                return  new SuccessDataResult<User>(user);
            }
            return  new ErrorDataResult<User>("Kullanıcı bulunamadı");
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult();
        }
    }
}