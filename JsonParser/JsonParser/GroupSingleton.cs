using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonParser
{
    class GroupSingleton
    {
        private static GroupSingleton groupInstance;

        public GroupWrapper Groups { get; private set; }
        private static object syncRoot = new Object();

        protected GroupSingleton(string json)
        {
            //this.Users = ;
            Groups = JsonConvert.DeserializeObject<GroupWrapper>(json);
        }

        public static GroupSingleton getInstance(string name)
        {
            if (groupInstance == null)
            {
                lock (syncRoot)
                {
                    if (groupInstance == null)
                        groupInstance = new GroupSingleton(name);
                }
            }
            return groupInstance;
        }
    }
}
