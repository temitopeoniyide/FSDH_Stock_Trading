using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth_Service.Presentation.Payload
{
    public class CreateNewUser
    {

        [JsonProperty(PropertyName = "firstName")]
        public string Firstname { get; set; }
        [JsonProperty(PropertyName = "lastName")]
        public string Lastname { get; set; }
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }
    }
}
