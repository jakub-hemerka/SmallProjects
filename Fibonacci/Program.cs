using Fibonacci;

string? input = Console.ReadLine();

if (int.TryParse(input, out int x))
{
    Console.WriteLine(FibonacciSequence.GetNumber(x));
}