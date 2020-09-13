using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trading_Service.Domain.Models
{
    public class TblPurchase
    {
        [JsonProperty(PropertyName = "purchaseId")]
        public long PurchaseId { get; set; }

        [JsonProperty(PropertyName = "purchaseTimestamp")]
        public DateTime PurchaseTimestamp {get; set;}

        [JsonProperty(PropertyName = "stockPrice")]
        public decimal StockPrice { get; set;}

        [JsonProperty(PropertyName = "stockQuantity")]
        public decimal StockQuantity {get; set;}

        [JsonProperty(PropertyName = "userId")]
        public long UserId {get; set;}
        [JsonProperty(PropertyName = "companyId")]
        public long CompanyId { get; set;}
    }
}
