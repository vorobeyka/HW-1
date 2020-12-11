using System;

namespace task_3
{
    class Program
    {
        private static int[] _array;

        private static int _count;

        private static int _minValue;

        private static int _maxValue;

        private static long _sum = 0;

        private static double _average = 0;

        private static double _rootMeanSquare = 0; 

        static bool ParseValue(string value, out int result)
        {
            result = 0;
            if (value.Contains(' ')) return false;
            if (value.Length > int.MaxValue.ToString().Length) return false;
            if (!int.TryParse(value, out result)) return false;
            return true;
        }

        static void SortArray()
        {
            for (int i = 1; i < _count; i++)
            {
                var j = 0;
                var buf = _array[i];
                for (j = i - 1; j >= 0; j--)
                {
                    if (_array[j] < buf) break;
                    _array[j + 1] = _array[j];
                }
                _array[j + 1] = buf;
            }
        }

        static void CalculateAll()
        {
            SortArray();
            _minValue = _array[0];
            _maxValue = _array[_count - 1];
            _average = _sum / _count;
            foreach (var i in _array)
                _rootMeanSquare += Math.Pow(i - _average, 2);
            
            _rootMeanSquare = Math.Round(Math.Sqrt(_rootMeanSquare / _count), 4);
        }

        static void ResultOut(bool isCommandMode)
        {
            if (isCommandMode) {
                Console.WriteLine($"{_minValue}\n{_maxValue}\n{_sum}\n{_average}\n{_rootMeanSquare}");
            } else {
                Console.WriteLine($"Minimum = {_minValue}");
                Console.WriteLine($"Maximum = {_maxValue}");
                Console.WriteLine($"Sum of numbers = {_sum}");
                Console.WriteLine($"Average = {_average}");
                Console.WriteLine($"Root mean square = {_rootMeanSquare}");
                Console.Write("Sorted array: ");
            }
            for (int i = 0; i < _count; i++)
            {
                Console.Write(_array[i]);
                if (i + 1 != _count) Console.Write(" ");
                else Console.WriteLine();
            }
        }

        static int CommandMode(string[] args)
        {
            _count = args.Length;
            _array = new int[_count];
            for (int i = 0; i < _count; i++)
            {
                if (!ParseValue(args[i], out _array[i])) return -1;
                _sum += _array[i];
            }
            CalculateAll();
            ResultOut(true);
            return 0;
        }

        static int DialogMode()
        {
            Console.Write("Enter length of array -> ");
            if (!ParseValue(Console.ReadLine(), out _count) || _count <= 0)
            {
                Console.WriteLine("Invalid number, try again.");
                return DialogMode();
            }
            Console.WriteLine("Push your array:");

            _array = new int[_count];
            for (int i = 0; i < _count; )
            {
                Console.Write("-> ");
                if (!ParseValue(Console.ReadLine(), out _array[i]))
                {
                    Console.WriteLine("Invalid number, try again.");
                    continue;
                }
                _sum += _array[i];
                i++;
            }
            CalculateAll();
            ResultOut(false);
            return 0;
        }
        
        static int Main(string[] args)
        {
            if (args.Length > 0) return CommandMode(args);
            Console.WriteLine("Task 2.3. Array statistics by Andrey Basystyi.");
            Console.WriteLine("This program will help you to sort array and find:");
            Console.WriteLine("-minimum and maximum values\n-sum of all elements\n-average\n-root mean square.\n");
            return DialogMode();
        }
    }
}
