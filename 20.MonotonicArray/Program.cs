using System;

namespace _20.MonotonicArray
{
    class Program
    {
        static int[] array = { -1, -5, -10, -1100, -1100, -1101, -1102, -9001 };
        //static int[] array = { -1, -1, -2, -3, -4, -5, -5, -5, -6, -7, -8, -8, -9, -10, -11 };
        //static int[] array = { -1, -1, -1, -1, -1, -1, -1, -1 };
        static void Main(string[] args)
        {
            Console.WriteLine($"From my method array is monotonic : {IsMonotonicMyVersion(array)}");
            Console.WriteLine($"From expert method array is monotonic : {IsMonotonicExpertVersion(array)}");
            Console.ReadLine();
        }

        public static bool IsMonotonicExpertVersion(int[] array)
        {
            bool isNonDecreasing = true;
            bool isNonIncreasing = true;

            for (int i = 1; i < array.Length; i++)
            {
                if(array[i] < array[i - 1]) { 
                    isNonDecreasing = false; 
                }

                if(array[i] > array[i - 1])
                {
                    isNonIncreasing = false;
                }
            }

            return isNonDecreasing || isNonIncreasing;
        }

        public static bool IsMonotonicMyVersion(int[] array)
        {

            // Time O(N)
            // Space O(1)

            var direction = array[1] - array[0];

            if(array.Length <= 1)
            {
                return true;
            }
            
            if(IsDownwards(array))
            {
                for (int i = 1; i < array.Length; i++)
                {
                    if(array[i] > array[i - 1]) 
                    {
                        return false;
                    }
                }
            }
            else
            {
                for (int i = 1; i < array.Length; i++)
                {
                    if (array[i] < array[i - 1])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static bool IsDownwards(int[] array)
        {
            int pointer = 0;
            int num1 = array[pointer];
            int num2 = array[pointer + 1];
            
            while(num1 == num2)
            {
                pointer++;
                if(pointer == array.Length - 1)
                {
                    return true;
                }
                num1 = array[pointer];
                num2 = array[pointer + 1];
            }
            if(num2 < num1)
            {
                return true;
            }

            return false;
        }
    }
}
