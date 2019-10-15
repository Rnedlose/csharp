using System;

namespace try_catch
{
    class Program
    {
        static void Main()
        {
            double a;
            double b;
            double c;

            string firstNum;
            string secondNum;
            string choice;

            try
            {
                Console.WriteLine("Let's try a math problem.");
                Console.WriteLine("Enter two numbers, and then choose operator.");
                Console.WriteLine("\n\n");

                               
                Console.Write("Enter first number: ");
                a = double.Parse(firstNum = Console.ReadLine());
                Console.WriteLine("\n\n");

                Console.Write("Enter the second number: ");
                b = double.Parse(secondNum = Console.ReadLine());
                Console.WriteLine("\n\n");
                
                Console.WriteLine("Now choose operator from below list.");
                Console.WriteLine("\n\n");

                Console.WriteLine("1. Addition + ");
                Console.WriteLine("2. Subtraction - ");
                Console.WriteLine("3. Multiplication * ");
                Console.WriteLine("4. Division / ");
                Console.WriteLine("\n\n");

                choice = Console.ReadLine();
                Console.WriteLine("\n\n");

                if (choice == "1")
                {
                    c = a + b;
                    Console.WriteLine("Answer is " + c);
                }
                else if (choice == "2")
                {
                    c = a - b;
                    Console.WriteLine("Answer is " + c);
                }
                else if (choice == "3")
                {
                    c = a * b;
                    Console.WriteLine("Answer is " + c);
                }
                else if (choice == "4")
                {
                    c = a / b;
                    Console.WriteLine("Answer is " + c);
                }
                else
                {
                    throw new InvalidChoiceException(choice);
                }
            }
            catch (ArithmeticException ex)
            {
                Console.WriteLine("Aritmetic Exception.");
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Invalid.");
                Console.WriteLine(ex.Message);
            }
        }
    

        public class InvalidChoiceException : Exception
        {
            public InvalidChoiceException()
            {

            }

            public InvalidChoiceException (string message)
                : base(message)
            {

            }

            public InvalidChoiceException (string message, Exception inner)
                : base(message, inner)
            {

            }
        }
    }
}
