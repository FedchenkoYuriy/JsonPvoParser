using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonParser
{
    public class User
    {
        [JsonProperty("uid")]
        public int UserId { get; set; }
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("last_name ")]
        public string LastName { get; set; }
        [JsonProperty("pv_status")]
        public bool PVStatus { get; set; }
        [JsonProperty("added")]
        public DateTime Added { get; set; }
        [JsonProperty("groups")]
        public List<int> UserGroups { get; set; }

        public override string ToString()
        {
            return "#############"
                   + "\nUID: " + UserId
                   + "\nFirst Name: " + FirstName
                   + "\nLast Name: " + LastName
                   + "\nPVStatus: " + PVStatus
                   + "\nAdded: " + Added
                   + "\nUser Groups: " + UserGroups;
        }    

//
//        public bool updateUser()
//        {
//            //TODO: add prototype realise
//            return true;
//        }
//
    }
//
//    class UserWrapper 
//    {
//        [JsonProperty(PropertyName = "users")]
//        public List<User> UserCollection { get; set; }
//    }
}
