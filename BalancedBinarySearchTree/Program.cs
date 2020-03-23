using System;

namespace BinarySearchTree
{
    public class Node
    {
        public int NodeValue;
        public int Height;
        public Node LeftNode;
        public Node RigntNode;
    }
    public class BalancedBinaryTree
    {
        Node root;
        public BalancedBinaryTree()
        {
            root = null;
        }
        public Node InsertNode(Node node)
        {
            if (root == null)
            {
                root = node;
                node.Height = 1;
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
                node.Height = 1;
            }
            if (data < node.NodeValue)
            {
                if (node.LeftNode == null)
                {
                    node.LeftNode = new Node();
                    node.LeftNode.NodeValue = data;
                    node.LeftNode.Height = 1;
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
                    node.RigntNode.Height = 1;
                }
                else
                {
                    node.RigntNode = InsertNodeRec(node.RigntNode, data);
                }
            }
            //Calculate left and right Height of each node
            node = GetHeight(node);           
            int balanceFactor = GetBalanceFactor(node);

            if (balanceFactor > 1)
            {
                if (data < node.LeftNode.NodeValue)
                {
                    node = LeftBalanceing(node);
                }
                else
                {
                    node = LeftRightBalancing(node);
                }
            }
            else if (balanceFactor < -1)
            {
                if (data > node.RigntNode.NodeValue)
                {
                    node = RightBalanceing(node);
                }
                else
                    node = RightLeftBalancing(node);
            }
            return node;
        }
        public int GetBalanceFactor(Node node)
        {
            int balanceFactor = 0;
            if (node.LeftNode != null && node.RigntNode == null)
            {
                balanceFactor = node.LeftNode.Height;
            }
            else if (node.LeftNode == null && node.RigntNode != null)
            {
                balanceFactor = -(node.RigntNode.Height);
            }
            else if (node.LeftNode != null && node.RigntNode != null)
            {
                balanceFactor = node.LeftNode.Height - node.RigntNode.Height;
            }
            return balanceFactor;
        }
        public Node GetHeight(Node node)
        {
            if (node.LeftNode != null && node.RigntNode == null)
            {
                node.Height = node.LeftNode.Height + 1;
            }
            else if (node.LeftNode != null && node.RigntNode != null)
            {
                if (node.LeftNode.Height > node.RigntNode.Height)
                {
                    node.Height = node.LeftNode.Height + 1;
                }
                else if (node.LeftNode.Height < node.RigntNode.Height)
                {
                    node.Height = node.RigntNode.Height + 1;
                }
                else
                    node.Height = node.RigntNode.Height + 1;
            }
            else if (node.RigntNode != null && node.LeftNode == null)
            {
                node.Height = node.RigntNode.Height + 1;
            }
            else if (node.RigntNode == null && node.LeftNode == null)
            {
                node.Height = 1;
            }
            return node;
        }
        public Node RightBalanceing(Node node)
        {
            Node tempNode = node.RigntNode;
            node.RigntNode = tempNode.LeftNode;
            tempNode.LeftNode = node;
            tempNode.LeftNode = GetHeight(tempNode.LeftNode);
            return tempNode;
        }
        public Node LeftBalanceing(Node node)
        {
            Node tempNode = node.LeftNode;
            node.LeftNode = tempNode.RigntNode;
            tempNode.RigntNode = node;
            tempNode.RigntNode = GetHeight(tempNode.RigntNode);
            return tempNode;
        }
        public Node LeftRightBalancing(Node node)
        {
            Node tempNode = node.LeftNode;
            node.LeftNode = RightBalanceing(tempNode);
            node = LeftBalanceing(node);
            node = GetHeight(node);
            return node;
        }
        public Node RightLeftBalancing(Node node)
        {
            Node tempNode = node.RigntNode;
            node.RigntNode = LeftBalanceing(tempNode);
            node = RightBalanceing(node);
            node = GetHeight(node);
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
        public Node DeleteNode(Node node)
        {
            root = DeleteNodeRec(root, node.NodeValue);
            return root;
        }
        public Node DeleteNodeRec(Node node, int data)
        {
            Node nodeToDelete = node;
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
                    Node minValueNode = node.RigntNode;
                    int minv = minValueNode.NodeValue;
                    while (minValueNode.LeftNode != null)
                    {
                        minv = minValueNode.LeftNode.NodeValue;
                        minValueNode = minValueNode.LeftNode;
                    }
                    node.NodeValue = minv;
                    node.RigntNode = DeleteNodeRec(node.RigntNode, minv);
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
            if (node != null)
            {
                node = GetHeight(node);
                int balanceFactor = GetBalanceFactor(node);

                if (balanceFactor > 1)
                {
                    if (node.NodeValue < node.LeftNode.NodeValue)
                    {
                        node = LeftBalanceing(node);
                    }
                    else
                    {
                        node = LeftRightBalancing(node);
                    }
                }
                else if (balanceFactor < -1)
                {
                    if (node.NodeValue > node.RigntNode.NodeValue)
                    {
                        node = RightBalanceing(node);
                    }
                    else
                        node = RightLeftBalancing(node);
                }
            }
            return node;
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            BalancedBinaryTree balBinaryTree = new BalancedBinaryTree();
            Console.WriteLine("Pleae Enter the number of node :");
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                int data = Convert.ToInt32(Console.ReadLine());
                Node node = new Node();
                node.NodeValue = data;
                balBinaryTree.InsertNode(node);
            }
            Console.WriteLine("Preorder traversal of  tree is : ");
            balBinaryTree.PreOrderTraverser();
            Console.WriteLine("Pleae Enter Value Which you want to delete :");
            int deleteValue = Convert.ToInt32(Console.ReadLine());
            Node nodeDelete = new Node();
            nodeDelete.NodeValue = deleteValue;
            balBinaryTree.DeleteNode(nodeDelete);
            Console.WriteLine("After Delete Preorder traversal of Balanced Binary tree is : ");
            balBinaryTree.PreOrderTraverser();
        }
    }
}

