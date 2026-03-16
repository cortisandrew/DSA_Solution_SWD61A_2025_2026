using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresImplementations
{
    public class SinglyLinkedList<T>
    {
        public int Count
        {
            get;
            private set;
        }

        public SinglyLinkedListNode<T>? Head
        {
            get; 
            private set;
        }

        public void InsertFirst(T element)
        {
            // Step (i) - create a new node with the element to be stored
            SinglyLinkedListNode<T> newNode = new SinglyLinkedListNode<T>(element);

            // Step (ii) - update the next of the new node
            newNode.Next = Head;

            // Step (iii) - update the head to point towards the new node (which is added at the first position)
            Head = newNode;

            // Step (iv)
            Count++;
        }

        public T RemoveFirst()
        {
            // Step (0) - Validation / Checks
            if (Head == null) // Count == 0 // checking count == 0 is equivalent
            {
                // there are no elements to remove!
                // therefore you can't remove first and you cannot get an element that does not exist!
                throw new InvalidOperationException("You cannot remove an element from an empty linked list!");
            }

            // Step (i) - Store the element that you wish to remove
            T returnValue = Head.Element;

            // Step (ii) - Move Head "one step forward"
            Head = Head.Next;

            // Step (iii)
            Count--;

            // Step (iv)
            return returnValue;
        }

        public SinglyLinkedListNode<T>? Next(SinglyLinkedListNode<T> currentNode)
        {
            ArgumentNullException.ThrowIfNull(nameof(currentNode), "You should not pass a null!");

            // Either return the next node (if it exists) or null if currentNode is the last node (and therefore Next is null)
            return currentNode.Next;
        }

        public SinglyLinkedListNode<T>? Prev(SinglyLinkedListNode<T> currentNode)
        {
            ArgumentNullException.ThrowIfNull(nameof(currentNode), "You should not pass a null!");

            throw new NotImplementedException();
        }

        public override string ToString()
        {
            // I will use an ArrayBasedVector to store all the elements temporarily
            List<string> elements = new List<string>();

            // Start from the first not in the linked list
            SinglyLinkedListNode<T>? currentNode = Head;

            // while I still have nodes (and elements) to print...
            while (currentNode != null)
            {
                // add the element to the elements List
                elements.Add(
                    currentNode.Element?.ToString() ?? string.Empty);

                // Null coalesce operators
                // ?. - if Element is null, do not call Null.ToString(), but instead return null
                // ?? - if the left hand side is null, replace the null with the right hand side

                // move forward one step to the next node
                currentNode = currentNode.Next;
            }

            elements.Add("NULL");

            return string.Join(" -> ", elements);
        }


    }
}
