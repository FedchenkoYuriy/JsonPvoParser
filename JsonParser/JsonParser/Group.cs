using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonParser
{
    public class Group
    {
        [JsonProperty("gid")]
        public string GroupId { get; set; }
        [JsonProperty("name")]
        public string GroupName { get; set; }        
        [JsonProperty("members_count")]
        public string NumberOfUsers { get; set; }
    }

    class GroupWrapper
    {
        [JsonProperty(PropertyName = "groups")]
        public IEnumerable<Group> Groups { get; set; }
    }
}
