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
        private static GroupRepository _instace;
        private static object _syncRoot;
        private static ObservableCollection<Group> _groups;        

        private FileUtils FileUtils { get; set; }

        private GroupRepository()
        {
            _groups = new ObservableCollection<Group>();
            LoadGroups();
        }


        public static GroupRepository GetInstance()
        {
            _syncRoot = new object();

            if (_instace == null)
            {
                lock (_syncRoot)
                {
                    if (_instace == null)
                        _instace = new GroupRepository();
                }
            }
            return _instace;
        }

        private void LoadGroups()
        {
            if (_groups.Count == 0)
            {                
                FileUtils = new FileUtils();                        
                try
                {                    
                    foreach (var group in FileUtils.ReadGroups())
                    {                        
                        _groups.Add(group);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("get groups" +  e);
                    Console.ReadKey();
                    throw;
                }
            }            
        }

        public IEnumerable<Group> GetGroups()
        {            
            return _groups;
        }

        public Group GetGroup(int groupId)
        {
            return _groups.First(x => x.GroupId == groupId);
        }

        public void AddGroup(Group group)
        {
            _groups.Add(group);
        }

        public void UpdateGroup(Group group)
        {
            var item = _groups.First(x => x.GroupId == group.GroupId);

            if (item.NumberOfUsers != group.NumberOfUsers)
            {
                item.GroupName = group.GroupName;
                item.NumberOfUsers = group.NumberOfUsers;                
            }            
        }
    }
}
