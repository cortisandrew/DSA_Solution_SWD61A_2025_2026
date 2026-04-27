// See https://aka.ms/new-console-template for more information


using Trees;

BinarySearchTree<string> bst = new BinarySearchTree<string>();

bst.Insert(5, "Data for 5");
bst.Insert(3, "Data for 3");
bst.Insert(7, "Data for 7");
bst.Insert(2, "Data for 2");
bst.Insert(4, "Data for 4");
bst.Insert(6, "Data for 6");

Console.WriteLine("Binary Search Tree created");
Console.WriteLine(bst);

Console.WriteLine(bst.Search(7));

try
{
    bst.Search(8);
}
catch (KeyNotFoundException ex)
{
    Console.WriteLine(ex.Message);
}

BinarySearchTree<string> bst2 = new BinarySearchTree<string>();

bst2.Insert(1, "Data for 1");
bst2.Insert(2, "Data for 2");
bst2.Insert(3, "Data for 3");
bst2.Insert(4, "Data for 4");
bst2.Insert(5, "Data for 5");
bst2.Insert(6, "Data for 6");

Console.WriteLine("Binary Search Tree created");

