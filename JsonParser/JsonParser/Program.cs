using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JsonParser
{
    class Program
    {
        static void Main(string[] args)
        {

            var users = UserRepository.GetInstance("Path here").GetUsers();
/**
            foreach (var user in users)
            {
                Console.WriteLine("Users: " + user);
            }
    **/
            UserRepository.GetInstance("Path here").UpdateUser(new User
            {
                UserId = 1001,
                FirstName = "update 1",
                LastName = "update 2",
                Added = new DateTime(),
                PVStatus = true,
                UserGroups = new HashSet<int>
                {
                    1111, 2222, 3333, 4444, 12345, 12356
                }
            });

            foreach (var user in users)
            {
                Console.WriteLine("Users: " + user);
            }

            
            //            var groups = GroupRepository.GetInstance().GetGroups();
            //
            //            Console.WriteLine("Get groups was called: " + groups.Count());
            //
            //            GroupRepository.GetInstance().AddGroup(new Group
            //            {
            //                GroupId = 333,
            //                GroupName = "New Group",
            //                NumberOfUsers = 12
            //            });
            //
            //            Console.WriteLine("Get groups was called: " + groups.Count());


            //            Console.WriteLine(GroupRepository.GetInstance().GetGroup(333));    


            //var users = UserRepository.GetInstance().GetUsers();
            //Console.WriteLine("Get Users was called: " + users.Count());

            //var sortedUsers = UserRepository.GetInstance().GetUsers(12356);
            //Console.WriteLine("Get Users was called: " + sortedUsers.Count());
            //Console.WriteLine(UserRepository.GetInstance().GetUser(3));


            //            FileUtils file = new FileUtils();
            //var groups = file.ReadGroups();
            //Console.WriteLine(test);
            //var groups = JsonConvert.DeserializeObject<GroupWrapper>(test);
            //foreach (var group in groups)
            //{
            //Console.WriteLine(group);
            //}

            //var users = file.ReadUsers();
            //Console.WriteLine(test);
            //var groups = JsonConvert.DeserializeObject<GroupWrapper>(test);
            //foreach (var user in users)
            //{
            //Console.WriteLine(user);
            //}
            //var userColections = GroupRepository.GetInstance();
            //Console.WriteLine(userColections.GetGroups().First());            
            Console.Read();
        }
    }
}
