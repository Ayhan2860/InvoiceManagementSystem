using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.Encyption
{
    public class SigningCredentialsHelper
    {
       public SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
       {
           return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
       }
    }
}