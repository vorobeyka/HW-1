using System;
using System.Collections.Generic;

namespace task_1
{
    class Program
    {
        /*
        //I don't wanna do much much 'if' 'else' or 'switch' conditions for the game result,
        //that's why I created this matrix with all game events.
        //Please, enjoy my program.:)
        */
        static private int[][] gameMatrix = new int[3][];

        static private Commands userCommand;
        
        static private Commands computerCommand;

        static private string[] commands = { "paper", "stone", "scissors" };

        static private List<string> statistics = new List<string>(100);

        private enum Commands
        {
            paper,
            stone,
            scissors,
            exit,
            error
        }

        static int ErrorHandle()
        {
            Console.WriteLine("Invalid command.\nAvailable commands: 'paper', 'stone', 'scissors', 'exit'.");
            return 1;
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

        static int DoExit()
        {
            Console.WriteLine("_________________________");
            Console.WriteLine("_________________________");
            Console.WriteLine("Results:");

            for (int i = 0; i < statistics.Count; i++)
            {
                Console.WriteLine($"Round {i + 1}\n{statistics[i]}");
                Console.WriteLine("_________________________");
            }
            Environment.Exit(0);
            return 0;
        }

        static int PrintRound()
        {
            int i = (int) userCommand;
            int j = (int) computerCommand;
            string info = $"Player -> {commands[i]}\nComputer -> {commands[j]}\n";

            Console.WriteLine($"Computer -> {commands[(int) computerCommand]}");
            switch (gameMatrix[i][j])
            {
                case 1:
                    Console.WriteLine("You won");
                    statistics.Add(info + "Player WON!");
                break;
                case -1:
                    Console.WriteLine("You lose");
                    statistics.Add(info + "Computer WON!");
                break;
                default:
                    Console.WriteLine("Draw");
                    statistics.Add(info + "DRAW!");
                break;
            }
            return 0;
        }

        static int DoRound()
        {
            switch (userCommand)
            {
                case Commands.error: return ErrorHandle();
                case Commands.exit: return DoExit();
                default: return PrintRound();
            }
        }

        static void InitGameMatrix()
        {
            gameMatrix[0] = new int[3] { 0, 1, -1};
            gameMatrix[1] = new int[3] { -1, 0, 1};
            gameMatrix[2] = new int[3] { 1, -1, 0};
        }

        static void Main(string[] args)
        {
            Console.WriteLine("The game 'Stone-Scissors-Paper'.");
            Console.WriteLine("The program was written by Andrey Basystyi.");
            Console.WriteLine("Rules: you need to enter one of these command: 'paper', 'stone', 'scissors', 'exit'");
            Console.WriteLine("The computer offer its version at random.");
            Console.WriteLine("stone > scissors; scissors > paper; paper > stone.");
            Console.WriteLine("To exit from application enter 'exit'.");
            InitGameMatrix();
            while (true)
            {
                Console.Write("Enter command -> ");
                userCommand = SetCommand(Console.ReadLine());
                computerCommand = SetCommand(RandomCommand());
                DoRound();
                Console.WriteLine("_________________________");
            }
        }
    }
}
