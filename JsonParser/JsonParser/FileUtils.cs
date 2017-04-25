﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;


namespace JsonParser
{
    public static class FileUtils
    {
        //Groups
        public static IEnumerable<Group> ReadGroups()
        {
            var groups = new List<Group>();

            try
            {
                using (StreamReader sr = new StreamReader("../groupstest.txt"))
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
        public static void SaveGroups(IEnumerable<Group> groupColection)
        {
            try
            {
                using (StreamWriter file = new StreamWriter("../groupstest.txt", false))
                {
                    //file.WriteLine(groupColection);
                    string output = "{ \"groups\" : " + JsonConvert.SerializeObject(groupColection) + " }";
                    file.WriteLine(output);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }



        //Users
        public static IEnumerable<User> ReadUsers()
        {
            var users = new List<User>();

            try
            {
                using (StreamReader sr = new StreamReader("../userstest.txt"))
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


        public static void saveUsers(IEnumerable<User> userColection)
        {

            try
            {
                using (StreamWriter file = new StreamWriter("../userstest.txt", false))
                {
                    //file.WriteLine(groupColection);
                    string output = "{  \"users\" : " + JsonConvert.SerializeObject(userColection) + " }";
                    file.WriteLine(output);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }



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
