using System;
using System.Collections.Generic;

namespace _17.ThreeNumberSum
{
	class Program
	{
		static int[] array = new int[] { 12, 3, 1, 2, -6, 5, -8, 6 };
		static int target = 0;

        static void Main(string[] args)
        {
			List<int[]> result = ThreeNumberSum(array, target);
            foreach (var array in result)
            {
                foreach (var number in array)
                {
                    Console.Write(number + " ");
                }
				Console.Write($" = {target}");
                Console.WriteLine();
            }
            Console.ReadLine();
        }

		public static List<int[]> ThreeNumberSum(int[] array, int targetSum)
		{

			// Time - O(n^2)
			// Space - O(N)

			Array.Sort(array);
			List<int[]> output = new List<int[]>();

			for (int i = 0; i < array.Length - 2; i++)
			{
				int left = i + 1;
				int right = array.Length - 1;

				while (left < right)
				{
					int currentSum = array[i] + array[left] + array[right];
					if (currentSum == targetSum)
					{
						output.Add(new int[] { array[i], array[left], array[right] });
						left++;
						right--;
					}
					else if (currentSum > targetSum)
					{
						right--;
					}
					else if (currentSum < targetSum)
					{
						left++;
					}
				}
			}
			return output;
		}
	}
}
