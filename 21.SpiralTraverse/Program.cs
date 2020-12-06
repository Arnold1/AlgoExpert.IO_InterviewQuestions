using System;
using System.Collections.Generic;

namespace _21.SpiralTraverse
{
    class Program
    {
        //static int[,] array = new int[,] { { 1, 2, 3, 4 }, { 12, 13, 14, 5 }, { 11, 16, 15, 6 }, { 10, 9, 8, 7 } } ;

        static int[,] array = new int[,]{ {1, 11},
    {2, 12},
    {3, 13},
    {4, 14},
    {5, 15},
    {6, 16},
    {7, 17},
    {8, 18},
    {9, 19},
    {10, 20} };

    static void Main(string[] args)
        {
            SpiralTraverseIterative(array);
            SpiralTraverseRecursive(array);
           
        }

        static List<int> SpiralTraverseIterative(int[,] arr)
        {
            // Time - O(N)
            // Space = O(N)

            List<int> result = new List<int>();
            int startRow = 0;
            int endRow = arr.GetLength(1) - 1;
            int startCol = 0;
            int endCol = arr.GetLength(0) -1;

            while(startRow <= endRow && startCol <= endCol)
            {
                for (int i = startRow; i <= endRow; i++)
                {
                    result.Add(arr[startRow,i]);
                }

                for (int i = startCol+1; i <= endCol ; i++)
                {
                    result.Add(arr[i, endRow]);
                }

                for (int i = endRow-1; i >= startRow; i--)
                {
                    if(startCol == endCol) { break; }
                    result.Add(arr[endCol, i]);
                }

                for (int i = endCol-1; i >= startCol +1; i--)
                {
                    if (startRow == endRow) { break; }
                    result.Add(arr[i, startRow]);
                }

                startRow++;
                endRow--;
                startCol++;
                endCol--;
            }

           

            return result;
        }

        static List<int> SpiralTraverseRecursive(int[,] arr)
        {
            // Time - O(N)
            // Space - O(N)

            List<int> result = new List<int>();
            SpiralFill(arr, 0, arr.GetLength(1) - 1, 0, arr.GetLength(0) - 1, result);
            return result;
        }

        public static void SpiralFill(int[,] arr, int startRow, int endRow, int startCol, int endCol, List<int> result)
        {
           if(startRow > endRow || startCol > endCol)
           {
                return;
           }

            for (int i = startRow; i <= endRow; i++)
            {
                result.Add(arr[startRow, i]);
            }

            for (int i = startCol + 1; i <= endCol; i++)
            {
                result.Add(arr[i, endRow]);
            }

            for (int i = endRow - 1; i >= startRow; i--)
            {
                if (startCol == endCol) { break; }
                result.Add(arr[endCol, i]);
            }

            for (int i = endCol - 1; i >= startCol + 1; i--)
            {
                if (startRow == endRow) { break; }
                result.Add(arr[i, startRow]);
            }

            SpiralFill(arr, startRow + 1, endRow - 1, startCol + 1, endCol - 1, result);
        }
    }
}
