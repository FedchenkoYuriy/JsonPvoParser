using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonParser
{
    class UserSingleton
    {
            private static UserSingleton userInstance;

            //public UserWrapper Users { get; private set; }
            private static object syncRoot = new Object();

            protected UserSingleton(string json)
            {
            //this.Users = ;
            //Users = JsonConvert.DeserializeObject<UserWrapper>(json);
            }

            public static UserSingleton getInstance(string name)
            {
                if (userInstance == null)
                {
                    lock (syncRoot)
                    {
                        if (userInstance == null)
                        userInstance = new UserSingleton(name);
                    }
                }
                return userInstance;
            }
    }
}
