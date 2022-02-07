using System.Collections.Generic; //not specific to a particular datatype.
using System.Linq;  //set of technologies based on the integration of query.

namespace RoundRobinCLI
{
    internal class RoundRobin
    {
        //IEnumerable = interface that define one method.
        //IList = interface that represent a collection of object.
        public static IEnumerable<(int Day, L First, L Second)> ListMatches<L>(IList<L> teams)
        {
            var matches = new List<(int, L, L)>();

            if (teams == null || teams.Count < 2)
                return matches;

            //the default value of the teams is 0 therefore we write Skip(1).
            var restTeams = new List<L>(teams.Skip(1));
            var teamsCount = teams.Count;

            if (teams.Count % 2 != 0)
            {
                restTeams.Add(default);
                teamsCount++;
            }

            for (var day = 0; day < teamsCount - 1; day++)
            {
                if (restTeams[day % restTeams.Count]?.Equals(default) == false)
                    matches.Add((day, teams[0], restTeams[day % restTeams.Count]));

                //index = allow instane of class to be indexed just like array.
                for (var index = 1; index < teamsCount / 2; index++)
                {
                    var firstTeam = restTeams[(day + index) % restTeams.Count];
                    var secondTeam = restTeams[(day + restTeams.Count - index) % restTeams.Count];
                
                    if (firstTeam?.Equals(default) == false && secondTeam?.Equals(default) == false)
                        matches.Add((day, firstTeam, secondTeam));
 
                }
            }

            return matches;
        }
    }

}
