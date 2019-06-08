using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, HashSet<string>>> vloggerCollection = new Dictionary<string, Dictionary<string, HashSet<string>>>();

            string input = Console.ReadLine();

            while (input != "Statistics")
            {
                if (input.Contains("joined"))
                {
                    string username = input.Split()[0];

                    if (!vloggerCollection.ContainsKey(username))
                    {
                        vloggerCollection.Add(username, new Dictionary<string, HashSet<string>>());
                        vloggerCollection[username].Add("followings", new HashSet<string>());
                        vloggerCollection[username].Add("followers", new HashSet<string>());

                    }
                }
                else if (input.Contains("followed"))
                {

                    string[] username = input.Split();
                    string firstVlogger = username[0];
                    string secondVlogger = username[2];

                    if (!vloggerCollection.ContainsKey(firstVlogger) 
                        || !vloggerCollection.ContainsKey(secondVlogger) 
                        || firstVlogger == secondVlogger)
                    {
                        input = Console.ReadLine();
                        continue;
                    }

                    vloggerCollection[firstVlogger]["followings"].Add(secondVlogger);
                    vloggerCollection[secondVlogger]["followers"].Add(firstVlogger);

                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"The V-Logger has a total of {vloggerCollection.Count} vloggers in its logs.");

            int count = 1;

            var sortedVlogers = vloggerCollection
                .OrderByDescending(f => f.Value["followers"].Count)
                .ThenBy(f => f.Value["followings"].Count)
                .ToDictionary(k => k.Key, y => y.Value);

            foreach (var (username, value) in sortedVlogers)
            {
                int followersCount = sortedVlogers[username]["followers"].Count;
                int followingsCount = sortedVlogers[username]["followings"].Count;

                Console.WriteLine($"{count}. {username} : {followersCount} followers, {followingsCount} following");

                if (count == 1)
                {
                    var followersCollection = value["followers"].OrderBy(x => x).ToList();

                    foreach (var currentUsername in followersCollection)
                    {
                        Console.WriteLine($"*  {currentUsername}");
                    }
                }
                count++;
            }
        }
    }
}

