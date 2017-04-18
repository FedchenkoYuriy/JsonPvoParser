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
        [JsonProperty("is_closed ")]
        public string IsClosed { get; set; }
        [JsonProperty("members_count")]
        public string NumberOfUsers { get; set; }
        [JsonProperty("users")]
        public List<User> Users { get; set; }


        public string getId ()
        {
            return GroupId;
        }

        public string getName()
        {
            return GroupName;
        }

        public string getStatus()
        {
            return IsClosed;
        }

        public string getUserAmoount()
        {
            return NumberOfUsers;
        }

        public List<User> getUsers()
        {
            return Users;
        }
        
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
}
