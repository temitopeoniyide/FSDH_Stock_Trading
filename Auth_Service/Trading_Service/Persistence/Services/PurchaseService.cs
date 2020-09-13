using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading;
using System.Threading.Tasks;
using Trading_Service.Domain;
using Trading_Service.Domain.IServices;
using Trading_Service.Domain.Models;
using Trading_Service.JWT;
using Trading_Service.Presentation.Responses;
using Trading_Service.Utilities;

namespace Trading_Service.Persistence.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IUnitOfWork _unitofwork;
        private IConfiguration config;
        private readonly ILogWriter _logWriter;
        private readonly ITokenManager _tokenManager;
        public PurchaseService(IUnitOfWork unitofwork, IConfiguration _config, ILogWriter logWriter, ITokenManager tokenManager)
        {
            _unitofwork = unitofwork;
            config = _config;
            _logWriter = logWriter;
            _tokenManager = tokenManager;
        }
        public async Task<GetMyPurchases> GetMyPurchase()
        {
            try
            {
                var userid = long.Parse(Thread.CurrentPrincipal.Identity.Name);

                var purchases = await _unitofwork.Purchase.WhereAsync(o => o.UserId == userid);
                return new GetMyPurchases { Data = purchases, ResponseCode = "00" };
            }
            catch(Exception ex)
            {
                return new GetMyPurchases { ResponseCode = "99",ResponseMessage=ex.Message };

            }
        }
    }
}
