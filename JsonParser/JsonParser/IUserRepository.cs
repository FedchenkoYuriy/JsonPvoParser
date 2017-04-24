using System;
using System.Collections.Generic;

namespace JsonParser
{
    interface IUserRepository<User>
    {		
		IEnumerable<User> GetUsers();
		IEnumerable<User> GetUsers(int groupId);
		User GetUser(int userId);
		void AddUser(User user);
		void AddUsers(IEnumerable<User> users);
		void UpdateUser(User user);
	}
}
