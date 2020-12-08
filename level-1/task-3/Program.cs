using System;

namespace task_3
{
    class Program
    {
        private const double epsilon = 1.0 / 1999;

        static double SumOfRange()
        {
            double sum = 0;

            for (int i = 1; ; ++i) {
                double element = 1.0 / (i * (i + 1));
                if (element < epsilon) break;
                sum += element;
            }
            return sum;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Calculation the sum of range.");
            Console.WriteLine("The program was written by Andrey Basystyi.");
            Console.WriteLine("E = 1 / (i * (i + 1))");
            Console.WriteLine($"While element > Epsilon.\nEpsilon = {epsilon}");

            Console.WriteLine($"Sum of range = {SumOfRange()}");
        }
    }
}
