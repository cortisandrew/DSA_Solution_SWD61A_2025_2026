using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace RecursiveAlgorithms
{
    public class QuickSort
    {
        public void QS(int[] arrayToSort)
        {
            QS(arrayToSort, 0, arrayToSort.Length - 1);
        }

        private void QS(int[] arrayToSort, int left, int right)
        {
            // Base Case
            if (right - left < 1) // BUG FIX! < 1 not <= 1!!
            {
                // the sub-array has 0 or 1 elements, sub-array is already sorted, nothing to do
                return;
            }

            // Step 1: Select the pivot element
            int pivotIndex = left; // leftmost pivot //or otherwise call a metehod to select the pivot: SelectPivot(arrayToSort, left, right);

            // Step 2: Partition the array around the pivot
            int finalPivotIndex = Partitioner(arrayToSort, pivotIndex, left, right);

            // Step 3: Recursively call Quicksort on the left and right subarrays
            QuickSort(arrayToSort, left, finalPivotIndex - 1);
            QuickSort(arrayToSort, finalPivotIndex + 1, right);
        }

        private int Partitioner(int[] arrayToSort, int pivotIndex, int left, int right)
        {
            // Example of partitioning that does not use in-place
            // slow and not optimal

            // implement the below using an extension method
            arrayToSort.Swap(pivotIndex, left);
            int pivotValue = arrayToSort[left];

            List<int> smallerElements = new List<int>();
            List<int> largerElements = new List<int>();

            for (int  i = left + 1;  i <= right;  i++)
            {
                if (arrayToSort[i] < pivotValue)
                {
                    smallerElements.Add(arrayToSort[i]);
                }
                else
                {
                    largerElements.Add(arrayToSort[i]);
                }
            }

            int k = left;
            // copy back to the original array
            // starting from smallerElements, pivotValue and then largerElements

            for (int i = 0; i < smallerElements.Count; i++)
            {
                arrayToSort[k] = smallerElements[i];
                k++;
            }

            arrayToSort[k] = pivotValue; // place the pivot in its final position
            k++;

            for (int i = 0; i < largerElements.Count; i++)
            {
                arrayToSort[k] = largerElements[i];
                k++;
            }
        }
    }
}
