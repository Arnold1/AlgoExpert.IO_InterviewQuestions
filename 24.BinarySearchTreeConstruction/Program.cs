using BinaryTreeHelper;
using System;

namespace _24.BinarySearchTreeConstruction
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = BinaryTree.CreateTree();
            
            // All logic insert, conatins & remove are in the BinrayTreeHelper Class

            // Time + Space Best : O(log(N))
            // Time + Space Worst : O(N);
            tree.Insert(99);
            tree.Insert(7);
            tree.Remove(12);

            Console.WriteLine();
                        
        }

        
    }
}
