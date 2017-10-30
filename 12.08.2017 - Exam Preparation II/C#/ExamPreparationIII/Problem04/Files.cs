using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem04
{
    class Files
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, long>> data = new Dictionary<string, Dictionary<string, long>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                FillData(data);
            }

            string[] commandTokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string searchedExtension = commandTokens[0];
            string searchedRoot = commandTokens[2];
            bool haveIt = false;

            if (data.ContainsKey(searchedRoot))
            {
                foreach (var files in data[searchedRoot].OrderByDescending(s => s.Value).ThenBy(str => str.Key))
                {
                    string[] currFileInfo = files.Key.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    if (currFileInfo.Length == 2)
                    {
                        string currEx = currFileInfo[1];

                        if (searchedExtension == currEx)
                        {
                            Console.WriteLine("{0} - {1} KB", files.Key, files.Value);
                            haveIt = true;
                        }
                    }
                }
            }
            if (!haveIt)
            {
                Console.WriteLine("No");
            }
        }

        private static void FillData(Dictionary<string, Dictionary<string, long>> data)
        {
            string[] inputTokens = Console.ReadLine().Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string[] fileInfo = inputTokens.Last().Split(new char[] { ';' }).ToArray();

            string fileName = fileInfo[0];
            long size = long.Parse(fileInfo[1]);

            string root = inputTokens[0];
            if (!data.ContainsKey(root))
            {
                data.Add(root, new Dictionary<string, long>());
                data[root].Add(fileName, size);
            }
            else
            {
                if (!data[root].ContainsKey(fileName))
                {
                    data[root].Add(fileName, size);
                }
                else
                {
                    data[root][fileName] = size;
                }
            }
        }
    }
}