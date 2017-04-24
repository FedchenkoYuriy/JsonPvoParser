using System;
using System.Collections.Generic;

namespace JsonParser
{
    interface IGroupRepository<Group>
    {		
		IEnumerable<Group> GetGroups();		
		Group GetUser(int groupId);
		void AddGroup(Group user);				
		void UpdateGroup(Group group);
	}
}
