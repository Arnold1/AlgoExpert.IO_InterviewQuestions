using System;

namespace _9.BinarySearch
{
    class Program
    {
        static int[] array = { 0, 1, 21, 33, 45, 45, 61, 71, 72, 73 };
        static int target = 33;

        //static int[] array = { 1, 5, 23, 111 };

        //static int target = 120;


        static void Main(string[] args)
        {
            Console.WriteLine($"Recursive Method : Target {target} is at position {BinarySearch(array, target)}");
            Console.WriteLine($"Iterative Method : Target {target} is at position {BinarySearchIteratively(array, target)}");

            Console.ReadKey();
        }

        public static int BinarySearch(int[] array, int target)
        {
            int left = 0;
            int right = array.Length-1;
            return BinarySearchHelper(array, target, left, right);
        }

        public static int BinarySearchHelper(int[] array, int target, int leftPointer, int rightPointer)
        {
            // Time - O(log(N)) - where n is the length of the input array. It is log of N because the array is halved each time
            // Space - O(log(N)) - 

            if(leftPointer > rightPointer)
            {
                return -1;
            }
            int newpointer = (rightPointer + leftPointer) / 2;
            

            if (array[newpointer] == target)
            {
                return newpointer;
            }

            if (array[newpointer] > target)
            {
                return BinarySearchHelper(array, target, leftPointer, newpointer-1);
            }
            else if(array[newpointer] < target)
            {
                return BinarySearchHelper(array, target, newpointer+1, rightPointer);
            }
            

            return -1;
               
        }

        public static int BinarySearchIteratively(int[] array, int target)
        {
            // Time - O(log(N)) - where n is the length of the input array. It is log of N because the array is halved each time
            // Space - O(1) 

            int leftPointer = 0;
            int rightPointer = array.Length-1;

            while (true)
            {
                int newpointer = (rightPointer + leftPointer) / 2;
                
                if(leftPointer > rightPointer)
                {
                    return -1;
                }
                if(array[newpointer] == target)
                {
                    return newpointer;
                }
                if(array[newpointer] < target)
                {
                    leftPointer = newpointer + 1;
                    continue;
                }
                if(array[newpointer] > target)
                {
                    rightPointer = newpointer -1;
                    continue;
                }
            }
        }
    }
}
