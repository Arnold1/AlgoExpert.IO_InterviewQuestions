using System;
using System.Collections.Generic;

namespace _4.BranchSums
{

	public class BinaryTree
	{
		public int value;
		public BinaryTree left;
		public BinaryTree right;

		public BinaryTree(int value)
		{
			this.value = value;
			this.left = null;
			this.right = null;
		}
	}

	class Program
    {
        static void Main(string[] args)
        {
			BinaryTree tree = CreateTree();
			List<int> totals = BranchSums(tree);
            foreach (var total in totals)
            {
                Console.WriteLine(total);
			}

			Console.ReadLine();
        }

		public static List<int> BranchSums(BinaryTree root)
        {
			// Time = O(N) as we are traversing through every node but at each one performing a comstant time calcualtion. the constant time of O(1) is removed as it is insignigicant compared to O(N)
			// Space = O(N) returning a list of N length

			List<int> sums = new List<int>();
			CalculateBranchSums(root, 0, sums);
			return sums;
        }
		
		public static void CalculateBranchSums(BinaryTree node, int runningSum, List<int> BranchSums)
        {
            if (node == null)
            {
				return;
            }

			int newRunningSum = runningSum + node.value;
			if (node.left == null && node.right == null)
            {
				BranchSums.Add(newRunningSum);
				runningSum = 0;
				return;
            }
			CalculateBranchSums(node.left, newRunningSum, BranchSums);
			CalculateBranchSums(node.right, newRunningSum, BranchSums);

        }


		static BinaryTree CreateTree()
		{
			BinaryTree output = new BinaryTree(10);
			output.left = new BinaryTree(5) { left = new BinaryTree(3), right = new BinaryTree(4) };
			output.right = new BinaryTree(22) { left = new BinaryTree(20), right = new BinaryTree(29) };
			return output;

		}
	}
}
