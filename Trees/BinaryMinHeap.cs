using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    public class BinaryMinHeap
    {
        List<int> _data = new List<int>();  // int has a sort-order, this will be our key

        // the number of elements is equal to the count of the list
        public int Count => _data.Count;

        public void Add(int key)
        {
            // the new key is added. We have the complete property, BUT we need to maintain the min-heap-order property
            int currentIndex = _data.Count;  // the index of the new key will be the last index in the list
            _data.Add(key);  // add the new key to the end of the list

            UpHeap(currentIndex);  // restore the min-heap-order property by performing up-heap bubbling
        }

        private void UpHeap(int currentIndex)
        {
            // if currentIndex is 0, then we are at the root and there is no parent to compare with, so we can stop the bubbling process
            if (currentIndex == 0)
            {
                return;
            }

            // compare the current key with its parent key. If the current key is smaller than its parent key, we need to swap them
            int parentIndex = GetParentIndex(currentIndex);

            // if the key at the current index is strictly smaller than the key of the parent,
            // then we need to swap!
            if (_data[currentIndex] < _data[parentIndex])
            {
                // swap the current key with its parent key
                _data.Swap(currentIndex, parentIndex);
                // keep carrying out the UpHeap at the parent index (because it might still not have min-heap-order with its parent)
                UpHeap(parentIndex);
            }
            // else
            // heap-order is satisfied, we can stop the bubbling process
            return;
        }

        public int RemoveMin()
        {
            int result = _data[0];  // the minimum key is at the root (index 0)

            int currentIndex = _data.Count - 1;  // the index of the last key in the list (where we will not have heap-order after the swap)
            _data.Swap(0, currentIndex);  // swap the minimum key at the root with the last key in the list
            _data.RemoveAt(currentIndex);  // remove the last key (which contains the minimum key that is removed)

            DownHeap(0);  // restore the min-heap-order property by performing down-heap bubbling starting at the root (index 0)

            return result;
        }

        private void DownHeap(int currentIndex)
        {
            int leftChildIndex = GetLeftChildIndex(currentIndex);

            // if current index does not have any childer, stop
            #region Step 1: Check if the current index has children
            // if the node has children, it will first have the left child before the right child
            // because the heap is complete (fill in left to right)

            if (leftChildIndex >= _data.Count)
            {
                // the followin would be out-of-bounds:
                // _data[leftChildIndex]

                // this means, no left child, and therefore no right child
                return;
            }
            #endregion

            // we have at least one child, find the smallest child
            #region Step 2: Find the smallest child of the current index
            int smallestChildIndex = -1; // dummy value, will be updated below

            // if current has one child, or two children, find the smallest child out of these two
            if (leftChildIndex == _data.Count -1)
            {
                // the left child is the last node in the list, so there is no right child (complete property)
                // the index is already set above.
                smallestChildIndex = leftChildIndex;
            }
            else
            {
                // if have two children at the index
                int rightChildIndex = GetRightChildIndex(currentIndex);

                // find the smallest child index by comparing the key of the left child and the key of the right child
                if (_data[rightChildIndex] < _data[leftChildIndex])
                {
                    smallestChildIndex = rightChildIndex;
                }
                else
                {
                    smallestChildIndex = leftChildIndex;
                }
            }
            #endregion

            // we now know the smallest child and can compare and preserve the min-heap-order. Might require a recursive call
            #region Step 3: Compare the key of the current index with the key of the smallest child
            // we now know that we have at least one child, and we also know the index of the smallest child
            // we do not need to worry about the other child (if it exists) because the <= operation is transitive

            // compare the key of the current index with the key of the smallest child.
            if (_data[currentIndex] <= _data[smallestChildIndex])
            {
                // the key of the current index is SMALLER than the key of the smallest child,
                // STOP
                return;
            }
            // continue the DownHeap at the index of the smallest child (because it might still not have heap-order with its children)
            _data.Swap(currentIndex, smallestChildIndex);
            DownHeap(smallestChildIndex);
            #endregion
        }

        #region Supporting Methods

        private int GetLeftChildIndex(int parentIndex)
        {
            return 2 * parentIndex + 1;
        }

        private int GetRightChildIndex(int parentIndex)
        {
            return 2 * parentIndex + 2;
        }

        private int GetParentIndex(int childIndex)
        {
            // integer division will round down the result (absorption)
            return (childIndex - 1) / 2;
        }

        #endregion
    }
}
