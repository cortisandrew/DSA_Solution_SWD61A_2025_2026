using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresImplementations
{
    public class StackUsingABV<T> : IStackADT<T>
    {
        private readonly IVectorADT<T> _vector;

        public StackUsingABV()
        {
            _vector = new ArrayBasedVector<T>();
        }

        public int Count
        {
            get { return _vector.Count; }
        }

        public T Peek()
        {
            return _vector.GetElementAtRank(Count - 1);
        }

        public T Pop()
        {
            // Remove the item from the top of the stack (i.e. the last item found at Count - 1)
            return
                _vector.RemoveElementAtRank(Count - 1);
        }

        public void Push(T element)
        {
            // The top of the stack is at the end of the ABV
            _vector.Append(element);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = Count - 1; i >= 0; i--)
            {
                var element = _vector.GetElementAtRank(i);

                sb.AppendLine(element?.ToString() ?? string.Empty);
            }

            for (int i = 0; i < 20; i++)
            {
                sb.Append("=");
            }

            sb.AppendLine();

            return sb.ToString();
        }
    }
}
