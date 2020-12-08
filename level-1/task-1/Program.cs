using System;

namespace task_1
{
    class Program
    {
        private const double b = 1999;

        private const double c = 10;

        private const double d = 14;

        static double Function(double a)
        {
            double result = ((Math.Exp(a) + 4 * Math.Log10(c)) / Math.Sqrt(b)) *
                            Math.Abs(Math.Atan(d)) + 5 / Math.Sin(a);
            return Math.Round(result, 4);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Calculation function y = f(a,b,c,d).");
            Console.WriteLine("The program was written by Andrey Basystyi.");
            Console.WriteLine("y = ((e^a + 4 * lg(c)) / sqrt(b)) * |arctg(d)| + 5 / sin(a)");
            Console.WriteLine($"Where b = {b}, c = {c}, d = {d}.");
            Console.Write("Enter a = ");
            double a = double.Parse(Console.ReadLine());
            Console.WriteLine($"y = {Function(a)}");
        }
    }
}
