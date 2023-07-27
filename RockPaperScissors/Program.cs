using RockPaperScissors;

NerdGame game = new();


while (true)
{
    Console.WriteLine($"{game.OfferOptions()}, Konec");
    string input = Console.ReadLine()!;

	if (input.ToLower() == "konec")
	{
		break;
	}

	Console.WriteLine(game.Play(input));
}