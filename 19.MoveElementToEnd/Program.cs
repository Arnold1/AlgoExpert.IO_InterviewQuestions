using System;
using System.Collections.Generic;

namespace _19.MoveElementToEnd
{
    class Program
    {
        static List<int> array = new List<int> { 2, 1, 2, 2, 2, 3, 4, 2 };
        static List<int> array2 = new List<int> { 2, 1, 2, 2, 2, 3, 4, 2 };
        //static List<int> array = new List<int> { 3,3,3,3,3,3,3,3,3,3 };
        static int toMove = 2;
        static void Main(string[] args)
        {
            var result = MoveElementToEndMyMethod(array, toMove);
            var result2 = MoveElementsExpertVersion(array2, toMove);

            Console.Write($"The reesult from my method is : ");
            foreach (var number in result)
            {
                Console.Write(number + " ");
            }

            Console.WriteLine();
            Console.Write($"The reesult from expert method is : ");
            foreach (var number in result2)
            {
                Console.Write(number + " ");
            }
            Console.Read();
            
        }

        public static List<int> MoveElementToEndMyMethod(List<int> array, int toMove)
        {
            // Time - O(N) where N the is the length of array
            // Space - O(1) no extra sapce is used, it just manipulates original array

            int left = 0;
            int right = array.Count - 1;

            if(array.Count == 0)
            {
                return array;
            }

            while (right > left)
            {
                while (array[right] == toMove && right > 0)
                {
                    right--;
                }

                if (left < right && array[left] == toMove)
                {
                    Swap(array, left, right);
                }
                left++;
            }

            return array;
        }

        public static List<int> MoveElementsExpertVersion(List<int> array, int toMove)
        {
            int i = 0;
            int j = array.Count - 1;

            while(i < j){
                while(i < j && array[j] == toMove)
                {
                    j--;
                }
                if (array[i] == toMove)
                {
                    Swap(array, i, j);
                }
                i++;

            }
            return array;
        }

        public static void Swap(List<int> array, int left, int right)
        {
            int temp = array[left];            
            array[left] = array[right];
            array[right] = temp;
            right--;
        }
    }
}
