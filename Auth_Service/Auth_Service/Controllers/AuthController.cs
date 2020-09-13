using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth_Service.Domain.IServices;
using Auth_Service.Domain.Models;
using Auth_Service.JWT;
using Auth_Service.Presentation.Payload;
using Auth_Service.Presentation.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Auth_Service.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<CreateNewResponse> Register(CreateNewUser user)
        {
            return await _userService.RegisterUser(user);
        }
         [HttpPost]
        [Route("Signin")]
        public async Task<LoginResponse> Signin(Login details)
        {
            return await _userService.SignIn(details);
        }
        [HttpPost]
        [Route("FundWallet")]
        [JWTAuthHandler]
        public async Task<FundWalletResponse> FundWallet(decimal amount)
        {
            return await _userService.FundWallet(amount);
        }
        [HttpGet]
        [Route("GetUserInfo")]
        [JWTAuthHandler]
        public async Task<UserInfoResponse> GetUserInfo(long userid)
        {
            return await _userService.GetUserInfo(userid);
        }

    }
}