using EggCodeStampDecoder;

List<CountryModel> countries = FileReader.GetCountries();

EggDecoder decoder = new();

while (true)
{
    Console.Write("Enter the code found on the egg: ");
    string? input = Console.ReadLine();

    Console.WriteLine(decoder.Decode(input ?? ""));
}