using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresImplementations
{
    public class StackUsingSinglyLinkedLists<T> : IStackADT<T>
    {
        private SinglyLinkedList<T> linkedList = new SinglyLinkedList<T>();
        
        public int Count
        {
            get { return linkedList.Count; }
        }

        public T Peek()
        {
            if (linkedList.Head == null) //(Count == 0) // equivalent!
            {
                throw new InvalidOperationException("You can't peek in an empty stack");
            }

            return linkedList.Head.Element;
        }

        public T Pop()
        {
            return linkedList.RemoveFirst();
        }

        public void Push(T element)
        {
            linkedList.InsertFirst(element);
        }
    }
}
