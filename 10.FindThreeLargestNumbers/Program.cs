using System;

namespace _10.FindThreeLargestNumbers
{
    class Program
    {
        static int[] arrayNums = { 141, 1, 17, -7, -17, -27, 18, 541, 8, 7, 7 };
        

        static void Main(string[] args)
        {
            int[] largestNumbers = { int.MinValue, int.MinValue, int.MinValue };
            int[] threeLargest = { int.MinValue, int.MinValue, int.MinValue };

            foreach (var number in arrayNums)
            {
                InsertIntoArray(largestNumbers, number); // My Method created before watching explanation video
                UpdateLargest(threeLargest, number); // Algoexperts version (Much cleaner approach)
            }
            PrintArray(largestNumbers, "Mike's");
            Console.WriteLine();
            PrintArray(threeLargest, "AlgoExperts");
            Console.WriteLine();
            
        }

        public static void PrintArray(int[] array, string methodName)
        {
            Console.Write($"The three largest numbers in the array from {methodName} are : ");
            foreach (var number in array)
            {
                Console.Write($"{number} ");
            }
        }

        public static int[] InsertIntoArray(int[] array, int number)
        {
            // My solution before watching video
            // Time - O(N)
            // SPACE - O(1)

            for (int i = 2; i >= 0; i--)
            {
                if(number > array[i])
                {                    
                    if(i == 0)
                    {
                        array[i] = number;
                        return array;
                    }
                    else if(i == 1)
                    {
                        int temp = array[i];
                        array[i] = number;
                        array[i -1] = temp;
                        return array;
                    }
                    else if(i == 2)
                    {
                        int temp = array[i];
                        int temp2 = array[i - 1];
                        array[i] = number;
                        array[i - 1] = temp;
                        array[i - 2] = temp2;
                        return array;
                    }
                    
                }
                
            }

            return array;
        }

        public static void UpdateLargest(int[] threeLargest, int num)
        {
            if(num > threeLargest[2])
            {
                ShiftAndUpdate(threeLargest, num, 2);
            }
            else if(num > threeLargest[1])
            {
                ShiftAndUpdate(threeLargest, num, 1);
            }
            else if(num > threeLargest[0])
            {
                ShiftAndUpdate(threeLargest, num, 0);
            }
        }

        private static void ShiftAndUpdate(int[] array, int num, int index)
        {
            for (int i = 0; i <= index; i++)
            {
                if (i == index)
                {
                    array[i] = num;
                }
                else
                {
                    array[i] = array[i + 1];
                }
            }
        }
    }
}
