using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsa_CSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // C# built-in binary search algo
            int[] example = new int[] { 1, 3, 5, 6, 8, 11 };
            Console.WriteLine(Array.BinarySearch(example, 6));

            List<int> ints = new List<int>() { 5, 10, 15, 20, 25, 30 };
            Console.WriteLine(Program.interpolationSearch(example, 6, 3));

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
            while(low <= high && x >= arr[low] && x <= arr[high])
            {
                if(low == high)
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
    }
}
