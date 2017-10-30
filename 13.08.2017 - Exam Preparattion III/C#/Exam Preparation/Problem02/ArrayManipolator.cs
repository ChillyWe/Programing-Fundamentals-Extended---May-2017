using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem02
{
    class ArrayManipolator
    {
        static void Main(string[] args)
        {
            List<int> integers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] commandTokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                integers = Menu(integers, commandTokens);
                input = Console.ReadLine();
            }

            Console.WriteLine("[" + string.Join(", ", integers) + "]");
        }

        private static List<int> Menu(List<int> integers, string[] commandTokens)
        {
            switch (commandTokens[0])
            {
                case "exchange":
                    {
                        int index = int.Parse(commandTokens[1]);
                        int length = integers.Count;
                        if (index < 0 || index >= length)
                        {
                            Console.WriteLine("Invalid index");
                        }
                        else
                        {
                            integers = Exchange(index, length, integers);
                        }
                    }
                    break;
                case "max":
                    {
                        bool isEven = IsEven(commandTokens[1]);
                        int maxIndex = Max(isEven, integers);

                        if (maxIndex >= 0)
                        {
                            Console.WriteLine(maxIndex);
                        }
                        else
                        {
                            Console.WriteLine("No matches");
                        }
                    }
                    break;
                case "min":
                    {
                        bool isEven = IsEven(commandTokens[1]);
                        int minIndex = Min(isEven, integers);

                        if (minIndex >= 0)
                        {
                            Console.WriteLine(minIndex);
                        }
                        else
                        {
                            Console.WriteLine("No matches");
                        }
                    }
                    break;
                case "first":
                    {
                        List<int> numbers = TakeList(commandTokens[2], integers);
                        int count = int.Parse(commandTokens[1]);
                        if (count < 0 || count > integers.Count)
                        {
                            Console.WriteLine("Invalid count");
                        }
                        else
                        {
                            numbers = numbers.Take(count).ToList();
                            PrintFirstLast(numbers);
                        }
                    }
                    break;
                case "last":
                    {
                        List<int> numbers = TakeList(commandTokens[2], integers);
                        int count = int.Parse(commandTokens[1]);
                        if (count < 0 || count > integers.Count)
                        {
                            Console.WriteLine("Invalid count");
                        }
                        else
                        {
                            numbers.Reverse();
                            numbers = numbers.Take(count).ToList();
                            numbers.Reverse();
                            PrintFirstLast(numbers);
                        }
                    }
                    break;
            }

            return integers;
        }

        private static void PrintFirstLast(List<int> numbers)
        {
            if (numbers.Count == 0)
            {
                Console.WriteLine("[]");
            }
            else
            {
                Console.WriteLine("[" + string.Join(", ", numbers) + "]");
            }
        }

        private static int Min(bool isEven, List<int> integers)
        {
            int modulExpectedResult = isEven ? 0 : 1;

            var filteredSequence = integers.Where(n => n % 2 == modulExpectedResult);
            int minElement;
            if (filteredSequence.Count() > 0)
            {
                minElement = filteredSequence.Min();
            }
            else
            {
                return -1;
            }

            return integers.ToList().LastIndexOf(minElement);

        }

        private static int Max(bool isEven, List<int> integers)
        {
            int modulExpectedResult = isEven ? 0 : 1;

            var filteredSequence = integers
                .Where(n => n % 2 == modulExpectedResult);

            int maxElement;
            if (filteredSequence.Count() > 0)
            {
                maxElement = filteredSequence.Max();
            }
            else
            {
                return -1;
            }

            return integers.ToList().LastIndexOf(maxElement);
        }

        private static List<int> TakeList(string command, List<int> nums)
        {
            List<int> result = new List<int>();
            bool isEven = IsEven(command);

            if (isEven)
            {
                result = nums.Where(n => n % 2 == 0).ToList();
            }
            else
            {
                foreach (var num in nums)
                {
                    result = nums.Where(n => n % 2 != 0).ToList();
                }
            }

            return result;
        }

        public static bool IsEven(string text)
        {
            if (text == "even")
            {
                return true;
            }
            return false;
        }

        public static List<int> Exchange(int index, int length, List<int> nums)
        {
            List<int> itemPart = nums.Skip(index + 1).ToList();
            nums.RemoveRange(index + 1, itemPart.Count);
            nums.InsertRange(0, itemPart);

            return nums;
        }
    }
}