using System;

class App02
{
    enum WeekDays
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Days of the Week: ");
        foreach (var item in Enum.GetNames(typeof(WeekDays))) {
            Console.WriteLine(item);
        }

    }
}
