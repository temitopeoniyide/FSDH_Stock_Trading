using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth_Service.Presentation.Responses
{
    public class UserInfoResponse
    {

        [JsonProperty(PropertyName = "responseCode")]

        public string ResponseCode { get; set; }
        [JsonProperty(PropertyName = "responseMessage")]

        public string ResponseMessage { get; set; }

        [JsonProperty(PropertyName = "userInfo")]
        public UserInfo UserInfo { get; set; }
    }
    public class UserInfo
    {
        [JsonProperty(PropertyName = "userId")]
        public long UserId { get; set; }
        [JsonProperty(PropertyName = "firstName")]
        public string Firstname { get; set; }
        [JsonProperty(PropertyName = "lastName")]
        public string Lastname { get; set; }
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }
     
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
        [JsonProperty(PropertyName = "walletBalance")]
        public decimal WalletBalance { get; set; }
        [JsonProperty(PropertyName = "registrationTimestamp")]
        public DateTime RegistrationTimeStamp { get; set; }
    }
}
