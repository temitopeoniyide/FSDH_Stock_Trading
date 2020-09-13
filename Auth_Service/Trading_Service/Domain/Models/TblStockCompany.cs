using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trading_Service.Domain.Models
{
    public class TblStockCompany
    {
        [Key]
        [JsonProperty(PropertyName = "companyId")]
        public long CompanyId { get; set;}
        [JsonProperty(PropertyName = "companyName")]
        public string CompanyName { get; set; }
        [JsonProperty(PropertyName = "companyAcronym")]
        public string CompanyAcronym { get; set; }
        [JsonProperty(PropertyName = "stockPrice")]
        public decimal StockPrice { get; set; }
        [JsonProperty(PropertyName = "registrationTimestamp")]
        public DateTime RegistrationTimeStamp {get; set; }
    }
}
