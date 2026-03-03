// See https://aka.ms/new-console-template for more information
using DataStructuresImplementations;
using System.Diagnostics;

StackUsingABV<string> stackUsingABV = new StackUsingABV<string>();

stackUsingABV.Push("A");
Console.WriteLine(stackUsingABV);


stackUsingABV.Push("B");
stackUsingABV.Push("C");

Console.Clear();
Console.WriteLine(stackUsingABV);

Console.Clear();

Console.WriteLine("Popping the top of the stack:");
Console.WriteLine(
    stackUsingABV.Pop());


Console.Clear();
Console.WriteLine(stackUsingABV);


stackUsingABV.Push("D");
stackUsingABV.Push("E");

Console.WriteLine(stackUsingABV);


/*
Stopwatch sw = new Stopwatch();

int repetitions = 20;

// The problem size impacts the resource requirements
int[] problemSizes = new int[] { 10, 50, 100, 150, 200, 250, 300 };

IVectorADT<int> vectorADT;

// This allows the setup to work and avoid issues with small problem sizes being very slow
// Setup the system and run the operations without outputting the timing results
vectorADT = new ArrayBasedVector<int>(1000);
for (int i = 0; i < 100; i++)
{
    sw.Start();
    vectorADT.InsertElementAtRank(0, 1);
    vectorADT.Append(1);
    sw.Stop();
}

Console.WriteLine("Timing Append");
foreach (int elementsToAdd in problemSizes)
{
    sw.Reset();
    //Console.WriteLine($"Append {elementsToAdd} elements to an ABV");

    for (int j = 0; j < repetitions; j++)
    {
        vectorADT = new ArrayBasedVector<int>();

        for (int i = 0; i < elementsToAdd; i++)
        {
            sw.Start();
            vectorADT.Append(i);
            sw.Stop();
        }
    }

    Console.WriteLine($"{elementsToAdd}:{sw.ElapsedTicks / (double)repetitions} ticks");
}

Console.WriteLine("Timing Insert at rank 0");
foreach (int elementsToAdd in problemSizes)
{
    sw.Reset();
    //Console.WriteLine($"Insert at rank 0, {elementsToAdd} elements to an ABV");

    for (int j = 0; j < repetitions; j++)
    {
        vectorADT = new ArrayBasedVector<int>();

        for (int i = 0; i < elementsToAdd; i++)
        {
            sw.Start();
            vectorADT.InsertElementAtRank(0, i);
            sw.Stop();
        }

    }
    Console.WriteLine($"{elementsToAdd}:{sw.ElapsedTicks / (double)repetitions} ticks");
}
*/

/*
IVectorADT<string> vectorADT = new ArrayBasedVector<string>();

vectorADT.InsertElementAtRank(0, "Eve");
Console.WriteLine(vectorADT);

vectorADT.InsertElementAtRank(1, "Francis");
Console.WriteLine(vectorADT);

vectorADT.InsertElementAtRank(2, "Charles");
Console.WriteLine(vectorADT);

vectorADT.InsertElementAtRank(1, "Adam");
Console.WriteLine(vectorADT);

vectorADT.InsertElementAtRank(0, "Bob");
Console.WriteLine(vectorADT);

vectorADT.InsertElementAtRank(2, "Mavis");
Console.WriteLine(vectorADT);

Console.WriteLine("Get element at rank 2");
Console.WriteLine(vectorADT.GetElementAtRank(2));

Console.WriteLine("Remove the element at rank 1");
Console.WriteLine(
    vectorADT.RemoveElementAtRank(1));
*/