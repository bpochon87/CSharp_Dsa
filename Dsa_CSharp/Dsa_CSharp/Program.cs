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
            //// C# built-in sort method
            //int[] example = new int[] { 3, 1, 6, 2, 8, 0 };
            //Array.Sort(example);
            //// If we use Console.WriteLine(example);, it won't print contents. To print contents,
            //// we need to iterate over each element in the collection.
            //foreach(int i in example)
            //{
            //    Console.WriteLine(i + " ");
            //}

            //// C# built-in binary search algo
            //int[] example1 = new int[] { 1, 3, 5, 6, 8, 11 };
            //Console.WriteLine(Array.BinarySearch(example1, 6));

            //List<int> ints = new List<int>() { 5, 10, 15, 20, 25, 30 };
            //Console.WriteLine(Program.interpolationSearch(example1, 6, 3));

            //// Tree traversal algorithms.
            //Node leftNode = new Node()
            //{
            //    data = 1,
            //    left = null,
            //    right = null
            //};

            //Node rightNode = new Node()
            //{
            //    data = 3,
            //    left = null,
            //    right = null,
            //};

            //Node root = new Node()
            //{
            //    data = 2,
            //    left = leftNode,
            //    right = rightNode
            //};
            //PostOrder(root);

            // Selection sort.
            int[] example2 = new int[] { 1, 5, -2 };
            Console.WriteLine(selectionSort(example2));

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

        ////////////////////////////////////////////////////////////////////////////////////////
        // Sorting algorithms

        // Selection sort
        static int[] selectionSort(int[] arr)
        {
            int len = arr.Length;
            for(int i = 0; i < len; i++)
            {
                int minIndex = i;
                for (int j = 0; j < len; j++)
                {
                    if (arr[j] < arr[minIndex])
                    {
                        minIndex = j;
                    }
                }
                int temp = arr[i];
                arr[i] = arr[minIndex];
                arr[minIndex] = temp;
            }
            return arr;
        }

        // Bubble sort algorithm
        static int[] bubbleSort(int[] arr)
        {
            int len = arr.Length;
            for(int i = len - 1; i >= 0; i--)
            {
                for(int j = 1; j <= i; j++)
                {
                    if (arr[j - 1] > arr[j])
                    {
                        int temp = arr[j - 1];
                        arr[j - 1] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
            return arr;
        }
        // Quick sort algorithm
        // Two functions: one to determine the partition and one to perform quick sort
        // Function #1: determine partition
        static int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[left];
            while(true)
            {
                while (arr[left] < pivot)
                {
                    left++;
                }

                while (arr[right] > pivot)
                {
                    right--;
                }

                if(left < right)
                {
                    if (arr[left] == arr[right])
                    {
                        return right;
                    }
                }
            }
        }

        // Function #2: Quick Sort
        static int[] quickSort(int[] arr, int left, int right)
        {
            if(left < right)
            {
                int pivot = Partition(arr, left, right);
                if(pivot > 1)
                {
                    quickSort(arr, left, pivot - 1);
                }
                if(pivot + 1 < right)
                {
                    quickSort(arr, pivot + 1, right);
                }
            }
            return arr;
        }

        // Merge sort algorithm
        public static int[] mergeSort(int[] array)
        {
            int[] left;
            int[] right;
            int[] result = new int[array.Length];

            if (array.Length <= 1)
            {
                return array;
            }

            int midPoint = array.Length / 2;

            left = new int[midPoint];

            if(array.Length % 2 == 0)
            {
                right = new int[midPoint]; 
            }
            else
            {
                right = new int[midPoint + 1];
            }

            for (int i = 0; i < midPoint; i++)
            {
                left[i] = array[i];
            }

            int x = 0;

            for (int i = midPoint; i < array.Length; i++)
            {
                right[x] = array[i];
                x++;
            }

            left = mergeSort(left);
            right = mergeSort(right);
            result = merge(left, right);
            return result;
        }

        // Our merge function
        public static int[] merge(int[] left, int[] right)
        {
            int resultLength = right.Length + left.Length;
            int[] result = new int[resultLength];
            int indexLeft = 0, indexRight = 0, indexResult = 0;
            while(indexLeft < left.Length || indexRight < right.Length)
            {
                if(indexLeft < left.Length && indexRight < right.Length)
                {
                    if (left[indexLeft] <= right[indexRight])
                    {
                        result[indexResult] = left[indexLeft];
                        indexLeft++;
                        indexResult++;
                    }
                    else
                    {
                        result[indexResult] = right[indexRight];
                        indexRight++;
                        indexResult++;
                    }
                }
                else if (indexLeft < left.Length)
                {
                    result[indexResult] = left[indexLeft];
                    indexLeft++;
                    indexResult++;
                }
                else if(indexRight < right.Length)
                {
                    result[indexResult] = right[indexRight];
                    indexRight++;
                    indexResult++;
                }
            }
            return result;
        }

        // Insertion sort algorithm.
        static int[] insertionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int value = arr[i];
                for(int j = i - 1; j > -1 && arr[j] > value; j--)
                {
                    arr[j + 1] = arr[j];
                }
                arr[i + 1] = value;
            }
            return arr;
        }

        // Radix sort algorithm
        static int[] radixSort(int[] data)
        {
            int[] temp = new int[data.Length];

            for(int shift = 31; shift > -1; shift--)
            {
                int j = 0;

                for (int i = 0; i < data.Length; i++)
                {
                    bool move = (data[i] << shift) >= 0;

                    if(shift == 0 ? !move : move)
                    {
                        data[i - j] = data[i];
                    } else
                    {
                        temp[j++] = data[i];
                    }
                }
                Array.Copy(temp, 0, data, data.Length - j, j);
            }
            return data;
        }

        // Heap sort algorithm
        public static int[] heapSort(int[] arr)
        {
            int n = arr.Length;
            for(int i = n / 2 - 1; i >= 0; i--)
            {
                heapify(arr, n, i);
            }

            // The purpose of this loop is to one-by-one extract an element from the heap.
            for(int i = n - 1; i >= 0; i--)
            {
                swap(arr, 0, i);
                heapify(arr, i, 0);
            }
        }

        static void heapify(int[] arr, int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (left < n && arr[left] > arr[largest])
            {
                largest = left;
            }

            if (right < n && arr[right] > arr[largest])
            {
                largest = right;
            }

            if(largest != i)
            {
                swap(arr, i, largest);
                heapify(arr, n, largest);
            }
        }

        static void swap(int[] arr, int element1, int element2)
        {
            int swap = arr[element1];
            arr[element1] = arr[element2];
            arr[element2] = swap;
        }

        // Shell sort algorithm
        static int[] shellSort(int[] arr)
        {
            int length = arr.Length;
            for (int gap = length / 2; gap > 0; gap /= 2)
            {
                for(int i = gap; i < length; i += 1)
                {
                    int temp = arr[i];
                    int j;
                    for(j = 1; j >= gap && arr[j - gap] > temp; j -= gap)
                    {
                        arr[j] = arr[j - gap]; 
                    }
                    arr[j] = temp;
                }
            }
            return arr;
        }
    }
}
