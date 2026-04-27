// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

Console.WriteLine("Hello, World!");

int n = 20;
int t;

Console.WriteLine(E(n));
//Console.WriteLine(C(n));


//int[] problemSizes = [3, 4, 5, 6, 7, 8, 9, 10];

/*
foreach (int problemSize in problemSizes)
{
    int[] X = new int[problemSize];
    X[0] = 1000;

    _ = FindMax(
    X,
    out n, // n and t are "out" parameters, which means that the method will set these values for us
    out t
    );

    Console.WriteLine($"n: {n},\t t:{t}"); // 3n + 1
}
*/

/*
_ = FindMax(
    [14, 34, 12, 26, 18], // X
    out n, // n and t are "out" parameters, which means that the method will set these values for us
    out t
    );
*/

static int A(int n)
{
    int count = 0;

    for (int i = 0; i < n; i++)
    {
        count++;
    }
    return count;
}

static int B(int n) // Theta(n^2)
{
    int count = 0;

    for (int i = 0; i < n; i++) // repeat the inner loop xn
    {
        for (int j = 0; j < n; j++) // repeat the count++ xn
        {
            count++;                // O(1) work
        }
    }
    return count;
}

static int C(int n) // Theta(n)
{
    int count = 0;

    for (int i = 0; i < n; i++)// n
    {
        count++;
    }
    for (int i = 0; i < n; i++)// n
    {
        count++;
    }
    for (int i = 0; i < n; i++)// n
    {
        count++;
    }

    // n+n+n = 3n
    return count;
}

// Theta(n^2)
static int D(int n)
{
    int count = 0;

    for (int i = 0; i < n; i++)// n
    {
        count++;
    }

    for (int i = 0; i < n; i++) // repeat the inner loop xn
    {
        for (int j = 0; j < n; j++) // repeat the count++ xn
        {
            count++;                // O(1) work
        }
    }

    // n + n^2
    return count;
}

static int FindMaxLinQ(int[] X)
{
    return X.Max(x => x);
}

static int E(int n) // Exercise!!!
{
    int count = 0;

    for (int i = 0; i < n; i++) 
    {
        int countBefore = count;
        for (int j = i; j < n; j++) // j starts from i instead of 0
        {
            //Console.WriteLine($"{i},{j}");
            count++;                // O(1) work
        }
        Console.WriteLine($"Work for inner look with i={i} is {count - countBefore}");
    }
    return count;
}


static int FindMax(int[] X, out int n, out int t)
{
    // n = X.Length (the problem size)
    n = X.Length;
    t = 0; // t represents the number of operations

    int m = X[0];
    t++;

    int k = 1;
    t++;

    while (k < n)
    {
        // compared k < n, and expression is true
        t++;

        // compare X[k]>m
        t++;
        if (X[k] > m)
        {
            m = X[k];
            t++;
        }

        k++;
        t++; // additional operation for incrementing k
    }
    // compared k < n, and expression is false (exited while loop)
    t++;

    // return value m is an operation
    t++;
    return m;
}