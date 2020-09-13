using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trading_Service.Domain.IServices;
using Trading_Service.JWT;
using Trading_Service.Presentation.Payload;
using Trading_Service.Presentation.Responses;

namespace Trading_Service.Controllers
{
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockCompanyService _stockCompanyService;
        private readonly IStocksService _stocksService;
        private readonly IPurchaseService _purchaseService;


        public StockController(IStockCompanyService stockCompanyService, IStocksService stocksService, IPurchaseService purchaseService)
        {
            _stockCompanyService = stockCompanyService;
            _stocksService = stocksService;
            _purchaseService = purchaseService;
        }
        [HttpPost]
        [Route("AddStockCompany")]
        [JWTAuthHandler]
        public async Task<AddCompanyResponse> AddStockCompany(AddNewCompany company)
        {
            return await _stockCompanyService.AddCompany(company);
        }
        [HttpGet]
        [Route("GetStockCompanies")]
        [JWTAuthHandler]
        public async Task<CompanyResponse> GetStockCompanies()
        {
            return await _stockCompanyService.GetCompanies();
        }

        [HttpGet]
        [Route("GetMyPurchases")]
        [JWTAuthHandler]
        public async Task<GetMyPurchases> GetMyPurchases()
        {
            return await _purchaseService.GetMyPurchase();
        }

        [HttpGet]
        [Route("BuyStock")]
        [JWTAuthHandler]
        public async Task<PurchaseStockResponse> BuyStcok(PurchaseStock stock)
        {
            return await _stocksService.PurchaseStock(stock);
        }
    }
}