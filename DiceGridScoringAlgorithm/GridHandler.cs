using System.Text;

namespace DiceGridScoringAlgorithm;

internal class GridHandler
{
    private readonly sbyte[,] _grid;

    public sbyte[,] Grid => _grid;

    public GridHandler()
    {
        _grid = new sbyte[4, 4];
    }

    public string DisplayGrid()
    {
        StringBuilder builder = new();
        for (int x = 0; x < _grid.GetLength(0); x++)
        {

            for (int y = 0; y < _grid.GetLength(1); y++)
            {
                _ = builder.Append($" {_grid[x, y]} ");
            }
            _ = builder.AppendLine();
        }

        return builder.ToString();
    }

    public void GenerateGrid()
    {
        for (int x = 0; x < _grid.GetLength(0); x++)
        {
            for (int y = 0; y < _grid.GetLength(1); y++)
            {
                _grid[x, y] = (sbyte)Random.Shared.Next(1, 7);
            }
        }
    }
}