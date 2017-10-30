using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem01
{
    class Trainers
    {
        static void Main(string[] args)
        {
            Dictionary<string, decimal> teamData = new Dictionary<string, decimal>();
            teamData.Add("Technical", 0);
            teamData.Add("Theoretical", 0);
            teamData.Add("Practical", 0);
            int n = int.Parse(Console.ReadLine());
      //      string winnersTeam = string.Empty;
      //      decimal winersScore = decimal.MinValue;

            for (int i = 0; i < n; i++)
            {
                decimal distanceInMiles = decimal.Parse(Console.ReadLine());
                decimal cargoInTons = decimal.Parse(Console.ReadLine());
                string teamName = Console.ReadLine();

                decimal distanceInMeters = distanceInMiles * 1600m;
                decimal cargoInKilos = cargoInTons * 1000m;
                decimal cargoIncome = cargoInKilos * 1.5m;
                decimal fuelPrice = 0.7m * distanceInMeters * 2.5m;
                decimal participantEarnedMoney = (cargoIncome) - (fuelPrice);

                teamData[teamName] += participantEarnedMoney;
            }
            foreach (var team in teamData.OrderByDescending(m => m.Value))
            {
                string name = team.Key;
                decimal score = team.Value;
                Console.WriteLine("The {0} Trainers win with ${1:f3}.", name, score);
                break;
            }
            
        }
    }
}