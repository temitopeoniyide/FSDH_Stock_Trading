using Trading_Service.Domain;
using Trading_Service.Domain.IServices;
using Trading_Service.Domain.Models;
using Trading_Service.JWT;
using Trading_Service.Presentation.Payload;
using Trading_Service.Presentation.Responses;
using Trading_Service.Utilities;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading_Service.Extensions;

namespace Trading_Service.Persistence.Services
{
    public class StockCompanyService : IStockCompanyService
    {
        private readonly IUnitOfWork _unitofwork;
        private IConfiguration config;
        private readonly ILogWriter _logWriter;
        private readonly ITokenManager _tokenManager;
        public StockCompanyService(IUnitOfWork unitofwork, IConfiguration _config, ILogWriter logWriter, ITokenManager tokenManager)
        {
            _unitofwork = unitofwork;
            config = _config;
            _logWriter = logWriter;
            _tokenManager = tokenManager;
        }

        public async Task<AddCompanyResponse> AddCompany(AddNewCompany company)
        {
           try {
              var MappedCompany=  Mapper.MapProperties<TblStockCompany>(company);
                 await _unitofwork.StockCompanies.AddAsync(MappedCompany);
                return new AddCompanyResponse { ResponseCode = "00", ResponseMessage = "success" };
            }
            catch (Exception ex)
            {
                _logWriter.LogWrite("Message: " + ex.Message + Environment.NewLine + "InnerException: " + ex.InnerException + Environment.NewLine + "StackTrace: " + ex.StackTrace);

                return new AddCompanyResponse { ResponseCode = "99", ResponseMessage = ex.Message };

            }

        }

        public  async Task<CompanyResponse> GetCompanies()
        {
           try {
                var companies = await _unitofwork.StockCompanies.GetAllAsync();
                return new CompanyResponse { ResponseCode = "00", Companies = companies, ResponseMessage = "success" };
            }
            catch (Exception ex)
            {
                _logWriter.LogWrite("Message: " + ex.Message + Environment.NewLine + "InnerException: " + ex.InnerException + Environment.NewLine + "StackTrace: " + ex.StackTrace);

                return new CompanyResponse { ResponseCode = "99", ResponseMessage = ex.Message };

            }
        }

     
    }
}
