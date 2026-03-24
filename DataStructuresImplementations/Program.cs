// See https://aka.ms/new-console-template for more information
using DataStructuresImplementations;
using System.Diagnostics;

// The problem size impacts the resource requirements
int[] problemSizes = new int[] { 100, 200, 400, 800, 1600, 3200, 6400, 12800, 256000, 5120000 };
int repetitions = 20;
Stopwatch _stopwatch = new Stopwatch();
QueueUsingSinglyLinkedList<int> _queue;
QueueUsingABV<int> _queueUsingABV;


// Extra work, not timed - this allows the program to setup properly
// Do not report this time, as it will be very large
for (int i = 0; i < 100; i++)
{
    _queue = new QueueUsingSinglyLinkedList<int>();
    _queueUsingABV = new QueueUsingABV<int>();

    for (int j = 0; j < 200; j++)
    {
        _stopwatch.Start();
        _queue.Enqueue(i);
        _queueUsingABV.Enqueue(i);
        _stopwatch.Stop();
    }   
}

Console.WriteLine("Queue using Singly Linked Lists");
// Take a "picture" for the resource requirements for each problem size
foreach (int problemSize in problemSizes)
{
    // Take the "picture" for this problem size
    _stopwatch.Reset(); // set the stopwatch back to 0 for this problem size

    #region Setup - Prepare the problem for the problem size
    // Setup the problem:

    // build a queue that has problemSize elements
    _queue = new QueueUsingSinglyLinkedList<int>();
    for (int i = 0; i < problemSize; i++)
    {
        _queue.Enqueue(0);
    }
    #endregion

    // Carry out the actual work:
    // * It consumes the resources for the problem size
    // * It depends on your implementation
    // * It depends on your hardware
    // * It also depends on background noise / processes

    for (int i = 0; i < repetitions; i++)
    {
        _stopwatch.Start();
        _queue.Enqueue(1);
        _stopwatch.Stop();
    }

    // Disadvantage: You may not capture scenarios that happen very rarely

    // Advantage of Empirical Analysis: This is the "actual" time you expect to take,
    // so you can compare actual times on the same machines between algorithms

    Console.WriteLine($"{problemSize}|{_stopwatch.ElapsedTicks/(double)repetitions}");
}

Console.WriteLine("Queue using Array Based Vectors");
// Same as above for the new structure
foreach (int problemSize in problemSizes)
{
    _stopwatch.Reset(); // set the stopwatch back to 0 for this problem size


    _queueUsingABV = new QueueUsingABV<int>();
    
    // Setup a large queue that has as many elements as the problemSize
    for (int i = 0; i < problemSize; i++)
    {
        _queueUsingABV.Enqueue(i);
    }

    // Measure (repeatedly)
    for (int i = 0; i < repetitions; i++)
    {
        _stopwatch.Start();
        _queueUsingABV.Enqueue(1);
        _stopwatch.Stop();
    }

    // Advantage of Empirical Analysis: This is the "actual" time you expect to take,
    // so you can compare actual times on the same machines between algorithms

    Console.WriteLine($"{problemSize}|{_stopwatch.ElapsedTicks / (double)repetitions}");
}

Console.WriteLine("Queue Dequeue using Array Based Vectors");
// Same as above for the new structure
foreach (int problemSize in problemSizes)
{
    _stopwatch.Reset(); // set the stopwatch back to 0 for this problem size


    _queueUsingABV = new QueueUsingABV<int>();

    // Setup a large queue that has as many elements as the problemSize
    for (int i = 0; i < problemSize; i++)
    {
        _queueUsingABV.Enqueue(i);
    }

    // Measure (repeatedly)
    for (int i = 0; i < repetitions; i++)
    {
        _stopwatch.Start();
        _queueUsingABV.Dequeue();
        _stopwatch.Stop();
    }

    // Advantage of Empirical Analysis: This is the "actual" time you expect to take,
    // so you can compare actual times on the same machines between algorithms

    Console.WriteLine($"{problemSize}|{_stopwatch.ElapsedTicks / (double)repetitions}");
}





//TestQueue();



// TestSinglyLinkedList();
// TestStackusingABV();

static void TestStackusingABV()
{
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
}

static void TestSinglyLinkedList()
{
    SinglyLinkedList<string> singlyLinkedList = new SinglyLinkedList<string>();

    if (singlyLinkedList.Count > 0)
    {
        Console.WriteLine(
            singlyLinkedList.RemoveFirst());
    }

    try
    {
        singlyLinkedList.RemoveFirst();
    }
    catch (InvalidOperationException)
    {
        Console.WriteLine("You have tried to remove an element from an empty list, which is invalid...");
        // TODO: Log or Handle this exception!!!
    }

    singlyLinkedList.InsertFirst("D");
    singlyLinkedList.InsertFirst("C");
    //singlyLinkedList.InsertFirst("B");

    Console.WriteLine(singlyLinkedList);

    Console.WriteLine();
    Console.WriteLine("Insert first 'A'");

    singlyLinkedList.InsertFirst("A");
    Console.WriteLine(singlyLinkedList);

    singlyLinkedList.InsertFirst("S");
    Console.WriteLine(singlyLinkedList);

    Console.WriteLine("Remove First Element");
    Console.WriteLine(
        singlyLinkedList.RemoveFirst());
    Console.WriteLine(singlyLinkedList);

    SinglyLinkedListNode<string>? __currentNode = singlyLinkedList.Head;

    singlyLinkedList.InsertAfter(__currentNode!, "B");
    Console.WriteLine(singlyLinkedList);
}

static void TestQueue()
{
    QueueUsingSinglyLinkedList<string> queue = new QueueUsingSinglyLinkedList<string>();

    queue.Enqueue("A");
    queue.Enqueue("B");
    queue.Enqueue("C");

    Console.WriteLine(queue.Dequeue());

    queue.Enqueue("D");
    queue.Enqueue("E");

    while (queue.Count > 0)
    {
        Console.WriteLine(queue.Dequeue());
    }
}


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