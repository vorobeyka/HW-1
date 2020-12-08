using System;

namespace task_1
{
    class Program
    {
        static private Commands userCommand;
        
        static private Commands computerCommand;

        private static string[] commands = { "paper", "stone", "scissors" };

        private enum Commands
        {
            paper,
            stone,
            scissors,
            exit,
            error
        }

        static void ErrorHandle()
        {
            Console.WriteLine("Invalid command. Available commands: 'paper', 'stone', 'scissors', 'exit'.");
        }

        static string RandomCommand()
        {
            Random rnd = new Random();
            return commands[rnd.Next(0, 3)];
        }

        static Commands SetCommand(string value)
        {
            switch (value)
            {
                case "paper": return Commands.paper;
                case "stone": return Commands.stone;
                case "scissors": return Commands.scissors;
                case "exit": return Commands.exit;
                default: return Commands.error;
            }
        }

        static void DoExit()
        {

        }

        static void DoRound()
        {
            if (userCommand == computerCommand)
            {
                Console.WriteLine("NON");
                return;
            }
            switch (userCommand)
            {
                case Commands.paper:
                    if (computerCommand == Commands.scissors) Console.WriteLine("compuhter win");
                    else Console.WriteLine("4elovek win");
                break;
                case Commands.stone:
                    if (computerCommand == Commands.paper) Console.WriteLine("compuhter win");
                    else Console.WriteLine("4elovek win");
                break;
                case Commands.scissors:
                    if (computerCommand == Commands.stone) Console.WriteLine("compuhter win");
                    else Console.WriteLine("4elovek win");
                break;
                case Commands.exit:
                    DoExit();
                break;
                default:
                    ErrorHandle();
                break;
            }
        }

        static void Game()
        {
            while (true)
            {
                Console.Write("Enter command -> ");
                userCommand = SetCommand(Console.ReadLine());
                computerCommand = SetCommand(RandomCommand());
                DoRound();
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("The game 'Stone-Scissors-Paper'.");
            Console.WriteLine("The program was written by Andrey Basystyi.");
            Console.WriteLine("Rules: you need to enter one of these command: 'paper', 'stone', 'scissors', 'exit'");
            Console.WriteLine("The computer offer its version at random.");
            Console.WriteLine("stone > scissors; scissors > paper; paper > stone.");
            Console.WriteLine("To exit from application enter 'exit'.");
            Game();
        }
    }
}
