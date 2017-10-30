using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Problem04
{
    class CubicMessages
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int m = int.Parse(Console.ReadLine());

            while (input != "Over!")
            {
                string pattern = @"^(?<first>[0-9]+)(?<message>[a-zA-Z]+)(?<last>[^a-zA-Z\s]*(\d+)*)$";
                var isMatch = Regex.IsMatch(input, pattern);

                if (isMatch)
                {
                    List<int> indexList = new List<int>();
                    Match message = Regex.Match(input, pattern);
                    char[] indexString = message.Groups["first"].Value.ToCharArray();
                    FillIndexListPart2(indexString, m, indexList);

                    char[] encryptedWord = message.Groups["message"].Value.ToCharArray();

                    char[] index3 = message.Groups["last"].Value.ToCharArray();
                    FillIndexListPart2(index3, m, indexList);

                    if (encryptedWord.Length == m)
                    {
                        Decrypt(indexList, encryptedWord);
                    }
                }
                input = Console.ReadLine();
                int.TryParse(Console.ReadLine(), out m);
            }
        }

        private static void Decrypt(List<int> indexList, char[] encryptedWord)
        {
            StringBuilder sb = new StringBuilder(indexList.Count);
            foreach (var index in indexList)
            {
                if (index == -1)
                {
                    sb.Append(' ');
                }
                else
                {
                    char currentChar = encryptedWord[index];
                    sb.Append(currentChar);
                }

            }
            if (indexList.Count == sb.Length)
            {
                Console.WriteLine(string.Join("", encryptedWord) + " == {0}", sb.ToString());
            }
        }

        private static void FillIndexListPart2(char[] index3, int m, List<int> indexList)
        {
            foreach (var charR in index3)
            {
                int currentNumber;
                bool isIt = int.TryParse(charR.ToString(), out currentNumber);
                if (isIt)
                {
                    if (currentNumber < m)
                    {
                        indexList.Add(currentNumber);
                    }
                    else
                    {
                        indexList.Add(-1);
                    }
                }
            }
        }
    }
}