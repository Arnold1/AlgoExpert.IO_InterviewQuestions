using System;
using System.Linq;

namespace _23.ArrayOfProducts
{
    class Program
    {
        static int[] array = new int[] { 5, 1, 4, 2 };
        //static int[] array = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        static void Main(string[] args)
        {
            int[] result1 = ArrayOfProductsMyNiaveWay(array); // Nested for loops O(N^2) Time
            int[] result2 = ArrayOfProductTwoExtraArrays(array); // Optimal Time of O(N) and space O(N)
            int[] result3 = ArrayOfProductOptimal(array); // Even better as it doesnt create two extra arrays
        }

        private static int[] ArrayOfProductsMyNiaveWay(int[] array)
        {
            // Time - O(N^2)
            // Space - O(N)

            int[] results = new int[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                int productSum = 1;

                for (int j = 0; j < array.Length; j++)
                {                        
                    if (i != j)
                    {
                        productSum = productSum * array[j];                 
                    }
                    results[i] = productSum;
                }
            }

            return results;
        }

        public static int[] ArrayOfProductTwoExtraArrays(int[] array)
        {

            // Time - O(N) 3N reduces to N
            // Space - O(N)
            int[] results = new int[array.Length];
            int[] leftProducts = new int[array.Length];
            int[] rightProducts = Enumerable.Repeat(1, array.Length).ToArray();

            int leftRunningProduct = 1;
            for (int i = 0; i < array.Length; i++)
            {
                leftProducts[i] = leftRunningProduct;
                leftRunningProduct *= array[i];
            }

            int rightRunningProduct = 1;
            for (int i = array.Length-1; i >= 0; i--)
            {
                rightProducts[i] = rightRunningProduct;
                rightRunningProduct *= array[i];
            }

            for (int i = 0; i < results.Length; i++)
            {
                results[i] = leftProducts[i] * rightProducts[i];
            }

            return results;
        }

        public static int[] ArrayOfProductOptimal(int[] array)
        {

            // Time - O(N) 3N reduces to N
            // Space - O(N)
            int[] results = new int[array.Length];
            
            int leftRunningProduct = 1;
            for (int i = 0; i < array.Length; i++)
            {
                results[i] = leftRunningProduct;
                leftRunningProduct *= array[i];
            }

            int rightRunningProduct = 1;
            for (int i = array.Length - 1; i >= 0; i--)
            {
                results[i] *= rightRunningProduct;
                rightRunningProduct *= array[i];
            }

            return results;
        }
    }
}
