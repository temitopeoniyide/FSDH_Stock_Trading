using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trading_Service.Presentation.Payload
{
    public class AddNewCompany
    {

        [JsonProperty(PropertyName = "companyName")]
        public string CompanyName { get; set; }
        [JsonProperty(PropertyName = "companyAcronym")]
        public string CompanyAcronym { get; set; }
        [JsonProperty(PropertyName = "stockPrice")]
        public decimal StockPrice { get; set; }

    }
}
