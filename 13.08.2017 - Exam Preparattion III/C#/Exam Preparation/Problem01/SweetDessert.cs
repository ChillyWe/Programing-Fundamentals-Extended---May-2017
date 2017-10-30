using System;

namespace Problem01
{
    class SweetDessert
    {
        static void Main(string[] args)
        {
            decimal amountOfCash = decimal.Parse(Console.ReadLine());
            long guests = long.Parse(Console.ReadLine());
            decimal bananaPrice = decimal.Parse(Console.ReadLine());
            decimal eggsPrice = decimal.Parse(Console.ReadLine());
            decimal berriesPrice = decimal.Parse(Console.ReadLine());

            decimal set = (2 * bananaPrice) + (4 * eggsPrice) + (0.2m * berriesPrice);

            long neededSets = guests / 6;

            if (guests % 6 != 0)
            {
                neededSets++;
            }

            decimal totalPrice = neededSets * set;

            if (totalPrice <= amountOfCash)
            {
                Console.WriteLine("Ivancho has enough money - it would cost {0:f2}lv.", totalPrice);
            }
            else
            {
                decimal neededMoney = totalPrice - amountOfCash;
                Console.WriteLine("Ivancho will have to withdraw money - he will need {0:f2}lv more.", neededMoney);
            }
        }
    }
}