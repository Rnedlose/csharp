using System;

class App01
{
    static void Main(string[] args)
    {
        Greeting();
    }
    static void Greeting(){
                string str01;
        do {
            Console.WriteLine("Please enter a name: ");
            str01 = Console.ReadLine();
            if (str01 == "") {
                Console.WriteLine("See you next time!");
            }else
                Console.WriteLine("Hello, " + str01);
        }while (str01 != "");
    }
}
