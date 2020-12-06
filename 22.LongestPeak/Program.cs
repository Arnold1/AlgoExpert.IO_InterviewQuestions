using System;
using System.Collections.Generic;

namespace _22.LongestPeak
{
    class Program
    {
        //static public int[] array = { 1, 2, 3, 3, 4, 0, 10, 6, 5, -1, -3, 2, 3 };
        static public int[] array = { 1, 3, 2 };

        static void Main(string[] args)
        {
            FindLongestPeak(array);
        }

        private static void FindLongestPeak(int[] array)
        {
            List<int> peaks = GetPeakPositions(array);
            int biggest = GetLongestPeak(array, peaks);

            int biggest2 = FindLongestExpertMethod(array);
            Console.WriteLine();
        }

        public static int FindLongestExpertMethod(int[] array)
        {
            int longestLength = 0;
            int i = 1;
            while(i < array.Length - 1)
            {
                bool isPeak = array[i-1] < array[i] && array[i] > array[i + 1];
                if (!isPeak)
                {
                    i++;
                    continue;
                }

                int leftIdx = i - 2;
                while(leftIdx >=0 && array[leftIdx] < array[leftIdx + 1])
                {
                    leftIdx--;
                }

                int rightIdx = i + 2;
                while(rightIdx < array.Length && array[rightIdx] < array[rightIdx - 1])
                {
                    rightIdx++;
                }

                int currentPeakLength = rightIdx - leftIdx -1;
                longestLength = currentPeakLength > longestLength ? currentPeakLength : longestLength;
                i = rightIdx;
            }
            return longestLength;
        }

        public static int GetLongestPeak(int[] array, List<int> peaks)
        {

            // Time - O(N)
            // Space - O(1)

            int biggestPeak = 0;

            foreach (var peak in peaks)
            {                
                int current = peak - 1;
                int previous = peak;
                int leftLength = 1;
                int rightLength = 0;
               
                while (true)
                {
                    if(current < 0) { break; }
                    if (array[current] < array[previous])
                    {
                        leftLength++;
                        current--;
                        previous--;
                        continue;
                    }
                    break;
                }

                previous = peak;
                current = peak + 1;

                while (true)
                {
                    if (current >= array.Length) { break; }
                    if (array[previous] > array[current])
                    {
                        rightLength++;
                        current++;
                        previous++;
                        continue;
                    }
                    break;
                    
                }
                biggestPeak = rightLength + leftLength > biggestPeak ? rightLength + leftLength : biggestPeak;
            }
            return biggestPeak;
        }

        public static List<int> GetPeakPositions(int[] arr)
        {

            // time for this method O(N)

            List<int> postions = new List<int>();

            for (int i = 1; i < arr.Length-1; i++)
            {
                if(arr[i] > arr[i-1] && arr[i] > arr[i + 1])
                {
                    postions.Add(i);
                }
            }

            return postions;
        }
    }
}
