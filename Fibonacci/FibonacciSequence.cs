using System.Numerics;

namespace Fibonacci;
public class FibonacciSequence
{
    public static BigInteger GetNumber(int number)
    {
        return Calculate(number);
    }

    private static BigInteger Calculate(int index)
    {
        BigInteger[] sequence = new BigInteger[index + 1];

        for (int i = 0; i <= index; i++)
        {
            if (i == 0)
            {
                sequence[i] = 0;
                continue;
            }

            if (i == 1 || i == 2)
            {
                sequence[i] = 1;
                continue;
            }

            sequence[i] = sequence[i - 1] + sequence[i - 2];
        }

        return sequence[index];
    }
}