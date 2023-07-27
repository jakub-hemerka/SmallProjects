namespace RockPaperScissors;
public record GameOption
{
    public string Name { get; init; }
    public string Identifier { get; init; }
    public Dictionary<string, string> WinAgainst { get; init; }

    public GameOption(string name) : this(name, new Dictionary<string, string>())
    {
    }

    public GameOption(string name, Dictionary<string, string> winAgainst)
    {
        Name = name;
        Identifier = name.Trim().ToLowerInvariant().RemoveDiacritics();
        WinAgainst = winAgainst;
    }
}