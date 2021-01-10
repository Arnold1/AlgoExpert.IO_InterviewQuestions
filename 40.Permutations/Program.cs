using System;
using System.Collections.Generic;

namespace _40.Permutations
{
    class Program
    {
        static void Main(string[] args)
        {
            // Time - O(n*n!)
            // Space - O(n*n!)
            List<int> array = new List<int> { 1, 2, 3, };
            List<List<int>> permutations = new List<List<int>>();
            GetPermuations(0, array, permutations);
            Console.WriteLine("Hello World!");
        }

        public static void GetPermuations(int i, List<int> array, List<List<int>> permutations)
        {
            if(i == array.Count - 1)
            {
                permutations.Add(new List<int>(array));
            }
            else
            {
                for (int j = i; j < array.Count; j++)
                {
                    Swap(array, i, j);
                    GetPermuations(i + 1, array, permutations);
                    Swap(array, i, j);
                }
            }
        }
        public static void Swap(List<int> array, int i, int j)
        {
            int tmp = array[i];
            array[i] = array[j];
            array[j] = tmp;
        }
    }
}
