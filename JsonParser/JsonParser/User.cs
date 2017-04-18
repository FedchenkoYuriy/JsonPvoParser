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
        [JsonProperty("deactivated")]
        public bool IsDeactivated { get; set; }
        [JsonProperty("hiden")]
        public int IsHiden { get; set; }
        [JsonProperty("pw_write")]
        public bool PwWrite { get; set; }

        public string getUserLink()
        {
            //TODO Return User Link
            return UserId;
        }

        public string getUid()
        {
            return UserId;
        }

        public string getFirstName()
        {
            return FirstName;
        }

        public string getLastName()
        {
            return LastName;
        }

        public bool isDeactivated()
        {
            return IsDeactivated;
        }

        public int isHiden()
        {
            return IsHiden;
        }

        public bool isPV()
        {
            return PwWrite;
        }

        public bool updateUser()
        {
            //TODO: add prototype realise
            return true;
        }

        public bool setPVStatus(bool newStatus)
        {
            PwWrite = newStatus;
            return true;
        }
    }
}
