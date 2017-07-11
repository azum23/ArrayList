using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayListApp
{
    class Program
    {
        public static void PrintValues(IEnumerable obj)
        {
            Console.WriteLine("Dynamic array");
            foreach (var i in obj)
            {
                Console.Write($"[{i}] ");
            }
            Console.WriteLine("\n");
        }

        static void Main(string[] args)
        {
            int[] arg = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            AxArrayList<int> aList = new AxArrayList<int>(arg);
            PrintValues(aList);

            Console.WriteLine(aList.Insert(20, 1));
            PrintValues(aList);

            Console.WriteLine(aList.InsertAfter(21, 20));
            PrintValues(aList);

            var search = 1;
            Console.WriteLine($"The element [{search}] in the array has number {aList.Finder(search)}");

            Console.ReadLine();
        }
    }
}
