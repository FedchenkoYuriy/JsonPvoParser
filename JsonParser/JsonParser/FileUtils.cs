using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonParser
{
    class FileUtils

    {

        //Groups
        public string readGroups()
        {
            try
            {
                using (StreamReader sr = new StreamReader("GroupFile.txt"))
                {
                    string line = sr.ReadToEnd();
                    if (IsValidJson(line))
                    {
                        return line;
                    }
                    return "Fail";
                }
            }
            catch (Exception e)
            {
                return "Fail";
            }
        }


        public void saveGroups(string newGroupFile)
        {
         
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Public\TestFolder\WriteLines2.txt", true))
                {
                    file.WriteLine(newGroupFile);
                }
            
        }


        //Users
        public string readUsers()
        {
            try
            {
                using (StreamReader sr = new StreamReader(@"C:\Users\user\Source\Repos\JsonPvoParser\JsonParser\JsonParser\UserFile.txt"))
                {
                    string line = sr.ReadToEnd();
                    if (IsValidJson(line))
                    {
                        return line;
                    }
                    return "Fail";
                }
            }
            catch (Exception e)
            {
                return "Fail";
            }
        }


        public void saveUsers(string newUserFile)
        {

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Public\TestFolder\WriteLines2.txt", true))
            {
                file.WriteLine(newUserFile);
            }

        }


        //Checking for json in string
        private bool IsValidJson(string strInput)
        {
            strInput = strInput.Trim();
            if ((strInput.StartsWith("{") && strInput.EndsWith("}")) || 
                (strInput.StartsWith("[") && strInput.EndsWith("]"))) 
            {
                try
                {
                    var obj = JToken.Parse(strInput);
                    return true;
                }
                catch (JsonReaderException jex)
                {
                    return false;
                }
                catch (Exception ex) 
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
