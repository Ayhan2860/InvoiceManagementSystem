
using System.Security.Claims;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.ComplexTypes;

namespace Business.Abstract
{
    public interface IAuthService
    {
       
        IDataResult<User>  Login(UserForLoginDto userForLoginDto);
        IDataResult<ClaimsPrincipal>  GetClaimsPrincipal(string schema, User user);
    }
}