using System;
using System.Collections.Generic;
using BinaryTreeHelper;

namespace _5.DepthFirstSearch
{
    

    class Program
    {
        static void Main(string[] args)
        {
            // This is slightly differeent to the question on algoexpert as the tree in the question had 3 edges instead of left and right nodes.
            // This solution is a normal tree with left and right nodes.
            // The actual solution is commented out below

            BinaryTree tree = BinaryTree.CreateTree();
            List<int> result = new List<int>();
            DepthFirstSearch(tree, result);
            
            foreach (var number in result)
            {
                Console.WriteLine(number);
            }
            Console.ReadLine();
        }

        static List<int> DepthFirstSearch (BinaryTree tree, List<int> numbers)
        {
            // (V) Is the vertices of the tree i.e the nodes
            // (E) Edge is the line connecting the nodes

            // Time - O(V+E)
            // Space - O(V)
            if(tree == null)
            {
                return numbers;
            }
            numbers.Add(tree.value);
            if (tree.left != null)
            {
                DepthFirstSearch(tree.left, numbers);
            }
            if( tree.right != null)
            {
                DepthFirstSearch(tree.right, numbers);
            }
            return numbers;
        } 
    }
}



//public class Node
//{
//    public string name;
//    public List<Node> children = new List<Node>();

//    public Node(string name)
//    {
//        this.name = name;
//    }

//    public List<string> DepthFirstSearch(List<string> array)
//    {
//        array.Add(this.name);
//        foreach (var child in children)
//        {
//            child.DepthFirstSearch(array);
//        }
//        return array;
//    }

//    public Node AddChild(string name)
//    {
//        Node child = new Node(name);
//        children.Add(child);
//        return this;
//    }
//}
//}

