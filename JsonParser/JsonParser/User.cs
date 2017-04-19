using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonParser
{
    class User
    {
        [JsonProperty("uid")]
        public string UserId { get; set; }
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("last_name ")]
        public string LastName { get; set; }
        [JsonProperty("pw_write")]
        public bool PwWrite { get; set; }
        public DateTime addedDate { get; set; }
        public List<string> userGroups { get; set; }




        public bool updateUser()
        {
            //TODO: add prototype realise
            return true;
        }

    }

    class UserWrapper 
    {
        [JsonProperty(PropertyName = "users")]
        public List<User> UserCollection { get; set; }
    }
}
