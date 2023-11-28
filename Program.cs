using Calculator.Core;
using System;

namespace ConsoleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            RunCalculator();
        }

        private static void RunCalculator()
        {
            bool calculate = true;

            while (calculate)
            {
                decimal number1 = GetUserInputDecimal("Enter the first number: ");

                Console.WriteLine("Choose *, /, + or -");
                char Operator = GetOperatorInput();

                decimal number2 = GetUserInputDecimal("Enter the second number: ");

                CalculateAndDisplayResult(number1, number2, Operator);

                calculate = ShouldContinueCalculation();
            }

            Console.WriteLine("Exiting the calculator...");

        }

        private static decimal GetUserInputDecimal(string questionText)
        {
            decimal inputValue;

            do
            {
                Console.WriteLine(questionText);
                string inputUser = Console.ReadLine();

                if (string.IsNullOrEmpty(inputUser))
                {
                    Console.WriteLine("You must enter a number.");
                    Console.WriteLine();
                }
                else
                {
                    if (decimal.TryParse(inputUser, out inputValue))
                    {
                        if (HasMoreThanTwoDecimals(inputUser))
                        {
                            Console.WriteLine("You can only enter up to 2 decimal places.");
                            Console.WriteLine();
                            continue;
                        }

                        return inputValue;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                        Console.WriteLine();
                    }
                }
            } while (true);
        }

        private static bool HasMoreThanTwoDecimals(string inputUser)
        {
            int decimalLength = inputUser.IndexOfAny(new char[] { '.', ',' });
            return decimalLength != -1 && inputUser.Substring(decimalLength + 1).Length > 2;
        }

        private static char GetOperatorInput()
        {
            char[] validOperators = { '*', '/', '+', '-' };
            char Operator;

            while (true)
            {
                string input = Console.ReadLine();

                if (input.Length == 1 && validOperators.Contains(input[0]))
                {
                    Operator = input[0];
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid operator. Please enter *, /, + or -");
                }
            }

            return Operator;
        }

        private static void CalculateAndDisplayResult(decimal number1, decimal number2, char Operator)
        {
            CalculateService calculator = new CalculateService();
            var calculatedResult = calculator.PerformCalculation(number1, number2, Operator);

            if (!calculatedResult.IsCalculated)
            {
                Console.WriteLine(calculatedResult.Error);
            }
            else
            {
                Console.WriteLine("Result: " + calculatedResult.CalculatedResult);
            }
        }

        private static bool ShouldContinueCalculation()
        {
            Console.WriteLine("To calculate again, press 'y'. To exit, press 'n'");
            string confirmation = Console.ReadLine().ToLower();

            if (confirmation == "y")
            {
                return true;
            }
            else if (confirmation == "n")
            {
                Console.WriteLine("Exiting the calculator...");
                return false;
            }
            else
            {
                Console.WriteLine("Invalid input. Exiting...");
                Environment.Exit(0);
                return false;
            }
        }
    }
}
