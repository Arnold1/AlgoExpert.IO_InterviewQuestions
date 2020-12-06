using BinaryTreeHelper;
using System;
using System.Collections.Generic;

namespace _26.BSTTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            // All 3 methods are Time O(N) and Space O(N)

            BinaryTree tree = BinaryTree.CreateTree();
            List<int> result = new List<int>();
            //var test = PreOrder(tree, result);
            PostOrder(tree, result);
            Console.WriteLine();
        }

        public static List<int>PreOrder(BinaryTree tree, List<int> result)
        {            
            result.Add(tree.value);
            if (tree.left != null) PreOrder(tree.left, result);
            if (tree.right != null) PreOrder(tree.right, result);  
            return result;
        }

        public static List<int> InOrder(BinaryTree tree, List<int> result)
        {
            if(tree.left != null) InOrder(tree.left, result);
            result.Add(tree.value);
            if(tree.right != null) InOrder(tree.right, result);
            return result;
        }

        public static List<int> PostOrder(BinaryTree tree, List<int> result)
        {
            if (tree.left != null) PostOrder(tree.left, result);           
            if (tree.right != null) PostOrder(tree.right, result);
            result.Add(tree.value);
            return result;
        }


    }
}
