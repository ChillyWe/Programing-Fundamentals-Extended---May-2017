using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problem03
{
    class Trainegram
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();

            string locoPattern = @"^(?<locomotive>\<\[[^A-Za-z0-9]*\]\.)(?<wagons>.*)$";
            string wagonPattern = @"^(\.\[[A-Za-z0-9]*\]\.)*$";

            while (input != "Traincode!")
            {
                if (Regex.IsMatch(input, locoPattern))
                {
                    Match takeLoco = Regex.Match(input, locoPattern);
                    string locomotive = takeLoco.Groups["locomotive"].Value;
                    string wagons = takeLoco.Groups["wagons"].Value;

                    if (wagons.Length == 0)
                    {
                        Console.WriteLine(input);
                    }
                    else
                    {
                        if (Regex.IsMatch(wagons, wagonPattern))
                        {
                            MatchCollection wagonsS = Regex.Matches(wagons, wagonPattern);

                            Console.WriteLine(input);
                        }
                    }
                }
                input = Console.ReadLine();
            }
        }
    }
}