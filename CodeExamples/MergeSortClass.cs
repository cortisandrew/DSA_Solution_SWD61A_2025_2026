using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExamples
{
    public class MergeSortClass
    {
        public List<int> MergeSort(List<int> a)
        {
            // Base case
            if (a.Count <= 1)
            {
                return a; // a is trivially sorted
            }

            int n = a.Count;

            List<int> a1 = a.Take(n / 2).ToList();
            List<int> a2 = a.Skip(n / 2).ToList();

            throw new NotImplementedException();
        }
    }
}
