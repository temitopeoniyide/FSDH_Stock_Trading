using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth_Service.Presentation.Responses
{
    public class LoginResponse
    {
        [JsonProperty(PropertyName = "responseCode")]

        public string ResponseCode { get; set; }
        [JsonProperty(PropertyName = "responseMessage")]

        public string ResponseMessage { get; set; }

        [JsonProperty(PropertyName = "loginData")]

        public Data LoginData { get; set; }
    }
    public class Data
    {
        [JsonProperty(PropertyName = "userFirtName")]

        public string UserFirstname { get; set; }
        [JsonProperty(PropertyName = "token")]

        public string Token { get; set; }
        [JsonProperty(PropertyName = "expiresIn")]

        public int ExpiresIn { get; set; }
    }
}
