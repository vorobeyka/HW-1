using System;

namespace task_2
{
    class Program
    {
        static double PercentCalc(double margin, double value)
        {
            return Math.Round(100 / value / (1 + margin / 100));
        }

        static double Margin(params double[] k)
        {
            double rez = 0;

            foreach (double val in k)
                rez += 1 / val;
            rez = 1 - 1 / rez;
            return Math.Round(rez * 100);
        }

        static void Main(string[] args)
        {
            string ownerName;
            string guestName;
            double ownerWinRate;
            double guestWinRate;
            double drawRate;

            Console.WriteLine("Calculation of margin");
            Console.WriteLine("The program was written by Andrey Basystyi.");
            Console.Write("Enter the name of the first team -> ");
            ownerName = Console.ReadLine();
            Console.Write("Enter the name of the second team -> ");
            guestName = Console.ReadLine();
            Console.Write("Enter W1 rate -> ");
            ownerWinRate = double.Parse(Console.ReadLine());
            Console.Write("Enter X rate -> ");
            drawRate = double.Parse(Console.ReadLine());
            Console.Write("Enter W2 rate -> ");
            guestWinRate = double.Parse(Console.ReadLine());

            double margin = Margin(ownerWinRate, guestWinRate, drawRate);
            Console.WriteLine($"Victory {ownerName} : {PercentCalc(margin, ownerWinRate)}%");
            Console.WriteLine($"Victory {guestName} : {PercentCalc(margin, guestWinRate)}%");
            Console.WriteLine($"Dead heat : {PercentCalc(margin, drawRate)}%");
            Console.WriteLine($"Bookmaker's margin : {margin}%");
        }
    }
}
