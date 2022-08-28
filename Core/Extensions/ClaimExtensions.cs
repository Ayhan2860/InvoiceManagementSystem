using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Core.Extensions
{
    public static class ClaimExtensions
    {
         public static void AddNameIdentifier(this ICollection<Claim> claims, string nameIdentifier)
        {
            claims.Add(new Claim(ClaimTypes.NameIdentifier , nameIdentifier));
        }


        public static void AddEmail(this ICollection<Claim> claims, string email)
        {
            claims.Add(new Claim(ClaimTypes.Email, email));
         
        }

        public static void AddName(this ICollection<Claim> claims, string name)
        {
            claims.Add(new Claim(ClaimTypes.Name, name));
           
        }

        public static void AddRoles(this ICollection<Claim> claims, string[] roles)
        {
            roles.ToList().ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));
        }

        public static ClaimsIdentity GetClaimsIdentity(this ICollection<Claim> claims, string schema)
        {
              return new ClaimsIdentity(claims, schema);
        }

        public static ClaimsPrincipal GetClaimsPrincipal(ClaimsIdentity claimsIdentity)
        {
              return new ClaimsPrincipal(claimsIdentity);
        }
      

    }
}