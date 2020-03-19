using System;

namespace BinarySearchTree
{
    class Node
    {
        public int nodeValue;
        public Node leftNode;
        public Node rigntNode;
        public Node InsertNode(Node bstObj, int data)
        {
            if (bstObj.nodeValue == 0)
            {
                bstObj.nodeValue = data;
            }
            else if (data < bstObj.nodeValue)
            {
                if (bstObj.leftNode == null)
                {
                    bstObj.leftNode = new Node();
                    bstObj.leftNode.nodeValue = data;
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
                }
                else
                {
                    bstObj.rigntNode = InsertNode(bstObj.rigntNode, data);
                }
            }

            return bstObj;
        }
        public Node DeleteNode(Node bstObj, int data)
        {
            // Node newNode = new Node();
            Node newNode = bstObj;
            if (bstObj.nodeValue == data)
            {
                if (bstObj.leftNode == null)
                {
                    bstObj = newNode.rigntNode;
                }
                else if (bstObj.rigntNode == null)
                {
                    bstObj = newNode.leftNode;
                }
                else
                {
                    Node minNode = bstObj.rigntNode;
                    int minv = minNode.nodeValue;
                    while (minNode.leftNode != null)
                    {
                        minv = minNode.leftNode.nodeValue;
                        minNode = minNode.leftNode;
                    }
                    bstObj.nodeValue = minv;
                    bstObj.rigntNode = DeleteNode(bstObj.rigntNode, minv);
                }
            }
            else
            {
                if (data > bstObj.nodeValue)
                {
                    bstObj.rigntNode = DeleteNode(bstObj.rigntNode, data);
                }
                else
                    bstObj.leftNode = DeleteNode(bstObj.leftNode, data);
            }
            return bstObj;
        }
        public Node preOrder(Node node)
        {
            if (node != null)
            {
                Console.Write(node.nodeValue + " ");
                preOrder(node.leftNode);
                preOrder(node.rigntNode);
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
            root.preOrder(root);

            Console.WriteLine("Pleae Enter Value Which you want to delete :");
            int deleteValue = Convert.ToInt32(Console.ReadLine());
            root = root.DeleteNode(root, deleteValue);
            Console.WriteLine("After Delete Preorder traversal of  tree is : ");
            root.preOrder(root);
        }
    }
}
