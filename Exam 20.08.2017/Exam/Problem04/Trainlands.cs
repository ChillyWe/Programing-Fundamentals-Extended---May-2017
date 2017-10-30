using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem04
{
    class Trainlands
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, long>> trainData = new Dictionary<string, Dictionary<string, long>>();

            string input = Console.ReadLine();

            while (input != "It's Training Men!")
            {
                string[] inputTokens = input.Split(new char[] { ' ', '-', '>', ':' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                if (inputTokens.Length > 2 && inputTokens[1] != "=")
                {
                    string trainName = inputTokens[0];
                    string wagonName = inputTokens[1];
                    long wagonPower = long.Parse(inputTokens[2]);

                    if (!trainData.ContainsKey(trainName))
                    {
                        trainData.Add(trainName, new Dictionary<string, long>());
                    }
                    if (!trainData[trainName].ContainsKey(wagonName))
                    {
                        trainData[trainName].Add(wagonName, wagonPower);
                    }
                }

                if (inputTokens.Length == 2)
                {
                    string firstTrainName = inputTokens[0];
                    string secoundTrainName = inputTokens[1];

                    if (!trainData.ContainsKey(firstTrainName))
                    {
                        trainData.Add(firstTrainName, new Dictionary<string, long>());
                    }

                    foreach (var wagon in trainData[secoundTrainName])
                    {
                        string wagonName = wagon.Key;
                        long wagonPower = wagon.Value;

                        trainData[firstTrainName].Add(wagonName, wagonPower);
                    }
                    trainData.Remove(secoundTrainName);
                }

                if (inputTokens.Length > 2 && inputTokens[1] == "=")
                {
                    string firstTrainName = inputTokens[0];
                    string secoundTrainName = inputTokens[2];

                    if (!trainData.ContainsKey(firstTrainName))
                    {
                        trainData.Add(firstTrainName, new Dictionary<string, long>());
                    }
                    trainData[firstTrainName].Clear();
                    
                    foreach (var wagon in trainData[secoundTrainName])
                    {
                        string wagonName = wagon.Key;
                        long wagonPower = wagon.Value;

                        trainData[firstTrainName].Add(wagonName, wagonPower);
                    }
                }
                input = Console.ReadLine();
            }

            foreach (var train in trainData.OrderByDescending(p => p.Value.Values.Sum()).
                                                ThenBy(w => w.Value.Count))
            {
                string trainName = train.Key;
                Dictionary<string, long> wagonData = train.Value;
                Console.WriteLine("Train: {0}", trainName);

                foreach (var wagon in wagonData.OrderByDescending(p => p.Value))
                {
                    string wagonName = wagon.Key;
                    long wagonPower = wagon.Value;
                    Console.WriteLine("###{0} - {1}", wagonName, wagonPower);
                }
            }
        }
    }
}