using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace _1.TwoSumNumber
{
    class Program
    {
        //static int[] numbers = { 3, -1, 11, 1, 5, 6, -4, 8 };
        //static int target = 10;

        static int[] numbers = CreateRandomNumberArray(2000000);
        static int target = 74230;

        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            CreateRandomNumberArray(200);
            sw.Start();
            Tuple<int, int> result = UseHasHTable();
            sw.Stop();
            Console.WriteLine($"Hashtable method : {result.Item1} + {result.Item2} = {target} (time take {sw.ElapsedTicks} ticks)");
            sw.Reset();

            sw.Start();
            Tuple<int, int> result2 = SortFirst();
            sw.Stop();
            Console.WriteLine($"Sort method      : {result2.Item1} + {result2.Item2} = {target} (time take {sw.ElapsedTicks} ticks)");
            sw.Reset();
            
            sw.Start();
            Tuple<int, int> result3 = DoubleLoop();
            sw.Stop();
            Console.WriteLine($"Double Loop      : {result3.Item1} + {result3.Item2} = {target} (time take {sw.ElapsedTicks} ticks)") ;
            sw.Reset();

            Console.ReadLine();
        }

        static Tuple<int, int> UseHasHTable()
        {

            // Time = O(N)
            // space = O(N)

            Dictionary<int, bool> numbersSet = new Dictionary<int, bool>();
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbersSet.ContainsKey(target - numbers[i]))
                {
                    return new Tuple<int, int>(target - numbers[i], numbers[i]);
                }
                else
                {
                    numbersSet.Add(numbers[i], true);
                }
            }

            return new Tuple<int, int>(1, 1);
        }

        static Tuple<int, int> SortFirst()
        {

            // Time =  O(n log( n)) 
            // Space = O(1)

            int[] sortedNumbers = (int[])numbers.Clone();
            Array.Sort(sortedNumbers);
            int leftPointer = 0;
            int rightPointer = sortedNumbers.Length - 1;

            while (leftPointer < rightPointer)
            {
                if (sortedNumbers[leftPointer] + sortedNumbers[rightPointer] == target)
                {
                    return new Tuple<int, int>(sortedNumbers[leftPointer], sortedNumbers[rightPointer]);
                }

                if (sortedNumbers[leftPointer] + sortedNumbers[rightPointer] < target)
                {
                    leftPointer++;
                }

                if (sortedNumbers[leftPointer] + sortedNumbers[rightPointer] > target)
                {
                    rightPointer--;
                }
            }

            return null;
        }

        static Tuple<int, int> DoubleLoop()
        {

            // Time = O(N^2)
            // Space = O(1)

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 0; j < numbers.Length; j++)
                {
                    if (j == i) { continue; }
                    if (numbers[i] + numbers[j] == target)
                    {
                        return new Tuple<int, int>(numbers[i], numbers[j]);
                    }
                }
            }
            return new Tuple<int, int>(1, 1);
        }

        static int[] CreateRandomNumberArray(int amountToCreate)
        {
            Random random = new Random();
            int[] output = new int[amountToCreate];

            for (int i = 0; i < amountToCreate; i++)
            {
                output[i] = random.Next(0, amountToCreate);
            }
            Console.WriteLine();

            return output.Distinct().ToArray();
        }
    }
}
