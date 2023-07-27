namespace RockPaperScissors;
public class NerdGame : StandardGame
{
    public NerdGame()
    {
        _options = new[]
        {
            new GameOption("Kámen", new() { ["nuzky"] = "Kámen tupí nůžky.", ["tapir"] = "Kámen rozdrtí tapíra." }),
            new GameOption("Nůžky", new() { ["papir"] = "Nůžky stříhají papír.", ["tapir"] = "Nůžky utnou hlavu tapírovi." }),
            new GameOption("Papír", new() { ["kamen"] = "Papír balí kámen.", ["spock"] = "Papír usvědčí Spocka." }),
            new GameOption("Tapír", new() { ["spock"] = "Tapír otráví Spocka.", ["papir"] = "Tapír sní papír." }),
            new GameOption("Spock", new() { ["kamen"] = "Spock vypaří kámen.", ["nuzky"] = "Spock zničí nůžky." })
        };
    }
}