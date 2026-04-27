using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees;

/// <summary>
/// Represents a vertex in a binary tree.
/// Each vertex has a key, data, and references to its children (two at most
/// </summary>
/// <typeparam name="T"></typeparam>
public class Vertex<T>
{
    /// <summary>
    /// The data type of the key must have a sort-order.
    /// In C#, you can use any type that implements the IComparable interface, such as int, string, etc.
    /// However, for simplicity, we will use int as the data type because it is easy to understand and provides operators like >=
    /// </summary>
    public int Key { get; private set; }

    /// <summary>
    /// This is the data associated with the key. E.g. Key is the Id of a person, and Data is the records of that same person.
    /// </summary>
    public T Data { get; private set; }

    /// <summary>
    /// This is the left child of the vertex
    /// If there is no left child, the Left will have a null value
    /// </summary>
    public Vertex<T>? Left { get; private set; }

    /// <summary>
    /// This is the right child of the vertex
    /// If there is no right child, the Right will have a null value
    /// </summary>
    public Vertex<T>? Right { get; private set; }

    public Vertex(int key, T data)
    {
        Key = key;
        Data = data;
    }

    #region Operations

    internal void Insert(int key, T data)
    {
        // if the new key is greater than the current vertex's key
        // to maintain the ordered property,
        // the new vertex must be on the right subtree of the current vertex
        if (key > Key)
        {
            // There are two cases:
            // Case (i): the right sub-tree is empty, then we can insert the new vertex as the right child of the current vertex
            if (Right == null)
            {
                Right = new Vertex<T>(key, data);
            }
            else // Case (ii): the right sub-tree is not empty
            {
                // This means that there is a Right vertex
                // So, we recursively call the Insert method on the right vertex
                Right.Insert(key, data);
            }
        }
        else // Left case is similar, this happens when the new key is less than or equal to the current vertex's key
        {
            if (Left == null)
            {
                Left = new Vertex<T>(key, data);
            }
            else
            {
                Left.Insert(key, data);
            }
        }
    }

    internal T Search(int key)
    {
        // If the key of the current vertex is the key being searched
        if (Key == key)
        {
            // we have found the target vertex, so we return the data associated with that vertex
            return Data;
        }

        // If the key that I'm searching for is larger than the current key
        // we search in the right subtree of the current vertex (ordered-property of the BST)
        if (key > Key)
        {
            if (Right == null)
            {
                // there are no keys to search for in the right subtree
                // this means that the key is not found in the tree
                throw new KeyNotFoundException($"The key {key} was not found in the tree");
            }

            return Right.Search(key);
        }
        else // key < Key
        {
            if (Left == null)
            {
                // there are no keys to search for in the left subtree
                // this means that the key is not found in the tree
                throw new KeyNotFoundException($"The key {key} was not found in the tree");
            }

            return Left.Search(key);
        }
    }

    #endregion
}
