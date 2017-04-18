using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonParser
{
    class PVObject
    {
        private GroupsObject groups;
        private List<Group> groupList;
        public PVObject (string json)
        {
            groups = JsonConvert.DeserializeObject<GroupsObject>(json);
            groupList = groups.Groups;
        }

        public Group getGroup(int id)
        {
           //TODO realise chosing algorithm
        }
        public List<Group> getAllGroups()
        {
            //TODO realise singleton
        }

        public User getUser(int id)
        {
            //TODO realise chosing algorithm
        }

        public List<User> getAllUsers()
        {
            //TODO realise singleton
        }
        

    }

}
