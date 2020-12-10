using System;

namespace task_2
{
    class Program
    {
        private static bool _isCommandMode = false;

        private static string _error;

        private static double _area;

        static bool ParseValue(string parseString, out double result)
        {
            result = 0;
            if (parseString.Length > Double.MaxValue.ToString().Length) return false;
            if (parseString.Contains(' ')) return false;
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

            if (!ParseValue(args[1], out side1))
            {
                _error = "Invalid first side. Try again.";
                return -1;
            }
            if (!ParseValue(args[2], out side2))
            {
                _error = "Invalid second side. Try again.";
                return -1;
            }
            if (!ParseValue(args[3], out side3))
            {
                _error = "Invalid third side. Try again.";
                return -1;
            }

            double p = (side1 + side2 + side3) / 2.0;
            _area = Math.Sqrt(p * (p - side1) * (p - side2) * (p - side3));

            if (_area == double.NaN)
            {
                _error = "Invalid result. Try again.";
                return -1;
            }
            if (_isCommandMode) Console.WriteLine(Math.Round(_area, 4));
            return 0;
        }

        static int CalcCircle(string[] args)
        {
            if (args.Length != 2) return -1;
            double radius;

            if (!ParseValue(args[1], out radius))
            {
                _error = "Invalid radius. Try again.";
                return -1;
            }

            _area = Math.PI * Math.Pow(radius, 2);
            if (_isCommandMode) Console.WriteLine(Math.Round(_area, 4));
            return 0;
        }

        static int CalcSquare(string[] args)
        {
            if (args.Length != 2) return -1;
            double side;

            if (!ParseValue(args[1], out side)) {
                _error = "Invalid side. Try again.";
                return -1;
            }

            _area = side * side;
            if (_isCommandMode) Console.WriteLine(Math.Round(_area, 4));
            return 0;
        }

        static int CalcRect(string[] args)
        {
            if (args.Length != 3) return -1;

            double side1;
            double side2;
            
            if (!ParseValue(args[1], out side1))
            {
                _error = "Invalid first side. Try again.";
                return -1;
            }
            if (!ParseValue(args[2], out side2))
            {
                _error = "Invalid second side. Try again.";
                return -1;
            }

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

        static string[] ReadRectParams()
        {
            Console.Write("Enter first side -> ");
            string side1 = Console.ReadLine();
            Console.Write("Enter second side -> ");
            string side2 = Console.ReadLine();
            return new string[]{ null, side1, side2 };
        }

        static string[] ReadCircleParams()
        {
            Console.Write("Enter radius -> ");
            string radius = Console.ReadLine();
            return new string[]{ null, radius };
        }

        static string[] ReadTriangleParams()
        {
            Console.Write("Enter first side -> ");
            string side1 = Console.ReadLine();
            Console.Write("Enter second side -> ");
            string side2 = Console.ReadLine();
            Console.Write("Enter third side -> ");
            string side3 = Console.ReadLine();
            return new string[]{ null, side1, side2, side3 };
        }

        static string[] ReadSquareParam()
        {
            Console.Write("Enter side -> ");
            string side = Console.ReadLine();
            return new string[]{ null, side };
        }

        static void DialogMode()
        {
            Console.WriteLine("Task 2.2.Shape area calculation by Andrey Basystyi.");
            Console.WriteLine("Dear user. This program can help you to calculate shape area.");
            Console.WriteLine("Available commands: 'rectangle', 'square', 'circle', 'triangle'. Without sensetive case.");
            Console.WriteLine("Then you must enter their parameters (more than 0).");
            Console.WriteLine("Example for triangle: 3 4 5");
            Console.WriteLine("For exit from program, enter -> 'exit.'\n");

            while (true)
            {
                Console.Write("Enter command -> ");
                string command = Console.ReadLine();
                switch (command.ToLower())
                {
                    case "rect":
                    case "rectangle": CalcRect(ReadRectParams());
                    break;
                    case "circle": CalcCircle(ReadCircleParams());
                    break;
                    case "triangle": CalcTriangle(ReadTriangleParams());
                    break;
                    case "square": CalcSquare(ReadSquareParam());
                    break;
                    case "exit":
                        Console.WriteLine("Byyyye!");
                        Environment.Exit(0);
                    break;
                    default: _error = "Invalid command. Available commands: 'rectangle', 'square', 'circle', 'triangle'.";
                    break;
                }
                if (_error != null) Console.WriteLine(_error);
                else Console.WriteLine($"Area = { Math.Round(_area, 4) }");
                _error = null;
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
