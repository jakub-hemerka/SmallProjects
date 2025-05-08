namespace EggCodeStampDecoder;

internal static class FileReader
{
    private static readonly string _filepath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "CountryCodes.csv");

    public static List<CountryModel> GetCountries()
    {
        List<CountryModel> output = new();

        if (!File.Exists(_filepath))
        {
            return output;
        }

        string[] lines = File.ReadAllLines(_filepath);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] vals = lines[i].Split(';', StringSplitOptions.RemoveEmptyEntries);
            CountryModel country = new(vals[0], vals[1], vals[2], Convert.ToUInt16(vals[3]));
            output.Add(country);
        }

        return output;
    }
}