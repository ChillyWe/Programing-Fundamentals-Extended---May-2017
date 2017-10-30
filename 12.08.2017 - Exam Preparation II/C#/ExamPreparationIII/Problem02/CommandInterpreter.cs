using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem02
{
    class CommandInterpreter
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] commandTokens = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                SwitchCommand(commandTokens, input);
                command = Console.ReadLine();
            }
            Console.WriteLine("[" + string.Join(", ", input) + "]");
        }

        private static void SwitchCommand(string[] commandTokens, List<string> input)
        {
            switch (commandTokens[0])
            {
                case "reverse":
                {
                    Reverse(commandTokens, input);
                }
                    break;
                case "sort":
                {
                    Sort(commandTokens, input);
                }
                    break;
                case "rollLeft":
                {
                    RollLeft(commandTokens, input);
                }
                    break;
                case "rollRight":
                {
                    RollRight(commandTokens, input);
                }
                    break;
            }
        }

        private static void Reverse(string[] commandTokens, List<string> input)
        {
            int start = int.Parse(commandTokens[2]);
            int count = int.Parse(commandTokens[4]);

            if (IsValidInput(start, count, input))
            {
                Console.WriteLine("Invalid input parameters.");
            }
            else
            {
                string[] reversedPart = input.Skip(start).Take(count).Reverse().ToArray();
                for (int i = 0; i < count; i++)
                {
                    input[start + i] = reversedPart[i];
                }
            }
        }

        private static void Sort(string[] commandTokens, List<string> input)
        {
            int start = int.Parse(commandTokens[2]);
            int count = int.Parse(commandTokens[4]);

            if (IsValidInput(start, count, input))
            {
                Console.WriteLine("Invalid input parameters.");
            }
            else
            {
                List<string> sortedPart = input.Skip(start).Take(count).OrderBy(s => s).ToList();

                for (int i = 0; i < count; i++)
                {
                    input[start + i] = sortedPart[i];
                }
            }
        }

        private static void RollLeft(string[] commandTokens, List<string> input)
        {
            int count = int.Parse(commandTokens[1]);

            if (count < 0)
            {
                Console.WriteLine("Invalid input parameters.");
            }
            else
            {
                for (int i = 0; i < count % input.Count; i++)
                {
                    string item = input[0];
                    input.RemoveAt(0);
                    input.Add(item);
                }
            }
        }

        private static void RollRight(string[] commandTokens, List<string> input)
        {
            int count = int.Parse(commandTokens[1]);

            if (count < 0)
            {
                Console.WriteLine("Invalid input parameters.");
            }
            else
            {
                for (int i = 0; i < count % input.Count; i++)
                {
                    string item = input[input.Count - 1];
                    input.RemoveAt(input.Count - 1);
                    input.Insert(0, item);
                }
            }
        }

        private static bool IsValidInput(int start, int count, List<string> input)
        {
            return start < 0 || count < 0 || start >= input.Count || (start + count) > input.Count;
        }
    }
}