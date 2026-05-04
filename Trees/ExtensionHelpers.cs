using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    /// <summary>
    /// Static class to create extension methods
    /// </summary>
    public static class ExtensionHelpers
    {
        /// <summary>
        /// The method has to be static because it is an extension method
        /// The first parameter, has a "this" modifier.
        /// This means that all instances of type <see cref="List{T}"/> will have access to this method
        /// The method signature will match the one I provide, except I don't need the "this" parameter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <exception cref="NotImplementedException"></exception>
        public static void Swap<T>(this List<T> list, int i, int j)
        {
            T temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }

        public static List<int> HeapSort(this List<int> list)
        {
            BinaryMinHeap heap = new BinaryMinHeap();
            List<int> sortedList = new List<int>(list.Count); // array size = n, so we don't have to worry about array growth when adding elements to the sorted list

            // get all elements from your original list (xn)
            foreach (int i in list)
            {
                // add each element to the heap O(log n)
                heap.Add(i);
            }

            // n elements to remove (xn)
            while (heap.Count > 0)
            {
                // O(log n) -- assuming no array growth
                sortedList.Add(
                    heap.RemoveMin()
                );
            }
            // O(n log n) total time: ( 2 x c x n x log n)
            return sortedList;
        }
    }
}
