// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

int n;
int t;

int[] problemSizes = [3, 4, 5, 6, 7, 8, 9, 10];

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

/*
_ = FindMax(
    [14, 34, 12, 26, 18], // X
    out n, // n and t are "out" parameters, which means that the method will set these values for us
    out t
    );
*/




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