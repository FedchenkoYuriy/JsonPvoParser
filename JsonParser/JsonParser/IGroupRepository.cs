using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace JsonParser
{
    public interface IGroupRepository
    {
        IEnumerable<Group> GetGroups();
        Group GetGroup(string groupId);
        void AddGroup(Group group);
        void UpdateGroup(Group group);
    }
}