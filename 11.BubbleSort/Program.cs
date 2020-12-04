using System;

namespace _11.BubbleSort
{
    class Program
    {
        static int[] testNumbers = { 8, 5, 2, 9, 5, 6, 3 };
        static int[] testNumbers2 = { 8, 5, 2, 9, 5, 6, 3 };

        static void Main(string[] args)
        {
            BubbleSort(testNumbers);
            BubbleSortAlgoExpoert(testNumbers2);

            Console.Write("The correct order from my method is : ");
            foreach (var number in testNumbers)
            {
                Console.Write($"{number} ");
            }

            Console.WriteLine();
            Console.Write("The correct order from algoexperts method is : ");
            foreach (var number in testNumbers2)
            {
                Console.Write($"{number} ");
            }

            Console.ReadLine();
        }

        public static int[] BubbleSort(int[] array) // My version before watching explanation video
        {
            // Time = O(N^2)
            // Space = O(1)
            bool sorted = false;
            int pointer = 0;
            int sortedElements = 0;

            if (array.Length == 1)
            {
                return array;
            }

            while (!sorted)
            {               

                if(pointer >= array.Length - 1 - sortedElements)
                {
                    pointer = 0;
                    sortedElements++;
                }
                if(array[pointer] > array[pointer+1])
                {
                    int temp = array[pointer + 1];
                    array[pointer + 1] = array[pointer];
                    array[pointer] = temp;
                    pointer++;
                }
                else
                {
                    pointer++;
                }
                if(sortedElements == array.Length)
                {
                    sorted = true;
                }
            }

            return array;
        }

        public static int[] BubbleSortAlgoExpoert(int[] array)
        {
            bool isSorted = false;
            int counter = 0;

            while (!isSorted)
            {
                isSorted = true;
                for (int i = 0; i < array.Length -1 - counter; i++)
                {
                    if(array[i] > array[i + 1])
                    {
                        Swap(i, i + 1, array);
                        isSorted = false;
                    }
                }
                counter++;
            }

            return array;
        }

        private static void Swap(int i, int j, int[] array)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
