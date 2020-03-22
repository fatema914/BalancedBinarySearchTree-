using System;

namespace BinarySearchTree
{
    class Node
    {
        public int nodeValue;
        public int height;
        public Node leftNode;
        public Node rigntNode;
        public Node InsertNode(Node node, int data)
        {
            if (node.nodeValue == 0)
            {
                node.nodeValue = data;
                node.height = 1;
            }
            else if (data < node.nodeValue)
            {
                if (node.leftNode == null)
                {
                    node.leftNode = new Node();
                    node.leftNode.nodeValue = data;
                    node.leftNode.height = 1;
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
                    node.rigntNode.height = 1;
                }
                else
                {
                    node.rigntNode = InsertNode(node.rigntNode, data);
                }
            }
            //Calculate left and right height of each node
            node = node.Getheight(node);
            //Calculate Is balancing needed of each node
            int balanceFactor = node.GetBalanceFactor(node);

            if (balanceFactor > 1)
            {
                if (data < node.leftNode.nodeValue)
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
                if (data > node.rigntNode.nodeValue)
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
            if (node.leftNode != null && node.rigntNode == null)
            {
                isBalance = node.leftNode.height;
            }
            else if (node.leftNode == null && node.rigntNode != null)
            {
                isBalance = -(node.rigntNode.height);
            }
            else if (node.leftNode != null && node.rigntNode != null)
            {
                isBalance = node.leftNode.height - node.rigntNode.height;
            }
            return isBalance;
        }
        public Node Getheight(Node node)
        {
            if (node.leftNode != null && node.rigntNode == null)
            {
                node.height = node.leftNode.height + 1;
            }
            else if (node.leftNode != null && node.rigntNode != null)
            {
                if (node.leftNode.height > node.rigntNode.height)
                {
                    node.height = node.leftNode.height + 1;
                }
                else if (node.leftNode.height < node.rigntNode.height)
                {
                    node.height = node.rigntNode.height + 1;
                }
                else
                    node.height = node.rigntNode.height + 1;
            }
            else if (node.rigntNode != null && node.leftNode == null)
            {
                node.height = node.rigntNode.height + 1;
            }
            else if (node.rigntNode == null && node.leftNode == null)
            {
                node.height = 1;
            }
            return node;
        }
        public Node RightBalanceing(Node node)
        {
            Node tempNode = node.rigntNode;
            node.rigntNode = tempNode.leftNode;
            tempNode.leftNode = node;
            tempNode.leftNode = Getheight(tempNode.leftNode);
            return tempNode;
        }
        public Node LeftBalanceing(Node node)
        {
            Node tempNode = node.leftNode;
            node.leftNode = tempNode.rigntNode;
            tempNode.rigntNode = node;
            tempNode.rigntNode = Getheight(tempNode.rigntNode);
            return tempNode;
        }
        public Node LeftRightBalancing(Node node)
        {
            Node tempNode = node.leftNode;
            node.leftNode = RightBalanceing(tempNode);
            node = LeftBalanceing(node);
            node = Getheight(node);
            return node;
        }
        public Node RightLeftBalancing(Node node)
        {
            Node tempNode = node.rigntNode;
            node.rigntNode = LeftBalanceing(tempNode);
            node = RightBalanceing(node);
            node = Getheight(node);
            return node;
        }
        public void PreOrder(Node node)
        {
            if (node != null)
            {
                Console.Write(node.nodeValue + " ");
                PreOrder(node.leftNode);
                PreOrder(node.rigntNode);
            }
        }
        public Node DeleteNode(Node node, int data)
        {
            Node tempNode = node;
            if (node.nodeValue == data)
            {
                if (node.leftNode == null)
                {
                    node = tempNode.rigntNode;
                }
                else if (node.rigntNode == null)
                {
                    node = tempNode.leftNode;
                }
                else
                {
                    Node minValueNode = node.rigntNode;
                    int minv = minValueNode.nodeValue;
                    while (minValueNode.leftNode != null)
                    {
                        minv = minValueNode.leftNode.nodeValue;
                        minValueNode = minValueNode.leftNode;
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
            if (node != null)
            {
                node = node.Getheight(node);
                int balanceFactor = node.GetBalanceFactor(node);

                if (balanceFactor > 1)
                {
                    if (node.nodeValue < node.leftNode.nodeValue)
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
                    if (node.nodeValue > node.rigntNode.nodeValue)
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
                int value = Convert.ToInt32(Console.ReadLine());
                root = root.InsertNode(root, value);
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

