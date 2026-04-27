// See https://aka.ms/new-console-template for more information

using RecursiveAlgorithms;

List<int> a = [65, 42, 32, 88, 15];

var msc = new MergeSortClass();
var a_sorted = msc.MergeSort(a);

Console.WriteLine(string.Join(", ", a_sorted));

