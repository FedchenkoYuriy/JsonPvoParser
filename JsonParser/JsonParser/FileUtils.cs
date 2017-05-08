using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace JsonParser
{
    public static class FileUtils
    {
        public static void Save(IEnumerable<Group> groupColection, IEnumerable<User> userColection, string path, DateTime date)
        {
            try
            {
                string dateFormat = date.ToString("_dd.MM.yyyy H-mm-ss ");
                try
                {
                    SaveGroups(groupColection, path, dateFormat);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    throw;
                }
                try
                {
                    SaveUsers(userColection, path, dateFormat);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    throw;
                }
                string[] fileEntries = Directory.GetFiles(path);
                Array.Sort(fileEntries, StringComparer.InvariantCulture);
                if(fileEntries.Length == 6)
                {
                    File.Delete(fileEntries[0]);
                    File.Delete(fileEntries[3]);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }


        //Groups
        public static IEnumerable<Group> ReadGroups(string path)
        {
            var groups = new List<Group>();

            try
            {
                using (StreamReader sr = new StreamReader(path))
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
        public static void SaveGroups(IEnumerable<Group> groupColection, string path, string dateFormat)
        {
            try
            {
                using (StreamWriter file = new StreamWriter(path + "groups" + dateFormat + ".txt", false))
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
        public static IEnumerable<User> ReadUsers(string path)
        {
            var users = new List<User>();

            try
            {
                using (StreamReader sr = new StreamReader(path))
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

        public static void SaveUsers(IEnumerable<User> userColection, string path, string dateFormat)
        {

            try
            {
                using (StreamWriter file = new StreamWriter(path +"users"+ dateFormat + ".txt", false))
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

    }
}
