// See https://aka.ms/new-console-template for more information

using Ref_Value_Types;

Console.WriteLine("Value Type");

int a = 5;
int b = 6;

Console.WriteLine($"The value of {nameof(a)}: {a}");    // 5
Console.WriteLine($"The value of {nameof(b)}: {b}");    // 6
Console.WriteLine();
Console.WriteLine();

a = b;
Console.WriteLine($"The value of {nameof(a)}: {a}");    // 6
Console.WriteLine($"The value of {nameof(b)}: {b}");    // 6
Console.WriteLine();
Console.WriteLine();

b = 10;
Console.WriteLine($"The value of {nameof(a)}: {a}");    // 6
Console.WriteLine($"The value of {nameof(b)}: {b}");    // 10
Console.WriteLine();
Console.WriteLine();

Console.WriteLine("Reference Type");
ReferenceTypeClass refA = new ReferenceTypeClass() { Value = 5 };
ReferenceTypeClass refB = new ReferenceTypeClass() { Value = 6 };

Console.WriteLine($"The value of {nameof(refA)}: {refA.Value}");    // 5
Console.WriteLine($"The value of {nameof(refB)}: {refB.Value}");    // 6
Console.WriteLine();
Console.WriteLine();

refA = refB;
Console.WriteLine($"The value of {nameof(refA)}: {refA.Value}");    // 6
Console.WriteLine($"The value of {nameof(refB)}: {refB.Value}");    // 6
Console.WriteLine();
Console.WriteLine();

refB.Value = 10;
Console.WriteLine($"The value of {nameof(refA)}: {refA.Value}");    // 10
Console.WriteLine($"The value of {nameof(refB)}: {refB.Value}");    // 10
Console.WriteLine();
Console.WriteLine();

