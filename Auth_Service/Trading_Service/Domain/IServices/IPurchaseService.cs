﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading_Service.Domain.Models;
using Trading_Service.Presentation.Payload;

namespace Trading_Service.Domain.IServices
{
    interface IPurchaseService
    {
        Task<IEnumerable<TblPurchase>> GetMyPurchase();

    }
}
