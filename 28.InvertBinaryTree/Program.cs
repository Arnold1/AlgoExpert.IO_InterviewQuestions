using BinaryTreeHelper;
using System;

namespace _28.InvertBinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
			BinaryTree tree = BinaryTree.CreateTree();
			InvertBinaryTree(tree);
        }
		public static void InvertBinaryTree(BinaryTree tree)
		{
			// Time - O(N) where n is the amount of nodes
			// Space - O(d) where d is the depth

			if (tree == null) { return; }
			var left = tree.left;
			var right = tree.right;

			tree.left = right;
			tree.right = left;
			InvertBinaryTree(tree.left);
			InvertBinaryTree(tree.right);

		}
	}
}
