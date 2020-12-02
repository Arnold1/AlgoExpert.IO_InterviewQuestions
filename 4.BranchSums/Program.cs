using BinaryTreeHelper;
using System;
using System.Collections.Generic;

namespace _4.BranchSums
{

	class Program
    {
        static void Main(string[] args)
        {
			BinaryTree tree = BinaryTree.CreateTree();
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
	}
}
