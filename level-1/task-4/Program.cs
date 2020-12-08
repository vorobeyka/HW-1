using System;

namespace task_4
{
    class Program
    {
        static void PrimeNumbers(int min, int max)
        {
            Console.WriteLine("Prime numbers:");
            for (int i = min; i <= max; i++)
            {
                bool flag = true;
                for (int j = 2; j <= Math.Sqrt(i) && flag; j++)
                {
                    if (i % j == 0) flag = false;
                }
                if (flag && i > 1) Console.WriteLine(i);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Searching prime numbers.");
            Console.WriteLine("The program was written by Andrey Basystyi.");
            Console.Write("Enter min value of range -> ");
            int min = int.Parse(Console.ReadLine());
            Console.Write("Enter max value of range -> ");
            int max = int.Parse(Console.ReadLine());
            if (max <= 0 || max < min) return;
            PrimeNumbers(min, max);
        }
    }
}
