using System;
using System.Collections.Generic;

namespace _2.Validate_Subsequence
{
    class Program
    {
        //static List<int> array = new List<int> { 5, 1, 22, 25, 6, -1, 8, 10 };
        //static List<int> sequence = new List<int> { 1, 6, -1, 10 };

        static List<int> array = new List<int> { 5, 1, 22, 25, 6, -1, 8, 10 };
        static List<int> sequence = new List<int> { 5, 1, 22, 22, 25, 6, -1, 8, 10 };

   
        static void Main(string[] args)
        {
            Console.WriteLine(IsValidSubsequence(array, sequence));
            Console.ReadLine();
        }

        static bool IsValidSubsequence(List<int> array, List<int> sequence)
        {
            int arrayPointer = 0;
            int numbersFound = 0;

            foreach (var number in sequence)
            {
                while(arrayPointer <= array.Count-1)
                {
                    if(array[arrayPointer] != number)
                    {
                        arrayPointer++;
                    }
                    else
                    {
                        arrayPointer++;
                        numbersFound++;
                        break;
                    }
                }
            }
            return numbersFound == sequence.Count;
        }
    }
}
