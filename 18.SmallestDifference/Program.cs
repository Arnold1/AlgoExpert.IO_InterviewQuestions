using System;
using System.Linq;

namespace _18.SmallestDifference
{
    class Program
    {
        static int[] array1 = { -1, 5, 10, 20, 28, 3 };
        static int[] array2 = { 26, 134, 135, 15, 17 };

        //static int[] array1 = { -1, 5, 10, 20, 3 };
        //static int[] array2 = { 26, 134, 135, 15, 17 };

        //static int[] array1 = { 10, 0, 20, 25, 2000 };
        //static int[] array2 = { 1005, 1006, 1014, 1032, 1031 };
       

    static void Main(string[] args)
        {
            SmallestDifferenceMyMethod(array1, array2);
            SmallestDifferenceExpertsVersion(array1, array2);
            Console.WriteLine("Hello World!");
        }

        static int[] SmallestDifferenceMyMethod(int[] arrayOne, int[] arrayTwo)
        {
            int[] smallest = new int[] { arrayOne[0], arrayTwo[0] };
            int smallestDifference = GetDifference(smallest);

            for (int i = 0; i < arrayOne.Length; i++)
            {
                for (int j = 0; j < arrayTwo.Length; j++)
                {
                    if (arrayOne[i] == 20) { 
                        Console.WriteLine(); 
                    }
                    if(GetDifference(new[] { arrayOne[i], arrayTwo[j] }) < smallestDifference){
                        smallest[0] = arrayOne[i];
                        smallest[1] = arrayTwo[j];
                        smallestDifference = GetDifference(smallest);
                    }
                }
            }
            return smallest;
        }

        public static int GetDifference(int[] nums)
        {
            int[] numbers = new[] { nums[0], nums[1] };
            Array.Sort(numbers);
            return numbers[1] - numbers[0];
        }

        static int[] SmallestDifferenceExpertsVersion(int[] arrayOne, int[] arrayTwo)
        {
            // Time - O(Nlog(N) + MLog(M))
            // Space - O(1)

            Array.Sort(arrayOne);
            Array.Sort(arrayTwo);
            int arrayOnePointer = 0;
            int arrayTwoPointer = 0;
            int current = int.MaxValue;
            int SmallestDiff = int.MaxValue;
            int[] smallest = new int[2];

            while (arrayOnePointer < arrayOne.Length && arrayTwoPointer < arrayTwo.Length)
            {
                int firstNum = arrayOne[arrayOnePointer];
                int secondNum = arrayTwo[arrayTwoPointer];

                if(firstNum < secondNum)
                {
                    current = secondNum - firstNum;
                    arrayOnePointer++;
                }
                else if(firstNum > secondNum)
                {
                    current = firstNum - secondNum;
                    arrayTwoPointer++;
                }
                else 
                {
                    return new[] { firstNum, secondNum };
                }

                if(SmallestDiff > current)
                {
                    SmallestDiff = current;
                    smallest = new[] { firstNum, secondNum };
                }
                
            }

            return smallest;
        }
    }
}
