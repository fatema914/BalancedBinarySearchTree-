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
        public void InsertNode(Node node)
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
        }
        public Node InsertNodeRec(Node node, int data)
        {
            if (data < node.NodeValue)
            {
                if (node.LeftNode == null)
                {
                    node.LeftNode = new Node
                    {
                        NodeValue = data,
                        Height = 1
                    };
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
                    node.RigntNode = new Node
                    {
                        NodeValue = data,
                        Height = 1
                    };
                }
                else
                {
                    node.RigntNode = InsertNodeRec(node.RigntNode, data);
                }
            }
            node = CalculateHeightOfNode(node);
            node = CalculateHeightDiffAndRotateNode(node, data);
            return node;
        }
        private Node CalculateHeightDiffAndRotateNode(Node node, int data)
        {
            int heightDifference = 0;
            if (node.LeftNode != null && node.RigntNode == null)
            {
                heightDifference = node.LeftNode.Height;
            }
            else if (node.LeftNode == null && node.RigntNode != null)
            {
                heightDifference = -(node.RigntNode.Height);
            }
            else if (node.LeftNode != null && node.RigntNode != null)
            {
                heightDifference = node.LeftNode.Height - node.RigntNode.Height;
            }

            if (heightDifference > 1)
            {
                if (data < node.LeftNode.NodeValue)
                {
                    node = LeftRotation(node);
                }
                else
                {
                    node = LeftRightRotation(node);
                }
            }
            else if (heightDifference < -1)
            {
                if (data > node.RigntNode.NodeValue)
                {
                    node = RightRotation(node);
                }
                else
                {
                    node = RightLeftRotation(node);
                }
            }
            return node;
        }
        private Node CalculateHeightOfNode(Node node)
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
        private Node RightRotation(Node node)
        {
            Node tempNode = node.RigntNode;
            node.RigntNode = tempNode.LeftNode;
            tempNode.LeftNode = node;
            tempNode.LeftNode = CalculateHeightOfNode(tempNode.LeftNode);
            return tempNode;
        }
        private Node LeftRotation(Node node)
        {
            Node tempNode = node.LeftNode;
            node.LeftNode = tempNode.RigntNode;
            tempNode.RigntNode = node;
            tempNode.RigntNode = CalculateHeightOfNode(tempNode.RigntNode);
            return tempNode;
        }
        private Node LeftRightRotation(Node node)
        {
            Node tempNode = node.LeftNode;
            node.LeftNode = RightRotation(tempNode);
            node = LeftRotation(node);
            node = CalculateHeightOfNode(node);
            return node;
        }
        private Node RightLeftRotation(Node node)
        {
            Node tempNode = node.RigntNode;
            node.RigntNode = LeftRotation(tempNode);
            node = RightRotation(node);
            node = CalculateHeightOfNode(node);
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
        public void DeleteNode(Node node)
        {
            root = DeleteNodeRec(root, node.NodeValue);
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
                 CalculateHeightOfNode(node);
                 CalculateHeightDiffAndRotateNode(node, node.NodeValue);
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

