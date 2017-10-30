using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Problem03
{
    class FootballLeague
    {
        static void Main(string[] args)
        {
            Dictionary<string, Team> teamData = new Dictionary<string, Team>();
            string key = Console.ReadLine();
            string escapedKey = Regex.Escape(key);
            string pattern = @"^.*(" + escapedKey + @")(?<teamA>[a-zA-z]*)(" + escapedKey + @").*(" + escapedKey + @")(?<teamB>[a-zA-z]*)(" + escapedKey + @").*(?<result>[0-9]+:[0-9]+)$";

            string input = Console.ReadLine();
            while (input != "final")
            {
                var match = Regex.Match(input, pattern);

                string teamA = match.Groups["teamA"].Value.ToUpper();
                teamA = Reverse(teamA);

                string teamB = match.Groups["teamB"].Value.ToUpper();
                teamB = Reverse(teamB);

                string[] result = match.Groups["result"].Value.Split(new char[]{':'}, StringSplitOptions.RemoveEmptyEntries).ToArray();
                long teamAgoals = long.Parse(result[0]);
                long teamBgoals = long.Parse(result[1]);
                long teamAPoints = SetPoints(teamAgoals, teamBgoals);
                long teamBPoints = SetPoints(teamBgoals, teamAgoals);

                SaveTeam(teamData, teamA, teamAgoals, teamAPoints);
                SaveTeam(teamData, teamB, teamBgoals, teamBPoints);
                
                input = Console.ReadLine();
            }

            long positionCount = 0;
            Console.WriteLine("League standings:");
            foreach (var team in teamData.OrderByDescending(p => p.Value.Points).ThenBy(t => t.Key))
            {
                string teamName = team.Key;
                long points = team.Value.Points;
                Console.WriteLine("{0}. {1} {2}", ++positionCount, teamName, points);
            }

            Console.WriteLine("Top 3 scored goals:");
            foreach (var team in teamData.OrderByDescending(g => g.Value.Goals).ThenBy(t => t.Key).Take(3))
            {
                string name = team.Key;
                long goals = team.Value.Goals;
                Console.WriteLine("- {0} -> {1}", name, goals);
            }
          
        }

        private static void SaveTeam(Dictionary<string, Team> teamData, string team, long teamgoals, long teamPoints)
        {
            if (teamData.ContainsKey(team))
            {
                teamData[team].Goals += teamgoals;
                teamData[team].Points += teamPoints;
            }
            else
            {
                teamData.Add(team, new Team(teamPoints, teamgoals));
            }
        }

        private static long SetPoints(long teamAgoals, long teamBgoals)
        {
            long teamPoints = 0;
            if (teamAgoals > teamBgoals)
            {
                teamPoints += 3;
            }
            else if (teamAgoals == teamBgoals)
            {
                teamPoints += 1;
            }

            return teamPoints;
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }

    class Team
    {
        public long Points { get; set; }
        public long Goals { get; set; }

        public Team(long points, long goals)
        {
            this.Points = points;
            this.Goals = goals;
        }
    }
}