using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trading_Service.Domain.Models
{
    public class TblStocks
    {

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "companyId")]
        public long CompanyId {get; set;}
        [JsonProperty(PropertyName = "userId")]
        public long UserId  {get; set;}

        [JsonProperty(PropertyName = "value")]
        public decimal Value { get; set; }
    }
}
