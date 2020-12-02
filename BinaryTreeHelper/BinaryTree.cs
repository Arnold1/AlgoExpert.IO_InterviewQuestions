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
            BinaryTree output = new BinaryTree(10);
            output.left = new BinaryTree(5) { left = new BinaryTree(3), right = new BinaryTree(4) };
            output.right = new BinaryTree(22) { left = new BinaryTree(20), right = new BinaryTree(29) };
            return output;

        }
    }
}
