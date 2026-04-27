using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursiveAlgorithms;

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

        List<int> a1_sorted = MergeSort(a1);
        List<int> a2_sorted = MergeSort(a2);

        return Merge(a1_sorted, a2_sorted);
    }

    /// <summary>
    /// The Merge merges together two <b>sorted</b> lists. This means that both parameters must be sorted.
    /// </summary>
    /// <param name="a1_sorted"></param>
    /// <param name="a2_sorted"></param>
    /// <returns></returns>
    private List<int> Merge(List<int> a1_sorted, List<int> a2_sorted)
    {
        int n = a1_sorted.Count + a2_sorted.Count; // number of elements to merge

        int i = 0; // next element to compare from a1_sorted
        int j = 0; // next element to compare from a2_sorted

        List<int> output = new List<int>(n); // output list with initial capacity n

        // while we still have elements to copy from both a1_sorted and a2_sorted
        while (i < a1_sorted.Count && j < a2_sorted.Count)
        {
            if (a1_sorted[i] <= a2_sorted[j])
            {
                // a1_sorted[i] is smaller than a2_sorted[j]
                output.Add(a1_sorted[i]);   // copy over
                i++;                        // increment i (we don't need to copy this element again)
            }
            else
            {
                // a2_sorted[j] is smaller than a1_sorted[i]
                output.Add(a2_sorted[j]);
                j++;
            }
        }

        while (i < a1_sorted.Count)
        {
            // a1_sorted has some elements to copy over
            output.Add(a1_sorted[i]);
            i++;
        }

        while (j < a2_sorted.Count)
        {
            // a2_sorted has some elements to copy over
            output.Add(a2_sorted[j]);
            j++;
        }

        return output;
    }
}
