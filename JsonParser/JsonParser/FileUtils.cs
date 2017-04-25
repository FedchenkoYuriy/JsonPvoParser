using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;


namespace JsonParser
{
    public class FileUtils
    {


        //Groups
        public IEnumerable<Group> ReadGroups()
        {
            var groups = new List<Group>();

            try
            {
                using (StreamReader sr = new StreamReader("../groups.txt"))
                {
                    string line = sr.ReadToEnd();

                    try
                    {
                        var obj = JObject.Parse(line);
                        var array = JArray.Parse(obj.GetValue("groups").ToString());

                        foreach (var group in array)
                        {
                            groups.Add(JsonConvert.DeserializeObject<Group>(group.ToString()));
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }                                               
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return groups;
        }


        //todo use JObject to convrt to json
        public void SaveGroups(string newGroupFile)
        {
            try
            {
                using (StreamWriter file = new StreamWriter("../groups1.txt", true))
                {
                    file.WriteLine(newGroupFile);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }                        
        }


        //Users
        public IEnumerable<User> ReadUsers()
        {
            var users = new List<User>();

            try
            {
                using (StreamReader sr = new StreamReader("../users.txt"))
                {
                    string line = sr.ReadToEnd();

                    try
                    {
                        var obj = JObject.Parse(line);
                        var array = JArray.Parse(obj.GetValue("users").ToString());

                        foreach (var group in array)
                        {
                            users.Add(JsonConvert.DeserializeObject<User>(group.ToString()));
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return users;
        }


//        public void saveUsers(string newUserFile)
//        {
//
//            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Public\TestFolder\WriteLines2.txt", true))
//            {
//                file.WriteLine(newUserFile);
//            }
//
//        }


//        //Checking for json in string
//        private bool IsValidJson(string strInput)
//        {
//            strInput = strInput.Trim();
//            if ((strInput.StartsWith("{") && strInput.EndsWith("}")) || 
//                (strInput.StartsWith("[") && strInput.EndsWith("]"))) 
//            {
//                try
//                {
//                    var obj = JToken.Parse(strInput);
//                    return true;
//                }
//                catch (JsonReaderException jex)
//                {
//                    return false;
//                }
//                catch (Exception ex) 
//                {
//                    return false;
//                }
//            }
//            else
//            {
//                return false;
//            }
//        }
    }
}
