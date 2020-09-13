using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading_Service.Domain;
using Trading_Service.Domain.IServices;
using Trading_Service.JWT;
using Trading_Service.Presentation.Payload;
using Trading_Service.Presentation.Responses;
using Trading_Service.Utilities;

namespace Trading_Service.Persistence.Services
{
    public class StocKService : IStocksService
    {
        private readonly IUnitOfWork _unitofwork;
        private IConfiguration config;
        private readonly ILogWriter _logWriter;
        private readonly ITokenManager _tokenManager;
        public StocKService(IUnitOfWork unitofwork, IConfiguration _config, ILogWriter logWriter, ITokenManager tokenManager)
        {
            _unitofwork = unitofwork;
            config = _config;
            _logWriter = logWriter;
            _tokenManager = tokenManager;
        }
        public Task<AddCompanyResponse> PurchaseStock(AddNewCompany user)
        {
            throw new NotImplementedException();
        }
    }
}
