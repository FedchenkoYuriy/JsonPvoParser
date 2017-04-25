using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace JsonParser
{
    class UserRepository : IUserRepository
    {
        private static UserRepository _instance;
        private static object _syncRoot = new Object();
        private static Dictionary<int, User> _users;

        private UserRepository()
        {
            _users = new Dictionary<int, User>();
            LoadUsers();
        }

        public static UserRepository GetInstance()
        {
            if (_instance == null)
            {
                lock (_syncRoot)
                {
                    if (_instance == null)
                        _instance = new UserRepository();
                }
            }
            return _instance;
        }

        private void LoadUsers()
        {
            if (_users.Count == 0)
            {
                try
                {
                    foreach (var user in FileUtils.ReadUsers())
                    {
                        _users.Add(user.UserId, user);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Load users" + e);
                    Console.ReadKey();
                    throw;
                }
            }
        }

        public bool IsUserExitst(int userId)
        {
            return _users.Keys.Contains(userId);
        }


        public IEnumerable<User> GetUsers()
        {
            return _users.Values;
        }

        public IEnumerable<User> GetUsers(int groupId)
        {
            return _users.Values.Where(x => x.UserGroups.Contains(groupId));
        }

        public User GetUser(int userId)
        {
            User user;

            if (_users.TryGetValue(userId, out user))
            {
                return user;
            }

            return null;
        }

        public void AddUser(User user)
        {
            if (!_users.Keys.Contains(user.UserId))
            {
                _users.Add(user.UserId, user);
            }            
        }

        public void AddUsers(IEnumerable<User> users)
        {
            foreach (var user in users)
            {
                AddUser(user);
            }
        }

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}