using System;

namespace BinarySearchTree
{
    class Node
    {
        public int nodeValue;
        public Node leftNode;
        public Node rigntNode;
        public Node InsertNode(Node node, int data)
        {
            if (node.nodeValue == 0)
            {
                node.nodeValue = data;
            }
            else if (data < node.nodeValue)
            {
                if (node.leftNode == null)
                {
                    node.leftNode = new Node();
                    node.leftNode.nodeValue = data;
                }
                else
                {
                    node.leftNode = InsertNode(node.leftNode, data);
                }
            }
            else
            {
                if (node.rigntNode == null)
                {
                    node.rigntNode = new Node();
                    node.rigntNode.nodeValue = data;
                }
                else
                {
                    node.rigntNode = InsertNode(node.rigntNode, data);
                }
            }

            return node;
        }
        public Node DeleteNode(Node node, int data)
        {
            // Node newNode = new Node();
            Node newNode = node;
            if (node.nodeValue == data)
            {
                if (node.leftNode == null)
                {
                    node = newNode.rigntNode;
                }
                else if (node.rigntNode == null)
                {
                    node = newNode.leftNode;
                }
                else
                {
                    Node minNode = node.rigntNode;
                    int minv = minNode.nodeValue;
                    while (minNode.leftNode != null)
                    {
                        minv = minNode.leftNode.nodeValue;
                        minNode = minNode.leftNode;
                    }
                    node.nodeValue = minv;
                    node.rigntNode = DeleteNode(node.rigntNode, minv);
                }
            }
            else
            {
                if (data > node.nodeValue)
                {
                    node.rigntNode = DeleteNode(node.rigntNode, data);
                }
                else
                    node.leftNode = DeleteNode(node.leftNode, data);
            }
            return node;
        }
        public Node PreOrder(Node node)
        {
            if (node != null)
            {
                Console.Write(node.nodeValue + " ");
                PreOrder(node.leftNode);
                PreOrder(node.rigntNode);
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
                int value = Convert.ToInt32(Console.ReadLine());
                root = root.InsertNode(root, value);
            }
            Console.WriteLine("Preorder traversal of  tree is : ");
            root.PreOrder(root);

            Console.WriteLine("Pleae Enter Value Which you want to delete :");
            int deleteValue = Convert.ToInt32(Console.ReadLine());
            root = root.DeleteNode(root, deleteValue);
            Console.WriteLine("After Delete Preorder traversal of  tree is : ");
            root.PreOrder(root);
        }
    }
}
