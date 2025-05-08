using DiceGridScoringAlgorithm;

GridHandler handler = new();

handler.GenerateGrid();

ScoreCounter counter = new(handler);

Console.WriteLine(handler.DisplayGrid());

counter.CalculateScore();

Console.WriteLine(counter.Score);