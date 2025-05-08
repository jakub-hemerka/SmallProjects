namespace DiceGridScoringAlgorithm;

internal class ScoreCounter
{
    public short Score { get; private set; }

    public void CalculateScore(sbyte[,] grid)
    {
        Score = 0;

        // Check corners
        CheckNumbers(grid[0, 0], grid[0, 3], grid[3, 0], grid[3, 3]);

        // Check top left to bottom right diagonal
        CheckNumbers(grid[0, 0], grid[1, 1], grid[2, 2], grid[3, 3]);

        // Check top right to bottom left diagonal
        CheckNumbers(grid[0, 3], grid[1, 2], grid[2, 1], grid[3, 0]);

        // Check rows
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            sbyte[] row = new sbyte[4];
            sbyte[] column = new sbyte[4];

            for (int j = 0; j < grid.GetLength(1); j++)
            {
                row[j] = grid[i, j];
                column[j] = grid[j, i];
                Score += grid[i, j];

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