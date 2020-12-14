using System;

namespace _29.MaxSubsetSumNoAdjacent
{
    class Program
    {
        static void Main(string[] args)
        {
			int[] testNumbers = new int[] { 75, 105, 120, 75, 90, 135 };
			int result = MaxSubsetSumNoAdjacent(testNumbers);

            Console.WriteLine($"The result is : {result}");
			Console.ReadLine();
        }

		public static int MaxSubsetSumNoAdjacent(int[] array)
		{
			// Time - O(n)
			// Space - O(n)

			if (array.Length == 0)
			{
				return 0;
			}
			else if (array.Length == 1)
			{
				return array[0];
			}
			int[] newArray = new int[array.Length];
			newArray[0] = array[0];
			newArray[1] = Math.Max(array[0], array[1]);
			for (int i = 2; i < array.Length; i++)
			{
				newArray[i] = Math.Max(newArray[i - 1], newArray[i - 2] + array[i]);
			}

			return newArray[newArray.Length - 1];
		}
	}
}
