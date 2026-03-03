using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresImplementations
{
    public class QueueUsingABV<T> : IQueueADT<T>
    {
        private readonly IVectorADT<T> _vector = new ArrayBasedVector<T>();

        public int Count
        {
            get { return _vector.Count; }
        }

        public T Dequeue()
        {
            // return _vector.RemoveElementAtRank(Count - 1);
            return _vector.RemoveElementAtRank(0);
        }

        public void Enqueue(T element)
        {
            //_vector.InsertElementAtRank(0, element);
            _vector.Append(element);
        }

        public T Peek()
        {
            return _vector.GetElementAtRank(0);
        }

        public override string ToString()
        {
            return _vector.ToString();
        }
    }
}
