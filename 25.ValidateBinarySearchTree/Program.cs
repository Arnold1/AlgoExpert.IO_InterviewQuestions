using BinaryTreeHelper;
using System;

namespace _25.ValidateBinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = BinaryTree.CreateTree();

            // Time - O(N) where n is the number is nodes, because we are traversing every node
            // Space - O(N) where N is the depth ( the length of the longest branch) because recursive calls are on the call stack

            bool test = ValidateTree(tree);
        }

        public static bool ValidateTree(BinaryTree tree)
        {

            return validateBinaryTreeHelper(tree, int.MinValue, int.MaxValue);
        }

        public static bool validateBinaryTreeHelper(BinaryTree tree, int minValue, int maxValue)
        {
            if(tree == null)
            {
                // if we hit a leaf then the tree is valid
                return true;
            }
            if(tree.value < minValue || tree.value >= maxValue)
            {
                return false;
            }

            bool leftIsValid = validateBinaryTreeHelper(tree.left, minValue, tree.value); // left node - max value of left node is current nodes value
            return leftIsValid && validateBinaryTreeHelper(tree.right, tree.value, maxValue);


        }
    }
}
