using System;
using System.Diagnostics;

namespace task_4
{
    class Program
    {
        private static uint _min = 0;

        private static uint _max = 0;

        private static int _n;

        static bool ParseValue(string parseString, out uint value)
        {
            value = 0;
            if (parseString.Contains(' ')) return false;
            if (parseString.Length > uint.MaxValue.ToString().Length) return false;
            if (!uint.TryParse(parseString, out value)) return false; 
            if (value > 1000000) return false;
            return true;
        }

        static void SetRange()
        {
            while (true)
            {
                Console.Write("Enter minimum value -> ");
                if (ParseValue(Console.ReadLine(), out _min)) break;
                Console.WriteLine("Invalid minimum value. Try again.");
            }
            while (true) {
                Console.Write("Enter maximum value -> ");
                if (ParseValue(Console.ReadLine(), out _max) && _max > _min) break;
                Console.WriteLine("Invalid maximum value. Try again.");
            }

            var n = 1;
            var count = _max - _min + 1;
            for ( ; Math.Pow(2, n) - count < 0; n++);
            if (Math.Abs(Math.Pow(2, n) - count) > Math.Abs(Math.Pow(2, n - 1) - count)) _n = n -1;
            else _n = n;
        }

        static void GuessNumber()
        {
            string answer;
            uint number;
            var rnd = new Random();
            var fails = 0;
            var points = 0;
            var guessValue = rnd.Next((int) _min, (int) _max + 1);
            Stopwatch time = new Stopwatch();

            Console.WriteLine($"I guess a number in range {_min}...{_max}. Try to guess.");
            // Debug.WriteLine(guessValue);

            time.Start();
            while (true)
            {
                Console.Write("-> ");
                if ((answer = Console.ReadLine()) == "exit") {
                    points = 0;
                    break;
                }
                if (!ParseValue(answer, out number))
                {
                    Console.WriteLine("Invalid value. Try again.");
                    continue;
                }
                if (number == guessValue) {
                    Console.WriteLine("You guessed!!!!");
                    points = (int)Math.Ceiling(100.0 * (_n - fails) / _n);
                    break;
                }
                fails++;
                if (number < guessValue) Console.WriteLine("To few!");
                else if (number > guessValue) Console.WriteLine("To much!");
            }
            time.Stop();

            Console.WriteLine($"Stats:\nPoints: {points}\nAttempts count: {fails + 1}\nTotal time: {time.ElapsedMilliseconds}ms");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Task 2.4. Game more lass by Andrey Basystyi.");
            Console.WriteLine("You must enter min and max values of the range and trie to guess number.");
            Console.WriteLine("Rules: range must be in interval from 0 to 1.000.000, only integers, max value mast be more than min value.");
            Console.WriteLine("Have fun! ;)");
            SetRange();
            GuessNumber();
        }
    }
}
