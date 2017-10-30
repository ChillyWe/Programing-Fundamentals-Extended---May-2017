using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem02
{
    class Program
    {
        static void Main(string[] args)
        {
            int locomotivePower = int.Parse(Console.ReadLine());
            List<int> wagons = new List<int>();
            string input = Console.ReadLine();

            while (input != "All ofboard!")
            {
                int num;
                bool isNum = int.TryParse(input, out num);

                if (isNum)
                {
                    wagons.Add(num);
                }
                int totalWeigth = wagons.Sum();
                if (totalWeigth > locomotivePower)
                {
                    int average = totalWeigth / wagons.Count;

                    // find closest to number
                    int closest = wagons.OrderBy(item => Math.Abs(average - item)).First();
                    wagons.Remove(closest);
                }
                input = Console.ReadLine();
            }
            wagons.Reverse();
            wagons.Add(locomotivePower);
            Console.WriteLine(string.Join(" ", wagons));
        }
    }
}