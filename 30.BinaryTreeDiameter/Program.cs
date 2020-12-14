using BinaryTreeHelper;
using System;

namespace _30.BinaryTreeDiameter
{

    public class TreeInfo
    {
        public int Diameter { get; set; }
        public int Height { get; set; }

        public TreeInfo(int diameter, int height)
        {
            this.Diameter = diameter;
            this.Height = height;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Diameter is the lenght of the longest path in the tree
            BinaryTree tree = BinaryTree.CreateTree();
            int result = GetTreeInfo(tree).Diameter;
        }

        public static TreeInfo GetTreeInfo(BinaryTree node)
        {
            // Time & Space - O(N)

            if(node == null)
            {
                return new TreeInfo(0, 0);
            }

            TreeInfo leftTreeInfo = GetTreeInfo(node.left);
            TreeInfo rightTreeInfo = GetTreeInfo(node.right);

            int longestPathThroughRoot = leftTreeInfo.Height + rightTreeInfo.Height;
            int maxDiameterSoFar = Math.Max(leftTreeInfo.Diameter, rightTreeInfo.Diameter);
            int currentDiameter = Math.Max(longestPathThroughRoot, maxDiameterSoFar);
            int currentHeight = 1 + Math.Max(leftTreeInfo.Height, rightTreeInfo.Height);

            return new TreeInfo(currentDiameter, currentHeight);
        }
    }
}
