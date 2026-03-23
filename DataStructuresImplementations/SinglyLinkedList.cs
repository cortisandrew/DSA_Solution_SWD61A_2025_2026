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

        public SinglyLinkedListNode<T>? Tail
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

            // NewStep - update the tail if necessary
            if (Head == null) // or Count == 0 or Tail == null
            {
                // We are adding the first element to the list
                Tail = newNode;
            }

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

            // Extra Step:
            // if we are removing the last element in the list
            if (Head == Tail)
            {
                // We are also removing the tail (since only one element remains)
                Tail = default;
            }

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

        public SinglyLinkedListNode<T> Prev(SinglyLinkedListNode<T> currentNode)
        {
            // check whether currentNode exists
            ArgumentNullException.ThrowIfNull(nameof(currentNode), "You should not pass a null!");

            // Step (i): Start from the very beginning
            SinglyLinkedListNode<T>? cursor = Head;

            // While our cursor is pointing towards an existing node
            while (cursor != null)
            {
                // check whether the node at the cursor is the previous
                if (cursor.Next == currentNode)
                {
                    // we have found the target!
                    return cursor;
                }

                // no, this is NOT the target! (Prev)
                // move forward one step
                cursor = cursor.Next;
            }

            // The previous was NOT found
            // cursor became null
            throw new ArgumentException(nameof(currentNode), 
                "The currentNode is not within the linked list!");
        }

        public void InsertAfter(SinglyLinkedListNode<T> currentNode, T element)
        {
            // Step (0)
            // check whether currentNode exists
            ArgumentNullException.ThrowIfNull(nameof(currentNode), "You should not pass a null!");

            // Step (i)
            // create the newNode with the new element
            SinglyLinkedListNode<T> newNode 
                = new SinglyLinkedListNode<T>(element);

            // Step (ii)
            // update the next reference of the newNode
            newNode.Next = currentNode.Next;

            // Extra Step:
            // If we are Inserting After the last node (i.e. the last node is the Tail of list)
            if (currentNode == Tail) {
                Tail = newNode; // The new tail is the new node
            }

            // Step (iii)
            // update the currentNode to point to the newNode
            currentNode.Next = newNode;

            // Step (iv)
            Count++;
        }

        public void InsertBefore(SinglyLinkedListNode<T> currentNode, T element)
        {
            // Step (0)
            // check whether currentNode exists
            ArgumentNullException.ThrowIfNull(nameof(currentNode), "You should not pass a null!");

            // Case (i):
            // currentNode == Head
            if (currentNode == Head)
            {
                // this means that we want to insert BEFORE the Head of list
                // this is the InsertFirst
                InsertFirst(element);
                return;
            }

            // Case (ii):
            // currentNode != Head
            // There is at least ONE previous node (if the currentNode is really within the linked list)
            SinglyLinkedListNode<T> prev = Prev(currentNode);
            InsertAfter(prev, element); // this is equivalent to our InsertBefore
            return;
        }

        public T RemoveBefore(SinglyLinkedListNode<T> currentNode, T element)
        {
            // Step (0):
            // validation...
            // check whether currentNode exists
            ArgumentNullException.ThrowIfNull(nameof(currentNode), "You should not pass a null!");

            if (currentNode == Head)
            {
                throw new InvalidOperationException("The current node is the head of list and there is nothing to remove before this node");
            }

            SinglyLinkedListNode<T> PrevNode = Prev(currentNode);

            // Case (i):
            // The previous of the currentNode is the Head of list
            // This is equivalent to the RemoveFirst
            if (PrevNode == Head)
            {
                return RemoveFirst();
            }

            // Case (ii):
            // We are in the middle of the list... you can call Prev of Prev without any issues
            SinglyLinkedListNode<T> newReference = Prev(PrevNode);
            return RemoveAfter(newReference);
        }

        public T RemoveAfter(SinglyLinkedListNode<T> newReference)
        {
            // TODO: Exercise!! - make sure to handle the Tail of list if the node removed happens to be the tail of list!
            throw new NotImplementedException("This is an exercise");
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

        public void InsertLast(T element)
        {
            // if (Count > 0) {
            if (Tail != null)
            {
                InsertAfter(Tail, element);
            }
            else // linked list is empty
            {
                InsertFirst(element);
            }
        }
    }
}
