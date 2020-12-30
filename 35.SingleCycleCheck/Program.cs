using System;

namespace _35.SingleCycleCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static bool hasSingleCycle(int[] array)
        {
            // Time O(n)
            // Space O(1)

            int numElementsVisited = 0;
            int currentIdx = 0;

            while(numElementsVisited < array.Length)
            {
                if(numElementsVisited > 0 && currentIdx == 0)
                {
                    return false;
                }

                numElementsVisited++;
                currentIdx = getNextIdx(currentIdx, array);
            }             
            return currentIdx == 0;
        }

        private static int getNextIdx(int currentIdx, int[] array)
        {
            int jump = array[currentIdx];
            int nextIdx = (currentIdx + jump) % array.Length;
            return nextIdx >= 0 ? nextIdx : nextIdx + array.Length;
        }
    }
}
