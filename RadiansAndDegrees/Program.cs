char[] validChoices = ['A', 'B', 'X'];
double oneRadianConverted = 180 / Math.PI;
double oneDegreeConverted = Math.PI / 180;

while (true)
{
    PrintMenu();
    string rawInput = Console.ReadLine()!;

    if (string.IsNullOrWhiteSpace(rawInput) || !validChoices.Contains(rawInput[0]))
    {
        Console.WriteLine("Invalid option, try again!");
    }

    if (rawInput[0] == 'X')
    {
        break;
    }

    Console.WriteLine();

    if (rawInput[0] == 'A')
    {
        Convertor("radians", "degrees", oneRadianConverted);
        continue;
    }

    if (rawInput[0] == 'B')
    {
        Convertor("degrees", "radians", oneDegreeConverted);
        continue;
    }
}

Console.WriteLine("Good Bye");

void PrintMenu()
{
    Console.WriteLine("---- Radians/Degrees Converter ----");
    Console.WriteLine("Choose one of the following options:");
    Console.WriteLine("A - Convert an angle from radians to degrees");
    Console.WriteLine("B - Convert an angle from degrees to radians");
    Console.WriteLine("X - Exit");
    Console.Write("Select an option (A, B or X): ");
}

void Convertor(string origin, string destination, double oneUnitConverted)
{
    while (true)
    {
        Console.Write($"Enter an angle in {origin}: ");

        if (double.TryParse(Console.ReadLine(), out double value))
        {
            double result = value * oneUnitConverted;
            Console.WriteLine($"This angle is {result} {destination}.");
            break;
        }

        Console.WriteLine("Invalid number, try again!");
    }
}