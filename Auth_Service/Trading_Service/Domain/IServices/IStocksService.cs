using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading_Service.Presentation.Payload;
using Trading_Service.Presentation.Responses;

namespace Trading_Service.Domain.IServices
{
 public   interface IStocksService
    {
        Task<AddCompanyResponse> PurchaseStock(AddNewCompany user);

    }
}
