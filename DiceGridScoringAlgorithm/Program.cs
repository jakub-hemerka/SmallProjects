using DiceGridScoringAlgorithm;

GridHandler handler = new();
ScoreCounter counter = new();

while (true)
{
    Console.Clear();
    Console.WriteLine("Currently generated grid:");
    handler.GenerateGrid();
    Console.WriteLine(handler.DisplayGrid());
    Console.WriteLine();
    counter.CalculateScore(handler.Grid);
    Console.WriteLine($"Score earned: {counter.Score}");

    Console.Write("\nShall I run again (Y/N): ");
    string input = Console.ReadLine() ?? "N";

    // Just trying to be evil
    if (input.Equals("N", StringComparison.InvariantCultureIgnoreCase))
    {
        break;
    }
}