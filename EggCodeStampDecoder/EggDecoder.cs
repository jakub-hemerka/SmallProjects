namespace EggCodeStampDecoder;

internal class EggDecoder
{
    private readonly List<CountryModel> _countries;

    public EggDecoder()
    {
        _countries = FileReader.GetCountries();
    }

    public string Decode(string code)
    {
        if (!IsCodeValid(code))
        {
            return "Invalid input.";
        }

        return $"{GetFarmingMethod(Convert.ToSByte(code[..1]))}\n{GetCountryOfOrigin(code.Substring(1, 2))}\n{GetFarmId(code[3..])}";
    }

    private string GetCountryOfOrigin(string countryCode)
    {
        return $"Country of origin: {_countries.FirstOrDefault(x => x.AlphaTwoCode == countryCode)?.Name ?? "Unknown Country"}";
    }

    private static string GetFarmId(string farmId)
    {
        return $"Farm Id: {farmId}";
    }

    private static string GetFarmingMethod(sbyte farmingMethod)
    {
        return farmingMethod switch
        {
            0 => "Organic Egg",
            1 => "Free Range Egg",
            2 => "Barn Egg",
            3 => "Cage Egg",
            _ => "Unknown"
        };
    }

    private static bool IsCodeValid(string code)
    {
        //A valid code contains at least 7 alphanumerical characters and should start with a number digit between 0 and 3.
        return code.All(char.IsLetterOrDigit) && code.Length >= 7 && char.IsDigit(code[0]) && sbyte.TryParse(code[..1], out sbyte result) && result >= 0 && result <= 3;
    }
}