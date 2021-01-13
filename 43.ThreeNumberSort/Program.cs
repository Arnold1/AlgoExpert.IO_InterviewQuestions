using System;
using System.Collections.Generic;

namespace _43.ThreeNumberSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 7, 8, 9, 7, 8, 9, 9, 9, 9, 9, 9, 9 };
            int[] order = new int[] { 8, 7, 9 };
            ThreeNumberSort2(array, order);
            Console.WriteLine("Hello World!");
        }

        static public int[] ThreeNumberSort(int[] array, int[] order)
        {

            // My attempt before watching video - Passes all tests but isnt the most efficient

            // Time O(N^2)
            // Space O(1)

            int numsFound = 0;

            for (int i = 0; i < order.Length; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    if(array[j] == order[i])
                    {
                        Swap(array, j, numsFound);
                        numsFound++;
                    }
                }
            }
            return array;
        }

        static public int[] ThreeNumberSort2(int[] array, int[] order)
        {
            // Attempt after watching video explination
            // Time O(N)
            // Space O(1)

            int firstNumIdx = 0;
            int secondNumIdx = 0;
            int lastNumIdx = array.Length - 1;

            int firstInOrder = order[0];
            int secondInOrder = order[1];

            while(secondNumIdx <= lastNumIdx)
            {
                int value = array[secondNumIdx];

                if(value == firstInOrder)
                {
                    Swap(array, firstNumIdx, secondNumIdx);
                    firstNumIdx++;
                    secondNumIdx++;
                }
                else if(value == secondInOrder)
                {
                    secondNumIdx++;
                }
                else
                {
                    Swap(array, secondNumIdx, lastNumIdx);
                    lastNumIdx--;                    
                }

            }



         
            return array;
        }

        public static int GetLastNumIndex(int[] array, int lastNum)
        {
            int lastNumPosition = array.Length - 1;
            for (int i = array.Length-1; i > 0; i--)
            {
                if(array[i] == lastNum)
                {
                    lastNumPosition--;
                }
                else
                {
                    return lastNumPosition;
                }
            }

            return lastNumPosition;
        }

       
        public static int GetIndex(int[] order, int number)
        {
            for (int i = 0; i < order.Length; i++)
            {
                if(order[i] == number)
                {
                    return i;
                }
            }
            return -1;
        }

        public static void Swap(int[] array, int moveFrom, int moveTo)
        {
            int temp = array[moveTo];
            array[moveTo] = array[moveFrom];
            array[moveFrom] = temp;
        }

        public static void Swap2(int[] array, int moveFrom, int moveTo)
        {
            int temp = array[moveFrom];
            array[moveTo] = array[moveFrom];
            array[moveFrom] = temp;
        }


    }
}
