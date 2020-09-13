using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth_Service.Presentation.Responses
{
    public class CreateNewResponse
    {
        [JsonProperty(PropertyName = "responseCode")]

        public string ResponseCode { get; set; }
        [JsonProperty(PropertyName = "responseMessage")]

        public string ResponseMessage { get; set; }
    }
}
