using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresImplementations
{
    /// <summary>
    /// A set of elements
    /// Elements get pushed to the top of the stack
    /// Elements get popped from the top of the stack
    /// The newest elements pushed gets removed first
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IStackADT<T>
    {
        /// <summary>
        /// Push the newest item to the top of the stack
        /// </summary>
        /// <param name="item"></param>
        void Push(T element);

        /// <summary>
        /// Pop the newest element from the top of the stack
        /// </summary>
        /// <returns></returns>
        T Pop();

        /// <summary>
        /// Look at the element at the top of the stack WITHOUT removing
        /// </summary>
        /// <returns></returns>
        T Peek();

        /// <summary>
        /// Number of element on stack
        /// </summary>
        int Count { get; }
    }
}
