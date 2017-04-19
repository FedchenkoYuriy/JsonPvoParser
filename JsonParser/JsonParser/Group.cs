using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonParser
{
    class Group
    {
        [JsonProperty("gid")]
        public string GroupId { get; set; }
        [JsonProperty("name")]
        public string GroupName { get; set; }
        
        [JsonProperty("members_count")]
        public string NumberOfUsers { get; set; }
        //[JsonProperty("users")]
        //public List<User> Users { get; set; }

        
        public bool updateGroup()
        {
            //TODO add prototype realise
            return true;
        }

        public bool SaveGroup()
        {
            //TODO add prototype realise
            return true;
        }
    }

    class GroupWrapper
    {
        [JsonProperty(PropertyName = "groups")]
        public List<Group> GroupCollection { get; set; }
    }
}
