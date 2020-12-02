using BinaryTreeHelper;
using System;

namespace _3.FindClosestValueInBinarySearchTree
{
    
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = BinaryTree.CreateTree();
            int target = 2;
            Console.WriteLine(FindClosestValueInBst(tree, target, tree.value));
            Console.ReadLine();

        }

        static int FindClosestValueInBst(BinaryTree tree, int target, int closest)
        {
            if (Math.Abs(target - closest) > Math.Abs(target - tree.value))
            {
                closest = tree.value;
            }

            if (target < tree.value && tree.left != null)
            {
                return FindClosestValueInBst(tree.left, target, closest);
            }
            else if (target > tree.value && tree.right != null)
            {
                return FindClosestValueInBst(tree.right, target, closest);
            }
            else
            {
                return closest;
            }
        }       
    }
}
