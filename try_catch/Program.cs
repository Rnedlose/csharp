using System;   
using System.Net.Mail;

namespace try_catch
{
    class Program
    {
        static void Main()
        {
            int a, b, c;
            string firstNum;
            string secondNum;
            string choice;
      
            try
            {
                Console.WriteLine("Let's try some math problems, then add them to an array.");
                Console.WriteLine("Enter two numbers, and then choose operator.");
                Console.WriteLine("\n\n");

                            
                Console.Write("Enter first number: ");
                a = int.Parse(firstNum = Console.ReadLine());
                Console.WriteLine("\n\n");

                Console.Write("Enter the second number: ");
                b = int.Parse(secondNum = Console.ReadLine());
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
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Cannot divide by zero.");
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Invalid.");
                Console.WriteLine(ex.Message);
            }catch (InvalidChoiceException ex) 
            {
                Console.WriteLine("Not a valid choice.");
                Console.WriteLine(ex.Message);
            }
            try
            {
                Console.WriteLine("Choose a number 1-9 to see that index in an array.");
                int[] nums = {14,26,32,49,51,67,79,84,96};
                int num;

                num = int.Parse(Console.ReadLine());

                Console.WriteLine("The number at index " + num + " is: " + nums[num]);                  
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("That index is out of bounds.");
                Console.WriteLine(ex.Message);
            }
            catch (InvalidChoiceException ex)
            {
                Console.WriteLine("Not a valid choice.");
                Console.WriteLine(ex.Message);
            }
            try
            {
                Console.WriteLine("Emails must be in format: username@host.*** ");
                Console.Write("Enter an email address to validate: ");
                string emailAddress = Console.ReadLine();
                MailAddress testEmail = new MailAddress(emailAddress);
                Console.WriteLine("Email Validated!");
            }
            catch(ArgumentNullException ex)
            {
                Console.WriteLine("Address is null!: " + ex.Message + "\n");
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine("Address is empty!: " + ex.Message + "\n");
            }
            catch(FormatException ex)
            {
                Console.WriteLine("The address is not in the correct format!: " + ex.Message + "\n");
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
