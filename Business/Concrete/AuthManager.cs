using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Business.Abstract;
using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Entities.ComplexTypes;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;

        public AuthManager(IUserService userService)
        {
            _userService = userService;
        }
        
       
        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
             var user = _userService.GetByEmail(userForLoginDto.Email).Data;
            
            if (user is null)
            {
                return new ErrorDataResult<User>("User not found");
            }
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, user.PasswordHash, user.PasswordSalt))
            {
                return new ErrorDataResult<User>("Please check your information");
            }
          
             return new SuccessDataResult<User>(user);
        }

        public IDataResult<ClaimsPrincipal> GetClaimsPrincipal(string schema, User user)
        {
            var userClaims = _userService.GetClaims(user).Data;
            var claims = SetClaims(user, userClaims);
            var claimsIdentity = new ClaimsIdentity(claims, schema);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            return new SuccessDataResult<ClaimsPrincipal>(claimsPrincipal);
        }

        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName }  {user.LastName}");
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());

            return claims;
        }
    }
}