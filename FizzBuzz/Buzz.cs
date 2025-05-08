namespace FizzBuzz;
public class Buzz
{
    public static void LinqEdition()
    {
        Enumerable
            .Range(0, 101)
            .Select(number =>
                (number % 15 == 0) ? "FizzBuzz" :
                (number % 3 == 0) ? "Fizz" :
                (number % 5 == 0) ? "Buzz" :
                number.ToString())
            .ToList()
            .ForEach(Console.WriteLine);
    }

    public static void IfElseEdition()
    {
        for (int i = 0; i <= 100; i++)
        {
            if (i % 3 == 0 && i % 5 == 0)
            {
                Console.WriteLine("FizzBuzz");
            }
            else if (i % 3 == 0)
            {
                Console.WriteLine("Fizz");
            }
            else if (i % 5 == 0)
            {
                Console.WriteLine("Buzz");
            }
            else
            {
                Console.WriteLine(i);
            }
        }
    }

    public static void ClassicSwitchEdition()
    {
        for (int i = 0; i <= 100; i++)
        {
            switch (i % 3, i % 5)
            {
                case (0, 0):
                    Console.WriteLine("FizzBuzz");
                    break;
                case (0, _):
                    Console.WriteLine("Fizz");
                    break;
                case (_, 0):
                    Console.WriteLine("Buzz");
                    break;
                default:
                    Console.WriteLine(i);
                    break;
            }
        }
    }

    public static void SwitchExpressionEdition()
    {
        for (int i = 0; i <= 100; i++)
        {
            Console.WriteLine(
            (i % 3, i % 5) switch
            {
                (0, 0) => "FizzBuzz",
                (0, _) => "Fizz",
                (_, 0) => "Buzz",
                (_, _) => i
            }
            );
        }
    }
}