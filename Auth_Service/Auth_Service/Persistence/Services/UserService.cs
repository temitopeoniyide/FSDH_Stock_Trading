using Auth_Service.Domain;
using Auth_Service.Domain.IServices;
using Auth_Service.Domain.Models;
using Auth_Service.JWT;
using Auth_Service.Presentation.Payload;
using Auth_Service.Presentation.Responses;
using Auth_Service.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Auth_Service.Extensions;

namespace Auth_Service.Persistence.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitofwork;
        private IConfiguration config;
        private readonly ILogWriter _logWriter;
        private readonly ITokenManager _tokenManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserService(IUnitOfWork unitofwork, IConfiguration _config, ILogWriter logWriter, ITokenManager tokenManager, IHttpContextAccessor httpContextAccessor)
        {
            _unitofwork = unitofwork;
            config = _config;
            _logWriter = logWriter;
            _tokenManager = tokenManager;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<CreateNewResponse> RegisterUser(CreateNewUser user)
        {
            try
            {
                var isUserExist = await _unitofwork.Users.IsExistingAsync(o => o.Email == user.Email);
                if(isUserExist)  return new CreateNewResponse { ResponseCode = "01", ResponseMessage = "Email already exist." };
                else
                {
                    var addUserResonse = await _unitofwork.Users.AddAsync(new TblUser { Email=user.Email,Firstname=user.Firstname,Lastname=user.Lastname,Password=new Encryptor().EncodePasswordMd5(user.Password),RegistrationTimeStamp=DateTime.Now});
                 var  committed=   await _unitofwork.CommitChangesAsync();
                    if(committed==1)   return new CreateNewResponse { ResponseCode = "00", ResponseMessage = "User Created Successfully" };
                    else return new CreateNewResponse { ResponseCode = "02", ResponseMessage = "Something went wrong try again later" };
                }


            }
            catch (Exception ex)
            {
                _logWriter.LogWrite("Message: " + ex.Message + Environment.NewLine + "InnerException: " + ex.InnerException + Environment.NewLine + "StackTrace: " + ex.StackTrace);
                return new CreateNewResponse { ResponseCode = "99", ResponseMessage = ex.Message };

            }
        }

        public async Task<LoginResponse> SignIn(Login details)
        {
            try
            {
                var encryptedPassword = new Encryptor().EncodePasswordMd5(details.Password);
                var user = await _unitofwork.Users.FirstOrDefaultAsync(o => o.Email == details.Email && o.Password==encryptedPassword);
                if (user != null) return new LoginResponse { ResponseCode = "01", ResponseMessage = "Login Successful", LoginData = new Data { UserFirstname = user.Firstname, ExpiresIn = 3600,Token=_tokenManager.GenerateToken(user.UserId.ToString()) } };
                else return new LoginResponse { ResponseCode = "02", ResponseMessage = "Email or password invalid" };

            }
            catch (Exception ex)
            {
                _logWriter.LogWrite("Message: "+ex.Message + Environment.NewLine + "InnerException: " + ex.InnerException + Environment.NewLine + "StackTrace: " + ex.StackTrace);

                return new LoginResponse { ResponseCode = "99", ResponseMessage = ex.Message };

            }
        }

        public async Task<FundWalletResponse>FundWallet(decimal amount)
        {
            try
            {
                var userid = Thread.CurrentPrincipal.Identity.Name;
                    var user = await _unitofwork.Users.GetByIdAsync(long.Parse(userid));
                    user.WalletBalance += amount;
                    _unitofwork.Users.Update(user);
                 return   new FundWalletResponse { ResponseCode = "00", ResponseMessage = "Wallet Funded Successfully" };
                
            }
            catch (Exception ex)
            {
                _logWriter.LogWrite("Message: " + ex.Message + Environment.NewLine + "InnerException: " + ex.InnerException + Environment.NewLine + "StackTrace: " + ex.StackTrace);

                return new FundWalletResponse { ResponseCode = "99", ResponseMessage = ex.Message };

            }
        }
        public async Task<UserInfoResponse> GetUserInfo(long userid)
        {
            try
            {
                var user = await _unitofwork.Users.GetByIdAsync(userid);
            return new UserInfoResponse {ResponseCode="00",UserInfo= Mapper.MapProperties<UserInfo>(user), ResponseMessage="success" };
            }
            catch (Exception ex)
            {
                _logWriter.LogWrite("Message: " + ex.Message + Environment.NewLine + "InnerException: " + ex.InnerException + Environment.NewLine + "StackTrace: " + ex.StackTrace);

                return new UserInfoResponse { ResponseCode = "99", ResponseMessage = ex.Message };

            }
        }
    }
}
