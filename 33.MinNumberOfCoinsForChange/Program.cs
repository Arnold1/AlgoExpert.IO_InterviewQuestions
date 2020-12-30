using System;

namespace _33.MinNumberOfCoinsForChange
{
    class Program
    {
        static void Main(string[] args)
        {
            int TotalAmount = 10;
            int[] denoms = { 1, 3, 4 };
            MinNumberOfCoinsForChange(TotalAmount, denoms);
            MinNumberOfCoinsForChangeExpert(TotalAmount, denoms);
            Console.Read();
        }

        public static int MinNumberOfCoinsForChangeExpert(int n, int[] denoms)
        {
            // Time - O(nm)
            // Space = O(n)

            int[] nums = new int[n + 1];
            Array.Fill(nums, int.MaxValue);
            nums[0] = 0;
            int toCompare = 0;
            foreach (var number in denoms)
            {
                for (int i = 1; i < nums.Length; i++)
                {
                    if(number <= i)
                    {
                        if(nums[i - number] == int.MaxValue)
                        {
                            toCompare = nums[i - number];
                        }
                        else
                        {
                            toCompare = nums[i - number] + 1;
                        }
                        nums[i] = Math.Min(nums[i], toCompare);
                    }
                    
                }
            }
            return nums[n] != int.MaxValue ? nums[n] : -1;
        }
        public static int MinNumberOfCoinsForChange(int n, int[] denoms)
        {
            // Attempt - Fails on last two test cases but passes all others.

            Array.Sort(denoms);
            int leftToFind = n;
            int pointer = denoms.Length - 1;
            int coinsUsed = 0;
            int failedLoop = 0;
            int minCoins = int.MaxValue;

            while (leftToFind > 0)
            {
                if(denoms[pointer] <= leftToFind)
                {
                    coinsUsed++;                    
                    leftToFind -= denoms[pointer];
                }
                else
                {
                    pointer--;
                }

                if (pointer < 0 && leftToFind > 0)
                {
                    coinsUsed = 0;
                    leftToFind = n;
                    failedLoop++;
                    pointer = denoms.Length - 1 - failedLoop;
                }

                if(failedLoop > denoms.Length - 1)
                {
                    return -1;
                }

                if (leftToFind == 0)
                {
                    minCoins = coinsUsed < minCoins ? coinsUsed : minCoins;
                }

            }

            return coinsUsed;
        }

        public static int CheckEachnum(int[] nums, int target)
        {
            int output = int.MaxValue;

            foreach (var number in nums)
            {
                if(target % number == 0)
                {
                    int coinsUsed = target / number;
                    output = coinsUsed < output ? coinsUsed : output;
                }
            }

            return output;
        }

    }
}