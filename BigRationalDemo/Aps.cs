using System;
using System.IO;
using System.Linq;
using BigRationalLib;

namespace BigRationalDemo
{
    public class Aps
    {
        public static List<BigRational> Fractions = new List<BigRational>();
        public static string Operator;
        public static int power;

        public static bool Quit = false;
        public static void CommandLoop()
        {
            while (!Quit)
            {
                Console.WriteLine();
                Console.WriteLine(">> What would you like to do?");
                string command = Console.ReadLine().ToLower();
                CommandRoute(command);
            }
        }

        public static void CommandRoute(string command)
        {
            if (command == "help")
                HelpCommand();
            else if (command == "quit")
                Quit = true;
            else if (command == "clear")
            {
                Fractions.Clear();
                Console.Clear();
                Console.WriteLine("Memory cleared successfully");
            }
            else if (command == "+" || command == "-" || command == "*" || command == "/" || command == "^")
                OperationCommand(command);
            else if (command.Length >= 1)
                FractalsCommand(command);
            else
                Console.WriteLine("{0} was not recognized, please try again.", command);
        }

        public static void HelpCommand()
        {
            Console.WriteLine();
            Console.WriteLine($"quit  - to close program");
            Console.WriteLine($"clear - to clear to remove the memorized fraction and console screen");
            Console.WriteLine($"help  - show help options\n");
            Console.WriteLine($"You can enter the fraction: <<numerator>>/<<denominator>>, example: 3/5 or -2/5.\n" +
                    $"Unfortunetly, you can't use fraction like 1 1/2 (one and a half), I'm still working on that!\n");
            Console.WriteLine($"If you want to perform some operations with fractions, you can use (+, -, *, /, ^),\n" +
                    $"exapmle: 2/3 * 1/2\n");
            Console.WriteLine($"You can't combine mathematical operations yet!\n" +
                    $"But... give me some time ;)");
        }

        public static void FractalsCommand(string command)
        {
            var parts = command.Split('/');
            int numerator;
            int denominator;
            if (!int.TryParse(parts[0], out numerator))
            {
                Console.WriteLine("{0} is not a integer.", parts[0]);
                return;
            }
            if (parts.Length > 1)
            {
                if (!int.TryParse(parts[1], out denominator))
                {
                    Console.WriteLine("{0} is not a integer.", parts[1]);
                    return;
                }
            }
            else denominator = 1;

            BigRational fraction = new BigRational(numerator, denominator);
            Fractions.Add(fraction);

            if (Fractions.Count == 2)
            {
                if (string.IsNullOrEmpty(Operator))
                {
                    Console.WriteLine();
                    Console.Write("Operators requires!");
                    return;
                }
                HereIsMagicCommand(Operator);
            }
        }

        public static void OperationCommand(string command)
        {
            if (command.Trim().Length != 1)
            {
                Console.WriteLine("Command not valid, operator requires a single char.");
                return;
            }
            if(command == "^")
            {
                Console.WriteLine("Set the power");
                power = int.Parse(Console.ReadLine());
                Operator = command;
                HereIsMagicCommand(power.ToString());
            }
            Operator = command;
        }

        public static void HereIsMagicCommand(string command)
        {
            BigRational br = new BigRational();
            if (Operator == "+") br = Fractions[0] + Fractions[1];
            if (Operator == "-") br = Fractions[0] - Fractions[1];
            if (Operator == "*") br = Fractions[0] * Fractions[1];
            if (Operator == "/") br = Fractions[0] / Fractions[1];            
            if (Operator == "^") br = BigRational.Pow(Fractions[0], power);           

            if(Operator == "^") Console.WriteLine("{0}{1}{2} = {3}", Fractions[0], Operator, power, br);
            else Console.WriteLine("{0} {1} {2} = {3}", Fractions[0], Operator, Fractions[1], br);

            Fractions.Clear();
            Fractions.Add(br);
        }
    }
}


