using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth_Service.JWT
{
  public  interface ITokenManager
    {
         string GenerateToken(string username);
         string ValidateToken(string token);
    }
}
