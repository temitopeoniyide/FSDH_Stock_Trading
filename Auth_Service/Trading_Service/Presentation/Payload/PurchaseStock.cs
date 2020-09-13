using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trading_Service.Presentation.Payload
{
    public class PurchaseStock
    {
        [JsonProperty(PropertyName = "stockId")]
        public long CompanyId { get; set; }

        [JsonProperty(PropertyName = "stockQuantity")]
        public double StockQuantity { get; set; }
    }
}
