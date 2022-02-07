using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoundRobinCLI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numPlayers, numGroup;

            Console.WriteLine("Enter number of Players in each group ");
            numPlayers = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter number of Groups ");
            numGroup = Convert.ToInt32(Console.ReadLine());

            if ((numGroup == 0))
                 Console.WriteLine("Number of Groups must be greater than 0");
 
            if ((numPlayers == 0 || numPlayers < 2) && (numGroup == 0))
                 Console.WriteLine("Number of Players must be greater than 1");
             
            else
            {
                int xx = 0;

                for (int m = 0; m < numGroup; m++)
                {
                    Console.WriteLine();
                    Console.WriteLine("Group " + (m + 1) + " Fixture");
                    Console.WriteLine();

                    List<string> teams = new List<string> { };

                    for (int i = 0; i < numPlayers; i++)
                    {
                        xx += 1;

                        teams.Add("Player " + xx);
                    }

                    //List<string> teams = new List<string> { "Chennai Super", "RCB", "Mumbai Indians", "Delhi", "KKR", "RR" };

                    foreach (var match in RoundRobin.ListMatches(teams))
                    {
                        Console.WriteLine($"{(match.Day + 1) + " day"} => {match.First}-{match.Second}");
                    }
                }
            }

            Console.Read();

        }
    }
}
