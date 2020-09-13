using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Trading_Service.Domain;
using Trading_Service.Domain.IServices;
using Trading_Service.Domain.Models;
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
        private readonly IHttpContextAccessor _httpContextAccessor;
        public StocKService(IUnitOfWork unitofwork, IConfiguration _config, ILogWriter logWriter, IHttpContextAccessor httpContextAccessor)
        {
            _unitofwork = unitofwork;
            config = _config;
            _logWriter = logWriter;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<PurchaseStockResponse> PurchaseStock(PurchaseStock purchase)
        {
            try
            {
                var userid = long.Parse(Thread.CurrentPrincipal.Identity.Name);
                var company = await _unitofwork.StockCompanies.GetByIdAsync(purchase.CompanyId);
                // Check User wallet balance from AuthMocroservice here
                var buy = new TblPurchase { CompanyId = company.CompanyId,StockPrice=company.StockPrice,StockQuantity=(decimal)purchase.StockQuantity,UserId =userid,Cost=(decimal)purchase.StockQuantity*company.StockPrice };
               await _unitofwork.Purchase.AddAsync(buy);
                var IhaveStock =await _unitofwork.Stocks.FirstOrDefaultAsync(o => o.UserId == userid && o.CompanyId == company.CompanyId);
                if (IhaveStock != null)
                {
                    IhaveStock.Value += (decimal)purchase.StockQuantity * company.StockPrice;
                    _unitofwork.Stocks.Update(IhaveStock);
                }
                else
                {
                    var stock = new TblStocks { CompanyId = company.CompanyId, UserId = userid, Value = (decimal)purchase.StockQuantity * company.StockPrice };
                 await  _unitofwork.Stocks.AddAsync(stock);
                }
                await _unitofwork.CommitChangesAsync();
                //Update User Wallet balance in Auth Microservice here//
                return new PurchaseStockResponse { ResponseCode = "99", ResponseMessage = "StockPurchased Successfully" };
            }
            catch (Exception ex)
            {
                _logWriter.LogWrite("Message: " + ex.Message + Environment.NewLine + "InnerException: " + ex.InnerException + Environment.NewLine + "StackTrace: " + ex.StackTrace);
                return new PurchaseStockResponse { ResponseCode = "99", ResponseMessage = ex.Message };

            }
        }
    }
}
