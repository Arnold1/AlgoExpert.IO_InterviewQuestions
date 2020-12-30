using System;
using System.Collections.Generic;

namespace _36.BreadthFirstSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

	public class Node
	{
		public string name;
		public List<Node> children = new List<Node>();

		public Node(string name)
		{
			this.name = name;
		}

		public List<string> BreadthFirstSearch(List<string> array)
		{
			// Time O(v + e)
			// Space O(v)

			Queue<Node> nodes = new Queue<Node>();
			nodes.Enqueue(this);

			while (nodes.Count > 0)
            {
				Node cuurent = nodes.Dequeue();
				array.Add(cuurent.name);
				cuurent.children.ForEach(n => nodes.Enqueue(n));
            }
			return array;
		}

		public Node AddChild(string name)
		{
			Node child = new Node(name);
			children.Add(child);
			return this;
		}
	}
}


