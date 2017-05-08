using System;
using System.Collections.Generic;


namespace JsonParser
{
    public class GroupRepository : IGroupRepository
    {
        private static GroupRepository _instace;
        private static object _syncRoot;
        private static Dictionary<int, Group> _groups;              

        private GroupRepository(string path)
        {
            _groups = new Dictionary<int, Group>();
            LoadGroups(path);
        }


        public static GroupRepository GetInstance(string path)
        {
            _syncRoot = new object();

            if (_instace == null)
            {
                lock (_syncRoot)
                {
                    if (_instace == null)
                        _instace = new GroupRepository(path);
                }
            }
            return _instace;
        }

        private void LoadGroups(string path)
        {
            if (_groups.Count == 0)
            {                                
                try
                {                    
                    foreach (var group in FileUtils.ReadGroups(path))
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
