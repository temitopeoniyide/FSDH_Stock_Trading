using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading_Service.Domain.Models;
using Trading_Service.Presentation.Payload;
using Trading_Service.Presentation.Responses;

namespace Trading_Service.Domain.IServices
{
    public interface IPurchaseService
    {
        Task<GetMyPurchases> GetMyPurchase();

    }
}
