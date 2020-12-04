using System;

namespace _13.SelectionSort
{
    class Program
    {
        static int[] testNumbers = { 8, 5, 2, 9, 5, 6, 3 };
        static int[] testNumbers2 = { 8, 5, 2, 9, 5, 6, 3 };
        static void Main(string[] args)
        {
            SelectionSortMyVersion(testNumbers);
            SelectionSortAlgoExpertVersion(testNumbers2);
            Console.Write("Sorted array from my method : ");
            foreach (var number in testNumbers)
            {
                Console.Write($"{number} ");
            }
            Console.WriteLine();

            Console.Write("Sorted array from AlgoExperts method : ");
            foreach (var number in testNumbers2)
            {
                Console.Write($"{number} ");
            }

            Console.ReadLine();
        }

        private static void SelectionSortMyVersion(int[] array)
        {
            // Time - O(N^2)  - Because we loop through multiple times
            // Space - O(1) - No extra space needed, just modyfing original array

            int sortedArraySize = 0;
            while (sortedArraySize < testNumbers.Length)
            {
                Swap(FindSmallestIndex(testNumbers, sortedArraySize), sortedArraySize, testNumbers);
                sortedArraySize++;
            }
        }

        public static void Swap(int currentSmallestIdx, int sortedArraySize, int[] array)
        {
            int temp = array[currentSmallestIdx];
            array[currentSmallestIdx] = array[sortedArraySize];
            array[sortedArraySize] = temp;

        }

        public static int FindSmallestIndex(int[] array, int startPos)
        {
            int indexOfSmallest = startPos;
            int currentSmallestNum = array[startPos];

            for (int i = startPos; i < array.Length; i++)
            {
                if(array[i] < currentSmallestNum)
                {
                    indexOfSmallest = i;
                    currentSmallestNum = array[i];
                }
            }

            return indexOfSmallest;
        }

        public static void SelectionSortAlgoExpertVersion(int[] array)
        {
            int currentIdx = 0;
            while (currentIdx < array.Length - 1)
            {
                int smallestIdx = currentIdx;
                for (int i = currentIdx + 1; i < array.Length; i++)
                {
                    if(array[smallestIdx] > array[i])
                    {
                        smallestIdx = i;
                    }
                }

                Swap(currentIdx, smallestIdx, array);
                currentIdx++;
            }
        }
    }
}
