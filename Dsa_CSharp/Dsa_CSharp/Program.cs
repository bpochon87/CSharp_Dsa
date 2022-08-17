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
            List<int> ints = new List<int>() { 5, 10, 15, 20, 25, 30 };
            Console.WriteLine(Program.linearSearch(ints, 35));

            Console.ReadLine();
        }

        // Linear search algorithm. Less efficient on larger data sets.
        static int linearSearch(List<int> elements, int x)
        {
            int length = elements.Count;
            for(int i = 0; i < length; i++)
            {
                if (elements[i] == x)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
