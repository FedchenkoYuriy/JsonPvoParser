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
        private static Dictionary<int, Group> _groups;              

        private GroupRepository()
        {
            _groups = new Dictionary<int, Group>();
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
                try
                {                    
                    foreach (var group in FileUtils.ReadGroups())
                    {                        
                        _groups.Add(group.GroupId, group);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Load Groups" +  e);
                    Console.ReadKey();
                    throw;
                }
            }            
        }

        public IEnumerable<Group> GetGroups()
        {            
            return _groups.Values;
        }

        public Group GetGroup(int groupId)
        {
            if (_groups.ContainsKey(groupId))
            {
                return _groups[groupId];
            }

            return null;
        }

        public void AddGroup(Group group)
        {
            if (_groups.ContainsKey(group.GroupId))
            {
                Console.WriteLine("Already exist: " + _groups[group.GroupId]);
                UpdateGroup(group);
            }
            else
            {
                _groups.Add(group.GroupId, group);
            }            
        }

        public void UpdateGroup(Group group)
        {
            if (_groups.ContainsKey(group.GroupId))
            {
                _groups[group.GroupId] = group;
            }            
        }
    }
}
