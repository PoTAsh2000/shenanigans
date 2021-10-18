using System;

namespace TwoEggProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int randomFloor = random.Next(1, 100);

            Console.WriteLine("Max floor: " + randomFloor);

            int floor = FirstEgg(randomFloor, 0, 14, 0)[0];
            int increase = FirstEgg(randomFloor, 0, 14, 0)[1];
            int tries = FirstEgg(randomFloor, 0, 14, 0)[2];

            Console.WriteLine("First egg broke at floor: " + floor);
            Console.WriteLine("Tries: " + tries);

            int startFloor = floor - increase;
            Console.WriteLine("second egg start: " + startFloor);
            Console.WriteLine("increase"+ increase);

            for (int i = 0; i < increase; i++)
            {
                Console.WriteLine(1);
                tries++;
                if (i == randomFloor)
                {
                    Console.WriteLine("Seconds egg broke at:" + i);
                    Console.WriteLine("At try: " + tries);
                }

            }
        }

        static int[] FirstEgg(int randomFloor, int floor, int increase, int tries)
        {
            floor += increase;

            if (floor >= randomFloor) return new int[] { floor, increase, tries + 1 };

            return FirstEgg(randomFloor, floor, increase - 1, tries + 1);
        }

    }
}
