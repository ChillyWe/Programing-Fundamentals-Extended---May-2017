using System;
using System.Linq;

namespace Problem01
{
    class SoftuniCoffeeOrders
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            decimal totalPrice = 0m;

            for (int i = 0; i < n; i++)
            {
                decimal price = decimal.Parse(Console.ReadLine());
                int[] dateTokens = Console.ReadLine().Split('/').Select(int.Parse).ToArray();

                int days = System.DateTime.DaysInMonth(dateTokens[2], dateTokens[1]);
                long capsulesCount = long.Parse(Console.ReadLine());

                decimal orderPrice =  (days * capsulesCount) * price;
                totalPrice += orderPrice;
                Console.WriteLine("The price for the coffee is: ${0:F2}", orderPrice);
            }
            Console.WriteLine("Total: ${0:f2}", totalPrice);
        }
    }
}