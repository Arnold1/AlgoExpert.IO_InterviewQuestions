using System;

namespace _14.PalindromeCheck
{
    class Program
    {
        static string str = "abcdcba";
        static void Main(string[] args)
        {
            Console.WriteLine($"My method says : { IsPalindrome(str)} ");
            Console.WriteLine($"Expert recursion method says : {IsPalindromeRecursion(str, 0)}");
            Console.ReadKey();
        }

        public static bool IsPalindrome(string str)
        {
            // My solution before watching explanation

            // Time - O(N)
            // Space O(1)

            int leftPointer = 0;
            int rightPointer = str.Length-1;

            while (leftPointer < rightPointer)
            {
                if (str[leftPointer] != str[rightPointer])
                {
                    return false;
                }
                else
                {
                    leftPointer++;
                    rightPointer--;
                }
            }
            return true; 
        }

        public static bool IsPalindromeRecursion(string str, int i)
        {
            // Time - O(N)
            // Space - O(N)

            int j = str.Length - 1 - i;
            return i >= j ? true : str[i] == str[j] && IsPalindromeRecursion(str, i + 1);
        }
    }
}
