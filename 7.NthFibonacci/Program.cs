using System;
using System.Collections.Generic;

namespace _7.NthFibonacci
{
    class Program
    {
        static Dictionary<int, int> memory = new Dictionary<int, int>();
        static void Main(string[] args)
        {
            int numberToFind = 13;
            int result = NthFibonacciForLoop(numberToFind);
            
            memory.Add(1, 0);
            memory.Add(2, 1);

            Console.WriteLine($"The {numberToFind}th fibonacci number from for loop                : {result}");
            Console.WriteLine($"The {numberToFind}th fibonacci number from while loop              : {NthFibonacciWhileLoop(numberToFind)}");
            Console.WriteLine($"The {numberToFind}th fibonacci number from bad recursive method    : {NthFibonacciBadVersion(numberToFind)}");
            Console.WriteLine($"The {numberToFind}th fibonacci number from good recursive method   : {NthFibonacciGoodVersion(numberToFind)}");
            
            
        }

        public static int NthFibonacciBadVersion(int nthNumber)
        {
            // Makes multiple calls for the same calculation

            // Time -  O(2^N) multiple unessecary repeated calls made i.e NthFibonacci(3) would be called 3 or 4 times
            // Space - O(N) 
            
            if(nthNumber == 2)
            {
                return 1;
            }
            else if(nthNumber == 1)
            {
                return 0;
            }
            else
            {
                return NthFibonacciBadVersion(nthNumber - 1) + NthFibonacciBadVersion(nthNumber -2); 
            }
            
        }

        public static int NthFibonacciGoodVersion(int nthNumber)
        {
            // Stores each calculated number in a hastable to prevent recalculating, meaning it would be constant time on them.

            // Time -  O(N) Call for each nth number only happens once now as they are stored in a dictionary.
            // Space - O(N) 

            if (nthNumber == 2)
            {
                return 1;
            }
            else if (nthNumber == 1)
            {
                return 0;
            }
            else
            {
                if (memory.ContainsKey(nthNumber))
                {
                    return memory[nthNumber];
                }
                else
                {
                    memory.Add(nthNumber, NthFibonacciGoodVersion(nthNumber -1) + NthFibonacciGoodVersion(nthNumber -2));
                    return memory[nthNumber];
                }
            }

        }



        public static int NthFibonacciForLoop(int nthNumber)
        {

            // Time 0(N)
            // Space O(1)

            int prevNumber = 1;
            int olderNumber = 0;

            if (nthNumber == 1 || nthNumber == 0)
            {
                return 0;
            }
            if (nthNumber == 2)
            {
                return 1;
            }

            for (int i = 0; i < nthNumber; i++)
            {
                if(i > 2)
                {
                    int temp = olderNumber;
                    olderNumber = prevNumber;
                    prevNumber = temp + prevNumber;
                }
            }

            return prevNumber + olderNumber;
        }

        public static int NthFibonacciWhileLoop(int nthNumber)
        {
            int[] lastTwo = { 0, 1 };
            int counter = 3;
            int nextFib = 0;
            
            while(counter <= nthNumber)
            {
                nextFib = lastTwo[0] + lastTwo[1];
                lastTwo[0] = lastTwo[1];
                lastTwo[1] = nextFib;
                counter += 1;
            }

            
            return nthNumber > 1 ? nextFib : 0;
        }
    }
}
