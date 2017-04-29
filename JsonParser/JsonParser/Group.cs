using Newtonsoft.Json;

namespace JsonParser
{
    public class Group
    {
        [JsonProperty("gid")]
        public int GroupId { get; set; }
        [JsonProperty("name")]
        public string GroupName { get; set; }        
        [JsonProperty("members_count")]
        public int NumberOfUsers { get; set; }

        public override string ToString()
        {
            return "#############"
                   + "\nGID: " + GroupId
                   + "\nNAME: " + GroupName
                   + "\nCOUNT: " + NumberOfUsers;
        }
    }
}
