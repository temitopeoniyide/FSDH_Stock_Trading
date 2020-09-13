using Auth_Service.Domain.Models;
using Auth_Service.Presentation.Payload;
using Auth_Service.Presentation.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth_Service.Domain.IServices
{
  public  interface IUserService
    {

        Task<CreateNewResponse> RegisterUser(CreateNewUser user);
        Task<LoginResponse> SignIn(Login details);
        Task<FundWalletResponse> FundWallet(decimal amount);
        Task<UserInfoResponse> GetUserInfo(long userid);

    }
}
