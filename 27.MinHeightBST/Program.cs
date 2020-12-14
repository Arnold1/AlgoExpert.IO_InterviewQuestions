using BinaryTreeHelper;
using System;
using System.Collections.Generic;

namespace _27.MinHeightBST
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> array = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            ConstructMinHeightBST(array, null, 0, array.Count - 1);
            ConstructMinHeightBSTBetter(array, 0, array.Count - 1);
        }

        
        public static BinaryTree ConstructMinHeightBST(List<int> array, BinaryTree tree, int startIdx, int endIdx)
        {
            // Time = O(n log(n)) where n is the length of the array
            // Space  = O(n)

            if (endIdx < startIdx)
            {
                return null;
            }
            int middle = (startIdx + endIdx) / 2;
            if (tree == null)
            {
                tree = new BinaryTree(array[middle]);
            }
            else
            {
                tree.Insert(array[middle]);
            }
           
            ConstructMinHeightBST(array, tree, startIdx, middle - 1);
            ConstructMinHeightBST(array, tree, middle+1, endIdx);

            return tree;
            
        }

        public static BinaryTree ConstructMinHeightBSTBetter(List<int> array, int startIdx, int endIdx)
        {
            // Time = O(n) where n is the length of the array
            // Space  = O(n)

            if (endIdx < startIdx) { return null; }
            int middle = (startIdx + endIdx) / 2;
            BinaryTree tree = new BinaryTree(array[middle]); 
            tree.left = ConstructMinHeightBSTBetter(array, startIdx, middle - 1);
            tree.right = ConstructMinHeightBSTBetter(array, middle + 1, endIdx);

            return tree;

        }
    }
}
