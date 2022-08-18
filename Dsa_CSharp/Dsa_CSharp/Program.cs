using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsa_CSharp
{

    // This class is referenced by our DepthFirstSearchTraversalOnTree method.
    public class Node
    {
        public Node left;
        public Node right;
        public int data;
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //// C# built-in binary search algo
            //int[] example = new int[] { 1, 3, 5, 6, 8, 11 };
            //Console.WriteLine(Array.BinarySearch(example, 6));

            //List<int> ints = new List<int>() { 5, 10, 15, 20, 25, 30 };
            //Console.WriteLine(Program.interpolationSearch(example, 6, 3));

            // Tree traversal algorithms.
            Node leftNode = new Node()
            {
                data = 1,
                left = null,
                right = null
            };

            Node rightNode = new Node()
            {
                data = 3,
                left = null,
                right = null,
            };

            Node root = new Node()
            {
                data = 2,
                left = leftNode,
                right = rightNode
            };
            PostOrder(root);

            Console.ReadLine();
        }

        // Linear search algo. Less efficient on larger data sets.
        static int linearSearch(List<int> elements, int x)
        {
            int length = elements.Count;
            for (int i = 0; i < length; i++)
            {
                if (elements[i] == x)
                {
                    return i;
                }
            }
            return -1;
        }

        // Binary search algo.
        static int binarySearch(List<int> elements, int x)
        {
            int start = 0;

            // stop indicates ending index of portion of the collection we're searching.
            // Subtracting one gives us our index.
            int stop = elements.Count - 1;

            // middle indicates middle index of collection where binary search will start.
            int middle = (int)((start + stop) / 2);
            while (elements[middle] != x && start < stop)
            {
                if (x < elements[middle])
                {
                    // Moving to left side of collection.
                    stop = middle - 1;
                }
                else
                {
                    // Moving to right side of collection.
                    start = middle + 1;
                }

                middle = (int)((start + stop) / 2);
            }

            return (elements[middle] != x) ? -1 : middle;
        }

        // Interpolation search algo.
        static int interpolationSearch(int[] arr, int length, int x)
        {
            int low = 0;
            int high = length - 1;
            while (low <= high && x >= arr[low] && x <= arr[high])
            {
                if (low == high)
                {
                    if (arr[low] == x)
                    {
                        return low;
                    }
                    else
                    {
                        return -1;
                    }
                }

                // This is probing the position while keeping in mind uniform distribution.
                int pos = low + (high - low) / (arr[high] - arr[low]) * (x - arr[low]);

                if (arr[pos] == x)
                {
                    return pos;
                }

                if (arr[pos] < x)
                {
                    low = pos + 1;
                }
                else
                {
                    high = pos - 1;
                }
            }
            return -1;
        }

        // Depth-first tree traversal algo
        public void DepthFirstSearchTraversalOnTree(Node root)
        {
            // Initializing new Stack of Nodes
            Stack<Node> nodes = new Stack<Node>();
            nodes.Push(root);
            while (nodes.Count > 0)
            {
                Node node = nodes.Pop();

                if (node.right != null)
                {
                    nodes.Push(node.right);
                }

                if (node.left != null)
                {
                    nodes.Push(node.left);
                }

                Console.WriteLine(" " + node.data);
            }
        }

        //// Depth-first graph traversal algo
        //// Non-working due to never initializing graph.
        //public HashSet<int> DepthFirstSearchTraversalOnGraph(Node root)
        //{
        //    HashSet<int> visited = new HashSet<int>();

        //    // Say: if root node is not in the adjacency list...
        //    if (!graph.AdjacencyList.ContainsKey(root))
        //    {
        //        return visited;
        //    }

        //    Stack<int> stack = new Stack<int>();
        //    stack.Push(root.data);

        //    while (stack.Count > 0)
        //    {
        //        int vertex = stack.Pop();

        //        if (visited.Contains(vertex))
        //        {
        //            continue;
        //        }

        //        visited.Add(vertex);

        //        foreach (var neighbor in graph.AdjacencyList[vertex])
        //        {
        //            // Say: if the visited HashSet does not contain neighbor...
        //            if (!visited.Contains(neighbor))
        //            {
        //                stack.Push(neighbor);
        //            }
        //        }

        //        return visited;
        //    }
        //}

        // Breadth-first tree traversal algo
        // Using Node class from top
        public void BreadthFirstSearchTraversalOnTree(Node root)
        {
            Queue<Node> nodes = new Queue<Node>();
            if (root == null)
            {
                return;
            }

            nodes.Enqueue(root);
            while (nodes.Count > 0)
            {
                Node node = nodes.Dequeue();
                Console.WriteLine(" " + node.data);
                if (node.left != null)
                {
                    nodes.Enqueue(node.left);
                }
                if (node.right != null)
                {
                    nodes.Enqueue(node.right);
                }
            }
        }

        ////Breadth-first graph traversal algo
        ////Non-working as graph is never initialized.
        //public HashSet<int> BreadthFirstTraversalOnGraph(Node root)
        //{
        //    HashSet<int> visited = new HashSet<int>();

        //    if (!graph.AdjacencyList.ContainsKey(root))
        //    {
        //        return visited;
        //    }

        //    Queue<int> q = new Queue<int>();
        //    q.Enqueue(root.data);
        //    while (q.Count > 0)
        //    {
        //        int vertex = q.Dequeue();

        //        if (visited.Contains(vertex))
        //        {
        //            continue;
        //        }

        //        visited.Add(vertex);

        //        foreach (var neighbor in graph.AdjacencyList[vertex])
        //        {
        //            if (!visited.Contains(neighbor))
        //            {
        //                q.Enqueue(neighbor);
        //            }
        //        }
        //    }
        //return visited;
        //}

        // In-order tree traversal algo
        static void InOrder(Node root)
        {
            if(root != null)
            {
                InOrder(root.left);
                Console.WriteLine(root.data);
                InOrder(root.right);
            }
        }

        // Pre-order tree traversal algo
        static void PreOrder(Node root)
        {
            if(root != null)
            {
                Console.WriteLine(root.data);
                PreOrder(root.left);
                PreOrder(root.right);
            }
        }

        // Post-order tree traversal algo
        static void PostOrder(Node root)
        {
            if(root != null)
            {
                PostOrder(root.left);
                PostOrder(root.right);
                Console.WriteLine(root.data);
            }
        }
    }
}
