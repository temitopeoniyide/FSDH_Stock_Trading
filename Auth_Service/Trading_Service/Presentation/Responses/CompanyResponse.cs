using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trading_Service.Domain.Models;

namespace Trading_Service.Presentation.Responses
{
    public class CompanyResponse
    {
        [JsonProperty(PropertyName = "responseCode")]

        public string ResponseCode { get; set; }
        [JsonProperty(PropertyName = "responseMessage")]

        public string ResponseMessage { get; set; }

        [JsonProperty(PropertyName = "companies")]

        public IEnumerable<TblStockCompany> Companies { get; set; }
    }
  
}
