using System;
using System.Collections.Generic;
using Newtonsoft.Json;

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
        public HashSet<int> UserGroups { get; set; }

        public override string ToString()
        {
            var str = "#############"
                      + "\nUID: " + UserId
                      + "\nFirst Name: " + FirstName
                      + "\nLast Name: " + LastName
                      + "\nPVStatus: " + PVStatus
                      + "\nAdded: " + Added + "\n";
            foreach (var group in UserGroups)
            {
                str += "grp: " + group + "\n";
            }

            return str;
        }    
    }
}
