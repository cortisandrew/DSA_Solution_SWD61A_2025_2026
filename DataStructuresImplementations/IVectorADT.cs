using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresImplementations
{
    /// <summary>
    /// This interface represents the VectorADT
    /// Whoever implements this interface, must provide a VectorADT.
    /// It will store an ORDERED set of elements. Each element will have its rank
    /// The VectorADT will also provide the necessary operations
    /// </summary>
    /// <typeparam name="T">
    /// This is the type for the elements to be stored
    /// </typeparam>
    public interface IVectorADT<T>
    {
        /// <summary>
        /// Gets the number of elements contained in the VectorADT.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Returns the element at the given rank
        /// </summary>
        /// <param name="rank">The rank of the element to return (must be between 0 and Count - 1 inclusive)</param>
        /// <returns>The element with the given rank (i.e. the number of elements before it is equal to rank)</returns>
        T GetElementAtRank(int rank);

        /// <summary>
        /// Replaces the element at the given rank and returns the old element which was replaced
        /// </summary>
        /// <param name="rank"></param>
        /// <param name="newElement"></param>
        /// <returns></returns>
        T ReplaceElementAtRank(int rank, T newElement);

        T RemoveElementAtRank(int rank);

        /// <summary>
        /// Add a new element at the specified rank
        /// This means that some existing elements may have their rank changed
        /// </summary>
        /// <param name="rank">Must be between a value of 0 and Count (inclusive)</param>
        /// <param name="element"></param>
        void InsertElementAtRank(int rank, T element);

        void Append(T element);
    }
}
