using System;

namespace BinarySearchTree
{
    public class BinaryTree
    {
        public class Node
        {
            public int NodeValue;
            public Node LeftNode;
            public Node RigntNode;
        }
        Node root;
        public BinaryTree()
        {
            root = null;
        }
        public Node InsertNode(int data)
        {
            if (root == null)
            {
                root = new Node();
                root.NodeValue = data;
            }
            else
            {
                root = InsertRec(root, data);
            }
            return root;
        }
        public Node InsertRec(Node node, int data)
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
                    node.LeftNode = InsertRec(node.LeftNode, data);
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
                    node.RigntNode = InsertRec(node.RigntNode, data);
                }
            }
            return node;
        }
        public Node DeleteNode(int data)
        {
            root = DeleteNodeRec(root, data);
            return root;
        }
        public Node DeleteNodeRec(Node node, int data)
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
                    int minValue = MinNode.NodeValue;
                    while (MinNode.LeftNode != null)
                    {
                        minValue = MinNode.LeftNode.NodeValue;
                        MinNode = MinNode.LeftNode;
                    }
                    node.NodeValue = minValue;
                    node.RigntNode = DeleteNodeRec(node.RigntNode, minValue);
                }
            }
            else
            {
                if (data > node.NodeValue)
                {
                    node.RigntNode = DeleteNodeRec(node.RigntNode, data);
                }
                else
                    node.LeftNode = DeleteNodeRec(node.LeftNode, data);
            }
            return node;
        }
        public Node PreOrder()
        {
           root = PreOrderRec(root);
            return root;
        }
        public Node PreOrderRec(Node node)
        {
            if (node != null)
            {
                Console.Write(node.NodeValue + " ");
                PreOrderRec(node.LeftNode);
                PreOrderRec(node.RigntNode);
            }
            return node;
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            BinaryTree bTree = new BinaryTree();
            Console.WriteLine("Pleae Enter the number of node :");
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                int Value = Convert.ToInt32(Console.ReadLine());
                bTree.InsertNode(Value);
            }
            Console.WriteLine("Preorder traversal of  tree is : ");
            bTree.PreOrder();

            Console.WriteLine("Pleae Enter Value Which you want to delete :");
            int DeleteValue = Convert.ToInt32(Console.ReadLine());
            bTree.DeleteNode(DeleteValue);
            Console.WriteLine("After Delete Preorder traversal of  tree is : ");
            bTree.PreOrder();
        }
    }
}
