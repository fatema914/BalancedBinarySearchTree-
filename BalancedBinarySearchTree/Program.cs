using System;

namespace BinarySearchTree
{
    class Node
    {
        public int NodeValue;
        public int Height;
        public Node LeftNode;
        public Node RigntNode;
        public Node InsertNode(Node node, int NewNodeValue)
        {
            if (node.NodeValue == 0)
            {
                node.NodeValue = NewNodeValue;
                node.Height = 1;
            }
            else if (NewNodeValue < node.NodeValue)
            {
                if (node.LeftNode == null)
                {
                    node.LeftNode = new Node();
                    node.LeftNode.NodeValue = NewNodeValue;
                    node.LeftNode.Height = 1;
                }
                else
                {
                    node.LeftNode = InsertNode(node.LeftNode, NewNodeValue);
                }
            }
            else
            {
                if (node.RigntNode == null)
                {
                    node.RigntNode = new Node();
                    node.RigntNode.NodeValue = NewNodeValue;
                    node.RigntNode.Height = 1;
                }
                else
                {
                    node.RigntNode = InsertNode(node.RigntNode, NewNodeValue);
                }
            }
            //Calculate left and right Height of each node
            node = node.GetHeight(node);
            //Calculate Is balancing needed of each node
            int balanceFactor = node.GetBalanceFactor(node);

            if (balanceFactor > 1)
            {
                if (NewNodeValue < node.LeftNode.NodeValue)
                {
                    node = node.LeftBalanceing(node);
                }
                else
                {
                    node = node.LeftRightBalancing(node);
                }
            }
            else if (balanceFactor < -1)
            {
                if (NewNodeValue > node.RigntNode.NodeValue)
                {
                    node = node.RightBalanceing(node);
                }
                else
                    node = node.RightLeftBalancing(node);
            }
            return node;
        }
        public int GetBalanceFactor(Node node)
        {
            int isBalance = 0;
            if (node.LeftNode != null && node.RigntNode == null)
            {
                isBalance = node.LeftNode.Height;
            }
            else if (node.LeftNode == null && node.RigntNode != null)
            {
                isBalance = -(node.RigntNode.Height);
            }
            else if (node.LeftNode != null && node.RigntNode != null)
            {
                isBalance = node.LeftNode.Height - node.RigntNode.Height;
            }
            return isBalance;
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
            Node TempNode = node.RigntNode;
            node.RigntNode = TempNode.LeftNode;
            TempNode.LeftNode = node;
            TempNode.LeftNode = GetHeight(TempNode.LeftNode);
            return TempNode;
        }
        public Node LeftBalanceing(Node node)
        {
            Node TempNode = node.LeftNode;
            node.LeftNode = TempNode.RigntNode;
            TempNode.RigntNode = node;
            TempNode.RigntNode = GetHeight(TempNode.RigntNode);
            return TempNode;
        }
        public Node LeftRightBalancing(Node node)
        {
            Node TempNode = node.LeftNode;
            node.LeftNode = RightBalanceing(TempNode);
            node = LeftBalanceing(node);
            node = GetHeight(node);
            return node;
        }
        public Node RightLeftBalancing(Node node)
        {
            Node TempNode = node.RigntNode;
            node.RigntNode = LeftBalanceing(TempNode);
            node = RightBalanceing(node);
            node = GetHeight(node);
            return node;
        }
        public void PreOrder(Node node)
        {
            if (node != null)
            {
                Console.Write(node.NodeValue + " ");
                PreOrder(node.LeftNode);
                PreOrder(node.RigntNode);
            }
        }
        public Node DeleteNode(Node node, int DeleteValue)
        {
            Node TempNode = node;
            if (node.NodeValue == DeleteValue)
            {
                if (node.LeftNode == null)
                {
                    node = TempNode.RigntNode;
                }
                else if (node.RigntNode == null)
                {
                    node = TempNode.LeftNode;
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
                    node.RigntNode = DeleteNode(node.RigntNode, minv);
                }
            }
            else
            {
                if (DeleteValue > node.NodeValue)
                {
                    node.RigntNode = DeleteNode(node.RigntNode, DeleteValue);
                }
                else
                    node.LeftNode = DeleteNode(node.LeftNode, DeleteValue);
            }
            if (node != null)
            {
                node = node.GetHeight(node);
                int balanceFactor = node.GetBalanceFactor(node);

                if (balanceFactor > 1)
                {
                    if (node.NodeValue < node.LeftNode.NodeValue)
                    {
                        node = node.LeftBalanceing(node);
                    }
                    else
                    {
                        node = node.LeftRightBalancing(node);
                    }
                }
                else if (balanceFactor < -1)
                {
                    if (node.NodeValue > node.RigntNode.NodeValue)
                    {
                        node = node.RightBalanceing(node);
                    }
                    else
                        node = node.RightLeftBalancing(node);
                }
            }
            return node;
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
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
            int deleteValue = Convert.ToInt32(Console.ReadLine());
            root = root.DeleteNode(root, deleteValue);
            Console.WriteLine("After Delete Preorder traversal of Balanced Binary tree is : ");
            root.PreOrder(root);
        }
    }
}

