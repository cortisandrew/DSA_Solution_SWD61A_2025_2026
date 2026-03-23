using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresImplementations
{
    public class QueueUsingSinglyLinkedList<T> : IQueueADT<T>
    {
        private readonly SinglyLinkedList<T> _singlyLinkedList = new SinglyLinkedList<T>();

        public int Count {
            get { 
                return _singlyLinkedList.Count; 
            }
        }

        public T Dequeue()
        {
            // Remove the element that has been waiting the longest (this will be at the Head of list)
            return _singlyLinkedList.RemoveFirst();
        }

        public void Enqueue(T element)
        {
            _singlyLinkedList.InsertLast(element);
        }

        public T Peek()
        {
            if (_singlyLinkedList.Head == null)
                throw new InvalidOperationException("The Queue is empty");

            return _singlyLinkedList.Head.Element;
            
            /*
            if (_singlyLinkedList.Count == 0)
                throw new InvalidOperationException("The Queue is empty");

            return _singlyLinkedList.Head!.Element;
            */

        }
    }
}
