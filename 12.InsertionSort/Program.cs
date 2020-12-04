using System;

namespace _12.InsertionSort
{
    class Program
    {
        static int[] testNumbers = { 8, 5, 2, 9, 5, 6, 3 };
        static void Main(string[] args)
        {
            // Time = O(N^2)
            // Space = O(1) - Changing array in place not using any extra memory
            InsertionSort(testNumbers);
            Console.WriteLine("Hello World!");
        }

        public static int[] InsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int j = i;

                while(j > 0 && array[j] < array[j - 1])
                {
                    Swap(j, j - 1, array);
                    j--;
                }
            }
            return array;
        }

        public static void Swap(int j, int i, int[] array)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
