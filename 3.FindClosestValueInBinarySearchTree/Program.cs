using System;

namespace _3.FindClosestValueInBinarySearchTree
{
    public class BST
    {
        public int value;
        public BST left;
        public BST right;

        public BST(int value)
        {
            this.value = value;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BST tree = CreateTree();
            int target = 2;
            Console.WriteLine(FindClosestValueInBst(tree, target, tree.value));
            Console.ReadLine();

        }

        static int FindClosestValueInBst(BST tree, int target, int closest)
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

        static BST CreateTree()
        {
            BST output = new BST(10);
            output.left = new BST(5) { left = new BST(3), right = new BST(4) };
            output.right = new BST(22) { left = new BST(20), right = new BST(29) };
            return output;
        }
    }
}
