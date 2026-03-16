using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresImplementations
{
    /// <summary>
    /// This represents the Node in a singly linked list
    /// It will store: an Element and a Next pointer
    /// </summary>
    public class SinglyLinkedListNode<T>
    {
        private T _element;

        private SinglyLinkedListNode<T>? _next = null;

        public T Element { 
            get 
            { 
                return _element; 
            } 
            internal set
            {
                _element = value;
            }
        }

        public SinglyLinkedListNode<T>? Next
        {
            get
            {
                return _next;
            }
            internal set
            {
                _next = value;
            }
        }

        /// <summary>
        /// Create a new instance of the Node and store the element that is passed as a parameter
        /// Optionally pass the next Node through the constructor
        /// </summary>
        /// <param name="element"></param>
        /// <param name="next"></param>
        public SinglyLinkedListNode(T element, SinglyLinkedListNode<T>? next = null)
        {
            _element = element;
            _next = next;
        }
    }
}
