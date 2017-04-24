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
            Console.Read();
        }
    }
}
