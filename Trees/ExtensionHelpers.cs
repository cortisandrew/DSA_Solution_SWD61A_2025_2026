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
            // Swap elements at index i and j in the list
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

        /// <summary>
        /// in-place quicksort
        /// </summary>
        /// <param name="_arrayToSort"></param>
        public static void QuickSort(this int[] _arrayToSort)
        {
            QuickSort(_arrayToSort, 0, _arrayToSort.Length - 1);
        }

        private static void QuickSort(int[] _arrayToSort, int left, int right)
        {
            // base case:
            // if the subarray has 0 or 1 elements, it is already sorted
            if (right - left <= 1)
            {
                // the subarray has 0 or 1 elements, nothing to sort
                return;
            }

            // Select the pivot element
            int pivotIndex = SelectPivot(_arrayToSort, left, right); // method to select the pivot

            // Partition the array around the pivot
            // Partition should provide the index of the pivot element in the partitioned array
            int newPivotIndex = Partition(_arrayToSort, pivotIndex, left, right); // partition around the pivot and return the new index of the pivot element after partitioning

            // Recursively call Quicksort TWICE, on the left and right subarrays
            // Usually, the length (right - left + 1) of the subarrays is about half
            QuickSort(_arrayToSort, left, newPivotIndex - 1); // sort the left subarray (elements less than the pivot)
            QuickSort(_arrayToSort, newPivotIndex + 1, right); // sort the right subarray (elements greater than the pivot)

            // if we are lucky, the pivot happens to be close to the middle position, so Quicksort will call itself with two roughly equal sub-arrays
            // if the pivot is always large or small (close to the edge), then you will have a worst case scenario
        }

        private static int SelectPivot(int[] arrayToSort, int left, int right)
        {
            return left; // leftmost pivot
        }

        /// <summary>
        /// The most commonly used partitioning schemes are Lomuto partition scheme and Hoare partition scheme
        /// </summary>
        /// <param name="_arrayToSort"></param>
        /// <param name="pivotIndex"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private static int Partition(int[] _arrayToSort, int pivotIndex, int left, int right)
        {
            throw new NotImplementedException();
        }
    }
}
