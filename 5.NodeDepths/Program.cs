using System;
using BinaryTreeHelper;
using System.Collections.Generic;

namespace _5.NodeDepths
{
    
    class Program
    {
        public static void Main(string[] args)
        {
            BinaryTree tree = BinaryTree.CreateTree();

            Console.WriteLine($"(Iterative Method) The node depth is {IterativeMethod(tree)}");
            Console.WriteLine($"(Recursive Method) The node depth is {RecursiveMethod(tree)}");
            Console.WriteLine();
        }

        public static int RecursiveMethod(BinaryTree tree, int depth=0)
        {
            // Time - O(N) where N is the number of nodes in tree
            // Space - O(H) where H is the height of tree
            if(tree == null)
            {
                return 0;
            }
            return depth + RecursiveMethod(tree.left, depth + 1) + RecursiveMethod(tree.right, depth + 1);
        }

        public static int IterativeMethod(BinaryTree tree)
        {
            // Time - O(N) where N is the number of nodes in tree
            // Space - O(H) where H is the height of the tree

            int sumOfDepths = 0;
            Stack<KeyValuePair<BinaryTree, int>> stack = new Stack<KeyValuePair<BinaryTree,int>>();
            stack.Push(new KeyValuePair<BinaryTree, int>(tree, 0));
            
            while(stack.Count > 0)
            {
                var nodeInfo = stack.Pop();
                var depth = nodeInfo.Value;

                BinaryTree node = nodeInfo.Key;

                if (node == null)
                {
                    continue;
                }

                sumOfDepths += depth;
                stack.Push(new KeyValuePair<BinaryTree, int>(node.left, depth + 1));
                stack.Push(new KeyValuePair<BinaryTree, int>(node.right, depth + 1));
            }

            return sumOfDepths;

        }       
    }
}
