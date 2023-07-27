namespace RockPaperScissors;
public class StandardGame
{
    protected readonly Random _rand;
    protected GameOption[] _options;
    protected int _userScore;
    protected int _computerScore;

    public StandardGame()
    {
        _rand = new();
        _options = new[]
        {
            new GameOption("Kámen", new() { ["nuzky"] = "Kámen tupí nůžky." }),
            new GameOption("Nůžky", new() { ["papir"] = "Nůžky stříhají papír." }),
            new GameOption("Papír", new() { ["kamen"] = "Papír balí kámen." })
        };
    }

    private void ResetScore()
    {
        _userScore = 0;
        _computerScore = 0;
    }

    private GameOption GetComputerChoice()
    {
        return _options[_rand.Next(_options.Length)];
    }

    public string OfferOptions()
    {
        return $"Dostupné příkazy: {string.Join(", ", _options.Select(x => x.Name))}, Reset";
    }

    public string Play(string userInput)
    {
        userInput = userInput.Trim().ToLowerInvariant().RemoveDiacritics();

        if (userInput == "reset")
        {
            ResetScore();
            return "Skóre bylo vynulováno.";
        }

        if (!_options.Any(x => x.Identifier == userInput))
        {
            return "Tuto možnost nemám v nabídce...";
        }

        GameOption userChoice = _options.Where(x => x.Identifier == userInput).First();

        string message = Evaluate(userChoice);
        message += $"Tvoje skóre: {_userScore}\nSkóre počítače: {_computerScore}\n";
        return message;
    }

    private string Evaluate(GameOption userChoice)
    {
        GameOption computerChoice = GetComputerChoice();
        string output = $"Volba hráče: {userChoice.Name}\n";
        output += $"Volba počítače: {computerChoice.Name}\n";

        if (userChoice.Identifier == computerChoice.Identifier)
        {
            output += "Nerozhodně.\n";
            return output;
        }

        if (userChoice.WinAgainst.ContainsKey(computerChoice.Identifier))
        {
            _userScore += 1;
            output += $"Vyhráváš! {userChoice.WinAgainst[computerChoice.Identifier]}\n";
            return output;
        }

        _computerScore += 1;
        output += $"Bohužel prohráváš. {computerChoice.WinAgainst[userChoice.Identifier]}\n";
        return output;
    }
}
