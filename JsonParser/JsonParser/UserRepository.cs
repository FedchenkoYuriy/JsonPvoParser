using System;
using System.Collections.Generic;
using System.Linq;

namespace JsonParser
{
    class UserRepository : IUserRepository
    {
        private static UserRepository _instance;
        private static object _syncRoot = new Object();
        private static Dictionary<int, User> _users;

        private UserRepository(string path)
        {
            _users = new Dictionary<int, User>();
            LoadUsers(path);
        }

        public static UserRepository GetInstance(string path)
        {
            if (_instance == null)
            {
                lock (_syncRoot)
                {
                    if (_instance == null)
                        _instance = new UserRepository(path);
                }
            }
            return _instance;
        }

        private void LoadUsers(string path)
        {
            if (_users.Count == 0)
            {
                try
                {
                    foreach (var user in FileUtils.ReadUsers(path))
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

            if (_users.Keys.Contains(user.UserId))
            {                
                _users[user.UserId].FirstName = user.FirstName;
                _users[user.UserId].LastName = user.LastName;
                _users[user.UserId].PVStatus = user.PVStatus;
                _users[user.UserId].Added = user.Added;

                foreach (var groupId in user.UserGroups)
                {                    
                    if (!_users[user.UserId].UserGroups.Contains(groupId))
                    {                        
                        _users[user.UserId].UserGroups.Add(groupId);
                    }                                        
                }
            }     
        }
    }
}