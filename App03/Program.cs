using System;

namespace App03
{
    class Program
    {
        static void Main(string[] args)
        {
            int[]  Nums = {2,5,23,98,100,456,23};

            foreach (int i in Nums)
            {
                Console.Write("The array element is: ");
                Console.WriteLine(i);
            }
            Console.WriteLine("The total sum of all the array elements is: " + SumOfArray(Nums));
        }
        static int SumOfArray(int[] Arr)
        {
            int Total = 0;
            foreach (int i in Arr)
            {
                Total += i;
            }
            return Total;
        }
    }
}
