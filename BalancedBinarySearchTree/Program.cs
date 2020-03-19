using System;

namespace BinarySearchTree
{
    class Node
    {
        public int nodeValue;
        public int height;
        public Node leftNode;
        public Node rigntNode;
        public Node InsertNode(Node bstObj, int data)
        {
            if (bstObj.nodeValue == 0)
            {
                bstObj.nodeValue = data;
                bstObj.height = 1;
            }
            else if (data < bstObj.nodeValue)
            {
                if (bstObj.leftNode == null)
                {
                    bstObj.leftNode = new Node();
                    bstObj.leftNode.nodeValue = data;
                    bstObj.leftNode.height = 1;
                }
                else
                {
                    bstObj.leftNode = InsertNode(bstObj.leftNode, data);
                }
            }
            else
            {
                if (bstObj.rigntNode == null)
                {
                    bstObj.rigntNode = new Node();
                    bstObj.rigntNode.nodeValue = data;
                    bstObj.rigntNode.height = 1;
                }
                else
                {
                    bstObj.rigntNode = InsertNode(bstObj.rigntNode, data);
                }
            }
            //Calculate left and right height of each node
            bstObj = bstObj.Getheight(bstObj);
            //Calculate Is balancing needed of each node
            int balanceFactor = bstObj.GetBalanceFactor(bstObj);

            if (balanceFactor > 1)
            {
                if (data < bstObj.leftNode.nodeValue)
                {
                    bstObj = bstObj.LeftBalanceing(bstObj);
                }
                if (data > bstObj.rigntNode.nodeValue)
                {
                    bstObj = bstObj.LeftRightBalancing(bstObj);
                }
            }
            else if (balanceFactor < -1)
            {
                if (data > bstObj.rigntNode.nodeValue)
                {
                    bstObj = bstObj.RightBalanceing(bstObj);
                }
                else
                    bstObj = bstObj.RightLeftBalancing(bstObj);
            }
            return bstObj;
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
        public Node Getheight(Node bstObj)
        {
            if (bstObj.leftNode != null && bstObj.rigntNode == null)
            {
                bstObj.height = bstObj.leftNode.height + 1;
            }
            else if (bstObj.leftNode != null && bstObj.rigntNode != null)
            {
                if (bstObj.leftNode.height > bstObj.rigntNode.height)
                {
                    bstObj.height = bstObj.leftNode.height + 1;
                }
                else if (bstObj.leftNode.height < bstObj.rigntNode.height)
                {
                    bstObj.height = bstObj.rigntNode.height + 1;

                }
                else
                    bstObj.height = bstObj.rigntNode.height + 1;
            }
            else if (bstObj.rigntNode != null && bstObj.leftNode == null)
            {
                bstObj.height = bstObj.rigntNode.height + 1;
            }
            else if (bstObj.rigntNode == null && bstObj.rigntNode == null)
            {
                bstObj.height = 1;
            }
            return bstObj;
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
            Console.Write("Preorder traversal of  tree is : ");
            root.PreOrder(root);
        }
    }
}

