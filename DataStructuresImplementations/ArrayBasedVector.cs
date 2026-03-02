using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresImplementations
{
    /// <summary>
    /// The ArrayBasedVector is a Data Structure
    /// It is a implementation of the IVectorADT
    /// 
    /// It uses a array to store the elements
    /// The index of the array represents the rank
    /// There will be no gaps within the array
    /// We will leave some space at the end to allow more elements to be added
    /// </summary>
    public class ArrayBasedVector<T> : IVectorADT<T>
    {
        private const int DEFAULT_ARRAY_LENGTH = 4;
        private T[] _elements;

        private int _count = 0;
        public int Count
        {
            get { return _count; }
            private set { _count = value; }
        }
        public T GetElementAtRank(int rank)
        {
            if (rank < 0 || rank >= Count)
            {
                throw new ArgumentOutOfRangeException(
                    $"The value of the {nameof(rank)} paramter must be between 0 and {Count - 1} both inclusive.",
                    nameof(rank));
            }

            return _elements[rank];
        }

        public ArrayBasedVector(int arrayLength = DEFAULT_ARRAY_LENGTH)
        {
            _elements = new T[arrayLength];
        }

        public void InsertElementAtRank(int rank, T element)
        {
            if (rank < 0 || rank > Count)
            {
                throw new ArgumentOutOfRangeException(
                    $"The value of the {nameof(rank)} paramter must be between 0 and {Count} both inclusive.",
                    nameof(rank));
            }

            if (Count == _elements.Length)
            {
                // Array is full

                // create a larger array (twice the size)
                T[] newElements = new T[_elements.Length * 2];

                // copy all the elements from the old array to the new array
                _elements.CopyTo(newElements, 0);

                // replace the reference to use the newElements
                _elements = newElements;
            }

            // if the newly added element is NOT the last element,
            // we need to shift the elements to make space
            for (int i = Count - 1; i >= rank; i--)
            {
                _elements[i + 1] = _elements[i];
            }


            // Place the new element in the correct position
            _elements[rank] = element;

            // indicate that we have a new element
            Count++;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[ ");

            sb.Append(
                string.Join(", ", _elements.Take(Count))
                );

            sb.Append(" ]");

            return sb.ToString();
        }

        public void Append(T element)
        {
            // The next available position is Count
            // Place the element in the last position
            InsertElementAtRank(Count, element);
        }
        public T ReplaceElementAtRank(int rank, T newElement)
        {
            throw new NotImplementedException("TODO: Implement this as an exercise!");
        }

        public T RemoveElementAtRank(int rank)
        {
            if (rank < 0 || rank >= Count)
            {
                throw new ArgumentOutOfRangeException(
                    $"The value of the {nameof(rank)} paramter must be between 0 and {Count - 1} both inclusive.",
                    nameof(rank));
            }

            T elementToRemove = _elements[rank];

            // shift elements back
            for (int i = rank; i < Count - 1; i++)
            {
                _elements[i] = _elements[i + 1];
            }

            // prevent memory leaks
            // The value at _elements[Count - 1] needs to be removed
            // Otherwise, the program keeps a reference
            // and the GC will not remove it
            _elements[Count - 1] = default;

            // Decrement the count (we just removed one element!)
            Count--;

            return elementToRemove;
        }
    }
}
