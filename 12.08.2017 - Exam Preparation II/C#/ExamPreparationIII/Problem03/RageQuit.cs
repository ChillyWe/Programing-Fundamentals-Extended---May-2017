using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Problem03
{
    class RageQuit
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder sb = new StringBuilder();

            string pattern = @"(?<string>[^0-9]{0,20})(?<count>[0-9]+)";

            if (Regex.IsMatch(input, pattern))
            {
                MatchCollection strings = Regex.Matches(input, pattern);

                for (int i = 0; i < strings.Count; i++)
                {
                    string currStr = strings[i].Groups["string"].Value;
                    int times = int.Parse(strings[i].Groups["count"].Value);

                    for (int j = 0; j < currStr.Length; j++)
                    {
                        if (char.IsLower(currStr[j]))
                        {
                            string element = char.ToUpper(currStr[j]).ToString();
                            currStr = currStr.Replace(currStr[j].ToString(), element);
                        }
                    }
                    sb.Append(Repeat(currStr, times));
                }
            }

            int unique = sb.ToString().Distinct().Count();
            Console.WriteLine("Unique symbols used: {0}", unique);
            Console.WriteLine(sb.ToString());
        }

        public static string Repeat(string text, int times)
        {
            string repeatedStr = "";

            for (int i = 0; i < times; i++)
            {
                repeatedStr += text;
            }
            return repeatedStr;
        }
    }
}