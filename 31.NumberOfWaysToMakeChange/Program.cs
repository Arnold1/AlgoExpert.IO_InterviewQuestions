using System;

namespace _31.NumberOfWaysToMakeChange
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int n = 6;
            int[] denoms = new int[] { 1, 5 };
            Console.WriteLine($"The number of ways is { NumberOfWaysToMakeChange(n, denoms) }");
            Console.ReadLine();

        }

        public static int NumberOfWaysToMakeChange(int n, int[] denoms)
        {
            int[] ways = new int[n + 1];
            ways[0] = 1;
            for (int i = 0; i < denoms.Length; i++)
            {
                for (int j = 1; j < ways.Length; j++)
                {
                    if (denoms[i] <= j)
                    {
                        ways[j] += ways[j - denoms[i]];
                    }
                }
            }
            return ways[n];
        }
    }
}

// dynamic programming

// ways[] -  1 0 0 0 0 0 0 0 0 0 0
//           0 1 2 3 4 5 6 7 8 9 10
