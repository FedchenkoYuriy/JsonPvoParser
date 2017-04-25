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

            var groups = GroupRepository.GetInstance().GetGroups();

            Console.WriteLine("Get groups was called: " + groups.Count());

            GroupRepository.GetInstance().AddGroup(new Group
            {
                GroupId = 333,
                GroupName = "New Group",
                NumberOfUsers = 12
            });
            Console.WriteLine("Get groups was called: " + groups.Count());

            Console.WriteLine(GroupRepository.GetInstance().GetGroup(333));            

            
            
//            Console.WriteLine(Directory.GetCurrentDirectory());


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
