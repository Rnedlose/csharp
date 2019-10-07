using System;
using System.Net.Mail;

// Program Validates Emails are in the correct format of either user@host.XXX or user@host
// Program also Validates that passwords follow the constraints listed.

namespace Mod02Lab01
{
    class Program
    {
        static void Main(string[] args)
        {
            // Variables needed
            string choice;
            string emailAddress;
            string password;

            // Do While loop for menu selection
            do
            {   
                // Menu
                Console.WriteLine("\t 1. Validate Email Address");
                Console.WriteLine("\t 2. Validate Password");
                Console.WriteLine("\t 3. Exit Program.");

                Console.WriteLine("\t Please only enter 1, 2, or 3.");

                // Get user input for choice
                choice = Console.ReadLine();

                // If statement based on user choice

                // First option for validating email
                if (choice == "1")
                {
                    Console.WriteLine("\t Emails must be in format: username@host.*** ");
                    Console.Write("\t Enter an email address to validate: ");
                    emailAddress = Console.ReadLine();

                    // Attempts to validate that email is in correct format
                    try
                    {
                        MailAddress testEmail = new MailAddress(emailAddress);
                        Console.WriteLine("Email Validated!");
                    }
                    catch(ArgumentNullException ex)
                    {
                        Console.WriteLine("\n\t Address is null!: " + ex.Message + "\n");
                    }
                    catch(ArgumentException ex)
                    {
                        Console.WriteLine("\n\t Address is empty!: " + ex.Message + "\n");
                    }
                    catch(FormatException ex)
                    {
                        Console.WriteLine("\n\t The address is not in the correct format!: " + ex.Message + "\n");
                    }
                }

                // Second option for validating passwords
                else if (choice == "2")
                {
                    Console.WriteLine("\t Password must contain at least 10 characters,");
                    Console.WriteLine("\t 1 uppercase letter, 1 lowercase letter, 1 digit between 1-20,");
                    Console.WriteLine("\t and no quotes or semicolons.");
                    Console.Write("\t Enter in a password to validate: ");
                    password = Console.ReadLine();

                    // Uses @ValPassword function to determine if password meets constraints
                    if (ValPassword(password)) Console.WriteLine("Password is validated.");                    
                    else Console.WriteLine("Invalid Password.");                    
                }

            } while (choice != "3");            
        }
        // Password validation function.  Takes in a string, returns a bool.
        static bool ValPassword(string password)
        {
            // Length constraint for password validation
            const int MIN_LENGTH = 10;

            if (password == null) throw new ArgumentNullException();

            // Constraints.  Bools used to determine if constraint met
            bool meetsLengthRequirements = false;
            bool hasUpperCaseLetter = false;
            bool hasLowerCaseLetter = false;
            bool hasDecimalDigit = false;
            bool hasQuoteOrSemicolon = false;

            // Bool is true only if all constraints met
            bool isValid = false;

            // Checking constraints
            if (password.Length >= MIN_LENGTH) meetsLengthRequirements = true;            

            foreach (char c in password)
            {
                if (char.IsUpper(c)) hasUpperCaseLetter = true;                
                else if (char.IsLower(c)) hasLowerCaseLetter = true;                
                else if (char.IsDigit(c)) hasDecimalDigit = true;                
                else if (c == ';' || c == '"') hasQuoteOrSemicolon = true;                
            }

            // Checking if all constraints met
            if(meetsLengthRequirements && hasUpperCaseLetter && hasLowerCaseLetter && hasDecimalDigit && !hasQuoteOrSemicolon) isValid = true;                     
            
            // @Return true if all constraints met, else return false
            if (isValid) return true;
            else return false;            
        }
    }
}
