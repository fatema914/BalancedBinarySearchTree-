using System;

namespace BinarySearchTree
{
    public class Node
    {
        public int NodeValue;
        public Node LeftNode;
        public Node RigntNode;
    }
    public class BinaryTree
    {
        Node root;
        public BinaryTree()
        {
            root = null;
        }
        public Node InsertNode(Node node)
        {
            if (root == null)
            {
                root = node;
            }
            else
            {
                root = InsertNodeRec(root, node.NodeValue);
            }
            return root;
        }
        public Node InsertNodeRec(Node node, int data)
        {
            if (node.NodeValue == 0)
            {
                node.NodeValue = data;
            }
            if (data < node.NodeValue)
            {
                if (node.LeftNode == null)
                {
                    node.LeftNode = new Node();
                    node.LeftNode.NodeValue = data;
                }
                else
                {
                    node.LeftNode = InsertNodeRec(node.LeftNode, data);
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
                    node.RigntNode = InsertNodeRec(node.RigntNode, data);
                }
            }
            return node;
        }
        public Node DeleteNode(Node node)
        {
            root = DeleteNodeRec(root, node.NodeValue);
            return root;
        }
        public Node DeleteNodeRec(Node node, int data)
        {
            var nodeToDelete = node;
            if (node.NodeValue == data)
            {
                if (node.LeftNode == null)
                {
                    node = nodeToDelete.RigntNode;
                }
                else if (node.RigntNode == null)
                {
                    node = nodeToDelete.LeftNode;
                }
                else
                {
                    var findMinNode = node.RigntNode;
                    int minValue = findMinNode.NodeValue;
                    while (findMinNode.LeftNode != null)
                    {
                        minValue = findMinNode.LeftNode.NodeValue;
                        findMinNode = findMinNode.LeftNode;
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
        public Node PreOrderTraverser()
        {
            root = PreOrderRec(root);
            return root;
        }
        public Node PreOrderRec(Node node)
        {
            if (node != null)
            {
                Console.WriteLine(node.NodeValue + " ");
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
                Node node = new Node();
                int data = Convert.ToInt32(Console.ReadLine());
                node.NodeValue = data;
                bTree.InsertNode(node);
            }
            Console.WriteLine("Preorder traversal of  tree is : ");
            bTree.PreOrderTraverser();
            Console.WriteLine("Pleae Enter Value Which you want to delete :");
            int deleteValue = Convert.ToInt32(Console.ReadLine());
            Node nodeToDelete = new Node();
            nodeToDelete.NodeValue = deleteValue;
            bTree.DeleteNode(nodeToDelete);
            Console.WriteLine("After Delete Preorder traversal of  tree is : ");
            bTree.PreOrderTraverser();
        }
    }
}
