namespace DiceGridScoringAlgorithm;

internal class ScoreCounter
{
    private readonly GridHandler _handler;

    public short Score { get; private set; }

    public ScoreCounter(GridHandler handler)
    {
        _handler = handler;
    }

    public void CalculateScore()
    {
        Score = 0;

        // Check corners
        CheckNumbers(_handler.Grid[0, 0], _handler.Grid[0, 3], _handler.Grid[3, 0], _handler.Grid[3, 3]);

        // Check top left to bottom right diagonal
        CheckNumbers(_handler.Grid[0, 0], _handler.Grid[1, 1], _handler.Grid[2, 2], _handler.Grid[3, 3]);

        // Check top right to bottom left diagonal
        CheckNumbers(_handler.Grid[0, 3], _handler.Grid[1, 2], _handler.Grid[2, 1], _handler.Grid[3, 0]);

        // Check rows
        for (int i = 0; i < _handler.Grid.GetLength(0); i++)
        {
            sbyte[] row = new sbyte[4];
            sbyte[] column = new sbyte[4];

            for (int j = 0; j < _handler.Grid.GetLength(1); j++)
            {
                row[j] = _handler.Grid[i, j];
                column[j] = _handler.Grid[j, i];
                Score += _handler.Grid[i, j];

            }

            CheckNumbers(row);
            CheckNumbers(column);
        }
    }

    private void CheckNumbers(params sbyte[] numbers)
    {
        if (AreNumbersSameType(EvenComparison, numbers) || AreNumbersSameType(OddComparison, numbers))
        {
            Score += 20;
        }
    }

    private static bool AreNumbersSameType(Func<sbyte, bool> comparer, params sbyte[] numbers)
    {
        foreach (sbyte number in numbers)
        {
            if (comparer.Invoke(number))
            {
                return false;
            }
        }

        return true;
    }

    private bool EvenComparison(sbyte number)
    {
        return number % 2 == 0;
    }

    private bool OddComparison(sbyte number)
    {
        return number % 2 == 1;
    }
}