using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace JsonParser
{
    class GroupRepository : IGroupRepository
    {
        private static GroupRepository _Instace;
        private static object _syncRoot;
        private static ObservableCollection<Group> _groups;
        private GroupWrapper _groupWrapper;

        private FileUtils FileUtils { get; set; }

        private GroupRepository()
        {
            _groups = new ObservableCollection<Group>();
            getGroups();
        }


        public static GroupRepository GetInstance()
        {
            _syncRoot = new object();

            if (_Instace == null)
            {
                lock (_syncRoot)
                {
                    if (_Instace == null)
                        _Instace = new GroupRepository();
                }
            }
            return _Instace;
        }

        private void getGroups()
        {
            if (_groups == null)
            {                
                FileUtils = new FileUtils();
                _groupWrapper = JsonConvert.DeserializeObject<GroupWrapper>(FileUtils.readGroups());
                foreach (var group in _groupWrapper.Groups)
                {                    
                        _groups.Add(group);                                                        
                }                    
            }            
        }

        public IEnumerable<Group> GetGroups()
        {
            return _groups;
        }

        public Group GetGroup(string groupId)
        {
            return _groups.First(x => x.GroupId == groupId);
        }

        public void AddGroup(Group group)
        {
            _groups.Add(group);
        }

        public void UpdateGroup(Group @group)
        {
            var item = _groups.First(x => x.GroupId == group.GroupId);

            if (item.NumberOfUsers != group.NumberOfUsers)
            {
                item.GroupName = group.GroupName;
                item.NumberOfUsers = group.NumberOfUsers;
                // todo add users to user list
            }            
        }
    }
}
