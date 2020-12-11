using System;
using System.Text.RegularExpressions;

namespace level_3
{
    class Program
    {
        private static string _expression = "";

        private static Type? _type = null;

        private static double _number1 = 0;

        private static double _number2;

        private static double _result;

        private enum Type
        {
            Binary,
            BinaryByte,
            UnaryByte,
            Unary,
            Error
        }

        private static bool IsValidExpression()
        {
            _expression = _expression.Replace(" ", "");
            var regex = new Regex(@"[^pow\d\Wx]");
            _expression = _expression.Replace("pow", "#").Replace('x', '*');
            if (regex.IsMatch(_expression)) throw new Exception("");
            var regexSigns = new Regex(@"[^,\d]+");

            regex = new Regex(@"\d+,\d+|\d+");
            MatchCollection matches = regex.Matches(_expression);
            MatchCollection signsMatches = regexSigns.Matches(_expression);
            if (matches.Count > 2 || matches.Count == 0 || signsMatches.Count > 2) throw new Exception("");
            if (matches.Count == 1 && signsMatches.Count <= 1) 
            {
                if (_expression.StartsWith('!'))
                {
                    _type = Type.UnaryByte;
                }
                else if (!_expression.Contains('+') && !_expression.EndsWith('-'))
                {
                    _type ??= Type.Unary;
                }
                else throw new Exception("");
                _number1 = double.Parse(matches[0].Value);
            }
            else if (matches.Count == 2)
            {
                var binaryRegex = new Regex(@"\+|\*|\/|%|#|\\|-");
                if (binaryRegex.IsMatch(_expression)) {
                    _type = Type.Binary;
                    foreach (Match signs in signsMatches)
                        if (signs.Length > 2) throw new Exception("");
                }

                var binaryByteRegex = new Regex(@"&|\||\^");
                if (binaryByteRegex.IsMatch(_expression)) {
                    _type = _type == null ? Type.BinaryByte : throw new Exception("");
                    if (signsMatches.Count > 1) throw new Exception("");
                }
                if (_expression.Contains('!')) throw new Exception("");
                _number1 = double.Parse(matches[0].Value);
                _number2 = double.Parse(matches[1].Value);
            }
            return true;
        }

        static void BinaryCalc()
        {
            var regexSigns = new Regex(@"[^,\d]+");
            MatchCollection signsMatches = regexSigns.Matches(_expression);
            string operation;

            if (signsMatches.Count == 2)
            {
                if (signsMatches[0].ToString() == "-") _number1 *= -1;
                else throw new Exception("");
                string tmp = signsMatches[1].ToString();
                if (tmp.Length == 2 && tmp[1] == '-') _number2 *= -1;
                else if (tmp.Length == 2) throw new Exception("");
                operation = signsMatches[1].ToString();
            }
            else
            {
                string tmp = signsMatches[0].ToString();
                if (tmp.Length == 2 && tmp[1] == '-') _number2 *= -1;
                else if (tmp.Length == 2) throw new Exception("");
                operation = signsMatches[0].ToString();
            }

            switch (operation[0])
            {
                case '+': _result = _number1 + _number2;
                break;
                case '-': _result = _number1 - _number2;
                break;
                case '*': _result = _number1 * _number2;
                break;
                case '#': _result = Math.Pow(_number1, _number2);
                break;
                case '/':
                case '\\':
                    if (_number2 == 0) throw new Exception("Can't divide by 0.");
                    else _result = _number1 / _number2;
                break;
                case '%': _result = _number1 % _number2;
                break;
                default:
                break;
            }
        }

        static void BinaryByteCalc()
        {
            var binaryByteRegex = new Regex(@"&|\||\^");
            var match = binaryByteRegex.Match(_expression);

            if (match.ToString().Length != 1)
            {
                throw new Exception("");
            }
            if (_expression.StartsWith(match.ToString()) || _expression.EndsWith(match.ToString()))
            {
                throw new Exception(""); 
            }
            switch (match.ToString())
            {
                case "&": _result = (int)_number1 & (int)_number2;
                break;
                case "|": _result = (int)_number1 | (int)_number2;
                break;
                case "^": _result = (int)_number1 ^ (int)_number2;
                break;
                default: throw new Exception("");
            }
        }

        static void UnaryCalc()
        {
            var regex = new Regex(@"&|\||\^");
            var match = regex.Match(_expression);
            if (match == null)
            {
                _result = _number1;
            }
            else if (match.ToString() == "-" && _expression.StartsWith('-')) 
            {
                _result = -_number1;
            }
            else if (match.ToString() == "!" && _expression.EndsWith('!'))
            {
                if (_number1 == 0)
                {
                    _result = 1;
                }
                else if (_number1 < 0) 
                {
                    throw new Exception("Factorial can't be calculated by value less then 0.");
                }
                else
                {
                    _result = 1;
                    for (int i = 1; i <= _number1; i++)
                    {
                        _result *= i;
                    }
                }
            }
            else throw new Exception("");
        }

        static void UnaryByteCalc()
        {
            var regex = new Regex(@"\W");
            var match = regex.Match(_expression);
            if (match.ToString() == "!" && _expression.StartsWith('!'))
            {
                _result = ~(int)_number1;
            }
            else
            {
                throw new Exception("");
            }
        }

        static void DoCalc()
        {
            IsValidExpression();
            switch (_type)
            {
                case Type.Binary: BinaryCalc();
                break;
                case Type.BinaryByte: BinaryByteCalc();
                break;
                case Type.UnaryByte: UnaryByteCalc();
                break;
                case Type.Unary: UnaryCalc();
                break;
                default: break;
            }
        }

        static int CommandMode(string[] args)
        {
            foreach (var i in args)
                _expression += i;
            try {
                DoCalc();
                Console.WriteLine(_result);
            } catch (Exception)
            {
                return -1;
            }
            return 0;
        }

        static int DialogMode()
        {
            string command;
            while (true) {
                Console.Write("Enter command -> ");
                command = Console.ReadLine();
                try
                {
                    switch (command)
                    {
                        case "exit": Console.WriteLine("Byyye!");
                        return 0;
                        case "help": WriteHelp();
                        break;
                        default:
                            _expression = command; 
                            DoCalc();
                        break;
                    }
                    Console.WriteLine($"Answer = {_result}");
                } catch (Exception)
                {
                    Console.WriteLine("Invalid input. Try again. (You can always use 'help').");
                }
            }
        }

        static void WriteHelp()
        {
            Console.WriteLine("");
        }

        static int Main(string[] args)
        {
            if (args.Length > 0) return CommandMode(args);
            Console.WriteLine("Task 3. Calculator by Andrey Basystyi.");
            Console.WriteLine("This propram can calculate binary operations, byte binary, unary and byte unary.");
            Console.WriteLine("You need to enter you expression in command line.\nFor exit enter -> 'exit'.\nFor more help enter 'help'.");
            return DialogMode();
        }
    }
}
