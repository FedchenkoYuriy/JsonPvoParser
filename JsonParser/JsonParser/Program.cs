using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonParser
{
    class Program
    {
        static void Main(string[] args)
        {
            
            FileUtils file = new FileUtils();
            string test = file.readUsers();
            Console.WriteLine(test);
            var userColections = UserSingleton.getInstance(test);
            Console.WriteLine(userColections.Users.UserCollection[0].FirstName);
            Console.WriteLine(userColections.Users.UserCollection[1].FirstName);
            Console.Read();
        }
    }
}
