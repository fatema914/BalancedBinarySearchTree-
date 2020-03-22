using System;

namespace BinarySearchTree
{
    class Node
    {
        public int NodeValue;
        public Node LeftNode;
        public Node RigntNode;
        public Node InsertNode(Node node, int data)
        {
            if (node.NodeValue == 0)
            {
                node.NodeValue = data;
            }
            else if (data < node.NodeValue)
            {
                if (node.LeftNode == null)
                {
                    node.LeftNode = new Node();
                    node.LeftNode.NodeValue = data;
                }
                else
                {
                    node.LeftNode = InsertNode(node.LeftNode, data);
                }
            }
            else
            {
                if (node.RigntNode == null)
                {
                    node.RigntNode = new Node();
                    node.RigntNode.NodeValue = data;
                }
                else
                {
                    node.RigntNode = InsertNode(node.RigntNode, data);
                }
            }

            return node;
        }
        public Node DeleteNode(Node node, int data)
        {
            Node NewNode = node;
            if (node.NodeValue == data)
            {
                if (node.LeftNode == null)
                {
                    node = NewNode.RigntNode;
                }
                else if (node.RigntNode == null)
                {
                    node = NewNode.LeftNode;
                }
                else
                {
                    Node MinNode = node.RigntNode;
                    int MinValue = MinNode.NodeValue;
                    while (MinNode.LeftNode != null)
                    {
                        MinValue = MinNode.LeftNode.NodeValue;
                        MinNode = MinNode.LeftNode;
                    }
                    node.NodeValue = MinValue;
                    node.RigntNode = DeleteNode(node.RigntNode, MinValue);
                }
            }
            else
            {
                if (data > node.NodeValue)
                {
                    node.RigntNode = DeleteNode(node.RigntNode, data);
                }
                else
                    node.LeftNode = DeleteNode(node.LeftNode, data);
            }
            return node;
        }
        public Node PreOrder(Node node)
        {
            if (node != null)
            {
                Console.Write(node.NodeValue + " ");
                PreOrder(node.LeftNode);
                PreOrder(node.RigntNode);
            }
            return node;
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            Node bst = new Node();
            Node root = new Node();
            Console.WriteLine("Pleae Enter the number of node :");
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                int Value = Convert.ToInt32(Console.ReadLine());
                root = root.InsertNode(root, Value);
            }
            Console.WriteLine("Preorder traversal of  tree is : ");
            root.PreOrder(root);

            Console.WriteLine("Pleae Enter Value Which you want to delete :");
            int DeleteValue = Convert.ToInt32(Console.ReadLine());
            root = root.DeleteNode(root, DeleteValue);
            Console.WriteLine("After Delete Preorder traversal of  tree is : ");
            root.PreOrder(root);
        }
    }
}
