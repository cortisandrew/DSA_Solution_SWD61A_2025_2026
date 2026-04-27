using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trees;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Trees
{
    public class BinarySearchTree<T>
    {
        public BinarySearchTree() { }

        public Vertex<T>? Root { get; private set; }

        /// <summary>
        /// Adds a new vertex to the tree with the key and data passed as parameters
        /// It is important that the ordered property of the BST (binary search tree) is maintained after the insertion.
        /// This allows us to assume that the BST initially is ordered and it remains ordered after every insertion.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        public void Insert(int key, T data)
        {
            if (Root == null)
            {
                Root = new Vertex<T>(key, data);
            }
            else
            {
                // Root exists
                Root.Insert(key, data);

            }

            // if there is extra code here..
        }


        /// <summary>
        /// Search for the vertex with the key being searched
        /// If the vertex is found, return the data associated with that vertex
        /// Otherwise, throw an exception (KeyNotFoundException) indicating that the key was not found in the tree
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public T Search(int key)
        {
            if (Root == null)
            {
                // there are no vertices in the tree and therefore no data
                // the key cannot be found in the tree
                throw new KeyNotFoundException($"The key {key} was not found in the tree");
            }
            else
            {
                return Root.Search(key);
            }
        }

        /// <summary>
        /// Produces a string in DOT langauge that can be used to visualise your tree
        /// Note that if you have nodes with duplicate keys, you will have an issue in the diagram
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("digraph {");
            
            if (Root != null)
            {
                stringBuilder.AppendLine(Root.ToString());
            }

            stringBuilder.AppendLine("}");
            return stringBuilder.ToString();
        }
    }
}