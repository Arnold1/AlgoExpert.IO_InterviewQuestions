using System;

namespace BinaryTreeHelper
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

        public static BinaryTree CreateTree()
        {
            BinaryTree output = new BinaryTree(12);
            output.left = new BinaryTree(5) { left = new BinaryTree(2) {left = new BinaryTree(1) }, right = new BinaryTree(5) };
            output.right = new BinaryTree(15) { left = new BinaryTree(13) { right = new BinaryTree(14) }, right = new BinaryTree(22) };
            return output;
        }

        public BinaryTree Insert(int value)
        {

            // Average - O(log(N)) | O(1) Space
            // Worst - O(N) time | O(1) Space

            var currentNode = this;
            while (true)
            {
                if(value < currentNode.value)
                {
                    if(currentNode.left == null)
                    {
                        currentNode.left = new BinaryTree(value);
                        break;
                    }
                    else
                    {
                        currentNode = currentNode.left;
                    }
                }
                else
                {
                    if(currentNode.right == null)
                    {
                        currentNode.right = new BinaryTree(value);
                        break;
                    }
                    else
                    {
                        currentNode = currentNode.right;
                    }
                }
            }

            return this;
        }

        public bool Contains(int value)
        {
            // Average - O(log(N)) | O(1) Space
            // Worst - O(N) time | O(1) Space

            var currentNode = this;
            while (currentNode!= null)
            {
                if(value < currentNode.value)
                {
                    currentNode = currentNode.left;
                }
                else if (value > currentNode.value)
                {
                    currentNode = currentNode.right;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }

        public BinaryTree Remove(int value, BinaryTree parentNode = null)
        {

            // Average - O(log(N)) | O(1) Space
            // Worst - O(N) time | O(1) Space

            // First we find the node we want to remove
            // Then remove it.

            var currentNode = this;
            while(currentNode != null)
            {
                if(value < currentNode.value)
                {
                    parentNode = currentNode; // keep track of parent node
                    currentNode = currentNode.left;
                }
                else if(value > currentNode.value)
                {
                    parentNode = currentNode;
                    currentNode = currentNode.right;
                }
                else
                {
                    if(currentNode.left != null && currentNode.right != null)
                    {
                        // Here if node has 2 children nodes
                        currentNode.value = currentNode.right.getMinValue(); // set value to smallest value of right subtree
                        currentNode.right.Remove(currentNode.value, currentNode); // remove smallest value from where we got it
                    }
                    else if(parentNode == null)
                    {
                        if (currentNode.left != null)
                        {
                            currentNode.value = currentNode.left.value;
                            currentNode.right = currentNode.left.right;
                            currentNode.left = currentNode.left.left;
                        }
                        else if(currentNode.right != null)
                        {
                            currentNode.value = currentNode.right.value;
                            currentNode.left = currentNode.right.left;
                            currentNode.right = currentNode.right.right;
                        }
                        else
                        {
                            currentNode.value = 0;
                        }
                    }
                    else if(parentNode.left == currentNode)
                    {
                        if(currentNode.left != null)
                        {
                            parentNode.left = currentNode.left;
                        }
                        else
                        {
                            parentNode.left = currentNode.right;
                        }
                    }
                    else if (parentNode.right == currentNode)
                    {
                        if (currentNode.left != null)
                        {
                            parentNode.left = currentNode.right;
                        }
                        else
                        {
                            parentNode.right = currentNode.right;
                        }
                    }
                    break;
                }
            }
            return this;
        }

        private int getMinValue()
        {
            var currentNode = this;
            while(currentNode.left != null)
            {
                currentNode = currentNode.left;
            }

            return currentNode.value;
        }
    }
}
