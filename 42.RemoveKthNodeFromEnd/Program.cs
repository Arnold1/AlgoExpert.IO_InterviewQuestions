using System;

namespace _42.RemoveKthNodeFromEnd
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList list = CreateList();

            //RemoveKthNode(10, list);
            RemoveKthNodeSecondVersion(3, list);

            Console.WriteLine("Hello World!");
        }

        static public void RemoveKthNodeSecondVersion(int n, LinkedList head)
        {

            // Better version as it only loops once instead of twice like the previous attempt;

            // Time = O(N)

            // Space O(N)

            LinkedList currentNode = head;
            LinkedList nthNode = head;
            LinkedList previousNthNode = null;
            int counter = 0;

            while(currentNode != null)
            {
                if(counter >= n)
                {
                    previousNthNode = nthNode;
                    nthNode = nthNode.Next;
                }
                currentNode = currentNode.Next;
                counter++;
            }

            if(previousNthNode == null)
            {
                head.Value = nthNode.Next.Value;
                head.Next = nthNode.Next.Next;
                return;
            }
            previousNthNode.Next = nthNode.Next;
        }
        static public void RemoveKthNode(int node, LinkedList head)
        {

            // My attempt before watching video, It works perfect but it loosps twice which is not efficient.
            int lengthOfList = 0;
            LinkedList currentNode = head;
            while(currentNode != null)
            {
                lengthOfList++;
                currentNode = currentNode.Next;
            }

            int nodeToRemove = lengthOfList - node;
            int counter = 0;
            currentNode = head;
            LinkedList previousNode = null;

            while(counter <= nodeToRemove)
            {
                if(counter == nodeToRemove)
                {
                    if (previousNode == null)
                    {
                        head.Value = currentNode.Next.Value;
                        head.Next = currentNode.Next.Next;

                        return;
                    }
                    previousNode.Next = currentNode.Next;
                    return;
                }
                counter++;
                previousNode = currentNode;
                currentNode = currentNode.Next;
                
            }
            Console.WriteLine();
        }

        static public LinkedList CreateList()
        {
            LinkedList head = new LinkedList(1);
            LinkedList list2 = new LinkedList(2);
            LinkedList list3 = new LinkedList(3);
            LinkedList list4 = new LinkedList(4);
            LinkedList list5 = new LinkedList(5);
            LinkedList list6 = new LinkedList(6);
            LinkedList list7 = new LinkedList(7);
            LinkedList list8 = new LinkedList(8);
            LinkedList list9 = new LinkedList(9);
            LinkedList list10 = new LinkedList(10);
            head.Next = list2;
            list2.Next = list3;
            list3.Next = list4;
            list4.Next = list5;
            list5.Next = list6;
            list6.Next = list7;
            list7.Next = list8;
            list8.Next = list9;
            list9.Next = list10;

            return head;
        }

    }


    public class LinkedList
    {
        public int Value;
        public LinkedList Next = null;

        public LinkedList(int value)
        {
            this.Value = value;
        }
    }
}
