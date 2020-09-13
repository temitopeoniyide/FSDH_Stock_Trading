using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth_Service.Domain.Models
{
    public class TblUser
    {
        [JsonProperty(PropertyName = "userId")]
        public long UserId { get; set; }
        [JsonProperty(PropertyName = "firstName")]
        public string Firstname { get; set; }
        [JsonProperty(PropertyName = "lastName")]
        public string Lastname { get; set; }
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
        [JsonProperty(PropertyName = "walletBalance")]
        public decimal WalletBalance { get; set; }
        [JsonProperty(PropertyName = "registrationTimestamp")]
        public DateTime RegistrationTimeStamp { get; set; }
    }
}
