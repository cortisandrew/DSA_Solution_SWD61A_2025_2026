using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresImplementations
{
    /// <summary>
    /// The queue stores a set of elements
    /// Elements are enqueued to the back of the queue
    /// The element that has been in the queue the longest can be removed from the front of the queue through an operation called dequeue
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IQueueADT<T>
    {
        /// <summary>
        /// Add the element to the back of the queue
        /// </summary>
        /// <param name="element"></param>
        void Enqueue(T element);

        /// <summary>
        /// Remove the element from the front of the queue3
        /// </summary>
        /// <returns></returns>
        T Dequeue();

        T Peek();

        int Count { get; }
    }
}
