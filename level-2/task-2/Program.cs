using System;

namespace task_2
{
    class Program
    {
        private static bool _isCommandMode = false;

        // private static string _error;

        private static double _area;

        static bool ParseValue(string parseString, out double result)
        {
            result = 1;
            if (parseString.Length > Double.MaxValue.ToString().Length) return false;
            if (!double.TryParse(parseString, out result)) return false;
            if (result <= 0) return false;
            return true;
        }

        static int CalcTriangle(string[] args)
        {
            if (args.Length != 4) return -1;
            double side1 = 0;
            double side2 = 0;
            double side3 = 0;

            if (!ParseValue(args[1], out side1)
                || !ParseValue(args[2], out side2)
                || !ParseValue(args[3], out side3))
            {
                return -1;
            }

            double p = (side1 + side2 + side3) / 2.0;
            _area = Math.Sqrt(p * (p - side1) * (p - side2) * (p - side3));

            if (_area == double.NaN) return -1;
            if (_isCommandMode) Console.WriteLine(Math.Round(_area, 4));
            return 0;
        }

        static int CalcCircle(string[] args)
        {
            if (args.Length != 2) return -1;
            double radius;

            if (!ParseValue(args[1], out radius)) return -1;

            _area = Math.PI * Math.Pow(radius, 2);
            if (_isCommandMode) Console.WriteLine(Math.Round(_area, 4));
            return 0;
        }

        static int CalcSquare(string[] args)
        {
            if (args.Length != 2) return -1;
            double side;

            if (!ParseValue(args[1], out side)) return -1;

            _area = side * side;
            if (_isCommandMode) Console.WriteLine(Math.Round(_area, 4));
            return 0;
        }

        static int CalcRect(string[] args)
        {
            if (args.Length != 3) return -1;

            double side1;
            double side2;
            
            if (!ParseValue(args[1], out side1) || !ParseValue(args[2], out side2)) return -1;

            _area = side1 * side2;
            if (_isCommandMode) Console.WriteLine(Math.Round(_area, 4));
            return 0;
        }

        static int CommandMode(string[] args)
        {
            _isCommandMode = true;
            string shape = args[0];

            switch (shape.ToLower())
            {
                case "rect":
                case "rectangle": return CalcRect(args); 
                case "circle": return CalcCircle(args);
                case "triangle": return CalcTriangle(args);
                case "square": return CalcSquare(args);
                default: return -1;
            }
        }

        static void DialogMode()
        {
            Console.WriteLine("Task 2.2.Shape area calculation by Andrey Basystyi.");
            Console.WriteLine("Dear user. This program can help you to calculate shape area.");
            Console.WriteLine("Rules: you need to enter one of these command: 'rectangle', 'square', 'circle', 'triangle'.");
            Console.WriteLine("Then you must enter their ")
            while (true)
            {

            }
        }
        
        static int Main(string[] args)
        {
            if (args.Length > 0) return CommandMode(args);
            DialogMode();
            return 0;
        }
    }
}
