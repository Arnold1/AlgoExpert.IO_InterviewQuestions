using System;
using System.Linq;

namespace _34.KadanesAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 3, 5, -9, 1, 3, -2, 3, 4, 7, 2, -9, 6, 3, 1, -5, 4 };
            //int[] array = { -2, 1 };

            int result = KadanesAlgorithmMyAttempt(array); 
            int result2 = KadanesAlgorithmExpertVersion(array);
            Console.WriteLine("Hello World!");
        }

        public static int KadanesAlgorithmMyAttempt(int[] array)
        {
            // doesn't work on final few tests the rest are fine.
            int[] totals = new int[array.Length];
            totals[0] = array[0];
            bool newSubArray = false;
            int pointer = 1;
            int max = int.MinValue;

            while(pointer < array.Length) 
            {
                if (newSubArray)
                {
                    totals[pointer] = array[pointer];
                    newSubArray = false;
                    pointer++;
                    continue;
                }
                
                totals[pointer] = totals[pointer-1] + array[pointer];
                
                
                if(totals[pointer] < 0 ) //totals[pointer - 1] 
                {                    
                    newSubArray = true;
                    
                }

                pointer++;
            }

            return GetLargetsNum(totals);
        }

        public static int KadanesAlgorithmExpertVersion(int[] array)
        {
            // Space O(n)
            // Time O(1)
            int maxEndingHere = array[0];
            int maxSoFar = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                int num = array[i];
                maxEndingHere = Math.Max(num, maxEndingHere + num);
                maxSoFar = Math.Max(maxSoFar, maxEndingHere);
            }

            return maxSoFar;
        }

        
        public static int GetLargetsNum(int[] array)
        {
            int max = int.MinValue;
            foreach (var number in array)
            {
                max = Math.Max(max, number);
            }

            return max;
        }
    }
}
