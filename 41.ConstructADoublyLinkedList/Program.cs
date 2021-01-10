using System;

namespace _41.ConstructADoublyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList linkedList = new DoublyLinkedList(5);
            Node newNode = new Node(12);
            
            linkedList.Insert(new Node(8));
            linkedList.Insert(newNode);
            linkedList.Insert(new Node(23));
            linkedList.InsertAfter(newNode, new Node(27));
            linkedList.InsertAfter(new Node(23), new Node(99));
            linkedList.InsertBefore(newNode, new Node(283));
            linkedList.SetHead(new Node(83));
            linkedList.SetTail(newNode);

            bool test = linkedList.ContainsNodeWithValue(88);
            var testHead = linkedList.Head;
            var testTail = linkedList.Tail;

            linkedList.PrintList();
            Console.Read();
        }
    }

    public class DoublyLinkedList
    {
        public Node Head;
        public Node Tail;

        public DoublyLinkedList(int value)
        {
            Node newNode = new Node(value);
            Head = newNode;
            Tail = newNode;
        }

        public void SetHead(Node node)
        {
            if (Head == null)
            {
                Head = node;
                Tail = node;
                return;
            }
            InsertBefore(Head, node);

        }

        public void PrintList()
        {
            Node node = Head;

            Console.WriteLine($"Head = {Head.Value}");
            Console.WriteLine($"Tail = {Tail.Value}");
            Console.WriteLine();
            while (node != null)
            {
                Console.Write($"{ node.Value} -> ");
                node = node.Next;
            }
        }

        public void SetTail(Node node)
        {
            if (Tail == null)
            {
                SetHead(node);
                return;
            }
            InsertAfter(Tail, node);
        }

        public void Insert(Node node)
        {
            Node currentNode = Head;
            Node previousNode;

            while (currentNode != null)
            {
                if (currentNode.Next == null)
                {
                    currentNode.Next = node;
                    Tail = node;
                    node.Prev = currentNode;

                    return;
                }
                else
                {
                    currentNode = currentNode.Next;
                    previousNode = currentNode;
                }
            }
        }

        public void InsertAfter(Node node, Node nodeToInsert)
        {
            if (nodeToInsert == Head && nodeToInsert == Tail) { return; }
            RemoveNode(nodeToInsert);
            nodeToInsert.Prev = node;
            nodeToInsert.Next = node.Next;

            if (node.Next == null)
            {
                Tail = nodeToInsert;
            }
            else
            {
                node.Next.Prev = nodeToInsert;
            }
            node.Next = nodeToInsert;

        }

        public void InsertBefore(Node node, Node nodeToInsert)
        {
            if (nodeToInsert == Head && nodeToInsert == Tail) { return; }
            RemoveNode(nodeToInsert);

            nodeToInsert.Prev = node.Prev;
            nodeToInsert.Next = node;

            if (node.Prev == null)
            {
                Head = nodeToInsert;
            }
            else
            {
                node.Prev.Next = nodeToInsert;
            }
            node.Prev = nodeToInsert;
        }

        public void InsertAtPosition(int position, Node nodeToInsert)
        {
            Node currentNode = Head;
            if (position == 1)
            {
                SetHead(nodeToInsert);
                return;
            }

            int currentPosition = 1;
            while (currentNode != null && currentPosition != position)
            {
                currentNode = currentNode.Next;
                currentPosition++;
            }

            if (currentNode != null)
            {
                InsertBefore(currentNode, nodeToInsert);
            }
            else
            {
                SetTail(nodeToInsert);
            }
        }

        public bool ContainsNodeWithValue(int value)
        {
            Node currentNode = Head;
            while (currentNode != null)
            {
                if (currentNode.Value == value)
                {
                    return true;
                }
                currentNode = currentNode.Next;
            }
            return false;
        }

        public Node GetNode(int value)
        {
            Node currentNode = Head;
            while (currentNode != null)
            {
                if (currentNode.Value == value)
                {
                    return currentNode;
                }
                currentNode = currentNode.Next;
            }

            return null;
        }

        public void RemoveNodeWithValue(int value)
        {
            Node currentNode = Head;
            while (currentNode != null)
            {
                Node nodeToRemove = currentNode;
                currentNode = currentNode.Next;
                if (nodeToRemove.Value == value)
                {
                    RemoveNode(nodeToRemove);
                }

            }
        }

        public void RemoveNodeBindings(Node node)
        {
            if (node.Prev != null) { node.Prev.Next = node.Next; }
            if (node.Next != null) { node.Next.Prev = node.Prev; }
            node.Prev = null;
            node.Next = null;
        }

        public void RemoveNode(Node node)
        {
            if (node == Head) Head = Head.Next;
            if (node == Tail) Tail = Tail.Prev;
            RemoveNodeBindings(node);
        }
    }

    public class Node
    {
        public int Value { get; set; }
        public Node Prev;
        public Node Next;

        public Node(int value)
        {
            Value = value;
        }
    }
}
