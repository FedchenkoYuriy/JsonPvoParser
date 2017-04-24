using System.Collections.Generic;

namespace JsonParser
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        IEnumerable<User> GetUsers(int groupId);
        User GetUser(int userId);
        void AddUser(User user);
        void AddUsers(IEnumerable<User> users);
        void UpdateUser(User user);
    }
}